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
using System.Diagnostics.Eventing.Reader;

namespace CastrodeClietes
{
    
    public partial class FormLogin : Form
    {
        //Referencia da Conexão
        SqlConnection Conexao = new SqlConnection(@"Data Source=VALDIVINONETO;Initial Catalog=LoginProjeto;Integrated Security=True;Encrypt=False");
        public FormLogin()
        {
            InitializeComponent();
            txtUsuario.Select();
        }

        //Botão Entrar
        private void BtnEntrar_Click(object sender, EventArgs e)
        {
            Conexao.Open(); //Abrir a conexão
            string query = "SELECT * FROM Usuario WHERE Usarname = '"+txtUsuario.Text+"' AND Password = '"+txtSenha.Text+"'";
            SqlDataAdapter dp = new SqlDataAdapter(query,Conexao);
            DataTable dt = new DataTable();
            dp.Fill(dt);

            if (dt.Rows.Count == 1)
            {
                FrmPrincipal principal = new FrmPrincipal();
                this.Hide();
                principal.Show();
                Conexao.Close(); // Fechar a Conexão
            }            
            else
            {
                MessageBox.Show("Usuario ou Senha incorreta, Preencha o campo novamente", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsuario.Text = ""; // Limpa as texbox depois de serem verificadas
                txtSenha.Text = "";
                txtUsuario.Select(); // Cursor irá sinalizar a primeira textbox
                    
            }             
                        
             
            
        }

        // Botão Sair
        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();  
        }
    }
}
