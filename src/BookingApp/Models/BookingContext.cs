namespace BookingApp.Models;

class BookingContext
{
  public string Id { get; set; } = null!;
  public string Status => _currentState.Status;
  public string AttendeeName { get; set; } = string.Empty;
  public int TicketQuantity { get; set; } = 0;
  public string ClosedReason { get; set; } = string.Empty;
  private BookingState _currentState = null!;

  public BookingContext()
  {
    TransitionToState(new NewState());
  }

  public void TransitionToState(BookingState newState)
  {
    _currentState = newState;
    _currentState.EnterState(this);
  }

  public void SubmitDetails(string attendeeName, int ticketQuantity) => _currentState.SubmitDetails(this, attendeeName, ticketQuantity);
  public void Cancel() => _currentState.Cancel(this);
  public void DatePassed() => _currentState.DatePassed(this);
}