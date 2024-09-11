namespace BookingApp.Models;

class PendingState : BookingState
{
  private CancellationTokenSource _cancelToken = null!;

  public override string Status => BookingStatus.Pending;

  public override void Cancel(BookingContext context)
  {
    _cancelToken.Cancel();
  }

  public override void DatePassed(BookingContext context)
  {
    throw new InvalidOperationException("Booking is already in progress");
  }

  public override void EnterState(BookingContext context)
  {
    _cancelToken = new CancellationTokenSource();

    BookingService.ProcessBooking(context, ProcessingComplete, _cancelToken.Token);
  }

  private void ProcessingComplete(BookingContext context, ProcessingResult result)
  {
    switch (result)
    {
      case ProcessingResult.Success:
        context.TransitionToState(new BookedState());
        break;
      case ProcessingResult.Failure:
        context.TransitionToState(new NewState());
        break;
      case ProcessingResult.Canceled:
        context.TransitionToState(new ClosedState("Processing Canceled"));
        break;
    }
  }

  public override void SubmitDetails(BookingContext context, string attendeeName, int ticketQuantity)
  {
    throw new InvalidOperationException("You have already submitted your details");
  }
}