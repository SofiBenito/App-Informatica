using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Marca
    {
        private int id;
        private string nombre;
        public int Id
        {
            get { return id; }      
            set { id = value; } 
        }
        public string Nombre
        {
            get { return nombre; }  
            set { nombre = value; }
        }
        public override string ToString()
        {
            return Nombre;
        }
    }
}
