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

namespace POSDemo.Screens.Products
{
    public partial class ProductClass : Form
    {
        SuiEntities1 db = new SuiEntities1 ();
        string imagePath = "";

        public ProductClass()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(txtName.Text =="" || txtBarcode.Text == "" || txtPrice.Text == "" || txtQty.Text == "")
            {
                MessageBox.Show("بالرجاء إكمال البيانات المطلوبة اولا");
            }
            else
            {
                Product product = new Product();
                product.Name = txtName.Text;
                product.Code = txtBarcode.Text;
                product.Notes = txtNotes.Text;
                
                int qty, price;

                //int.TryParse(txtQty.Text, out qty);
                //int.TryParse(txtPrice.Text, out price);
                //product.Price = price;
                //product.Quantity = qty;

                bool CanSave = true;

                if (int.TryParse(txtPrice.Text, out price))
                {
                    product.Price = price;
                }
                else
                {
                    MessageBox.Show("بالرجاء إدخال السعر بطريقة صحيحة");
                    CanSave = false;
                    
                }

                if (int.TryParse(txtQty.Text, out qty))
                {
                    product.Quantity = qty;
                }
                else
                {
                    MessageBox.Show("بالرجاء إدخال الكمية بطريقة صحيحة");
                    CanSave = false;
                }

                if (CanSave)
                {
                    db.Products.Add(product);
                    db.SaveChanges();

                    if (imagePath != "")
                    {
                        string newpath = Environment.CurrentDirectory + "\\Images\\Products\\" + product.id + ".jpg";
                        File.Copy(imagePath, newpath);

                        product.Image = newpath;
                        db.SaveChanges();
                    }
                    MessageBox.Show("تم حفظ المنتج");
                }
            }



        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog(); //Open to choose pic
            if (dialog.ShowDialog() == DialogResult.OK)  // if chosen
            {
                imagePath = dialog.FileName;
                pictureBox1.ImageLocation = dialog.FileName;
            }
        }

    }
}
