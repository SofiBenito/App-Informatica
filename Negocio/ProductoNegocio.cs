using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ProductoNegocio
    {
        public List<Producto>listar()
        {
            List<Producto> lista = new List<Producto>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.settearConsulta("select codigo,detalle,tipo,p.marca IdMarca,m.nombreMarca Marca,precio,fecha from Productos P, Marcas M where p.marca=m.idMarca");
                datos.ejecutarLectura();
                while(datos.Lector.Read())
                {
                    Producto producto = new Producto();
                    if (!(datos.Lector["codigo"] is DBNull))
                        producto.Codigo = (int)datos.Lector["codigo"];
                    if (!(datos.Lector["detalle"] is DBNull))
                        producto.Detalle = (string)datos.Lector["detalle"];
                    if (!(datos.Lector["tipo"] is DBNull))
                        producto.Tipo = (int)datos.Lector["tipo"];

                    producto.Marca = new Marca();
                    if (!(datos.Lector["idMarca"] is DBNull))
                        producto.Marca.Id = (int)datos.Lector["IdMarca"];
                    if (!(datos.Lector["Marca"] is DBNull))
                        producto.Marca.Nombre = (string)datos.Lector["Marca"];
                    if (!(datos.Lector["precio"] is DBNull))
                        producto.Precio = (double)datos.Lector["precio"];
                    if (!(datos.Lector["fecha"] is DBNull))
                        producto.Fecha = (DateTime)datos.Lector["fecha"];

                    lista.Add(producto);

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
        public void agregar(Producto nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.settearConsulta("insert into Productos(codigo,detalle,tipo,marca,precio,fecha) values (@codigo,@detalle,@tipo,@marca,@precio,@fecha)");
                datos.settearParametros("@codigo", nuevo.Codigo);
                datos.settearParametros("@detalle", nuevo.Detalle);
                datos.settearParametros("@tipo", nuevo.Tipo);
                datos.settearParametros("@marca", nuevo.Marca.Id);
                datos.settearParametros("@precio", nuevo.Precio);
                datos.settearParametros("@fecha", nuevo.Fecha);
                datos.ejecutarAccion();
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
        public void modificar(Producto modificado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.settearConsulta("update Productos set detalle=@detalle, tipo= @tipo, marca=@marca, precio=@precio, fecha=@fecha where codigo=@codigo");
                datos.settearParametros("@detalle", modificado.Detalle);
                datos.settearParametros("@tipo", modificado.Tipo);
                datos.settearParametros("@marca", modificado.Marca.Id);
                datos.settearParametros("@precio", modificado.Precio);
                datos.settearParametros("@fecha", modificado.Fecha);
                datos.settearParametros("@codigo", modificado.Codigo);
          
                datos.ejecutarAccion();
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
        public void eliminarFisico(int codigo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.settearConsulta("Delete from Productos where codigo=@codigo");
                datos.settearParametros("@codigo",codigo);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
       
    }
}
