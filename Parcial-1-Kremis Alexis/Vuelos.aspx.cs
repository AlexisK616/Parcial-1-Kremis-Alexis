using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Parcial_1_Kremis_Alexis
{
    public partial class Vuelos : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["IssdTP42023ConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDropdowns();
                CargarGrid();
            }
        }

        void CargarDropdowns()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                // Aerolíneas
                SqlDataAdapter daAerolineas = new SqlDataAdapter("SELECT id, nombre FROM Aerolineas", conn);
                DataTable dtAerolineas = new DataTable();
                daAerolineas.Fill(dtAerolineas);
                ddlAerolinea.DataSource = dtAerolineas;
                ddlAerolinea.DataTextField = "nombre";
                ddlAerolinea.DataValueField = "id";
                ddlAerolinea.DataBind();

                // Modelos
                SqlDataAdapter daModelos = new SqlDataAdapter("SELECT id, detalle FROM AvionModelos", conn);
                DataTable dtModelos = new DataTable();
                daModelos.Fill(dtModelos);
                ddlModelo.DataSource = dtModelos;
                ddlModelo.DataTextField = "detalle";
                ddlModelo.DataValueField = "id";
                ddlModelo.DataBind();
            }
        }

        void CargarGrid()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter(@"
                SELECT V.id, V.numeroVuelo, A.nombre AS Aerolinea, M.detalle AS ModeloAvion
                FROM Vuelos V
                JOIN Aerolineas A ON V.idAerolinea = A.id
                JOIN AvionModelos M ON V.idAvionModelo = M.id", conn);

                DataTable dt = new DataTable();
                da.Fill(dt);
                gvVuelos.DataSource = dt;
                gvVuelos.DataBind();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Vuelos (numeroVuelo, idAerolinea, idAvionModelo) VALUES (@numero, @aero, @modelo); SELECT SCOPE_IDENTITY();", conn);
                cmd.Parameters.AddWithValue("@numero", txtNumeroVuelo.Text);
                cmd.Parameters.AddWithValue("@aero", ddlAerolinea.SelectedValue);
                cmd.Parameters.AddWithValue("@modelo", ddlModelo.SelectedValue);
                int nuevoId = Convert.ToInt32(cmd.ExecuteScalar());

                RegistrarOperacion("Vuelos insert");
                CargarGrid();
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Vuelos SET numeroVuelo=@numero, idAerolinea=@aero, idAvionModelo=@modelo WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("@numero", txtNumeroVuelo.Text);
                cmd.Parameters.AddWithValue("@aero", ddlAerolinea.SelectedValue);
                cmd.Parameters.AddWithValue("@modelo", ddlModelo.SelectedValue);
                cmd.Parameters.AddWithValue("@id", txtId.Text);
                cmd.ExecuteNonQuery();
                RegistrarOperacion("Vuelos Update");
                CargarGrid();
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Vuelos WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("@id", txtId.Text);
                cmd.ExecuteNonQuery();

                RegistrarOperacion("Vuelos Delete");
                CargarGrid();
            }
        }

        protected void gvVuelos_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvVuelos.SelectedRow;
            txtId.Text = row.Cells[1].Text;
            txtNumeroVuelo.Text = row.Cells[2].Text;
            ddlAerolinea.SelectedItem.Text = row.Cells[3].Text;
            ddlModelo.SelectedItem.Text = row.Cells[4].Text;
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