using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using CapaDeNegocios;

namespace Pasteleria
{
    public partial class frmCatalogo : Form
    {

        private Producto producto = new Producto();
        private ProductoCN cnProducto = new ProductoCN();

        public frmCatalogo()
        {
            InitializeComponent();
        }

        private void frmCatalogo_Load(object sender, EventArgs e)
        {
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
           

        }

        private bool Validaciones()
        {
            bool result = true;
            if (producto.nombre == null)
            {
                errorProvider1.SetError(dgProductos , "Seleccione un producto");
                result = false;
            }
            return result;
        }

        private void dgProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            producto.idProducto = Convert.ToInt32(dgProductos.Rows[e.RowIndex].Cells["idProducto"].Value);
            producto.nombre = Convert.ToString(dgProductos.Rows[e.RowIndex].Cells["nombre"].Value);
            producto.precio = Convert.ToDouble(dgProductos.Rows[e.RowIndex].Cells["precio"].Value);
            producto.stock = Convert.ToInt32(dgProductos.Rows[e.RowIndex].Cells["stock"].Value);
            producto.categoria = Convert.ToString(dgProductos.Rows[e.RowIndex].Cells["categoria"].Value);
            producto.tamaño = Convert.ToString(dgProductos.Rows[e.RowIndex].Cells["tamaño"].Value);
            producto.produccion = Convert.ToInt32(dgProductos.Rows[e.RowIndex].Cells["produccion"].Value);
            producto.foto = (byte[])dgProductos.Rows[e.RowIndex].Cells["foto"].Value;
            dgProductos.Rows[e.RowIndex].Cells["check"].Value = true;

            foreach (DataGridViewRow row in dgProductos.Rows)
            {
                if (row != dgProductos.Rows[e.RowIndex])
                {
                    row.Cells["check"].Value = false;
                }
            }
        }


        
    }
}
