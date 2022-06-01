using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Producto
    {
        private int codigo;
        private string detalle;
        private int tipo;
        private Marca marca;
        private double precio;
        private DateTime fecha;
        public int Codigo
        {
            get { return codigo; }  
            set { codigo = value; } 
        }
        public string Detalle
        {
            get { return detalle; } 
            set { detalle = value; }    
        }
        public int Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        public Marca Marca
        {
            get { return marca; }
            set { marca = value; }
        }
        public double Precio
        {
            get { return precio; }
            set { precio = value; }
        }
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

    }
}
