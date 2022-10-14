using ITDEVRISK.Domain;
using ITDEVRISK.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace ITDEVRISK.Bussines.Category
{
    public class Category : ICategoryExpired
    {       

        public bool Expired(DateTime datePay, DateTime dateReference)
        {
            ExpiredService categoryExpiredService = new(datePay, dateReference);
            return categoryExpiredService.ReturnResult();

        }

        
    }
}
