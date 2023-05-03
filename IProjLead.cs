using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CADAutoPrintPlugin_2023
{
      interface IProjLead
      {
            string ProjectLead { get; set; }

            int ProductionNumber { get; set; }
      }
}
