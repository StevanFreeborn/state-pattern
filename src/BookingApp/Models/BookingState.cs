namespace BookingApp.Models;

abstract class BookingState
{ 
  public abstract string Status { get; }
  public abstract void EnterState(BookingContext context);
  public abstract void Cancel(BookingContext context);
  public abstract void DatePassed(BookingContext context);
  public abstract void SubmitDetails(BookingContext context, string attendeeName, int ticketQuantity);
}