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
    public partial class complainant : Form
    {
        public complainant()
        {
            InitializeComponent();
        }
        private int id = 1;

        private void btn_save_Click(object sender, EventArgs e)
        {
            DateTime date = dtp_date.Value;

            // Check if all required fields are filled
            if (string.IsNullOrWhiteSpace(txt_name.Text) || string.IsNullOrWhiteSpace(txt_last.Text) || string.IsNullOrWhiteSpace(txt_age.Text) || string.IsNullOrWhiteSpace(cb_gender.Text) || string.IsNullOrWhiteSpace(txt_address.Text) || string.IsNullOrWhiteSpace(txtFname.Text) || string.IsNullOrWhiteSpace(txtLname.Text) || string.IsNullOrWhiteSpace(txtAge.Text) || string.IsNullOrWhiteSpace(cbGender.Text) || string.IsNullOrWhiteSpace(cbScrime.Text) || string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Please fill in all the required fields.", "Incomplete Form", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string query = "INSERT INTO blotterreport(blotterid,complainant_firstname, complainant_middlename, complainant_lastname, complainant_age, complainant_gender, complainant_address, suspect_firstname, suspect_middlename, suspect_lastname, suspect_age, suspect_gender,suspect_crime, suspect_address, date) VALUES (" +
                    "'" + lblABlotterid.Text + "'," +
                    "'" + txt_name.Text + "'," +
                    "'" + txt_middle.Text + "'," +
                    "'" + txt_last.Text + "'," +
                    "'" + txt_age.Text + "'," +
                    "'" + cb_gender.Text + "'," +
                    "'" + txt_address.Text + "'," +
                    "'" + txtFname.Text + "'," +
                    "'" + txtMname.Text + "'," +
                    "'" + txtLname.Text + "'," +
                    "'" + txtAge.Text + "'," +
                    "'" + cbGender.Text + "'," +
                    "'" + cbScrime.Text + "'," +
                    "'" + txtAddress.Text + "'," +
                    "'" + date.ToString("yyyy-MM-dd") + "');";

                MySqlConnection connect = new MySqlConnection(connection.ConnectionString);
                MySqlCommand command = new MySqlCommand(query, connect);
                command.CommandTimeout = 60;

                try
                {
                    connect.Open();

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Successfully Saved");

                        // Clear the form fields
                        txt_name.Clear();
                        txt_middle.Clear();
                        txt_last.Clear();
                        txt_age.Clear();
                        cb_gender.ResetText();
                        txt_address.Clear();
                        txtFname.Clear();
                        txtMname.Clear();
                        txtLname.Clear();
                        txtAge.Clear();
                        cbGender.ResetText();
                        cbScrime.ResetText();
                        txtAddress.Clear();

                        // Increment the ID
                        id++;
                        lblABlotterid.Text = id.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Failed to save data");
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

        private void hOMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HOME db = new HOME();
            this.Hide();
            db.Show();
        }

        private void complainant_Load(object sender, EventArgs e)
        {


            if (connection.check == true)
            {
                connection.check = false;


                string query = "SELECT * FROM blotterreport WHERE blotterid = '" + connection.IdContent + "'";

                using (MySqlConnection connect = new MySqlConnection(connection.ConnectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(query, connect))
                    {
                        command.CommandTimeout = 60;

                        try
                        {
                            connect.Open();

                            using (MySqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {


                                        txt_name.Text = reader.GetString(1);
                                        txt_middle.Text = reader.GetString(2);
                                        txt_last.Text = reader.GetString(3);
                                        txt_age.Text = reader.GetString(4);
                                        cb_gender.Text = reader.GetString(5);
                                        txt_address.Text = reader.GetString(6);
                                        txtFname.Text = reader.GetString(7);
                                        txtMname.Text = reader.GetString(8);
                                        txtLname.Text = reader.GetString(9);
                                        txt_age.Text = reader.GetString(10);
                                        cbGender.Text = reader.GetString(11);
                                        txtAddress.Text = reader.GetString(12);


                                    }
                                }
                            }
                        }
                        catch (Exception x)
                        {
                            MessageBox.Show("Query error: " + x.Message);
                        }
                    }
                }

            }
            else
            {

                string query = "SELECT count(*) from blotterreport";
                MySqlConnection connect = new MySqlConnection(connection.ConnectionString);
                MySqlCommand command = new MySqlCommand(query, connect);

                connect.Open();
                long rowCount = (long)command.ExecuteScalar();
                connect.Close();
                if (rowCount == 0)
                {
                    lblABlotterid.Text = id.ToString();
                }
                else
                {
                    string query2 = "SELECT  blotterid FROM blotterreport ORDER BY  blotterid DESC LIMIT 1";
                    MySqlConnection connect2 = new MySqlConnection(connection.ConnectionString);
                    MySqlCommand command2 = new MySqlCommand(query2, connect2);
                    connect2.Open();
                    id = (int)command2.ExecuteScalar();
                    id += 1;
                    lblABlotterid.Text = id.ToString();
                    connect2.Close();
                }
            }
        }

        private void txt_age_KeyPress(object sender, KeyPressEventArgs e)
        {
            char num = e.KeyChar;
            if (!char.IsDigit(num) && num != 8 && num != 46)
            {
                e.Handled = true;
            }
        }

        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            {
                char num = e.KeyChar;
                if (!char.IsDigit(num) && num != 8 && num != 46)
                {
                    e.Handled = true;
                }
            }

        }
    }

  }


