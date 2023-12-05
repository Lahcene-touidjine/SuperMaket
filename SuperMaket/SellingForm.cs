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
using DGVPrinterHelper;

namespace SuperMaket
{
    public partial class SellingForm : Form
    {
        public SellingForm()
        {
            InitializeComponent();
        }
        SqlConnection conx = new SqlConnection(@"Data Source=FRWIN10;Initial Catalog=Supermarket;Integrated Security=True");
        DGVPrinter printer = new DGVPrinter();
        private void afficher()
        {

            conx.Open();

            string qurey = "select ProdName,ProdPric  from ProductTable";
            SqlDataAdapter sda = new SqlDataAdapter(qurey, conx);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);

            var data = new DataSet();
            sda.Fill(data);
            ProdView1.DataSource = data.Tables[0];
            conx.Close();
            BillId.Text = "";
            ProdName.Text = "";
            ProdQty.Text = "";
            Catcb.Text = "";
            ProdPric.Text = "";



        }
        private void afficherBill()
        {

            conx.Open();

            string qurey = "select * from BillTable";
            SqlDataAdapter sda = new SqlDataAdapter(qurey, conx);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);

            var data = new DataSet();
            sda.Fill(data);
            BillView.DataSource = data.Tables[0];
            conx.Close();
            BillId.Text = "";
           



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
        private void ProdView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void ProdName_TextChanged(object sender, EventArgs e)
        {

        }

        private void ProdId_TextChanged(object sender, EventArgs e)
        {

        }

        private void ProdQty_TextChanged(object sender, EventArgs e)
        {

        }

        private void ProdPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void ProdView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            ProdName.Text = ProdView1.SelectedRows[0].Cells[0].Value.ToString();
           // ProdPric.Text = ProdView1.SelectedRows[0].Cells[1].Value.ToString() + " € ";

            ProdQty.Text = ProdView1.SelectedRows[0].Cells[1].Value.ToString();

        }

        private void SellingForm_Load(object sender, EventArgs e)
        {
            SellerNameLB.Text = Login.sellerName;
            DateLb.Text = DateTime.Today.ToShortDateString();
            afficher();
            fillcombox();
            afficherBill();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {
            //DateLb.Text = DateTime.Today.Day.ToString() + " / " + DateTime.Today.Month.ToString() + " / " + DateTime.Today.Year.ToString();
        }
        int number = 0; int REs = 0;

        private void button9_Click(object sender, EventArgs e)
        {

            if (ProdName.Text == "" || ProdQty.Text == "")
            {
                MessageBox.Show("please one of the option is missing ");
            }
            else
            {

                int Total = Convert.ToInt32(ProdPric.Text) * Convert.ToInt32(ProdQty.Text);



                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(ORDERView);
                newRow.Cells[0].Value = number + 1;
                newRow.Cells[1].Value = ProdName.Text;
                newRow.Cells[2].Value = ProdPric.Text;
                newRow.Cells[3].Value = ProdQty.Text;
                newRow.Cells[4].Value = Convert.ToInt32(ProdPric.Text) * Convert.ToInt32(ProdQty.Text);

                ORDERView.Rows.Add(newRow);
                number++;
                REs += Total;
                AmntLB.Text = REs + "€ ";


            }

        }

        private void button11_Click(object sender, EventArgs e)
        {
            printer.Title = "Lahcene MiniMarket Sell List ";
            printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "MiniMarket";
            printer.FooterSpacing = 10;
            printer.printDocument.DefaultPageSettings.Landscape = true;
            printer.PrintDataGridView(BillView);
        }

        private void button10_Click(object sender, EventArgs e)
        {
        }

        private void ORDERView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AmntLB_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (BillId.Text == "")
            {
                MessageBox.Show("  Bill ID is missing ");
            }
            else
            {
                try
                {
                    conx.Open();
                    string qurey = "insert into BillTable values(" + BillId.Text + ",'" + SellerNameLB.Text + "','" + DateLb.Text + "'," + REs.ToString() + ")";

                    SqlCommand com = new SqlCommand(qurey, conx);
                    com.ExecuteNonQuery();
                    MessageBox.Show("Order have been added Successfully", "Order information", MessageBoxButtons.OK,MessageBoxIcon.Information) ;
                    conx.Close();
                    afficherBill();
                   // BillId.Text = "";



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }

        private void SellerNameLB_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CategoryForm cat = new CategoryForm();
            cat.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SellingForm sel = new SellingForm();
            sel.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SellerForm sell = new SellerForm();
            sell.Show();
            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            afficher();
        }

        private void Catcb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string qurey = "SELECT * FROM ProductTable WHERE ProdCat='" + Catcb.SelectedValue.ToString() + "'";
            SqlCommand cmd = new SqlCommand(qurey, conx);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ProdView1.DataSource = dt;
        }
    }
}

      