//Form1.cs

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApplication1
{
   


    public partial class Login : Form
    {
        OleDbConnection cn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Dell\Downloads\Database1.accdb");
            OleDbDataAdapter da;
            DataTable dt = new DataTable();
          
    
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
           da = new OleDbDataAdapter("select * from saveon where username = '"+textBox1.Text+"' and password = '"+textBox2.Text+"'",cn);
           da.Fill(dt);
           if (dt.Rows.Count == 1)
           {

               this.Hide();
               SaveON next = new SaveON();
               next.Show();

           }
           else
           {

        
               System.Windows.Forms.MessageBox.Show("username or password is incorrect..... Try again !", "Invalid Login",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                  
              
           }
        }
         
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

       

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Are you sure you want to really exit ? ", "Exit", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else if (dialog == DialogResult.No)
            {
                e.Cancel = true;

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        public event EventHandler LLogin;
        public event EventHandler Cancel;

        private void OnLogin()
        {
            if (LLogin != null)
                LLogin(this, EventArgs.Empty);
        }

        private void OnCancel()
        {
            if (LLogin != null)
                LLogin(this, EventArgs.Empty);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.OnLogin();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.OnCancel();
        }
       
    
    }

}
