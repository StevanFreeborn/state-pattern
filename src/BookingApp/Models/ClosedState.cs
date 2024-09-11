namespace BookingApp.Models;

class ClosedState : BookingState
{
  private readonly string _closedReason;

  public override string Status => BookingStatus.Closed;

  public ClosedState(string closedReason)
  {
    _closedReason = closedReason;
  }

  public override void EnterState(BookingContext context)
  {
    context.ClosedReason = _closedReason;
  }

  public override void Cancel(BookingContext context)
  {
    throw new InvalidOperationException("You cannot cancel a closed booking");
  }

  public override void DatePassed(BookingContext context)
  {
    throw new InvalidOperationException("You cannot set a closed booking as date passed");
  }

  public override void SubmitDetails(BookingContext context, string attendeeName, int ticketQuantity)
  {
    throw new InvalidOperationException("You cannot submit details for a closed booking");
  }
}