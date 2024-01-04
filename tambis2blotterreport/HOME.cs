using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tambis2blotterreport
{
    public partial class HOME : Form
    {
        public HOME()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            complainantrecord db = new complainantrecord();
            this.Hide();
            db.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            complainant db = new complainant();
            this.Hide();
            db.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            complainant db = new complainant();
            this.Hide();
            db.Show();
        }
    }
    }
    

