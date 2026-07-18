using System;

namespace SparkToCode_Hotel_Managment_System
{
    internal class Room
    {
        public int roomNumber { get; set; }
        public string roomType { get; set; }
        public double pricePerNight { get; set; }
        public bool isAvailable { get; set; }

        public Room(int roomNumber, string roomType, double pricePerNight, bool isAvailable = true)
        {
            roomNumber = roomNumber;
            roomType = roomType;
            pricePerNight = pricePerNight;
            isAvailable = isAvailable;
        }

        public void DplayRoom()
        {
            string status = isAvailable ? "Available" : "Booked";

            Console.WriteLine(
                $"Room {roomNumber,-5} | {roomType,-8} | OMR {pricePerNight,8:F2}/night | {status}"
            );
        }
    }
}
