using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Entidades;
using CapaDeNegocios;

namespace Pasteleria
{
    public partial class frmMap : Form
    {

        GMarkerGoogle marker;
        GMapOverlay markerOverlay;
        DataTable dtPedidosRecientes;

        int filaSeleccionada = 0;
        double lat = -17.7839971735485;
        double lng = -63.180570602417;
        public Cliente cliente = new Cliente();
        private PedidoCN cnPed = new PedidoCN();

        public frmMap()
        {
            InitializeComponent();
        }

        private void frmMap_Load(object sender, EventArgs e)
        {
           
        }

        private void Seleccionar(object sender, DataGridViewCellMouseEventArgs e)
        {
            filaSeleccionada = e.RowIndex;
            //Recuperamos los datos del grid y los asignamos 
            txtDescripcion.Text = dgMarcadores.Rows[filaSeleccionada].Cells[0].Value.ToString();
            txtLat.Text = dgMarcadores.Rows[filaSeleccionada].Cells[1].Value.ToString();
            txtLng.Text = dgMarcadores.Rows[filaSeleccionada].Cells[2].Value.ToString();
            //Se asignan los valores del grid al marcador
            marker.Position = new PointLatLng(Convert.ToDouble(txtLat.Text), Convert.ToDouble(txtLng.Text));
            // se posiciona el foco del mapa en ese punto
            gMap1.Position = marker.Position;
        }

        private void gMap1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void gMap1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            //se obtiene los datos de lat y lng del mapa donde usuario presiono 
            double lat = gMap1.FromLocalToLatLng(e.X, e.Y).Lat;
            double lng = gMap1.FromLocalToLatLng(e.X, e.Y).Lng;

            //Se posicionan en el txt de la latirud y longitud 
            txtLat.Text = lat.ToString();
            txtLng.Text = lng.ToString();
            //Creamos el marcador para moverlo al lugar indicado 
            marker.Position = new PointLatLng(lat, lng);
            //tambien se agrega el mensaje al marcador (tooltip)
            marker.ToolTipText = string.Format("Ubicacion: \n Latitud: {0} \n Longitud:{1}", lat, lng);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
            this.DialogResult = DialogResult.Cancel;
        }
        public DataTable DatosMap()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Descripcion", typeof(string)));
            dt.Columns.Add(new DataColumn("Lat", typeof(double)));
            dt.Columns.Add(new DataColumn("Lng", typeof(double)));
            if (!string.IsNullOrEmpty(txtLat.Text))
                dt.Rows.Add(txtDescripcion.Text, Convert.ToDouble(txtLat.Text), Convert.ToDouble(txtLng.Text));

            return dt;
        }

        private void dgMarcadores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
