using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RD.EL;
using RD.DAL;

namespace RD.BLL
{    
    public class bPlot
    {
        dPlot odPlot = null;
        updatedNewEntryInfo EntityInfo = null;
        public bPlot()
        {
            odPlot = new dPlot();
        }
        public updatedNewEntryInfo InsertPlot(ePlot oePlot)
        {
            try
            {
                return EntityInfo = odPlot.InsertPlot(oePlot);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public updatedNewEntryInfo UPdatePlot(ePlot oePlot)
        {
            try
            {
                return EntityInfo = odPlot.UpdatePlot(oePlot);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public updatedNewEntryInfo DeletePlot(ePlot oePlot)
        {
            try
            {
                return EntityInfo = odPlot.DeletePlot(oePlot);
            }
            catch(Exception ex)
            {
                throw ex;                     
            }
        }
        public List<ePlot> GetPlotsByRegistyId(ePlot oePlot)
        {
            return odPlot.GetPlotsByRegistyId(oePlot);
        }
        
        
    }
}
