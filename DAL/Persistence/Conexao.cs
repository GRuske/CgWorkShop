using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; // SQL SERVER
using System.Data;

namespace DAL.Persistence
{
    public class Conexao
    {
        //Atributos da Classe

        //Protected pq só permite acesso por herança
        protected SqlConnection Con; //Utilizado para estabelecer a conexão
        protected SqlCommand Cmd; //Utilizado para comandos SQL
        protected SqlDataReader Dr; //Utilizado para ler os retornos da Query
        protected ConnectionState state;
        //Metodos

        protected void AbrirConexao()
        {
            try
            {
                //Connection String -> Clica no banco -> Propriedades -> Connection String
                Con = new SqlConnection("Data Source=.;Initial Catalog=CGWORKSHOP;Integrated Security=True");
                Con.Open();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); //Mostra o Erro;
            }
        }

        protected void FecharConexao()
        {
            try
            {
                state = Con.State;//Pega o Status da conexão
                if (state == ConnectionState.Open) //Se estiver aberta - Fecha
                {
                    Con.Close(); //Fecha a conexão
                }
            }
            catch (Exception ex)//declara o Erro
            {
                //Trata o Erro
                throw new Exception(ex.Message); //Mostra o Erro
            }
        }

    }
}
