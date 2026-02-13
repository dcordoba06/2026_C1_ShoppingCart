

using DataAccess.CRUD;
using DataAccess.DAO;
using Entities_DTOs;

public class Program
{
    public static void Main(string[] args)
    {

        var uc = new UserCrudFactory();

        var user = new User();

        Console.WriteLine("Digite el nombre del usuario, apellido, contrasenia, email, fecha nacimiento, estado -Separado por coma-");
        var text=Console.ReadLine();
        var vals = text.Split(",");

        user.Name= vals[0];
        user.LastName= vals[1];
        user.Password= vals[2];
        user.Email= vals[3];
        user.BirthDate= DateTime.Parse(vals[4]);
        user.Status= vals[5]; 
        
        try
        {
            uc.Create(user);
            Console.WriteLine("Ejecutado de manera exitosa");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
       


    }

}