using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITDEVRISK.Bussines.Category
{
    public class ExpiredService
    {
        public bool IsExpired;
        private TimeSpan TotalDays = TimeSpan.Zero;
        public ExpiredService(DateTime datePay, DateTime dateReference)
        {
            DateTime _dateReference = new(dateReference.Year, dateReference.Month, dateReference.Day);
            DateTime _datePay = new(datePay.Year, datePay.Month, datePay.Day);
            TotalDays = _datePay.Subtract(_dateReference);
            VerifyExpired();
        }

        private void VerifyExpired()
        {
            IsExpired = TotalDays.Days > 30;
        }

        public bool ReturnResult() => IsExpired;
    }
}
