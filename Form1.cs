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

namespace KT_L2
{
    public partial class Form1 : Form
    {
        private SqlConnection connect;
        string _connectectionString = "Data Source=A209PC37;Initial Catalog=QLHN;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
        }
        public void them(string a, string b, string c)
        {
            connect = new SqlConnection(_connectectionString);
            connect.Open();
            string insertString;
            insertString = "insert HoiNghi(maHoiNghi, tenHoiNghi, SoNguoi)  values(" + a + " , N'" + b + "' , " + c + ")";
            SqlCommand cmd = new SqlCommand(insertString, connect);
            cmd.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Thanh Cong!");
        }

        public void xoa(string a)
        {
            connect = new SqlConnection(_connectectionString);
            connect.Open();
            string deleteString;
            deleteString = "delete from HoiNghi WHERE maHoiNghi = '" + a + "'";
            SqlCommand cmd = new SqlCommand(deleteString, connect);
            cmd.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Thanh Cong!");

        }

        public void hienthi()
        {
            connect = new SqlConnection(_connectectionString);
            connect.Open();
            string selectString;
            selectString = "select HoiNghi.maHoiNghi, HoiNghi.tenHoiNghi, HoiNghi.SoNguoi, LoaiPhong.maLoaiPhong from LoaiPhong,HoiNghi";
            SqlDataAdapter da = new SqlDataAdapter(selectString, connect);
            DataTable dataTable = new DataTable();

            da.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            hienthi();
        }

        

        

        private void Form1_Load(object sender, EventArgs e)
        {

            hienthi();

            string selectString1 = "SELECT maLoaiPhong FROM LoaiPhong";
            SqlDataAdapter da1 = new SqlDataAdapter(selectString1, connect);
            DataTable dataTable1 = new DataTable();
            da1.Fill(dataTable1);

            // Set the DataTable as the data source for the ComboBox
            comboBox1.DataSource = dataTable1;
            comboBox1.DisplayMember = "maLoaiPhong";
            // Specify the display and value members
               // Display this column
           
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            them(textBox1.Text, textBox2.Text,textBox3.Text);
            hienthi();
        }
       
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            textBox1.Text = dataGridView1.Rows[numrow].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[numrow].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[numrow].Cells[2].Value.ToString();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            xoa(textBox1.Text);
            hienthi();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }
        


    }
}
