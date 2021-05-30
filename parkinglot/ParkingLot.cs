using System;
using System.Collections.Generic;
using System.Linq;

namespace parkinglot
{
    public class ParkingLot
    {
        public static int AvailableSpace { get; set; }
        public static SortedList<int, Vehicle> ParkedVehicles;


        public static void Process(string command) {

            if (string.IsNullOrEmpty(command))
            {
                return;
            }
            string[] args= command.Split(" ");

            if (args.Length < 0) {
                return;
            }
            CommandType type=CommandType.none;
            try
            {
                Enum.TryParse(args[0], out type);
            }
            catch {
                Console.WriteLine("Invalid command argument");
            }
            switch (type) {

                case CommandType.park:
                    if (args.Length < 3) {
                        Console.WriteLine("Invalids argument for command"+ command);
                        return;
                    }
                    Park(args[1],args[2]);
                    break;
                case CommandType.leave:
                    if (args.Length < 2)
                    {
                        Console.WriteLine("Invalids argument for command" + command);
                        return;
                    }
                    Leave(Convert.ToInt32(args[1]));
                    break;
                case CommandType.create_parking_lot:
                    if (args.Length < 2)
                    {
                        Console.WriteLine("Invalids argument for command" + command);
                        return;
                    }
                    AvailableSpace = Convert.ToInt32(args[1]);
                    ParkedVehicles = new SortedList<int, Vehicle>();
                    Console.WriteLine("Created a parking lot with "+AvailableSpace+" slots");
                    break;
                case CommandType.status:

                    Status();
                    break;
                case CommandType.registration_numbers_for_cars_with_colour:
                    if (args.Length < 2)
                    {
                        Console.WriteLine("Invalids argument for command" + command);
                        return;
                    }
                    GetRegNumbersForCarsWithColour(args[1]);
                    break;
                case CommandType.slot_numbers_for_cars_with_colour:
                    if (args.Length < 2)
                    {
                        Console.WriteLine("Invalids argument for command" + command);
                        return;
                    }
                    GetSlotNumbersForCarsWithColour(args[1]);
                    break;
                case CommandType.slot_number_for_registration_number:
                    if (args.Length < 2)
                    {
                        Console.WriteLine("Invalids argument for command" + command);
                        return;
                    }
                    GetSlotNumbersForCarsWithRegNum(args[1]);
                    break;


            }


        }

        public static void Park(string vehicleNumber, string color)
        {

            if (ParkedVehicles.Count == AvailableSpace)
            {
                Console.WriteLine("Sorry, parking lot is full");
                return;
            }
            int slot = GetFreeSlot();
            ParkedVehicles.Add(slot, new Vehicle()
            {
                Color = color,
                RegistrationNumber = vehicleNumber,
                SlotNumber = GetFreeSlot()
            });
            Console.WriteLine("Allocated slot number: " + slot);
            Console.WriteLine();
        }

        public static void Leave(int slotNumber)
        {
            if (slotNumber > 0 && slotNumber < AvailableSpace)
            {
                ParkedVehicles.Remove(slotNumber);
                Console.WriteLine("Slot number " + slotNumber + " is free");
            }
            else
            {
                Console.WriteLine("Invalid slot number: " + slotNumber);
            }
            Console.WriteLine();

        }

        public static void Status()
        {
            Console.WriteLine("Slot no.\tRegistration No.\tColour");
            Console.WriteLine();

            foreach (KeyValuePair<int, Vehicle> vehicle in ParkedVehicles)
            {

                Console.WriteLine(vehicle.Key + "\t\t" + vehicle.Value.RegistrationNumber + "\t\t" + vehicle.Value.Color);

            }
            Console.WriteLine();

        }

        public static void GetRegNumbersForCarsWithColour(string colour)
        {

            string[] regNums = ParkedVehicles.Where(t => t.Value.Color == colour).Select(t => t.Value.RegistrationNumber).ToArray();
            Console.WriteLine();
            if (regNums.Length == 0) {
                Console.WriteLine("Not Found");
                return;
            }
            Console.Write(regNums[0]);
            for (int i = 1; i < regNums.Length; i++)
            {
                Console.Write(", " + regNums[i]);
            }
            Console.WriteLine();

        }
        public static void GetSlotNumbersForCarsWithColour(string colour)
        {

            int[] slotNum = ParkedVehicles.Where(t => t.Value.Color == colour).Select(t => t.Key).ToArray();
            Console.WriteLine();
            if (slotNum.Length == 0)
            {
                Console.WriteLine("Not Found");
                return;
            }
            Console.Write(slotNum[0]);
            for (int i = 1; i < slotNum.Length; i++)
            {
                Console.Write(", " + slotNum[i]);
            }
            Console.WriteLine();

        }
        public static void GetSlotNumbersForCarsWithRegNum(string regNum)
        {
            int[] slotNum = ParkedVehicles.Where(t => t.Value.RegistrationNumber == regNum).Select(t => t.Key).ToArray();
            Console.WriteLine();
            if (slotNum.Length == 0)
            {
                Console.WriteLine("Not Found");
                return;
            }
            Console.Write(slotNum[0]);
            for (int i = 1; i < slotNum.Length; i++)
            {
                Console.Write(", " + slotNum[i]);
            }
            Console.WriteLine();

        }

        private static int GetFreeSlot()
        {
            if (ParkedVehicles.Count == 0)
            {
                return 1;
            }
            else
            {
                int[] keys = ParkedVehicles.Select(t => t.Key).ToArray();
                int prev = 0;
                int res = 1;
                foreach (int key in keys)
                {
                    if (key - prev != 1)
                    {
                        res = prev + 1;
                        break;
                    }
                    else {
                        res = key + 1;
                    }
                    prev = key;
                }
                return res;
            }

        }

    }
}
