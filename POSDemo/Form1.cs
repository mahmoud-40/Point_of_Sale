using POSDemo.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSDemo
{
    public partial class Form1 : Form
    {
        SuiEntities1 db = new SuiEntities1 ();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var res = db.Users.Where(x => x.UserName == txtUser.Text && x.Password==txtPassword.Text);
            //MessageBox.Show(res.Count().ToString());

            if(res.Count() > 0 )
            {
                this.Close();
                Thread th = new Thread(openform);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
            else
            {
                MessageBox.Show("Username or Password are invalid");
            }
            

        }
        void openform()
        {
            Application.Run(new MainForm());
        }
    }
}
