using Goodreads.Business.Service.Interface;

namespace Goodreads.Business.Service;

// this service is used instead of using UtcNow directly for better unit testing
public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.Now;
}