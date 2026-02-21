using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore
{
    public class BaseManager
    {

        protected void ManageException(Exception exception)
        {
            //TO DO: Escribir las excepciones en un archivo o en bd


            throw exception;
        }

    }
}
