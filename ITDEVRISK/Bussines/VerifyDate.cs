using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITDEVRISK.Bussines
{
    public class VerifyDate
    {
        private bool IsDateOk;        
        public VerifyDate(string date)
        {
            if (date.Length == 10)
                VerifyValues(date.Split('/'));
            else
                IsDateOk = false;
                       
        }

        private void VerifyValues(string[] valuesDateSplit)
        {
            if (valuesDateSplit.Length == 3)
            {
                if (ValidDay(int.Parse(valuesDateSplit[1])) && ValidMount(int.Parse(valuesDateSplit[0])) && ValidYear(int.Parse(valuesDateSplit[2])))
                {
                    IsDateOk = true;
                }
                else
                    IsDateOk = false;
            }
        }

        private bool ValidDay(int day)
        {
            if(day<=31)
                return true;
            return false;
        }
        private bool ValidMount(int mount)
        {
            if (mount <= 12)
                return true;
            return false;
        }
        private bool ValidYear(int year)
        {
            if (year > 0 )
                return true;
            return false;
        }

        public bool Return() => IsDateOk;

    }
}
