﻿using aland;
using System;
using System.Diagnostics;
using System.IO;

namespace isGited_withoutRc
{
    class withoutRc
    {
        AString astr = new AString();
        public void SearchInFiles(string rootPath, string folderName)
        {
            string dir = "";
            string[] dirs = new string[10000];
            dirs[0] = @"D:\projekt";


            for (int i = 0; i < dirs.Length; i++)
            {
                dir = dirs[i];

                string lastFolderName = getLastFolderName(dir);
                if (lastFolderName == folderName)
                {
                    try
                    {
                        if (isGited(rootPath))
                        {
                            Console.WriteLine(rootPath);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    string[] dirs_1 = Directory.GetDirectories(dir);
                }
            }
        }

        // finde den letzten Ordner im Pfad
        public string getLastFolderName(string dir)
        {
            // suche solange, bis du die Position des letzten \ gefunden hast
            int lastBackslashPosition = -1;
            int x = 0;
            string backLash = @"\";
            for (int i = 0; i < dir.Length; i++)
            {
                // suche bis zum nächsten \, merke die Position
                int searchBackslash = astr.Search(dir, backLash, i);
                if (searchBackslash != -1)
                {
                    i = searchBackslash + backLash.Length;

                }
                bool finded = (searchBackslash != -1);
                if (finded)
                {
                    // wenn es letztes \ ist, dann wurde des letzte Ordner gefunden
                    lastBackslashPosition = searchBackslash;
                }
            }

            //Console.WriteLine(lastBackslashPosition);
            // nimm alles hinter der Position des letzten \
            int LBLP = lastBackslashPosition + 1;
            int lastPosition = lastBackslashPosition + 1;
            int laenge = dir.Length - lastPosition;
            string lastFolderName = astr.SubString(dir, LBLP, laenge);
            return lastFolderName;
        }

        public bool isGited(string dir)
        {
            var p = Process.Start(
                new ProcessStartInfo("git", "diff")
                {
                    CreateNoWindow = false,
                    UseShellExecute = false,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true,
                    WorkingDirectory = dir
                }
            );

            string output = p.StandardOutput.ReadToEnd().TrimEnd();
            string errorInfoIfAny = p.StandardError.ReadToEnd().TrimEnd();
            p.WaitForExitAsync();
            if (errorInfoIfAny.Length != 0)
            {
                throw new Exception(errorInfoIfAny);
            }
            else if (output.Length != 0)
            {
                return true;
            }
            return false;
        }
    }
}
