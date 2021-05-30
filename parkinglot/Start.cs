using System;

namespace parkinglot
{
    class Start
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please Enter Input Type \n 0 - File \n 1 - Interactive");
            string val;
            val = Console.ReadLine();
            InputType inputType = (InputType)Convert.ToInt32(val);

            if (inputType == InputType.File)
            {
                Console.WriteLine("Please Enter File Path");
                string filePath = Console.ReadLine();

                FileHelper file = new FileHelper(filePath);
                file.ProcessFile();
            }
            else {

                while (val != "exit")
                {
                    val = Console.ReadLine();
                    ParkingLot.Process(val);
                }

            }
            Console.ReadLine();
        }
    }
}
