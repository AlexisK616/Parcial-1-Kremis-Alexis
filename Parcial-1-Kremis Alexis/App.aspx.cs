using System;
using System.Data.SqlClient;
using System.IO; // Asegúrate de incluir esto para manejar archivos
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
                    Log($"ID Sector encontrado: {idSector}");
                    SqlDataSource1.SelectCommand = "SELECT * FROM [Empleados] WHERE [id_sector] = @id_sector";
                    SqlDataSource1.SelectParameters.Clear();
                    SqlDataSource1.SelectParameters.Add("id_sector", idSector.ToString());
                }
                else
                {
                    Log($"Sector no encontrado: {nombreSector}");
                    SqlDataSource1.SelectCommand = "SELECT * FROM [Empleados]";
                }
            }
            else
            {
                Log("Se solicitó una búsqueda sin nombre de sector.");
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
                        Log($"ID Sector obtenido: {idSector} para el nombre de sector: {nombreSector}");
                    }
                }
                catch (Exception ex)
                {
                    Log($"Error al obtener el ID del sector: {ex.Message}");
                }
            }

            return idSector;
        }

        private void Log(string message)
        {
            string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs.txt"); 
            using (StreamWriter writer = new StreamWriter(logFilePath, true)) 
            {
                writer.WriteLine($"{DateTime.Now}: {message}");
            }
        }
    }
}
