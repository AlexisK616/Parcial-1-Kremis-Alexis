using System;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;

namespace Parcial_1_Kremis_Alexis
{
    public partial class App : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlDataSource1.SelectCommand = "SELECT V.id, V.numeroVuelo, A.nombre AS Aerolinea, M.detalle AS ModeloAvion " +
                                               "FROM Vuelos V " +
                                               "JOIN Aerolineas A ON V.idAerolinea = A.id " +
                                               "JOIN AvionModelos M ON V.idAvionModelo = M.id";
                Log("Select");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string filtro = TextBox1.Text;

            if (!string.IsNullOrEmpty(filtro))
            {
                SqlDataSource1.SelectCommand = "SELECT V.id, V.numeroVuelo, A.nombre AS Aerolinea, M.detalle AS ModeloAvion " +
                                               "FROM Vuelos V " +
                                               "JOIN Aerolineas A ON V.idAerolinea = A.id " +
                                               "JOIN AvionModelos M ON V.idAvionModelo = M.id " +
                                               "WHERE A.nombre LIKE @filtro OR M.detalle LIKE @filtro";
                SqlDataSource1.SelectParameters.Clear();
                SqlDataSource1.SelectParameters.Add("filtro", "%" + filtro + "%");
            }
            else
            {
                SqlDataSource1.SelectCommand = "SELECT V.id, V.numeroVuelo, A.nombre AS Aerolinea, M.detalle AS ModeloAvion " +
                                               "FROM Vuelos V " +
                                               "JOIN Aerolineas A ON V.idAerolinea = A.id " +
                                               "JOIN AvionModelos M ON V.idAvionModelo = M.id";
            }

            GridView1.DataBind();
            Log("Select");
        }

        private void Log(string message)
        {
            string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs.txt");
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now}: {message}");
            }
        }
        protected void btnIrAerolineas_Click(object sender, EventArgs e)
        {
            Response.Redirect("Aerolineas.aspx");
        }

        protected void btnIrModelos_Click(object sender, EventArgs e)
        {
            Response.Redirect("AvionModelos.aspx");
        }

        protected void btnIrVuelos_Click(object sender, EventArgs e)
        {
            Response.Redirect("Vuelos.aspx");
        }

    }
}

