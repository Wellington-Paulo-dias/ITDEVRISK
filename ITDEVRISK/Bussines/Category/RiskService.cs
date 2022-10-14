using ITDEVRISK.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITDEVRISK.Bussines.Category
{
    public class RiskService 
    {
        public int Risk;
        private double _value = 0;
        public RiskService(double value, string clientSector)
        {
            _value = value < 0 ? 0 : value;
            var _clientSector = string.IsNullOrEmpty(clientSector) ? Constants.NotFound : clientSector;
            if (_clientSector.Equals(Constants.NotFound))
            {
                Risk = -1;
            }
            else
            {
                switch (_clientSector)
                {
                    case Constants.SectorPublic:
                        SectorPublic();
                        break;
                    case Constants.SectorPrivate:
                        SectorPrivate();
                        break;
                }
            }
            
        }

        public void SectorPrivate()
        {
            CalculateSectorPrivate calculateSector = new(_value);
            Risk = calculateSector.Return();
        }

        public void SectorPublic()
        {
            CalculateSectorPublic calculateSector = new(_value);
            Risk = calculateSector.Return();
        }
        public int ReturnResult() => Risk;
    }
}
