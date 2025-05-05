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
    public partial class AvionModelos : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["IssdTP42023ConnectionString"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGrid();
            }
        }

        void CargarGrid()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM AvionModelos", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvModelos.DataSource = dt;
                gvModelos.DataBind();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO AvionModelos (detalle) VALUES (@detalle); SELECT SCOPE_IDENTITY();", conn);
                cmd.Parameters.AddWithValue("@detalle", txtDetalle.Text);
                int nuevoId = Convert.ToInt32(cmd.ExecuteScalar());

                RegistrarOperacion("AvionModelo INSERT");

                CargarGrid();
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE AvionModelos SET detalle=@detalle WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("@detalle", txtDetalle.Text);
                cmd.Parameters.AddWithValue("@id", txtId.Text);
                cmd.ExecuteNonQuery();

                RegistrarOperacion("AvionModelo DELETE");

                CargarGrid();
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM AvionModelos WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("@id", txtId.Text);
                cmd.ExecuteNonQuery();

                RegistrarOperacion("AvionModelo Delete");
                CargarGrid();
            }
        }

        protected void gvModelos_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvModelos.SelectedRow;
            txtId.Text = row.Cells[1].Text;
            txtDetalle.Text = row.Cells[2].Text;
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