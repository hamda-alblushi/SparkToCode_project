fxttttusing System;
using System.Collections.Generic;
using System.Linq;      
namespace SparkToCode_Hotel_Managment_System
{
    class Program
    {
        static void Main(string[] args)
        {
            // ----- System Lists -----
            List<Room> rooms = new List<Room>();
            List<Guest> guests = new List<Guest>();

            // Pre-load at least 6 rooms (mixed types)
            rooms.Add(new Room(101, "Single", 25.00)); 
            rooms.Add(new Room(102, "Single", 25.00));
            rooms.Add(new Room(201, "Double", 40.00));
            rooms.Add(new Room(202, "Double", 40.00));
            rooms.Add(new Room(301, "Suite", 75.00)); 
            rooms.Add(new Room(302, "Suite", 80.00));

            bool running = true;
            while (running)
            {
                PrintMenu();
                int choice = ReadInt("Enter your choice: ");
                Console.WriteLine();

                switch (choice)
                {
                    case 1: AddNewRoom(rooms); break;
                    case 2: RegisterNewGuest(guests); break;
                    case 3: BookRoom(guests, rooms); break;
                    case 4: ViewAllRooms(rooms); break;
                    case 5: ViewAllGuests(guests); break;
                    case 6: SearchFilterRooms(rooms); break;
                    case 7: GuestBookingStatistics(guests, rooms); break;
                    case 8: UpdateRoomPrice(rooms); break;
                    case 9: GuestLookupByName(guests); break;
                    case 10: RoomTypeBreakdown(rooms); break;
                    case 11: CheckOutGuest(guests, rooms); break;
                    case 12: RemoveUnavailableRooms(rooms, guests); break;
                    case 13: ExtendGuestStay(guests, rooms); break;
                    case 14: HighestRevenueBooking(guests, rooms); break;
                    case 15: GuestPaginationViewer(guests); break;
                    case 0: running = false; Console.WriteLine("Goodbye!"); break;
                    default: Console.WriteLine("Invalid choice. Please try again."); break;
                }

                if (running)
                {
                    Console.WriteLine("\nPress Enter to continue...");
                    Console.ReadLine();
                }
            }
        }

        // ================= MENU =================
        static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("================================================");
            Console.WriteLine("GRAND VISTA HOTEL — MANAGEMENT SYSTEM");
            Console.WriteLine("================================================");
            Console.WriteLine(" 1. Add New Room");
            Console.WriteLine(" 2. Register New Guest");
            Console.WriteLine(" 3. Book a Room for a Guest");
            Console.WriteLine(" 4. View All Rooms");
            Console.WriteLine(" 5. View All Guests");
            Console.WriteLine(" 6. Search & Filter Rooms");
            Console.WriteLine(" 7. Guest & Booking Statistics");
            Console.WriteLine(" 8. Update Room Price");
            Console.WriteLine(" 9. Guest Lookup by Name");
            Console.WriteLine("10. Room Type Breakdown Report");
            Console.WriteLine("11. Check Out a Guest");
            Console.WriteLine("12. Remove Unavailable Rooms");
            Console.WriteLine("13. Extend Guest Stay");
            Console.WriteLine("14. Highest Revenue Booking");
            Console.WriteLine("15. Guest Pagination Viewer");
            Console.WriteLine(" 0. Exit");
            Console.WriteLine("================================================");
        }

        // ================= INPUT HELPERS =================
        static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (int.TryParse(input, out int value)) return value;
                Console.WriteLine("Invalid input. Please enter a whole number.");
            }
        }

        static double ReadDouble(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (double.TryParse(input, out double value)) return value;
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }

        static string ReadString(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input)) return input.Trim();
                Console.WriteLine("Input cannot be empty.");
            }
        }

        // Helper: find a guest's room cost by looking up the linked room in the rooms list
        static double GuestCost(Guest g, List<Room> rooms)
        {
            Room r = rooms.FirstOrDefault(room => room.roomNumber.ToString() == g.roomNumber);
            return r != null ? g.calculateTotalCost(r.pricePerNight) : 0;
        }

        // ================= CASE 01 — Add New Room =================
        static void AddNewRoom(List<Room> rooms)
        {
            Console.WriteLine("--- Add New Room ---");
            int roomNumber = ReadInt("Enter room number: ");
            if (roomNumber <= 0)
            {
                Console.WriteLine("Error: Room number must be a positive number.");
                return;
            }

            if (rooms.Any(r => r.roomNumber == roomNumber))
            {
                Console.WriteLine($"Error: Room {roomNumber} already exists.");
                return;
            }

            string roomType = ReadString("Enter room type (Single/Double/Suite): ");
            double price = ReadDouble("Enter price per night: ");
            if (price <= 0)
            {
                Console.WriteLine("Error: Price must be a positive number.");
                return;
            }

            Room newRoom = new Room(roomNumber, roomType, price, true);
            rooms.Add(newRoom);

            Console.WriteLine("\nRoom added successfully!");
            newRoom.DplayRoom();
            Console.WriteLine($"Total rooms now: {rooms.Count}");
        }

        // ================= CASE 02 — Register New Guest =================
        static void RegisterNewGuest(List<Guest> guests)
        {
            Console.WriteLine("--- Register New Guest ---");
            string name = ReadString("Enter guest name: ");
            string checkInDate = ReadString("Enter check-in date (e.g. 2026-07-19): ");
            int nights = ReadInt("Enter number of nights: ");
            if (nights <= 0)
            {
                Console.WriteLine("Error: Number of nights must be a positive integer.");
                return;
            }

            string guestId = $"G{(guests.Count() + 1):D3}";
            Guest newGuest = new Guest(guestId, name, checkInDate, nights, "Not Assigned");
            guests.Add(newGuest);

            Console.WriteLine("\nGuest registered successfully!");
            newGuest.displayGuest();
        }

        // ================= CASE 03 — Book a Room for a Guest =================
        static void BookRoom(List<Guest> guests, List<Room> rooms)
        {
            Console.WriteLine("--- Book a Room for a Guest ---");
            string guestId = ReadString("Enter guest ID: ");
            Guest guest = guests.FirstOrDefault(g => g.guestId.Equals(guestId, StringComparison.OrdinalIgnoreCase));
            if (guest == null)
            {
                Console.WriteLine("Error: Guest not found.");
                return;
            }

            int roomNumber = ReadInt("Enter room number: ");
            Room room = rooms.FirstOrDefault(r => r.roomNumber == roomNumber);
            if (room == null)
            {
                Console.WriteLine("Error: Room not found.");
                return;
            }

            if (!room.isAvailable)
            {
                Console.WriteLine("Room is already booked.");
                return;
            }

            guest.roomNumber = room.roomNumber.ToString();
            room.isAvailable = false;

            double totalCost = guest.calculateTotalCost(room.pricePerNight);

            Console.WriteLine("\nBooking confirmed!");
            Console.WriteLine($"Guest: {guest.guestName}");
            Console.WriteLine($"Room: {room.roomNumber} ({room.roomType})");
            Console.WriteLine($"Price per night: OMR {room.pricePerNight:F2}");
            Console.WriteLine($"Total nights: {guest.totalNights}");
            Console.WriteLine($"Total cost: OMR {totalCost:F2}");
        }

        // ================= CASE 04 — View All Rooms =================
        static void ViewAllRooms(List<Room> rooms)
        {
            Console.WriteLine("--- All Rooms ---");
            if (!rooms.Any())
            {
                Console.WriteLine("No rooms have been added yet.");
                return;
            }

            Console.WriteLine($"Total rooms: {rooms.Count()}\n");
            var sorted = rooms.OrderBy(r => r.roomNumber).ToList();
            foreach (Room r in sorted)
                r.DplayRoom();
        }

        // ================= CASE 05 — View All Guests =================
        static void ViewAllGuests(List<Guest> guests)
        {
            Console.WriteLine("--- All Guests ---");
            if (!guests.Any())
            {
                Console.WriteLine("No guests have been registered yet.");
                return;
            }

            Console.WriteLine($"Total guests: {guests.Count()}\n");
            var sorted = guests.OrderBy(g => g.guestName).ToList();
            foreach (Guest g in sorted)
                g.displayGuest();
        }

        // ================= CASE 06 — Search & Filter Rooms =================
        static void SearchFilterRooms(List<Room> rooms)
        {
            bool back = false;
            while (!back)
            {
                Console.WriteLine("\n--- Search & Filter Rooms ---");
                Console.WriteLine("1. Show all available rooms");
                Console.WriteLine("2. Filter by room type");
                Console.WriteLine("3. Filter by max price");
                Console.WriteLine("4. Room price statistics");
                Console.WriteLine("0. Back");
                int choice = ReadInt("Enter choice: ");

                switch (choice)
                {
                    case 1:
                        var available = rooms.Where(r => r.isAvailable).OrderBy(r => r.pricePerNight).ToList();
                        if (!available.Any()) { Console.WriteLine("No rooms found for the selected criteria."); break; }
                        Console.WriteLine($"Count: {available.Count()}");
                        foreach (var r in available) r.DplayRoom();
                        break;

                    case 2:
                        string type = ReadString("Enter room type: ");
                        var byType = rooms.Where(r => r.roomType.Equals(type, StringComparison.OrdinalIgnoreCase)).ToList();
                        if (!byType.Any()) { Console.WriteLine("No rooms found for the selected criteria."); break; }
                        Console.WriteLine($"Count: {byType.Count()}");
                        foreach (var r in byType) r.DplayRoom();
                        break;

                    case 3:
                        double maxPrice = ReadDouble("Enter maximum price: ");
                        var byPrice = rooms.Where(r => r.isAvailable && r.pricePerNight <= maxPrice)
                                            .OrderBy(r => r.pricePerNight).ToList();
                        if (!byPrice.Any()) { Console.WriteLine("No rooms found for the selected criteria."); break; }
                        Console.WriteLine($"Count: {byPrice.Count()}");
                        foreach (var r in byPrice) r.DplayRoom();
                        break;

                    case 4:
                        if (!rooms.Any()) { Console.WriteLine("No rooms found for the selected criteria."); break; }
                        Console.WriteLine($"Total rooms: {rooms.Count()}");
                        Console.WriteLine($"Available rooms: {rooms.Count(r => r.isAvailable)}");
                        Console.WriteLine($"Average price: OMR {rooms.Average(r => r.pricePerNight):F2}");
                        Console.WriteLine($"Cheapest price: OMR {rooms.Min(r => r.pricePerNight):F2}");
                        Console.WriteLine($"Most expensive price: OMR {rooms.Max(r => r.pricePerNight):F2}");
                        break;

                    case 0:
                        back = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        // ================= CASE 07 — Guest & Booking Statistics =================
        static void GuestBookingStatistics(List<Guest> guests, List<Room> rooms)
        {
            Console.WriteLine("--- Guest & Booking Statistics ---");
            int totalGuests = guests.Count();
            int guestsWithRoom = guests.Count(g => g.roomNumber != "Not Assigned");
            int totalRooms = rooms.Count();
            int bookedRooms = rooms.Count(r => !r.isAvailable);

            Console.WriteLine($"Total registered guests: {totalGuests}");
            Console.WriteLine($"Guests with active booking: {guestsWithRoom}");
            Console.WriteLine($"Total rooms: {totalRooms}");
            Console.WriteLine($"Booked rooms: {bookedRooms}");

            var activeGuests = guests.Where(g => g.roomNumber != "Not Assigned").ToList();

            if (!activeGuests.Any())
            {
                Console.WriteLine("No active bookings recorded.");
                return;
            }

            double avgNights = activeGuests.Average(g => g.totalNights);
            Console.WriteLine($"Average nights (active bookings): {avgNights:F2}");

            Console.WriteLine("\nTop 3 Highest-Spending Guests:");
            var top3 = activeGuests
                .OrderByDescending(g => GuestCost(g, rooms))
                .Take(3)
                .ToList();

            foreach (var g in top3)
            {
                double cost = GuestCost(g, rooms);
                Console.WriteLine($"{g.guestName} — Room {g.roomNumber} — OMR {cost:F2}");
            }

            Console.WriteLine("\nBooking Summary:");
            var summaries = activeGuests
                .Select(g => $"{g.guestName} — Room {g.roomNumber} — {g.totalNights} nights — OMR {GuestCost(g, rooms):F2}")
                .ToList();
            foreach (var line in summaries)
                Console.WriteLine(line);
        }

        // ================= CASE 08 — Update Room Price =================
        static void UpdateRoomPrice(List<Room> rooms)
        {
            Console.WriteLine("--- Update Room Price ---");
            int roomNumber = ReadInt("Enter room number: ");
            Room room = rooms.FirstOrDefault(r => r.roomNumber == roomNumber);
            if (room == null)
            {
                Console.WriteLine("Error: Room not found.");
                return;
            }

            double newPrice = ReadDouble("Enter new price per night: ");
            if (newPrice <= 0)
            {
                Console.WriteLine("Error: Price must be a positive number. No change made.");
                return;
            }

            double oldPrice = room.pricePerNight;
            room.pricePerNight = newPrice;
            Console.WriteLine($"Price updated: OMR {oldPrice:F2} -> OMR {newPrice:F2}");
        }

        // ================= CASE 09 — Guest Lookup by Name =================
        static void GuestLookupByName(List<Guest> guests)
        {
            Console.WriteLine("--- Guest Lookup by Name ---");
            string search = ReadString("Enter name (or partial name): ");
            var matches = guests
                .Where(g => g.guestName.ToLower().Contains(search.ToLower()))
                .ToList();

            if (!matches.Any())
            {
                Console.WriteLine("No guests matched that search.");
                return;
            }

            Console.WriteLine($"Matches found: {matches.Count()}");
            foreach (var g in matches)
                Console.WriteLine($"{g.guestId} | {g.guestName} | Room: {g.roomNumber}");
        }

        // ================= CASE 10 — Room Type Breakdown Report =================
        static void RoomTypeBreakdown(List<Room> rooms)
        {
            Console.WriteLine("--- Room Type Breakdown Report ---");
            string[] types = { "Single", "Double", "Suite" };

            foreach (string type in types)
            {
                int count = rooms.Count(r => r.roomType.Equals(type, StringComparison.OrdinalIgnoreCase));
                if (count > 0)
                {
                    double avg = rooms.Where(r => r.roomType.Equals(type, StringComparison.OrdinalIgnoreCase))
                                       .Average(r => r.pricePerNight);
                    Console.WriteLine($"{type}: {count} room(s) | Average price: OMR {avg:F2}");
                }
                else
                {
                    Console.WriteLine($"{type}: 0 room(s) | Average price: N/A");
                }
            }

            if (rooms.Any())
                Console.WriteLine($"\nOverall average price: OMR {rooms.Average(r => r.pricePerNight):F2}");
            else
                Console.WriteLine("\nOverall average price: N/A");
        }

        // ================= CASE 11 — Check Out a Guest =================
        static void CheckOutGuest(List<Guest> guests, List<Room> rooms)
        {
            Console.WriteLine("--- Check Out a Guest ---");
            string guestId = ReadString("Enter guest ID: ");
            Guest guest = guests.FirstOrDefault(g => g.guestId.Equals(guestId, StringComparison.OrdinalIgnoreCase));
            if (guest == null)
            {
                Console.WriteLine("Error: Guest not found.");
                return;
            }

            if (guest.roomNumber == "Not Assigned")
            {
                Console.WriteLine("This guest has no active booking.");
                return;
            }

            Room room = rooms.FirstOrDefault(r => r.roomNumber.ToString() == guest.roomNumber);

            Console.WriteLine("\n--- Final Bill ---");
            Console.WriteLine($"Guest: {guest.guestName}");
            Console.WriteLine($"Room: {guest.roomNumber} ({room?.roomType})");
            Console.WriteLine($"Check-in: {guest.checkInDate}");
            Console.WriteLine($"Total nights: {guest.totalNights}");
            if (room != null)
            {
                Console.WriteLine($"Price per night: OMR {room.pricePerNight:F2}");
                Console.WriteLine($"Total cost: OMR {guest.calculateTotalCost(room.pricePerNight):F2}");
            }

            string confirm = ReadString("Confirm checkout? (Y/N): ");
            if (confirm.Trim().ToUpper() != "Y")
            {
                Console.WriteLine("Checkout cancelled. No changes made.");
                return;
            }

            // Free the room BEFORE removing the guest
            if (room != null) room.isAvailable = true;
            guests.Remove(guest);

            Console.WriteLine("\nCheckout complete.");
            Console.WriteLine($"Remaining guests: {guests.Count}");
            Console.WriteLine($"Remaining rooms: {rooms.Count}");
            if (room != null)
                Console.WriteLine($"Room {room.roomNumber} available: {rooms.Any(r => r.roomNumber == room.roomNumber && r.isAvailable)}");
        }

        // ================= CASE 12 — Remove Unavailable Rooms =================
        static void RemoveUnavailableRooms(List<Room> rooms, List<Guest> guests)
        {
            Console.WriteLine("--- Remove Unavailable Rooms ---");

            var removable = rooms
                .Where(r => !r.isAvailable && !guests.Any(g => g.roomNumber == r.roomNumber.ToString()))
                .OrderBy(r => r.roomNumber)
                .ToList();

            if (!removable.Any())
            {
                Console.WriteLine("All unavailable rooms are currently occupied. No rooms can be decommissioned.");
                return;
            }

            Console.WriteLine($"Removable rooms ({removable.Count()}):");
            foreach (var r in removable)
                Console.WriteLine($"Room {r.roomNumber} | {r.roomType} | OMR {r.pricePerNight:F2}");

            string confirm = ReadString("Confirm removal? (Y/N): ");
            if (confirm.Trim().ToUpper() != "Y")
            {
                Console.WriteLine("No rooms removed.");
                return;
            }

            int removedCount = rooms.RemoveAll(r => !r.isAvailable && !guests.Any(g => g.roomNumber == r.roomNumber.ToString()));

            Console.WriteLine($"\n{removedCount} room(s) removed.");
            Console.WriteLine($"Total rooms now: {rooms.Count}");
            var remaining = rooms.Select(r => $"Room {r.roomNumber} - {r.roomType}").ToList();
            foreach (var line in remaining)
                Console.WriteLine(line);
        }

        // ================= CASE 13 — Extend Guest Stay =================
        static void ExtendGuestStay(List<Guest> guests, List<Room> rooms)
        {
            Console.WriteLine("--- Extend Guest Stay ---");
            string guestId = ReadString("Enter guest ID: ");
            Guest guest = guests.FirstOrDefault(g => g.guestId.Equals(guestId, StringComparison.OrdinalIgnoreCase));
            if (guest == null)
            {
                Console.WriteLine("Error: Guest not found.");
                return;
            }

            if (guest.roomNumber == "Not Assigned")
            {
                Console.WriteLine("This guest has no active booking to extend.");
                return;
            }

            int extra = ReadInt("Enter additional nights: ");
            if (extra <= 0)
            {
                Console.WriteLine("Error: Additional nights must be a positive integer. No change made.");
                return;
            }

            guest.totalNights += extra;

            Room room = rooms.FirstOrDefault(r => r.roomNumber.ToString() == guest.roomNumber);
            Console.WriteLine($"Stay extended. New total nights: {guest.totalNights}");
            if (room != null)
                Console.WriteLine($"New total cost: OMR {guest.calculateTotalCost(room.pricePerNight):F2}");
        }

        // ================= CASE 14 — Highest Revenue Booking =================
        static void HighestRevenueBooking(List<Guest> guests, List<Room> rooms)
        {
            Console.WriteLine("--- Highest Revenue Booking ---");
            var active = guests.Where(g => g.roomNumber != "Not Assigned").ToList();

            if (!active.Any())
            {
                Console.WriteLine("No active bookings recorded.");
                return;
            }

            var topEarner = active
                .Select(g => new
                {
                    g.guestName,
                    g.roomNumber,
                    Cost = GuestCost(g, rooms)
                })
                .OrderByDescending(x => x.Cost)
                .Take(1)
                .First();

            Console.WriteLine("Top Earner:");
            Console.WriteLine($"Guest: {topEarner.guestName}");
            Console.WriteLine($"Room: {topEarner.roomNumber}");
            Console.WriteLine($"Total cost: OMR {topEarner.Cost:F2}");
        }

        // ================= CASE 15 — Guest Pagination Viewer =================
        static void GuestPaginationViewer(List<Guest> guests)
        {
            Console.WriteLine("--- Guest Pagination Viewer ---");
            int pageSize = 3;
            int totalPages = (int)Math.Ceiling(guests.Count() / (double)pageSize);
            if (totalPages == 0) totalPages = 1;

            int page = ReadInt($"Enter page number (1-{totalPages}): ");

            if (page < 1 || page > totalPages || !guests.Any())
            {
                Console.WriteLine("That page does not exist.");
                return;
            }

            var pageItems = guests.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            Console.WriteLine($"\nPage {page} of {totalPages}:");
            foreach (var g in pageItems)
                g.displayGuest();
        }

        
    }

    
}

