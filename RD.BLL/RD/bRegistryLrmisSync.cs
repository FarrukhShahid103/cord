using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RD.EL;
using RD.DAL;

namespace RD.BLL
{
    public class bRegistryLrmisSync
    {
        DRegistryLrmisSync odRegistryLrmisSync;
        updatedNewEntryInfo insertInfo = null;
        public updatedNewEntryInfo InsertLrmisRegistrySync(eRegistryOperations oeRegistryOperations, String CurrentDB)
        {
           
            odRegistryLrmisSync = new DRegistryLrmisSync(CurrentDB);
            insertInfo = odRegistryLrmisSync.InsertLrmisRegistrySync(oeRegistryOperations);
            return insertInfo;
        }
    }
}
