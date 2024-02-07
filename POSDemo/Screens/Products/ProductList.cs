using POSDemo.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace POSDemo.Screens.Products
{
    public partial class ProductList : Form
    {
        SuiEntities1 db = new SuiEntities1();
        string imagePath = "";

        public ProductList()
        {
            InitializeComponent();

            //dataGridView1.DataSource = db.Products.ToList();

        }

        private void ProductList_Load(object sender, EventArgs e)
        {
            this.productTableAdapter.Fill(this.suiDataSet.Product);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                dataGridView1.DataSource = db.Products.Where(x => x.Code == txtBarcode.Text).ToList();
            }
            else
            {
                dataGridView1.DataSource = db.Products.Where(x => x.Code == txtBarcode.Text || x.Name.Contains(txtName.Text)).ToList();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Products.ToList();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            var id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());

            var result = db.Products.SingleOrDefault(x => x.id == id);

            txtFormName.Text = result.Name;
            txtFormBarcode.Text = result.Code;
            txtNotes.Text = result.Notes;
            txtPrice.Text = result.Price.ToString();
            txtQty.Text = result.Quantity.ToString();
            pictureBox1.ImageLocation = result.Image;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (IsDataChanged())
            {
                SaveChangesToDatabase();
            }
            else
            {
                MessageBox.Show("No changes to save.");
            }
        }

        private bool IsDataChanged()
        {
            var id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var result = db.Products.SingleOrDefault(x => x.id == id);

            return result != null &&
                   (result.Name != txtName.Text ||
                    result.Code != txtBarcode.Text ||
                    result.Notes != txtNotes.Text ||
                    result.Price != Convert.ToInt32(txtPrice.Text) ||
                    result.Quantity != Convert.ToInt32(txtQty.Text) ||
                    result.Image != imagePath);
        }

        private void SaveChangesToDatabase()
        {
            var id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var product = db.Products.SingleOrDefault(x => x.id == id);

            if (product != null)
            {
                product.Name = txtFormName.Text;
                product.Code = txtFormBarcode.Text;
                product.Notes = txtNotes.Text;
                product.Price = Convert.ToInt32(txtPrice.Text);
                product.Quantity = Convert.ToInt32(txtQty.Text);

                db.SaveChanges();

                if (imagePath != "")
                {
                    string newpath = Environment.CurrentDirectory + "\\Images\\Products\\" + product.id + ".jpg";
                    File.Copy(imagePath, newpath, true);

                    product.Image = newpath;
                    db.SaveChanges();
                }

                MessageBox.Show("تم الحفظ بنجاح");
                dataGridView1.DataSource = db.Products.ToList();
            }
        }

    }
}
