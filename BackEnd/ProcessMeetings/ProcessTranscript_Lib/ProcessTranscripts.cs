﻿using System;
using System.IO;

namespace GM.ProcessTranscript
{
    public class TranscriptProcess
    {
        /*     ProcessTranscript process new PDF transcript files that arrive.
         *     It performs the following steps:
         *       1. Convert the PDF file to plain text.
         *       2. Make location specific fixes to convert it to a standard format.
         *          For example: fixes for Philadelphia, PA, USA
         *       3. Convert the file to JSON format.
         */

        const string WORK_FOLDER = "PreProcess";

        public bool Process(string filename, string meetingFolder)
        {
            //bool created;
            //MeetingInfo mi = new MeetingInfo(filename);
            //string meetingFolder = mi.MeetingFolder(datafiles);
            //if (!(created = FileSystem.CreateDirectory(meetingFolder)))
            //{
            //    Console.WriteLine("ProcessTranscripts.cs - ERROR: Could not create meeting folder. It may already exist.");
            //    return false;
            //}

            string workFolder = meetingFolder + "\\" + WORK_FOLDER + "\\";
            Directory.CreateDirectory(workFolder);

            // Step 1 - Copy PDF to meeting directory

            FileInfo infile = new FileInfo(filename);
            string outfile = workFolder + "1 original.pdf";
            File.Copy(filename, outfile);

            // Step 2 - Convert the PDF file to text

            string text = ConvertPdfToText.Convert(outfile);
            outfile = workFolder + "2 plain-text.txt";
            File.WriteAllText(outfile, text);

            // Step 3 - Fix the transcript: Put in common format

            // Make the specific fixes to the philly data
            Specific_Philadelphia_PA_USA philly = new Specific_Philadelphia_PA_USA("2016-03-17", workFolder);
            string transcript = philly.Fix(text);

            // Convert the fixed transcript to JSON
            ConvertToJson.Convert(ref transcript);
            outfile = workFolder + "3 ToBeTagged.json";
            File.WriteAllText(outfile, transcript);

            return true;
        }

    }
}