using ITDEVRISK.Domain;
using ITDEVRISK.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITDEVRISK.Bussines.Category
{
    public class CalculateSectorPrivate : ICalculateRisk
    {
        public double _value { get; set; }
        public int IsRiskEnum { get; set; }
        public double HighRiskMaxValue { get; set; } = 1000000;
       

        public CalculateSectorPrivate(double value)
        {
            _value = value;
            Calculate();
        }

        public void Calculate()
        {
            IsRiskEnum = _value > HighRiskMaxValue ? (int)EnumCategory.HighRisk : -1;
        }

        public int Return() => IsRiskEnum;
    }
}
