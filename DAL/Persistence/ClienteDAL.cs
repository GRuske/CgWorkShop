using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; //Acesso ao sql Server
using DAL.Model; //Essa o MODEL para usar o Cliente

namespace DAL.Persistence
{
    //Regras de negocio da aplicação
    public class ClienteDAL : Conexao //Herança
    {
        public void Gravar(Cliente cli)
        {
            try
            {
                AbrirConexao();
                //CMD da classe conexao - COMANDOS 
                //Insert
                Cmd = new SqlCommand("INSERT INTO CLIENTE (NOME, ENDERECO, EMAIL)" +
                                    "VALUES(@nome, @endereco, @email)", Con);
                Cmd.Parameters.AddWithValue("@nome", cli.Nome);
                Cmd.Parameters.AddWithValue("@endereco", cli.Endereco);
                Cmd.Parameters.AddWithValue("@email", cli.Email);

                Cmd.ExecuteNonQuery();//Executa a Query
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao gravar Cliente!" + ex.Message);
            }
            finally //
            {
                FecharConexao();
            }
        }

        public void Atualizar(Cliente cli)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("UPDATE CLIENTE SET NOME = @nome, ENDERECO = @endereco, EMAIL = @email WHERE CODIGO = @codigo", Con);

                Cmd.Parameters.AddWithValue("@nome", cli.Nome);
                Cmd.Parameters.AddWithValue("@endereco", cli.Endereco);
                Cmd.Parameters.AddWithValue("@email", cli.Email);
                Cmd.Parameters.AddWithValue("@codigo", cli.Codigo);

                Cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar o Cliente!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public void Excluir(int Codigo)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("DELETE FROM CLIENTE WHERE CODIGO = @codigo", Con);
                Cmd.Parameters.AddWithValue("@codigo", Codigo);
                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao deletar o Cliente!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public Cliente PesquisarPorCodigo(int Codigo)
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("SELECT * FROM CLIENTE WHERE CODIGO = @codigo", Con);
                Cmd.Parameters.AddWithValue("@codigo", Codigo);
                Dr = Cmd.ExecuteReader();
                //Pega o resultado da query
                Cliente c = null;

                if (Dr.Read())
                {
                    c = new Cliente();

                    c.Codigo    = Convert.ToInt32(Dr["Codigo"]);
                    c.Nome      = Convert.ToString(Dr["Nome"]);
                    c.Endereco  = Convert.ToString(Dr["Endereco"]);
                    c.Email     = Convert.ToString(Dr["Email"]);
                }

                return c;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao consultar o Cliente!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }

        public List<Cliente> Listar()
        {
            try
            {
                AbrirConexao();
                Cmd = new SqlCommand("SELECT * FROM CLIENTE", Con);
                Dr = Cmd.ExecuteReader();

                List<Cliente> lista = new List<Cliente>();

                while (Dr.Read())
                {
                    Cliente c = new Cliente();

                    c.Codigo = Convert.ToInt32(Dr["Codigo"]);
                    c.Nome = Convert.ToString(Dr["Nome"]);
                    c.Endereco = Convert.ToString(Dr["Endereco"]);
                    c.Email = Convert.ToString(Dr["Email"]);

                    lista.Add(c);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar os Clientes!" + ex.Message);
            }
            finally
            {
                FecharConexao();
            }
        }
    }
}
