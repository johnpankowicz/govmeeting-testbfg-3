﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace GM.ProcessRecordingLib
{
    public class ExtractAudio
    {
        /* Extract the audio from mp4 files in subfolders of specified folder.
         * In the "Fix" folder for a recording, there will be a subfolder for each
         * segment of the recording: 00-03-00, 00-06-00, 00=09-00, etc.
         * Each of these subfolders is initialized with three files:
         *    "fix.mp4"  - the video of this segment
         *    "fix.flac" - the audio of this segment
         *    "fix.json" - the transcription of this segment
         */


        public void ExtractAll(string inputFolder)
        {
            foreach (string dir in Directory.GetDirectories(inputFolder))
            {
                string inputFile = dir + "\\fix.mp4";
                // Todo-g - convert to mp3 instead of flac.
                string outputFile = dir + "\\fix.flac";

                Extract(inputFile, outputFile);
            }
        }

        // Extract the audio from a file
        public void Extract(string inputFile, string outputFile)
        {
            RunCommand runCommand = new RunCommand();

            string inputFileQuoted = "\"" + inputFile + "\"";
            string outputFileQuoted = "\"" + outputFile + "\"";

            string command = "ffmpeg -i " + inputFileQuoted + " -ac 1 -ab 192000 -vn " + outputFileQuoted + " 2>&1";
            runCommand.ExecuteCmd(command);

            //// Convert to mono (it's now done in one step above)
            //string monoFileQuoted = "\"" + monoFile + "\"";
            //command = "ffmpeg -i " + outputFileQuoted + " -ac 1 " + monoFileQuoted + " 2>&1";
            //runCommand.ExecuteCmd(command);
        }
    }
}
