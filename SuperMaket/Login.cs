using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SuperMaket
{
    public partial class Login : Form
    {
        
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection conx = new SqlConnection(@"Data Source=FRWIN10;Initial Catalog=Supermarket;Integrated Security=True");
        public static string sellerName;
        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (Role.SelectedItem.ToString()=="Admin") {

                if (Username.Text == "" || Pass.Text == "")
                {

                    MessageBox.Show("Enter your username or password");
                }
                else
                {
                    if (Role.SelectedItem.ToString() == "Admin")
                    {
                        if (Username.Text == "Admin" && Pass.Text == "Admin123")
                        {
                            MessageBox.Show("Login Succsessfuly ");
                            ProductForm prd = new ProductForm();
                            prd.Show();
                            this.Hide();

                        }
                        else
                        {
                            MessageBox.Show("username or password incorrect ");
                        }
                    }
                    else if (Role.SelectedItem.ToString() == "User")
                    {
                        MessageBox.Show("your a user");

                    }
                    else
                    {
                        MessageBox.Show("select Role");
                    }


                }

            }
           else
            {
                string qurey = "SELECT * FROM SellerTable WHERE SelName='" + Username.Text + "' AND SelPassword='" + Pass.Text + "'";
                DataTable table = new DataTable();
                SqlDataAdapter data = new SqlDataAdapter(qurey, conx);
                data.Fill(table);
                if (table.Rows.Count > 0)
                {
                    MessageBox.Show("Login Succsessfuly ");
                    sellerName = Username.Text;
                    SellingForm sell = new SellingForm();
                    sell.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Username or password inncorect y zabi foucs ");
                }

            }



        }

       
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2HtmlLabel7_MouseEnter(object sender, EventArgs e)
        {
            Label7.ForeColor = Color.White;
        }

        private void Label7_MouseLeave(object sender, EventArgs e)
        {
            Label7.ForeColor = Color.DarkCyan;
        }

        private void guna2HtmlLabel1_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_MouseEnter(object sender, EventArgs e)
        {
            guna2HtmlLabel1.ForeColor = Color.White;
        }

        private void guna2HtmlLabel1_MouseLeave(object sender, EventArgs e)
        {
            guna2HtmlLabel1.ForeColor = Color.DarkCyan;
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
