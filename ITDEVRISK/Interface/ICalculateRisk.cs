using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITDEVRISK.Interface
{
    public interface ICalculateRisk
    {
        double _value { get; set; }
        int IsRiskEnum { get; set; }
        double HighRiskMaxValue { get; set; }

        void Calculate();

        int Return();
    }
}
