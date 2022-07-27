using aland;
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
            dirs[0] = rootPath;

            for (int i = 0; i < dirs.Length; i++)
            {
                if (dirs[i] != null || dirs[i] != "" || dirs[i] != " ")
                {
                    dir = dirs[i];
                    Console.WriteLine(dir + " ich bin");
                }



                int y = 1;
                //Console.WriteLine($"befor {i} {dir}");
                if (dir != null || dir != "")
                {
                    string[] dirs_1 = Directory.GetDirectories(dir);

                    for (int x = 0; x < dirs_1.Length; x++)
                    {
                        dirs[y] = dirs_1[x];

                        string lastFolderName = getLastFolderName(dirs[y]);
                        //Console.WriteLine(lastFolderName);


                        if (lastFolderName == folderName)
                        {
                            try
                            {
                                Console.WriteLine(dirs[y]);
                                if (isGited(dirs[y]))
                                {
                                    //Console.WriteLine(dirs[y]);
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        y++;
                    }
                }
                else
                {
                    Console.WriteLine("lol");
                }
            }

        }

        // finde den letzten Ordner im Pfad
        public string getLastFolderName(string dir)
        {
            if (dir != null || dir == "")
            {

                // suche solange, bis du die Position des letzten \ gefunden hast
                int lastBackslashPosition = -1;
                string backLash = @"/";
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
                Console.WriteLine(lastFolderName);
                return lastFolderName;
            }

            return "";
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
