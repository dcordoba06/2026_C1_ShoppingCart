using DataAccess.CRUD;
using Entities_DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore
{

    //Clase de negocio con validaciones y acciones
    public class UserManager : BaseManager
    {

        //Metodo que crea el usuario, validar que este sea mayor de edad
        //Envia un correo de bienvenida al usuario
        public void Create(User u)
        {
            try
            {
                //Valida que el usuario sea mayor de 18
                if (IsOver18(u))
                {
                    var uCrud = new UserCrudFactory();
                    uCrud.Create(u);

                    //Una vez creado envia el mail de bienvenida
                    EmailManager.SendWelcomeEmail(u);

                }
                else
                {
                    throw new Exception("El usuario no cumple con la edad minima para registrarse en el sistema");
                }


            }
            catch (Exception ex) { 
                ManageException(ex);
            }

        }

        public void Update(User u)
        {

            try
            {
                //Valida que el usuario sea mayor de 18
                if (IsOver18(u))
                {
                    var uCrud = new UserCrudFactory();
                    uCrud.Update(u);

                }
                else
                {
                    throw new Exception("El usuario no cumple con la edad minima para registrarse en el sistema");
                }


            }
            catch (Exception ex)
            {
                ManageException(ex);
            }

        }

        public void Delete(User u)
        {
            try
            {
                var uCrud = new UserCrudFactory();
                uCrud.Delete(u);

            }
            catch (Exception ex)
            {
                ManageException(ex);

            }
        }

        public List<User> RetrieveAll()
        {
            var list = new List<User>();
            try
            {
                var uCrud = new UserCrudFactory();
                list=uCrud.RetrieveAll<User>();
            }
            catch (Exception ex) {

                ManageException(ex);
            }
            
            return list;
        }

        public User RetrieveUserById(int id)
        {
           var user = new User();

            try
            {
                var uCrud = new UserCrudFactory();
                user = uCrud.RetrieveById<User>(id);
            }
            catch (Exception ex) {
                ManageException(ex);
            }

            return user;
        }


        private bool IsOver18(User user) {

            var currentDate = DateTime.Now;

            int age = currentDate.Year - user.BirthDate.Year;

            if (user.BirthDate > currentDate.AddYears(-age).Date)
            {
                age--;
            }
            return age >= 18;
        }

        //Agregar metodos update, delete, retrieve


    }
}
