using POSDemo.Screens.Products;
using POSDemo.Screens.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSDemo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewUser u = new NewUser();
            u.Show();
        }

        private void العملاءToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductClass p = new ProductClass();
            p.Show();
        }

        private void listProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductList productList = new ProductList();
            productList.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProductList productList = new ProductList();
            productList.Show();
        }
    }
}
