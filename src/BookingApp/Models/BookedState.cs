namespace BookingApp.Models;

class BookedState : BookingState
{
  public override string Status => BookingStatus.Booked;

  public override void Cancel(BookingContext context)
  {
    context.TransitionToState(new ClosedState("Booking was cancelled"));
  }

  public override void DatePassed(BookingContext context)
  {
    context.TransitionToState(new ClosedState("We hope you enjoyed the event"));
  }

  public override void EnterState(BookingContext context)
  {
    return;
  }

  public override void SubmitDetails(BookingContext context, string attendeeName, int ticketQuantity)
  {
    throw new InvalidOperationException("You have already booked your place");
  }
}