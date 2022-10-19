using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RD.DAL
{
    public class StoreProcedures
    {
        #region Insert Procedure

        public const string proc_InsertDistrict = "territory.proc_InsertDistrict";
        public const string proc_InsertMauza = "territory.proc_InsertMauza";
        public const string proc_InsertSubRegistrar = "territory.proc_InsertSubRegistrar";
        public const string proc_InsertTehsil = "territory.proc_InsertTehsil";
        public const string proc_InsertTown = "territory.proc_InsertTown";
        public const string proc_InsertRegistryOperations = "rd.proc_InsertRegistryOperations";
        public const string proc_InsertLrmisRegistryInfo = "[transactions].[proc_InsertRegistryInfo]";
        public const string proc_InsertKhasra = "rd.proc_InsertKhasra";
        public const string proc_Insertfard = "rd.proc_Insertfard";
        public const string proc_InsertPerson = "rd.proc_InsertPerson";
        public const string proc_InsertPersonPicByPersonId = "rd.proc_InsertPersonPicByPersonId";
        public const string proc_InsertRegistryPerson = "rd.proc_InsertRegistryPerson";
        public const string proc_InsertRegistryImages = "rd.proc_InsertRegistryImages";
        public const string proc_InsertRegistryType = "Setup.proc_InsertRegistryType";
        public const string proc_InsertCaste = "Setup.proc_InsertCaste";
        public const string proc_InsertPartyType = "Setup.proc_InsertPartyType";
        public const string proc_InsertConfigurations = "Setup.proc_InsertConfigurations";
        public const string proc_InsertForms = "users.proc_InsertForms";
        public const string proc_InsertMauzaRights = "users.proc_InsertMauzaRights";
        public const string proc_InsertMenu = "users.proc_InsertMenu";
        public const string proc_InsertModule = "users.proc_InsertModule";
        public const string proc_InsertRole = "users.proc_InsertRole";
        public const string proc_InsertUserN = "users.proc_InsertUserN";
        public const string proc_InsertUserRoles = "users.proc_InsertUserRoles";
        public const string proc_InsertUserWithRole = "users.proc_InsertUserWithRole";
        public const string proc_InsertUserRights = "users.proc_InsertUserRights";
        public const string proc_InsertRoleRights = "users.proc_InsertRoleRights";

        public const string proc_InsertPlot = "[rd].[proc_InsertPlot]";
        
        #endregion

        #region Get Procedure

        public const string proc_GetDistrict = "territory.proc_GetDistrict";
        public const string proc_GetMauza = "territory.proc_GetMauza";
        public const string proc_GetSubRegistrar = "territory.proc_GetSubRegistrar";
        public const string proc_GetTehsil = "territory.proc_GetTehsil";
        public const string proc_GetTown = "territory.proc_GetTown";
        public const string Proc_GetRegistryOperations = "rd.Proc_GetRegistryOperations";
        public const string proc_GetRegistryType = "Setup.proc_GetRegistryType";
        public const string proc_GetRegistryTypeWithParams = "rd.Proc_GetRegistryWithParams";
        public const string proc_GetPartyType = "Setup.proc_GetPartyType";
        public const string proc_GetCaste = "Setup.proc_GetCaste";
        public const string proc_GetConfigurations = "Setup.proc_GetConfigurations";
        public const string Proc_GetKhasra = "rd.Proc_GetKhasra";
        public const string Proc_GetPerson = "rd.Proc_GetPerson";
        public const string Proc_GetFard = "rd.Proc_GetFard";
        public const string Proc_GetRegistryPerson = "rd.Proc_GetRegistryPerson";
        public const string proc_GetRegistryImages = "rd.proc_GetRegistryImages";
        public const string proc_GetForms = "users.proc_GetForms";
        public const string proc_GetMauzaRights = "users.proc_GetMauzaRights";
        public const string proc_GetMenu = "users.proc_GetMenu";
        public const string proc_GetModule = "users.proc_GetModule";
        public const string proc_GetRole = "users.proc_GetRole";
        public const string proc_GetUserN = "users.proc_GetUserN";
        public const string proc_GetUserRoles = "users.proc_GetUserRoles";
        public const string proc_GetUserRights = "users.proc_GetUserRights";
        public const string Proc_GetPersonByRegistryid = "rd.Proc_GetPersonByRegistryid";
        public const string proc_GetRoleRights = "users.proc_GetRoleRights";
        public const string proc_GetPlotByRegistryId = "[rd].[GetPlotByRegistryId]";
        #endregion

        #region Update Procedure

        public const string proc_UpdateDistrict = "territory.proc_UpdateDistrict";
        public const string proc_UpdateMauza = "territory.proc_UpdateMauza";
        public const string proc_UpdateSubRegistrar = "territory.proc_UpdateSubRegistrar";
        public const string proc_UpdateTehsil = "territory.proc_UpdateTehsil";
        public const string proc_UpdateTown = "territory.proc_UpdateTown";
        public const string proc_UpdateRegistryOperations = "rd.proc_UpdateRegistryOperations";
        public const string proc_UpdateRegistryType = "Setup.proc_UpdateRegistryType";
        public const string proc_UpdatePartyType = "Setup.proc_UpdatePartyType";
        public const string proc_UpdateCaste = "Setup.proc_UpdateCaste";
        public const string proc_UpdateConfigurations = "Setup.proc_UpdateConfigurations";
        public const string proc_UpdateKhasra = "rd.proc_UpdateKhasra";
        public const string proc_Updatefard = "rd.proc_Updatefard";
        public const string proc_UpdatePerson = "rd.proc_UpdatePerson";
        public const string proc_UpdatePersonPicByPersonId = "rd.proc_UpdatePersonPicByPersonId";
        public const string proc_UpdateRegistryPerson = "rd.proc_UpdateRegistryPerson";
        public const string proc_UpdateRegistryImages = "rd.proc_UpdateRegistryImages";
        public const string proc_UpdateForms = "users.proc_UpdateForms";
        public const string proc_UpdateMauzaRights = "users.proc_UpdateMauzaRights";
        public const string proc_UpdateMenu = "users.proc_UpdateMenu";
        public const string proc_UpdateModule = "users.proc_UpdateModule";
        public const string proc_UpdateRole = "users.proc_UpdateRole";
        public const string proc_UpdateUser = "users.proc_UpdateUser";
        public const string proc_UpdateUserRoles = "users.proc_UpdateUserRoles";
        public const string proc_UpdateUserWithRole = "users.proc_UpdateUserWithRole";
        public const string proc_UpdateUserRights = "users.proc_UpdateUserRights";
        public const string proc_UpdateRegistryOperationsStage = "rd.proc_UpdateRegistryOperationsStage";
        public const string proc_UpdateRoleRights = "users.proc_UpdateRoleRights";
        public const string proc_UpdatePlot = "[rd].[proc_UpdatePlot]";

        #endregion

        #region Delete Procedure

        public const string proc_DeleteDistrict = "territory.proc_DeleteDistrict";
        public const string proc_DeleteSubRegistrar = "territory.proc_DeleteSubRegistrar";
        public const string proc_DeleteTehsil = "territory.proc_DeleteTehsil";
        public const string proc_DeleteTown = "territory.proc_DeleteTown";
        public const string proc_DeleteMauza = "territory.proc_DeleteMauza";
        public const string proc_DeleteFard = "rd.proc_DeleteFard";
        public const string proc_DeleteKhasra = "rd.proc_DeleteKhasra";
        public const string proc_DeletePerson = "rd.proc_DeletePerson";
        public const string proc_DeleteRegistryOperations = "rd.proc_DeleteRegistryOperations";
        public const string proc_DeleteRegistryPerson = "rd.proc_DeleteRegistryPerson";
        public const string proc_DeleteRegistryImages = "rd.proc_DeleteRegistryImages";
        public const string proc_DeleteCaste = "Setup.proc_DeleteCaste";
        public const string proc_DeleteRegistryType = "Setup.proc_DeleteRegistryType";
        public const string proc_DeletePartyType = "Setup.proc_DeletePartyType";
        public const string proc_DeleteConfigurations = "Setup.proc_DeleteConfigurations";
        public const string proc_DeleteForms = "users.proc_DeleteForms";
        public const string proc_DeleteMauzaRights = "users.proc_DeleteMauzaRights";
        public const string proc_DeleteMenu = "users.proc_DeleteMenu";
        public const string proc_DeleteModule = "users.proc_DeleteModule";
        public const string proc_DeleteRole = "users.proc_DeleteRole";
        public const string proc_DeleteUser = "users.proc_DeleteUser";
        public const string proc_DeleteUserRoles = "users.proc_DeleteUserRoles";
        public const string proc_DeleteUserRights = "users.proc_DeleteUserRights";
        public const string proc_DeleteRoleRights = "users.proc_DeleteRoleRights";

        public const string proc_DeletePlot = "[rd].[proc_DeletePlot]";

        #endregion


    }
}
