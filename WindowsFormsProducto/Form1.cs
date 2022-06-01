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
    public partial class Form1 : Form
    {
        private List<Producto>lProducto=new List<Producto>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargar();
            LblAvisos.Visible = false;

        }

        private void cargar()
        {
            ProductoNegocio productoNegocio = new ProductoNegocio();
            try
            {
                lProducto = productoNegocio.listar();
                dgvProductos.DataSource = lProducto;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos != null)
            {
                Producto seleccionado = (Producto)dgvProductos.CurrentRow.DataBoundItem;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmAltaProducto agregar = new FrmAltaProducto(true);
            agregar.ShowDialog();
            cargar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Producto seleccionado;
            seleccionado = (Producto)dgvProductos.CurrentRow.DataBoundItem;
            FrmAltaProducto modificar=new FrmAltaProducto(seleccionado,false);
            modificar.ShowDialog();
            cargar(); 
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            ProductoNegocio productoNegocio=new ProductoNegocio();
            Producto seleccionado;
            try
            {
                DialogResult respuesta =MessageBox.Show("¿Seguro Que Quiere Borrarlo?","Eliminando",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    seleccionado = (Producto)dgvProductos.CurrentRow.DataBoundItem;
                    productoNegocio.eliminarFisico(seleccionado.Codigo);
                    cargar();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
           DialogResult respuesta= MessageBox.Show("¿Seguro Que Quiere Abandonar La Aplicacion?", "Saliendo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (respuesta == DialogResult.Yes)
            {
                Close();
            }
           

        }

        private void txtFiltroRapido_TextChanged(object sender, EventArgs e)
        {
            List<Producto> listaFiltrada;
            string filtro=txtFiltroRapido.Text;

            if(filtro.Length>=2)
            {
                listaFiltrada = lProducto.FindAll(x => x.Detalle.ToUpper().Contains(filtro.ToUpper()) || x.Marca.Nombre.ToUpper().Contains(filtro.ToUpper()));
            }
            else
            {
                listaFiltrada = lProducto;
            }
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = listaFiltrada;

        }

        private void txtFiltroRapido_Click(object sender, EventArgs e)
        {
            LblAvisos.Visible = true;
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            LblAvisos.Visible=false;
        }
    }
}
