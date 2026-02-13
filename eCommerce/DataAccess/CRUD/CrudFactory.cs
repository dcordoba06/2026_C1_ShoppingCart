using DataAccess.DAO;
using Entities_DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CRUD
{

    //Clase padre/madre abstracta de los crud
    //define como se hacen y comportan los crud en la arquitectura
    public abstract class CrudFactory
    {

        protected SqlDAO sqlDAO;

        //Definir los metodos que forman parte del contrato
        //CREATE
        //RETRIEVE
        //UPDATE
        //DELETE


        public abstract void Create(BaseDTO baseDTO);
        public abstract void Update(BaseDTO baseDTO);
        public abstract void Delete(BaseDTO baseDTO);
        public abstract T RetrieveById<T>(int id);
        public abstract List<T> RetrieveAll<T>();

    }
}
