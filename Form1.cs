using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace WinFormsApp11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void LoadDatta()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-ODHNQKP\SQLEXPRESS;Initial Catalog=QLBT;Integrated Security=True");
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from T", conn);
            DataTable s = new DataTable();
            adapter.Fill(s);
            dataGridView1.DataSource = s;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-ODHNQKP\SQLEXPRESS;Initial Catalog=QLBT;Integrated Security=True");
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from T", conn);
            DataTable s = new DataTable();
            adapter.Fill(s);
            dataGridView1.DataSource = s;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-ODHNQKP\SQLEXPRESS;Initial Catalog=QLBT;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = string.Format("insert into T values ('{0}','{1}','{2}','{3}','{4}')", textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text);
            MessageBox.Show("");
            cmd.ExecuteNonQuery();
            this.LoadDatta();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-ODHNQKP\SQLEXPRESS;Initial Catalog=QLBT;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = string.Format("delete from T where MNCC = '{0}'", textBox1.Text);
            MessageBox.Show("");
            cmd.ExecuteNonQuery();
            this.LoadDatta();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            }
            catch (Exception)
            {
                textBox1.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-ODHNQKP\SQLEXPRESS;Initial Catalog=QLBT;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = string.Format("update T set TNCC= '{1}' ,DIACHI = '{2}',SDT = '{3}',SFAX='{4}' where MNCC= '{0}'", textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text);
            MessageBox.Show("");
            cmd.ExecuteNonQuery();
            this.LoadDatta();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-ODHNQKP\SQLEXPRESS;Initial Catalog=QLBT;Integrated Security=True");
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from T where MNCC = '" + textBox1.Text + "' ", conn);
            DataTable s = new DataTable();
            adapter.Fill(s);
            dataGridView1.DataSource = s;
        }
    }
}