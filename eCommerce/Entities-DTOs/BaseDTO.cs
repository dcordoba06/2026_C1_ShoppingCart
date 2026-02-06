using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_DTOs
{
    public class BaseDTO
    {
        /*
         * Clase base, papa de todos los DTOs o POJOS
         */

        public int Id { get; set; }
        public string Status { get; set; }
        public DateTime Created {  get; set; }
        public DateTime Updated { get; set; }

    }
}
