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
                Console.WriteLine("Execute consult SQL SUCCESS ");
                SqlDataSource1.SelectCommand = "SELECT * FROM [Empleados]";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TextBox1.Text))
            {
                int idSector = ObtenerIdSector(TextBox1.Text);

                if (idSector > 0)
                {
                    SqlDataSource1.SelectCommand = "SELECT * FROM [Empleados] WHERE [id_sector] = @id_sector";
                    SqlDataSource1.SelectParameters.Clear();
                    SqlDataSource1.SelectParameters.Add("id_sector", idSector.ToString());
                }
                else
                {
                    SqlDataSource1.SelectCommand = "SELECT * FROM [Empleados]";
                }
            }
            else
            {
                SqlDataSource1.SelectCommand = "SELECT * FROM [Empleados]";
            }

            GridView1.DataBind();
            Console.WriteLine("Execute consult SQL SUCCESS ");
        }

        private int ObtenerIdSector(string nombreSector)
        {
            Console.WriteLine("Execute ObtenerIdSector" + ": " + nombreSector);
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
                        Console.WriteLine("Execute SQL SUCCESS " + ": " + result);
                        idSector = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return idSector;
        }
    }
}
