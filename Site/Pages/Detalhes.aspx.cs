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
    public partial class Detalhes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pnlDados.Visible = false;
            lblMensagem.Text = "";
        }

        protected void btnPesquisarCliente(object sender, EventArgs e)
        {
            try
            {
                int codigo = Convert.ToInt32(txtCodigo.Text); //Converte te String da Pg para int
                ClienteDAL cd = new ClienteDAL();
                Cliente cliente = cd.PesquisarPorCodigo(codigo);

                if (cliente != null)
                {
                    pnlDados.Visible = true;
                    txtNome.Text = cliente.Nome;
                    txtEndereco.Text = cliente.Endereco;
                    txtEmail.Text = cliente.Email;

                }
                else
                {
                    lblMensagem.Text = "Cliente não encontrado!";
                }

            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
            }
        }

        protected void btnAtualizarCliente(object sender, EventArgs e)
        {
            try
            {
                ClienteDAL cd = new ClienteDAL();
                Cliente c = new Cliente();
                
                c.Codigo = Convert.ToInt32(txtCodigo.Text);
                c.Nome = Convert.ToString(txtNome.Text);
                c.Email = Convert.ToString(txtEmail.Text);
                c.Endereco = Convert.ToString(txtEndereco.Text);

                cd.Atualizar(c);

                lblMensagem.Text = "Cliente atualizado com sucesso!";
            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
            }
        }

        protected void btnExcluiCliente(object sender, EventArgs e)
        {
            try
            {
                int codigo = Convert.ToInt32(txtCodigo.Text);
                ClienteDAL cd = new ClienteDAL();
                cd.Excluir(codigo);

                lblMensagem.Text = "Cliente removido com sucesso!";

                txtEmail.Text = string.Empty;
                txtEndereco.Text = string.Empty;
                txtNome.Text = string.Empty;
            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
            }
        }
    }
}