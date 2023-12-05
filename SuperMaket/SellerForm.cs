using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperMaket
{
    public partial class SellerForm : Form
    {
        public SellerForm()
        {
            InitializeComponent();
        }
        SqlConnection conx = new SqlConnection(@"Data Source=FRWIN10;Initial Catalog=Supermarket;Integrated Security=True");

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CategoryForm cat = new CategoryForm();
            cat.Show();
            this.Hide();
        }

        private void SellerForm_Load(object sender, EventArgs e)
        {
            afficher();
        }

        private void button9_Click(object sender, EventArgs e)
        {

            try
            {
                conx.Open();
                string qurey = "insert into SellerTable values(" + SelId.Text + ",'" + SelName.Text + "','" + SelAge.Text + "','" + SelPhone.Text + "','" + SelPassword.Text + "')";

                SqlCommand com = new SqlCommand(qurey, conx);
                com.ExecuteNonQuery();
                MessageBox.Show("Items have been added Successfully");
                conx.Close();
                afficher();
                SelId.Text = "";
                SelName.Text = "";
                SelAge.Text = "";
                SelPhone.Text = "";
                SelPassword.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
       
        }
        private void afficher()
        {

            conx.Open();

            string qurey = "select * from SellerTable";
            SqlDataAdapter sda = new SqlDataAdapter(qurey, conx);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);

            var data = new DataSet();
            sda.Fill(data);
            SelView.DataSource = data.Tables[0];
            conx.Close();




        }
        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                if (SelId.Text == "")
                {
                    MessageBox.Show("please select the Seller to Delete");

                }
                else
                {
                    conx.Open();

                    string Q = "DELETE FROM SellerTable WHERE SelId=" + SelId.Text + "";
                    SqlCommand com = new SqlCommand(Q, conx);
                    com.ExecuteNonQuery();
                    MessageBox.Show("categorey Deleted Successfully ");
                    conx.Close();
                    afficher();
                    SelId.Text = "";
                    SelName.Text = "";
                    SelAge.Text = "";
                    SelPhone.Text = "";
                    SelPassword.Text = "";

                }
            }


            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                if (SelId.Text == "" || SelName.Text == "" || SelAge.Text == "")
                {
                    MessageBox.Show("please select the category to edit");
                }
                else
                {
                    conx.Open();
                    string query = "update SellerTable set SelName='" + SelName.Text + "',SelAge='" + SelAge.Text + "',SelPhone='" + SelPhone.Text + "',SelPassword='" + SelPassword.Text + "'where SelId=" + SelId.Text + ";";

                    SqlCommand com1 = new SqlCommand(query, conx);
                    com1.ExecuteNonQuery();
                    MessageBox.Show("categorey updated Successfully ");
                    conx.Close();
                    afficher();
                    SelId.Text = "";
                    SelName.Text = "";
                    SelAge.Text = "";
                    SelPhone.Text = "";
                    SelPassword.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SelView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SelId.Text = SelView.SelectedRows[0].Cells[0].Value.ToString();
            SelName.Text = SelView.SelectedRows[0].Cells[1].Value.ToString();
            SelAge.Text = SelView.SelectedRows[0].Cells[2].Value.ToString();
            SelPhone.Text = SelView.SelectedRows[0].Cells[3].Value.ToString();
            SelPassword.Text = SelView.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ProductForm prod = new ProductForm();
            prod.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SellingForm sel = new SellingForm();
            sel.Show();
            this.Hide();
        }
    }
}
