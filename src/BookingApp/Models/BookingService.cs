namespace BookingApp.Models;

static class BookingService
{
  public static void ProcessBooking(BookingContext context, Action<BookingContext, ProcessingResult> onCompleteCallback, CancellationToken cancellationToken)
  {
    var result = ProcessingResult.Success;

    try
    {
      Task.Delay(2000, cancellationToken).Wait(cancellationToken);

      if (cancellationToken.IsCancellationRequested)
      {
        result = ProcessingResult.Canceled;
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine($"An error occurred: {ex.Message}");
      result = ProcessingResult.Failure;
    }
    finally
    {
      onCompleteCallback(context, result);
    }
  }
}

enum ProcessingResult
{
  Success,
  Failure,
  Canceled
}