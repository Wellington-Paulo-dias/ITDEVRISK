using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITDEVRISK.Domain
{
    public class Constants
    {
        public const string NotFound = "NotFound";

        public const string SectorPrivate = "Private";

        public const string SectorPublic = "Public";

        public class Category
        {
            public const string EXPIRED = "EXPIRED";
            public const string HIGHRISK = "HIGHRISK";
            public const string MEDIUMRISK = "MEDIUMRISK";

        }
    }
}
