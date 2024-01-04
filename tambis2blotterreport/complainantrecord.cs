using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace tambis2blotterreport
{
    public partial class complainantrecord : Form
    {
        public complainantrecord()
        {
            InitializeComponent();
        }

        private void dgvComplainantrecord_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int selectedrow;
                selectedrow = e.RowIndex;
                DataGridViewRow row = dgvBlotterrecord.Rows[selectedrow];

                connection.IdContent = row.Cells[0].Value.ToString();
                connection.check = true;


            }
            catch (Exception c)
            {
                MessageBox.Show(c.Message);
            }
        
    }

        private void complainantrecord_Load(object sender, EventArgs e)
        {
            dgvBlotterrecord.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(dgvBlotterrecord.Font, System.Drawing.FontStyle.Bold);
            string[] columnNames = new string[] {"blotterid","complainant_firstname"," complainant_middlename","complainant_lastname", "complainant_age","complainant_gender"," complainant_address"," suspect_firstname"," suspect_middlename", "suspect_lastname", "suspect_age", "suspect_gender","suspect_crime", "suspect_address", "date" };

           dgvBlotterrecord.ColumnCount = 15;

            for (int a = 0; a < columnNames.Length; a++)
            {
                dgvBlotterrecord.Columns[a].HeaderText = columnNames[a];
            }

            string query = "SELECT * FROM blotterreport";
            MySqlConnection connect = new MySqlConnection(connection.ConnectionString);
            MySqlCommand command = new MySqlCommand(query, connect);
            command.CommandTimeout = 60;

            try
            {
                connect.Open();

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dgvBlotterrecord.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetString(9), reader.GetString(10), reader.GetString(11), reader.GetString(12), reader.GetString(13), reader.GetString(14));
                    }
                }

            }
            catch (Exception x)
            {
                MessageBox.Show("Query error: " + x.Message);
            }

        }

        private void hOMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HOME db = new HOME();
            this.Hide();
            db.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgvBlotterrecord.Rows.Clear();

            dgvBlotterrecord.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(dgvBlotterrecord.Font, System.Drawing.FontStyle.Bold);
            string[] columnNames = new string[] { "blotterid", "complainant_firstname", "complainant_middlename", "complainant_lastname", "complainant_age", "complainant_gender", "complainant_address", "suspect_firstname", "suspect_middlename", "suspect_lastname", "suspect_age", "suspect_gender", "suspect_crime", "suspect_address", "date" };

            dgvBlotterrecord.ColumnCount = 15;
            string query = "";

            for (int a = 0; a < columnNames.Length; a++)
            {
                dgvBlotterrecord.Columns[a].Name = columnNames[a];
            }

            if (int.TryParse(txtSearch.Text, out _))
            {
                // Corrected the query for numerical fields
                query = "SELECT * FROM blotterreport WHERE blotterId = " + txtSearch.Text +  " OR complainant_age = " + txtSearch.Text + ";";
            }
            else if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                // Corrected the query for string fields
                query = "SELECT * FROM blotterreport WHERE complainant_firstname = '" + txtSearch.Text + "' OR complainant_middlename = '" + txtSearch.Text +
                    "' OR complainant_lastname = '" + txtSearch.Text + "' OR complainant_gender = '" + txtSearch.Text + "' OR complainant_gender = '" + txtSearch.Text + "';";
            }

            MySqlConnection connect = new MySqlConnection(connection.ConnectionString);
            MySqlCommand command = new MySqlCommand(query, connect);
            command.CommandTimeout = 60;

            try
            {
                connect.Open();

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dgvBlotterrecord.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetString(9), reader.GetString(10), reader.GetString(11), reader.GetString(12), reader.GetString(13), reader.GetDateTime(14).ToString("yyyy-MM-dd"));
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("Query error: " + x.Message);
            }
            finally
            {
                connect.Close();
            }

        }
    }
}
