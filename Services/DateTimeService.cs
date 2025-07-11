﻿namespace EShop.Services
{
    public interface IDateTimeService
    {
        DateTime UtcNow { get; }
    }

    public class DateTimeService : IDateTimeService
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}