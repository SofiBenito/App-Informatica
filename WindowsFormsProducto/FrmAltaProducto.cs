using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace WindowsFormsProducto
{
    public partial class FrmAltaProducto : Form
    {
         private bool nuevo = false;
         Producto producto;
        public FrmAltaProducto(bool nuevo)
        {
            InitializeComponent();
            this.nuevo = nuevo;
            Text = "Agregando Producto";
        }
        public FrmAltaProducto(Producto producto,bool nuevo)
        {
            InitializeComponent();
            this.producto= producto;    
            this.nuevo = nuevo;
            Text = "Modificado Producto";
        }

        private void FrmAltaProducto_Load(object sender, EventArgs e)
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            try
            {
                cboMarca.DataSource = marcaNegocio.listar();
                cboMarca.ValueMember = "Id";
                cboMarca.DisplayMember = "Nombre";

                if (nuevo==false)
                {
                    txtCodigo.Enabled = false;
                    txtDetalle.Text = producto.Detalle;
                    cboMarca.SelectedValue = producto.Marca.Id;
                    if (producto.Tipo==1)
                    {
                        rbtNoteBook.Checked= true;
                    }
                    else
                    {
                        rbtNetBook.Checked = true;
                    }
                    txtPrecio.Text = producto.Precio.ToString();
                    dtpFecha.Text = producto.Fecha.ToString();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }
        private bool soloNumeros(string cadena)
        {
            foreach (char caracter in cadena)
            {
                if (!(char.IsNumber(caracter)))
                {
                    return false;
                }
            }
            return true;
        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            ProductoNegocio negocio = new ProductoNegocio();
            try
            {
                if (nuevo == true)
                    producto = new Producto();
                producto.Detalle=txtDetalle.Text;
                producto.Marca = (Marca)cboMarca.SelectedItem;
                if (rbtNoteBook.Checked == true)
                {
                    producto.Tipo=1;
                }
                else
                {
                    producto.Tipo = 2;
                }
                if (!(soloNumeros(txtPrecio.Text)))
                {

                    MessageBox.Show("Solo Numeros En El Campo Precio Por Favor");
                    return;

                }
                else
                {
                    producto.Precio = Convert.ToDouble(txtPrecio.Text);
                }
                
                producto.Fecha = dtpFecha.Value;

                if (nuevo==false)
                {
                    negocio.modificar(producto);
                    MessageBox.Show("Modificado Exitosamente");
                }
                else
                {
                    
                   producto.Codigo = Convert.ToInt32(txtCodigo.Text);
                   negocio.agregar(producto);
                   MessageBox.Show("Agregado Exitosamente");
                    
                }

                Close();


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();    
        }

     
    }
}
