using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TOOL_BINH_TRAN.model
{
    public class ContactInfo
    {
        public string ContactPointType { get; set; } = "";
        public string NormalizedContactPoint { get; set; } = "";
        public bool HasAnyPendingStatus { get; set; }
    }
}
