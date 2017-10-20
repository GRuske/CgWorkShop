using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.Model;
using DAL.Persistence;

namespace Site.Pages
{
    public partial class Cadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCadastrarCliente(object sender, EventArgs e)
        {
            try
            {
                Cliente c = new Cliente();

                c.Nome      = txtNome.Text;
                c.Endereco  = TxtEndereco.Text;
                c.Email     = TxtEmail.Text;

                ClienteDAL cd = new ClienteDAL();
                cd.Gravar(c);

                lblMensagem.Text = "Cliente " + c.Nome.Trim() + " cadastrado com sucesso!";

                txtNome.Text     = string.Empty;
                TxtEndereco.Text = string.Empty;
                TxtEmail.Text    = string.Empty;
            }
            catch (Exception ex)
            {
                lblMensagem.Text = "Erro ao gravar o Cliente" + ex.Message;
            }
        }
    }
}