using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{

    //Vamos usar el patron del Singleton
    /*
     * Clase que se encarha de la comunicacion con la base de datos
     * Aasegura que solo exista una unica instancia de esta clase
     */
    public class SqlDAO
    {
        //Paso 1: Crear una instancia privada de la misma clase
        private static SqlDAO instance;

        private string connectionString;

        //Paso 2: Redefinir el constructor, para convertirlo en privado
        private SqlDAO() {

            connectionString = @"Data Source=srv-sql01-dcordoba.database.windows.net;Initial Catalog=2026C1-ecommerce;User ID=sysman;Password=Cenfotec123!;Trust Server Certificate=True";
        }

        //Paso 3:Metodo que expone la instancia de  la clase
        public static SqlDAO GetInstance() {
            if (instance == null) { 
                instance= new SqlDAO();
            }

            return instance;

        }

        //Metodo para ejecutar SP sin retorno de data
        public void ExecuteProcedure(SqlOperation operation) { 
            
            using(var conn=new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand(operation.ProcedureName, conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                })
                {
                    //Set de los parametros
                    foreach (var param in operation.Parameters)
                    {
                        cmd.Parameters.Add(param);
                    }

                    //Ejecutar el SP contra la base de datos
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
