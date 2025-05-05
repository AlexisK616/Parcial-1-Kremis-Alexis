using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;

namespace Parcial_1_Kremis_Alexis
{
    public partial class Aerolineas : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["IssdTP42023ConnectionString"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarGrid();
        }

        void CargarGrid()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Aerolineas", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvAerolineas.DataSource = dt;
                gvAerolineas.DataBind();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Aerolineas (nombre) VALUES (@nombre); SELECT SCOPE_IDENTITY();", conn);
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                int nuevoId = Convert.ToInt32(cmd.ExecuteScalar());

                RegistrarOperacion("Aerolíneas INSERT");
                CargarGrid();
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Aerolineas SET nombre=@nombre WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@id", txtId.Text);
                cmd.ExecuteNonQuery();

                RegistrarOperacion("Aerolíneas UPDATE");
                CargarGrid();
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Aerolineas WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("@id", txtId.Text);
                cmd.ExecuteNonQuery();

                RegistrarOperacion("Aerolíneas DELETE");
                CargarGrid();
            }
        }

        void RegistrarOperacion(string mensaje)
        {
            string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs.txt");
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {mensaje}");
            }
        }
    }
}