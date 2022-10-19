using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RD.EL
{
    public class ePlot
    {
        #region Variables
        Guid plot_Id;
        Guid registry_Id;
        string plotNo;
        string east;
        string west;
        string south;
        string north;
        string khasraNo;
        #endregion
        #region Properties
        public Guid Plot_Id
        {
            get { return plot_Id; }
            set { plot_Id = value; }
        }
        public Guid Registry_Id
        {
            get { return registry_Id; }
            set { registry_Id = value; }
        }
        public string PlotNo
        {
            get { return plotNo; }
            set { plotNo = value; }
        }
        public string East
        {
            get { return east; }
            set { east = value; }
        }
        public string West
        {
            get { return west; }
            set { west = value; }
        }
        public string North
        {
            get { return north; }
            set { north = value; }
        }
        public string South
        {
            get { return south; }
            set { south = value; }
        }
        public string KhasraNo
        {
            get { return khasraNo; }
            set { khasraNo = value; }
        }       
        #endregion
    }
}
