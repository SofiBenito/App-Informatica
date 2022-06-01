using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class MarcaNegocio
    {
        public List<Marca>listar()
        {
            List<Marca> lista = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.settearConsulta("select idMarca,nombreMarca from Marcas Order by 2");
                datos.ejecutarLectura();

                while(datos.Lector.Read())
                {
                    Marca marca = new Marca();
                    if (!(datos.Lector["idMarca"] is DBNull))
                        marca.Id = (int)datos.Lector["idMarca"];
                    if (!(datos.Lector["nombreMarca"] is DBNull))
                        marca.Nombre = (string)datos.Lector["nombreMarca"];
                    lista.Add(marca);   
                }
                return lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
