using System.Data;
using System.Data.SqlClient;

namespace HelloApp
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            label4.ForeColor = Color.White;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Black;
        }
        Point lastpoint;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X  - lastpoint.X;
                this.Top += e.Y - lastpoint.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastpoint = new Point(e.X, e.Y);
        }

        private void button_enter_Click(object sender, EventArgs e)
        {
            string user_login = loginBox1.Text;
            string user_password = passBox2.Text;

            DBConnection db = new DBConnection();
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand("SELECT * FROM users WHERE Nickname = @UL AND Password = @UP", db.Get_connection());
            cmd.Parameters.Add("@UL", SqlDbType.VarChar).Value = user_login;
            cmd.Parameters.Add("@UP", SqlDbType.VarChar).Value = user_password;
            adapter.SelectCommand = cmd;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Добро пожаловать");
            }
            else
            {
                MessageBox.Show("Nothin found, sorry");
            }

        }

        private void button_enter_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void button_enter_Enter(object sender, EventArgs e)
        {
            button_enter_Click(sender, e);
        }
    }
}