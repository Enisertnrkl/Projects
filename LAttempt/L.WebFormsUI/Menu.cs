using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using L.Business.Abstract;
using L.Business.Concrete;
using L.DataAccess.Concrete.EntityFramework;
using L.Entities.Concrete;

namespace L.WebFormsUI
{
    public partial class Menu : Form
    {
        IProductService _productService;
        public Menu()
        {
            InitializeComponent();
            _productService = new ProductManager(new EfProductDal());
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                if (!(decimal.Parse(tbPrice.Text) <= 0))
                {
                    try
                    {
                        var product = new Product
                            { ProductName = tbName.Text, ProductPrice = decimal.Parse(tbPrice.Text) };
                        _productService.Add(product);
                        MessageBox.Show("Product added!");
                        LoadProducts();

                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show($"Something went wrong.{exception.Message}");
                    }
                }
                else
                {
                    MessageBox.Show("Price cannot be lower than 1.");
                }
            }
            else
            {
                MessageBox.Show("Cannot leave empty.");
            }
        }

        bool ValidateInputs()
        {
            return !string.IsNullOrEmpty(tbName.Text) && !string.IsNullOrEmpty(tbPrice.Text);
        }

        private void LoadProducts()
        {
            dataGridView1.DataSource = _productService.GetAll();
        }

    }
}
