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
    public partial class CategoryForm : Form
    {
        public CategoryForm()
        {
            InitializeComponent();
        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        SqlConnection conx = new SqlConnection(@"Data Source=FRWIN10;Initial Catalog=Supermarket;Integrated Security=True");
        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                conx.Open();
                string Query = "insert into CategoryTable Values("+ CatIDTb.Text + ",'" + CatNameTb.Text + "','" + CatDescTb.Text + "')";
                SqlCommand com = new SqlCommand(Query, conx);
                com.ExecuteNonQuery();
                MessageBox.Show("categorey Added Successfully ");
                conx.Close();
                Pup();
                CatIDTb.Text = "";
                CatNameTb.Text = "";
                CatDescTb.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Pup()
        {

            conx.Open();

            string qurey = "select * from CategoryTable";
            SqlDataAdapter sda = new SqlDataAdapter(qurey, conx);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);

            var data = new DataSet();
            sda.Fill(data);
            CateView.DataSource = data.Tables[0];
            conx.Close();




        }


        private void CategoryForm_Load(object sender, EventArgs e)
        {
            Pup();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                if (CatIDTb.Text == ""|| CatNameTb.Text ==""|| CatDescTb.Text=="")
                {
                    MessageBox.Show("please select the category to edit");
                }
                else
                {
                    conx.Open();
                    string query = "update CategoryTable set CatName='" + CatNameTb.Text + "',CatDesc='" + CatDescTb.Text + "'where CatID=" + CatIDTb.Text + ";";

                    SqlCommand com1 = new SqlCommand(query, conx);
                    com1.ExecuteNonQuery();
                    MessageBox.Show("categorey updated Successfully ");
                    conx.Close();
                    Pup();
                    CatIDTb.Text = "";
                    CatNameTb.Text = "";
                    CatDescTb.Text = "";
                   
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CateView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CatIDTb.Text = CateView.SelectedRows[0].Cells[0].Value.ToString();
            CatNameTb.Text = CateView.SelectedRows[0].Cells[1].Value.ToString();
            CatDescTb.Text = CateView.SelectedRows[0].Cells[2].Value.ToString();
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                if (CatIDTb.Text == "")
                {
                    MessageBox.Show("please select the category to Delete");

                }
                else {
                    conx.Open();

                    string Q = "DELETE FROM CategoryTable WHERE CatId="+CatIDTb.Text +"";
                    SqlCommand com = new SqlCommand(Q, conx);
                    com.ExecuteNonQuery();
                    MessageBox.Show("categorey Deleted Successfully ");
                    conx.Close();
                    Pup();
                    CatIDTb.Text = "";
                    CatNameTb.Text = "";
                    CatDescTb.Text = "";

                }
            }


            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ProductForm prod = new ProductForm();
            prod.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SellerForm sle = new SellerForm();
            sle.Show();
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
