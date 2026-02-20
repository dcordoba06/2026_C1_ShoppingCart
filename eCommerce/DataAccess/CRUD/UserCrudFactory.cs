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

            var lstUsers=new List<T>();

            var operation=new SqlOperation();
            operation.ProcedureName = "RET_ALL_USER_PR";

            var lstResults= sqlDAO.ExecuteQueryProcedure(operation);

            if (lstResults.Count > 0)
            {
                foreach (var item in lstResults)
                {
                    var user = BuildUser(item);
                    lstUsers.Add((T)Convert.ChangeType(user, typeof(T)));
                }
            }

            return lstUsers;
           
        }

        public override T RetrieveById<T>(int id)
        {
            
            var operation = new SqlOperation();
            operation.ProcedureName = "RET_USER_BY_ID_PR";
            operation.AddIntParam("P_ID", id);

            var lstResults = sqlDAO.ExecuteQueryProcedure(operation);

            if (lstResults.Count > 0)
            {
                var item = lstResults[0];

                var user= BuildUser(item);

                return (T) Convert.ChangeType(user, typeof(T));
                
            }
            return default(T);
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

        //Metodo que construye el DDTO del usuario a partir de la data que viene de la consulta en BD
        private User BuildUser(Dictionary<string, object> row)
        {
            var user = new User()
            {
                Id = (int)row["ID"],
                Created = (DateTime)row["Created"],
                Name = (string)row["Name"],
                LastName = (string)row["LastName"],
                Password = (string)row["Password"],
                Email = (string)row["Email"],
                BirthDate = (DateTime)row["BirthDate"],
                Status = (string)row["Status"],
            };
            return user;

        }

    }
}
