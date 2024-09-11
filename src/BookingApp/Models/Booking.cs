namespace BookingApp.Models;

class Booking
{
  public string Id { get; init; } = Guid.NewGuid().ToString();
  public string Status { get; private set; } = BookingStatus.New;
  public string AttendeeName { get; private set; } = string.Empty;
  public int TicketQuantity { get; private set; } = 0;
  public string ClosedReason { get; private set; } = string.Empty;

  public void SubmitDetails(string attendeeName, int ticketQuantity)
  {
    throw new NotImplementedException();
  }

  public void Cancel()
  {
    Status = BookingStatus.Closed;
    ClosedReason = "Booking was cancelled";
  }

  public void DatePassed()
  {
    Status = BookingStatus.Closed;
    ClosedReason = "Booking date has passed";
  }
}

static class BookingStatus
{
  public const string New = "New";
  public const string Closed = "Closed";
  public const string Pending = "Pending";
  public const string Booked = "Booked";
}