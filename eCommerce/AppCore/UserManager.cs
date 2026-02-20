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


            }
            catch (Exception ex) { 
            
            }

        }

        private bool IsOver18(User u) {

            return true;
        }

        //Agregar metodos update, delete, retrieve


    }
}
