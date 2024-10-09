using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace Parcial_1_Kremis_Alexis
{
    public partial class App : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlDataSource1.SelectCommand = "SELECT * FROM [Empleados]";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string nombreSector = TextBox1.Text;

            if (!string.IsNullOrEmpty(nombreSector))
            {
                int idSector = ObtenerIdSector(nombreSector);

                if (idSector > 0)
                {
                    Response.Write("<script>alert('ID Sector: " + idSector + "');</script>");
                    SqlDataSource1.SelectCommand = "SELECT * FROM [Empleados] WHERE [id_sector] = @id_sector";
                    SqlDataSource1.SelectParameters.Clear();
                    SqlDataSource1.SelectParameters.Add("id_sector", idSector.ToString());
                }
                else
                {
                    Response.Write("<script>alert('Sector no encontrado');</script>");
                    SqlDataSource1.SelectCommand = "SELECT * FROM [Empleados]";
                }
            }
            else
            {
                SqlDataSource1.SelectCommand = "SELECT * FROM [Empleados]";
            }

            GridView1.DataBind();
        }

        private int ObtenerIdSector(string nombreSector)
        {
            int idSector = -1;
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["IssdTP42023ConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT id FROM EmpleadoSectores WHERE nombre = @nombreSector";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nombreSector", nombreSector);

                try
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        idSector = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
                }
            }

            return idSector;
        }
    }
}
