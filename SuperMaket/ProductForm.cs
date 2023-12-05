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
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
        }
        SqlConnection conx = new SqlConnection(@"Data Source=FRWIN10;Initial Catalog=Supermarket;Integrated Security=True");

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            CategoryForm cat = new CategoryForm();
            cat.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                conx.Open();
                string qurey = "insert into ProductTable values(" + ProdId.Text + ",'" + ProdName.Text + "','" + ProdQty.Text + "','" + ProdPrice.Text + "','" + Catcb.Text + "')";

                SqlCommand com = new SqlCommand(qurey, conx);
                com.ExecuteNonQuery();
                MessageBox.Show("Items have been added Successfully");
                conx.Close();
                afficher();
                ProdId.Text = "";
                ProdName.Text = "";
                ProdQty.Text = "";
                Catcb.Text = "";
                ProdPrice.Text = "";
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        private void afficher()
        {

            conx.Open();

            string qurey = "select * from ProductTable";
            SqlDataAdapter sda = new SqlDataAdapter(qurey, conx);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);

            var data = new DataSet();
            sda.Fill(data);
            ProdView.DataSource = data.Tables[0];
            conx.Close();
            ProdId.Text = "";
            ProdName.Text = "";
            ProdQty.Text = "";
            Catcb.Text = "";
            ProdPrice.Text = "";



        }

        void fillcombox()
        {

            conx.Open();
            SqlCommand cmd = new SqlCommand("select CatName from CategoryTable", conx);

            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CatName", typeof(string));
            dt.Load(sdr);
            Catcb.ValueMember = "CatName";
            Catcb.DataSource = dt;
            conx.Close();


        }
        void fillcombox2()
        {

            conx.Open();
            SqlCommand cmd = new SqlCommand("select CatName from CategoryTable", conx);

            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CatName", typeof(string));
            dt.Load(sdr);
            SearchCat.ValueMember = "CatName";
            SearchCat.DataSource = dt;
            conx.Close();


        }



        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                if (ProdId.Text == "")
                {
                    MessageBox.Show("please select the Seller to Delete");

                }
                else
                {
                    conx.Open();

                    string Q = "DELETE FROM ProductTable WHERE SelId=" + ProdId.Text + "";
                    SqlCommand com = new SqlCommand(Q, conx);
                    com.ExecuteNonQuery();
                    MessageBox.Show("categorey Deleted Successfully ");
                    conx.Close();
                    afficher();
                    ProdId.Text = "";
                    ProdName.Text = "";
                    ProdQty.Text = "";
                    Catcb.Text = "";
                    ProdPrice.Text = "";

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
                if (ProdId.Text == "" || ProdName.Text == "" || ProdQty.Text == ""|| ProdPrice.Text == "")
                {
                    MessageBox.Show("please one of the option is missing ");
                }
                else
                {
                    conx.Open();
                    string query = "update ProductTable set ProdName='" + ProdName.Text + "',ProdQty='" + ProdQty.Text + "',ProdPrice='" + ProdPrice.Text + "',ProdCat='" + Catcb.Text + "'where ProdId=" + ProdId.Text + ";";

                    SqlCommand com1 = new SqlCommand(query, conx);
                    com1.ExecuteNonQuery();
                    MessageBox.Show("categorey updated Successfully ");
                    conx.Close();
                    afficher();
                    ProdId.Text = "";
                    ProdName.Text = "";
                    ProdQty.Text = "";
                    Catcb.Text = "";
                    ProdPrice.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            afficher();
            fillcombox();
            fillcombox2();
        }

        private void ProdView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ProdId.Text = ProdView.SelectedRows[0].Cells[0].Value.ToString();
            ProdName.Text = ProdView.SelectedRows[0].Cells[1].Value.ToString();
            ProdQty.Text = ProdView.SelectedRows[0].Cells[2].Value.ToString();
            ProdPrice.Text = ProdView.SelectedRows[0].Cells[3].Value.ToString();
            Catcb.Text = ProdView.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SellerForm sel = new SellerForm();
            sel.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SellingForm sel = new SellingForm();
            sel.Show();
            this.Hide();
        }

        private void Catcb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string qurey = "SELECT * FROM ProductTable WHERE ProdCat='" + SearchCat.SelectedValue.ToString() + "'";
            SqlCommand cmd = new SqlCommand(qurey,conx);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ProdView.DataSource = dt;

        }

        private void button12_Click(object sender, EventArgs e)
        {
            afficher();
        }
    }
}
