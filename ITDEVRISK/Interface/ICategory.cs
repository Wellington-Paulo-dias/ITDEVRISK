using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITDEVRISK.Interface
{
    public interface ICategoryExpired
    {
       bool Expired(DateTime datePay, DateTime dateReference);


    }
}
