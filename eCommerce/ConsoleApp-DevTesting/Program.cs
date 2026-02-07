

using DataAccess.DAO;

public class Program
{
    public static void Main(string[] args)
    {

        //Prueba de funcionamieento del DAO.

        var sql = SqlDAO.GetInstance();

        var sqlOperation = new SqlOperation { ProcedureName = "CRE_USER_PR" };
        sqlOperation.AddStringParam("P_NAME", "Dennis");
        sqlOperation.AddStringParam("P_LAST_NAME", "Cordoba");
        sqlOperation.AddStringParam("P_PASSWORD", "Qwerty123");
        sqlOperation.AddStringParam("P_EMAIL", "dcordoba@ucenfotec.ac.cr");
        sqlOperation.AddDateTimeParam("P_BIRTH_DATE", DateTime.Now);
        sqlOperation.AddStringParam("P_STATUS", "AC");

        try
        {
            sql.ExecuteProcedure(sqlOperation);
            Console.WriteLine("Ejecutado de manera exitosa");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
       


    }

}