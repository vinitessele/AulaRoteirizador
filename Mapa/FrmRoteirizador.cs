using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Mapa
{
    public partial class FrmMapa : Form
    {
        public FrmMapa()
        {
            InitializeComponent();
        }

        private void FrmMapa_Load(object sender, System.EventArgs e)
        {
            CarregarMapa();
            AddMarkerMap(-24.4676731, -53.5589826, "Marque Aqui");
        }

        private void CarregarMapa()
        {
            gMapControl1.MapProvider = BingMapProvider.Instance;
            //gMapControl1.MapProvider = GoogleMapProvider.Instance;
            //get tiles from server only
            gMapControl1.Manager.Mode = AccessMode.ServerOnly;
            //not use proxy
            GMapProvider.WebProxy = null;
            gMapControl1.Position = new PointLatLng(- 24.7106052,-53.7211754);

            //zoom min/max; default both = 2
            gMapControl1.MinZoom = 1;
            gMapControl1.MaxZoom = 100;
            //set zoom
            gMapControl1.Zoom = 13;
        }
        private void AddMarkerMap(double latitude, double longitude, string texto)
        {
            PointLatLng point = new PointLatLng(latitude, longitude);

            GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.lightblue_dot);
            GMapOverlay markers = new GMapOverlay("markers");
            markers.Markers.Add(marker);
            gMapControl1.Overlays.Add(markers);

            marker.ToolTipText = texto;
            marker.ToolTip.Fill = Brushes.Black;
            marker.ToolTip.Foreground = Brushes.White;
            marker.ToolTip.Stroke = Pens.Black;
            marker.ToolTip.TextPadding = new Size(20, 20);
        }
    }
}
