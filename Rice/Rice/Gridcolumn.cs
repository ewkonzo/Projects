using System;
using System.Collections.Generic;
using System.Linq;

namespace Rice
{
    public class Gridcolumn : DevExpress.XtraGrid.Columns.GridColumn
    {
        private Boolean listctype;
        public virtual Boolean Showinlist { get { return listctype; } set { listctype = value; } }
    }
}
