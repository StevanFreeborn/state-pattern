namespace BookingApp.Models;

class NewState : BookingState
{
  public override string Status => BookingStatus.New;

  public override void Cancel(BookingContext context)
  {
    context.TransitionToState(new ClosedState("Booking was cancelled"));
  }

  public override void DatePassed(BookingContext context)
  {
    context.TransitionToState(new ClosedState("Booking date has passed"));
  }

  public override void EnterState(BookingContext context)
  {
    context.Id = Guid.NewGuid().ToString();
  }

  public override void SubmitDetails(BookingContext context, string attendeeName, int ticketQuantity)
  {
    context.AttendeeName = attendeeName;
    context.TicketQuantity = ticketQuantity;
    context.TransitionToState(new PendingState());
  }
}