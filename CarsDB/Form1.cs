using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarsDB
{
    public partial class Form1 : Form
    {
        string connectionString;
        SqlConnection connection;
        public Form1()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["CarsDB.Properties.Settings.CarsConnectionString"].ConnectionString;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PopulateCarsTable();
        }
        public void PopulateCarsTable()
        {
            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM CarMark", connection))
            {
                DataTable CarTable = new DataTable();
                adapter.Fill(CarTable);

                listCars.DisplayMember = "CarMarkName";
                listCars.ValueMember = "CarModelName";
                listCars.DataSource = CarTable;
            }
        }

        private void listCars_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateCarMarks();
        }

        private void PopulateCarMarks()
        {
            string query = "SELECT Car.Name FROM CarMark INNER JOIN Car ON Car.CarModelName=CarMark.Id WHERE CarMark.Id=@CarModelName";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                command.Parameters.AddWithValue("@CarModelName", listCars.SelectedValue);
                DataTable carMarkTable = new DataTable();
                adapter.Fill(carMarkTable);

                listCarMarks.DisplayMember = "CarMarkId";
                listCarMarks.ValueMember = "CarMarkName";
                listCarMarks.DataSource = carMarkTable;
            }

        }
        private void listCarMarks_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
