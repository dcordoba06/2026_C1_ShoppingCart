using DataAccess.DAO;
using Entities_DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CRUD
{
    public class UserCrudFactory : CrudFactory
    {

        public UserCrudFactory() { 
        
            sqlDAO=SqlDAO.GetInstance();
        }

        public override void Create(BaseDTO baseDTO)
        {          
            var user = baseDTO as User;

            //Ejecucion del SP
            var sqlOperation = new SqlOperation();
            sqlOperation.ProcedureName = "CRE_USER_PR";

            sqlOperation.AddStringParam("P_NAME", user.Name);
            sqlOperation.AddStringParam("P_LAST_NAME", user.LastName);
            sqlOperation.AddStringParam("P_PASSWORD", user.Password);
            sqlOperation.AddStringParam("P_EMAIL", user.Email);
            sqlOperation.AddDateTimeParam("P_BIRTH_DATE", user.BirthDate);
            sqlOperation.AddStringParam("P_STATUS", user.Status);

            sqlDAO.ExecuteProcedure(sqlOperation);

        }

        public override void Delete(BaseDTO baseDTO)
        {
            var user = baseDTO as User;

            //Ejecucion del SP
            var sqlOperation = new SqlOperation();
            sqlOperation.ProcedureName = "DEL_USER_PR";

            sqlOperation.AddIntParam("P_ID", user.Id);

            sqlDAO.ExecuteProcedure(sqlOperation);
        }

        public override List<T> RetrieveAll<T>()
        {
            throw new NotImplementedException();
        }

        public override T RetrieveById<T>(int id)
        {
            throw new NotImplementedException();
        }

        public override void Update(BaseDTO baseDTO)
        {
            var user = baseDTO as User;

            //Ejecucion del SP
            var sqlOperation = new SqlOperation();
            sqlOperation.ProcedureName = "UPD_USER_PR";

            sqlOperation.AddIntParam("P_ID", user.Id);
            sqlOperation.AddStringParam("P_NAME", user.Name);
            sqlOperation.AddStringParam("P_LAST_NAME", user.LastName);
            sqlOperation.AddStringParam("P_PASSWORD", user.Password);
            sqlOperation.AddStringParam("P_EMAIL", user.Email);
            sqlOperation.AddDateTimeParam("P_BIRTH_DATE", user.BirthDate);
            sqlOperation.AddStringParam("P_STATUS", user.Status);

            sqlDAO.ExecuteProcedure(sqlOperation);

        }
    }
}
