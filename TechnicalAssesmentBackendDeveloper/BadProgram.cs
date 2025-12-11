namespace TechnicalAssesmentBackendDeveloper;

public class Booking
{
    public string GuestName { get; private set; }
    public string RoomNumber { get; private set; }
    public DateTime CheckInDate { get; private set; }
    public DateTime CheckOutDate { get; private set; }
    public int TotalDays { get; private set; }
    public double RatePerDay { get; private set; }
    public double Discount { get; private set; }
    public double TotalAmount { get; private set; }

    public async Task BookRoomAsync(string name, string room, DateTime checkin, DateTime checkout, double rate, double discountRate)
    {
        if (checkout <= checkin)
            throw new ArgumentException("Checkout date must be after check-in date.");

        if (rate < 0)
            throw new ArgumentException("Rate per day cannot be negative.");

        if (discountRate < 0 || discountRate > 100)
            throw new ArgumentException("Discount must be between 0 and 100.");

        GuestName = name;
        RoomNumber = room;
        CheckInDate = checkin;
        CheckOutDate = checkout;
        RatePerDay = rate;
        Discount = discountRate;

        TotalDays = (checkout - checkin).Days;
        TotalAmount = TotalDays * RatePerDay;
        TotalAmount -= (TotalAmount * Discount / 100);

        await LogBookingDetailsAsync();

        PrintBookingSummary();
    }

    private void PrintBookingSummary()
    {
        Console.WriteLine("Booking Summary:");
        Console.WriteLine($"Guest Name: {GuestName}");
        Console.WriteLine($"Room Number: {RoomNumber}");
        Console.WriteLine($"Check-In: {CheckInDate}");
        Console.WriteLine($"Check-Out: {CheckOutDate}");
        Console.WriteLine($"Total Days: {TotalDays}");
        Console.WriteLine($"Total Amount: {TotalAmount}");
    }

    private async Task LogBookingDetailsAsync()
    {
        await Task.Delay(500); // Simulated delay
        Console.WriteLine("Booking log saved.");
    }

    public void Cancel()
    {
        Console.WriteLine("Booking cancelled.");

        GuestName = string.Empty;
        RoomNumber = string.Empty;
        CheckInDate = DateTime.MinValue;
        CheckOutDate = DateTime.MinValue;
        RatePerDay = 0;
        Discount = 0;
        TotalAmount = 0;
        TotalDays = 0;
    }
}

public static class AppHost
{
    public static async Task RunAsync()
    {
        Booking booking = new Booking();

        await booking.BookRoomAsync("Alice", "101", DateTime.Now, DateTime.Now.AddDays(3), 150.5, 10);
        booking.Cancel();
    }
}
