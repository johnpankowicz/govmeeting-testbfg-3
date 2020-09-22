﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using GM.Configuration;
using GM.ProcessRecording;
using GM.Utilities;
using Xunit;
using Moq;
using Microsoft.Extensions.Options;
using GM.DatabaseModel;
using GM.FileDataRepositories;
using GM.DatabaseAccess;
using System.IO;
using System.Globalization;

namespace GM.WorkflowApp.Tests
{
    public class WF3_Transcribe_Tests
    {
        WF3_Transcribe wf3;
        readonly ILogger<WF3_Transcribe> logger;
        readonly IOptions<AppSettings> config;
        IRecordingProcess recordingProcess;
        readonly string datafilesPath;

        public WF3_Transcribe_Tests()
        {
            // Mock ILogger. Use null logger
            logger = new NullLogger<WF3_Transcribe>();
            // This is in case we need to debug CI using logging.
            //ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            //logger = loggerFactory.CreateLogger<WF3_Transcribe_Tests>();
            //logger.LogInformation("In constructor WF3_Transcribe_Tests");

            // We  create a temporary DATAFILES folder with a unique name.
            datafilesPath = Path.Combine(Directory.GetCurrentDirectory(), @"DATAFILES" + Guid.NewGuid());

            // Mock the settings used in Appsettings
            AppSettings appsettings = new AppSettings()
            {
                DatafilesPath = datafilesPath,
                RequireManagerApproval = true
            };
            var mock = new Mock<IOptions<AppSettings>>();
            mock.Setup(a => a.Value).Returns(appsettings);
            config = mock.Object;

        }

        [Fact()]
        public void Create_WF3_Transcribe_Test()
        {
            var mockDbOp = new Mock<IDBOperations>();
            IDBOperations dBOperations = mockDbOp.Object;

            wf3 = new WF3_Transcribe(logger, config, recordingProcess, dBOperations);
            Assert.True(wf3 != null, "Create new WF3_Transcribe");
        }

        [Fact()]
        public void Run_WF3_Transcribe_One_Recording_Test()
        {
            // Mock some sample database records, a Meeting and GovBody.
            // WF2_ProcessTranscripts will search for all meetings with
            // correct SourceType, WorkStatus and Approved status.
            string meetingDate = "2018-12-25";  // random meeting date
            CultureInfo ci = CultureInfo.InvariantCulture;
            DateTime meetingDateTime = DateTime.ParseExact(meetingDate, "yyyy-MM-dd", ci);
            long govbodyId = 5;  // random Id
            List<Meeting> meetings = new List<Meeting>()
            {
                new Meeting()
                {
                    Date = meetingDateTime,
                    GovBodyId = govbodyId,
                    Language = "en",
                    SourceFilename = "source.mp4",
                    SourceType = SourceType.Recording,
                    WorkStatus = WorkStatus.Received,
                    Approved = true
                }
            };
            GovBody govbody = new GovBody()
            {
                Id = govbodyId,
                LongName = "USA_ME"
            };

            // Create the Datafiles folder
            Directory.CreateDirectory(datafilesPath);

            // WF2_Transcribe expects a workfolder for this meeting to already exist.
            string workfolderName = govbody.LongName + "_" + meetingDate;
            string workFolderPath = Path.Combine(datafilesPath, workfolderName);
            Directory.CreateDirectory(workFolderPath);

            //  It expects the workfolder to contain the file for the recording to be processed.
            string sourceFilePath = Path.Combine(workFolderPath, meetings[0].SourceFilename);
            File.WriteAllText(sourceFilePath, "Sample Source File Contents");

            // Mock the DBOperations that it will call
            var mockDbOp = new Mock<IDBOperations>();
            mockDbOp.Setup(a => a.FindMeetings(SourceType.Recording, WorkStatus.Received, true)).Returns(meetings);
            mockDbOp.Setup(a => a.WriteChanges());
            mockDbOp.Setup(a => a.GetWorkFolderName(It.IsAny<Meeting>())).Returns(workfolderName);
            IDBOperations dBOperations = mockDbOp.Object;

            // Mock RecordingProcess.Process(..)
            // This is the method that will be called to do the actual processing
            var mockRecordingProcess = new Mock<IRecordingProcess>();
            mockRecordingProcess.Setup(a => a.Process(sourceFilePath, workFolderPath, "en"));
            recordingProcess = mockRecordingProcess.Object;


            //################ This is the actual test. Everything else was setup ############. 
            wf3 = new WF3_Transcribe(logger, config, recordingProcess, dBOperations);
            wf3.Run();
            // 
            //################################################################################. 

            //// WF2_Transcribe should have written the results to the processedFile
            //string processedFile = Path.Combine(workFolderPath, WorkfileNames.processedTranscript);
            //Assert.True(File.Exists(processedFile), "Processed results were written to file.");

            //// Check the content of processedFile
            //string results = File.ReadAllText(processedFile);
            //Assert.True(results == processingResults, "Processed results are correct");

            // Clean up the temporary Datafiles folder and all its contents.
            GMFileAccess.DeleteDirectoryAndContents(datafilesPath);
        }
    }
}
