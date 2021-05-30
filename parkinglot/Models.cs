using System;
using System.Collections.Generic;
using System.Text;

namespace parkinglot
{
    public class Vehicle
    {
       public string Color { get; set; }
       public string RegistrationNumber { get; set; }
       public int SlotNumber { get; set;  }
    }
    public enum InputType
    {
        File=0,
        Interactive=1
    }

    public enum CommandType
    {
        create_parking_lot,
        park,
        leave,
        status,
        registration_numbers_for_cars_with_colour,
        slot_numbers_for_cars_with_colour,
        slot_number_for_registration_number,
        none
    }
}
