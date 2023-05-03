using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CADAutoPrintPlugin_2023
{
    public class BoMItem
    {
        private string _partnumber;
        private string _description;
        private string _rev;
        private string _stocknumber;
        private int _qty;
        private string _comptype;
        private string _bomfinish;
        private int _finishid;
        private string _stockname;
        private string _usage;
        private string _units;
        private bool _isinternal;
        private int _defaultfinish;
        private bool _isconfigurable;
        private string _status;
        private string _path;

        public string PartNumber { get => _partnumber; set => _partnumber = value; }

        public string Description { get => _description; set => _description = value; }

        public string Rev { get => _rev; set => _rev = value; }

        public string StockNumber { get => _stocknumber; set => _stocknumber = value; }

        public int Qty { get => _qty; set => _qty = value; }

        public string CompType { get => _comptype; set => _comptype = value; }

        public string BoMFinish { get => _bomfinish; set => _bomfinish = value; }

        public int FinishID { get => _finishid; set => _finishid = value; }

        public string StockName { get => _stockname; set => _stockname = value; }

        public string Usage { get => _usage; set => _usage = value; }

        public string Units { get => _units; set => _units = value; }

        public bool IsInternal { get => _isinternal; set => _isinternal = value; }

        public int DefaultFinish { get => _defaultfinish; set => _defaultfinish = value; }

        public bool IsConfigurable { get => _isconfigurable; set => _isconfigurable = value; }

        public string Status { get => _status; set => _status = value; }

        public string Path { get => _path; set => _path = value; }
    }
}
