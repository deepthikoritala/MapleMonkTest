using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace parkinglot
{
    class FileHelper
    {
        string FilePath { get; set; }

        List<string> commands;

        public FileHelper(string filePath) {
            this.FilePath = filePath;
            commands = new List<string>();
        }

        public void ProcessFile() {
            string line;
            try
            {
                StreamReader sr = new StreamReader(FilePath);
                line = sr.ReadLine();
                commands.Add(line);
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                    commands.Add(line);
                }
                sr.Close();
               
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("File Read completed");
            }

            foreach (string s in commands) {
                ParkingLot.Process(s);
            }
            Console.ReadLine();
        }
    }
}
