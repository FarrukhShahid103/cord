using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using RD.EL;
using System.Data.Common;
using System.Data;

namespace RD.DAL
{
    public class dPlot : DataBaseHelper
    {
        DbCommand oCmd;
        IDataReader oDReader;
        public dPlot()
        {

        }
        public override void InitializeAccessors()
        {

        }
        public updatedNewEntryInfo InsertPlot(ePlot oePlot)
        {
            string storProc = StoreProcedures.proc_InsertPlot;
            int effectRow = 0;
            updatedNewEntryInfo insertInfo = new updatedNewEntryInfo();
            if (oePlot != null)
            {
                oePlot.Plot_Id = Guid.NewGuid();
                using (oCmd = Db.GetStoredProcCommand(storProc))
                {
                    Db.AddInParameter(oCmd, "@Plot_Id", DbType.Guid, oePlot.Plot_Id);
                    Db.AddInParameter(oCmd, "@Registry_Id", DbType.Guid, oePlot.Registry_Id);
                    Db.AddInParameter(oCmd, "@PlotNo", DbType.String, oePlot.PlotNo);
                    Db.AddInParameter(oCmd, "@KhasraNo", DbType.String, oePlot.KhasraNo);
                    Db.AddInParameter(oCmd, "@East", DbType.String, oePlot.East);
                    Db.AddInParameter(oCmd, "@West", DbType.String, oePlot.West);
                    Db.AddInParameter(oCmd, "@South", DbType.String, oePlot.South);
                    Db.AddInParameter(oCmd, "@North", DbType.String, oePlot.North);
                    effectRow = Db.ExecuteNonQuery(oCmd);
                    if (effectRow > -1)
                    {
                        insertInfo.Id = oePlot.Plot_Id;
                        insertInfo.Success = true;
                    }
                    else
                    {
                        insertInfo.Success = false;
                    }
                }
            }
            return insertInfo;
        }

        public updatedNewEntryInfo UpdatePlot(ePlot oePlot)
        {
            string storProc = StoreProcedures.proc_UpdatePlot;
            int effectRow = 0;
            updatedNewEntryInfo UPdateInfo = new updatedNewEntryInfo();
            if (oePlot != null)
            {
                using (oCmd = Db.GetStoredProcCommand(storProc))
                {
                    try
                    {
                        Db.AddInParameter(oCmd, "@Plot_Id", DbType.Guid, oePlot.Plot_Id);
                        Db.AddInParameter(oCmd, "@PlotNo", DbType.String, oePlot.PlotNo);
                        Db.AddInParameter(oCmd, "@KhasraNo", DbType.String, oePlot.KhasraNo);
                        Db.AddInParameter(oCmd, "@East", DbType.String, oePlot.East);
                        Db.AddInParameter(oCmd, "@West", DbType.String, oePlot.West);
                        Db.AddInParameter(oCmd, "@South", DbType.String, oePlot.South);
                        Db.AddInParameter(oCmd, "@North", DbType.String, oePlot.North);
                        effectRow = Db.ExecuteNonQuery(oCmd);
                        if (effectRow > -1)
                        {
                            UPdateInfo.Id = oePlot.Plot_Id;
                            UPdateInfo.Success = true;
                        }
                        else
                        {
                            UPdateInfo.Success = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        oCmd.Dispose();
                    }
                }
            }
            return UPdateInfo;
        }
        public updatedNewEntryInfo DeletePlot(ePlot oePlot)
        {
            string storProc = StoreProcedures.proc_DeletePlot;
            int effectRow = 0;
            updatedNewEntryInfo DeleteInfo = new updatedNewEntryInfo();
            if (oePlot != null)
            {
                using (oCmd = Db.GetStoredProcCommand(storProc))
                {
                    try
                    {
                        Db.AddInParameter(oCmd, "@Plot_Id", DbType.Guid, oePlot.Plot_Id);
                        effectRow = Db.ExecuteNonQuery(oCmd);
                        if (effectRow != 0)
                        {
                            DeleteInfo.Id = oePlot.Plot_Id;
                            DeleteInfo.Success = true;
                        }
                        else
                        {
                            DeleteInfo.Success = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        oCmd.Dispose();
                    }

                }
            }
            return DeleteInfo;
        }
        public List<ePlot> GetPlotsByRegistyId(ePlot oePlot)
        {
            List<ePlot> oeListPlots = new List<ePlot>();
            try
            {
                string storProc = StoreProcedures.proc_GetPlotByRegistryId;
                oCmd = Db.GetStoredProcCommand(storProc);
                Db.AddInParameter(oCmd, "@Registry_Id", DbType.Guid, oePlot.Registry_Id);
                oDReader = Db.ExecuteReader(oCmd);               

                while (oDReader.Read())
                {
                    ePlot oePlots = new ePlot();
                    oePlots.Plot_Id = ValidateFields.GetSafeGuid(oDReader["Plot_Id"].ToString());
                    oePlots.Registry_Id = ValidateFields.GetSafeGuid(oDReader["registry_Id"].ToString());
                    oePlots.PlotNo = ValidateFields.GetSafeString(oDReader["PlotNo"]);
                    oePlots.KhasraNo = ValidateFields.GetSafeString(oDReader["KhasraNo"]);
                    oePlots.East = ValidateFields.GetSafeString(oDReader["East"]);
                    oePlots.West = ValidateFields.GetSafeString(oDReader["West"]);
                    oePlots.South = ValidateFields.GetSafeString(oDReader["South"]);
                    oePlots.North = ValidateFields.GetSafeString(oDReader["North"]);

                    oeListPlots.Add(oePlots);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oCmd.Dispose();
                oDReader.Dispose();
            }
            return oeListPlots;
        }
    }
 }

