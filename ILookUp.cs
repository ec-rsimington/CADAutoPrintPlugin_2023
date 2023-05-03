using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CADAutoPrintPlugin_2023
{
    interface ILookUp
    {
        string LookupPath { get; set; }
        bool bolProjNum { get; set; }
        bool bolProjName { get; set; }
        bool bolItemQty { get; set; }
    }
}
