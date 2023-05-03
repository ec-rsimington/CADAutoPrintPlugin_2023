using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CADAutoPrintPlugin_2023
{
    internal interface IPrintItems
    {
        List<BoMItem> printItems { get; set; }
    }
}
