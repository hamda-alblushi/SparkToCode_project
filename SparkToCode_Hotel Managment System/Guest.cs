using System;

namespace SparkToCode_Hotel_Managment_System
{
    internal class Guest
    {
        public string guestId { get; set; }
        public string guestName { get; set; }
        public string roomNumber { get; set; }
        public string checkInDate { get; set; }
        public int totalNights { get; set; }

        public Guest(string guestId, string guestName, string checkInDate, int totalNights, string roomNumber = "Not Assigned")
        {
            this.guestId = guestId;
            this.guestName = guestName;
            this.checkInDate = checkInDate;
            this.totalNights = totalNights;
            this.roomNumber = roomNumber;
        }

        public void displayGuest()
        {
            Console.WriteLine($"{guestId} | {guestName,-15} | Room: {roomNumber,-12} | Check-in: {checkInDate,-12} | Nights: {totalNights}");
        }

        // Since Guest does not store price, the caller supplies the room's
        // pricePerNight (looked up from the rooms list) to compute the bill.
        public double calculateTotalCost(double pricePerNight)
        {
            return totalNights * pricePerNight;
        }
    }
}
