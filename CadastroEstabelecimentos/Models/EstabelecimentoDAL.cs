using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CadastroEstabelecimentos.Models
{
    public class EstabelecimentoDAL
    {
        readonly string stringDeConexao = "Server=tcp:fernuvem.database.windows.net,1433;Initial Catalog=TesteFernando;Persist Security Info=False;User ID=dbaFernando;Password=B@nana00;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        
        public IEnumerable<Estabelecimento> BuscarTodos()
        {
            List<Estabelecimento> ListaRegistros = new List<Estabelecimento>();

            using (SqlConnection conexao = new SqlConnection(stringDeConexao))
            {
                SqlCommand comando = new SqlCommand("USP_BuscaTodosRegistros", conexao);
                comando.CommandType = CommandType.StoredProcedure;
                conexao.Open();
                SqlDataReader dr = comando.ExecuteReader();
                while(dr.Read())
                {
                    Estabelecimento ItemRegistro = new Estabelecimento();
                    ItemRegistro.Id = Convert.ToInt32(dr["Id"].ToString());
                    ItemRegistro.RazaoSocial = dr["Razao_Social"].ToString();
                    ItemRegistro.NomeFantasia = dr["Nome_Fantasia"].ToString();
                    ItemRegistro.CNPJ = dr["CNPJ"].ToString();
                    ItemRegistro.Email = dr["Email"].ToString();
                    ItemRegistro.Endereco = dr["Endereço"].ToString();
                    ItemRegistro.Cidade = dr["Cidade"].ToString();
                    ItemRegistro.Estado = dr["Estado"].ToString();
                    ItemRegistro.Telefone = dr["Telefone"].ToString();
                    ItemRegistro.DataDeCadastro = Convert.ToDateTime(dr["Data_de_Cadastro"].ToString());
                    ItemRegistro.Categoria = dr["Categoria"].ToString();
                    ItemRegistro.Status =  dr["Status"].ToString();
                    ItemRegistro.Agencia = dr["Agencia"].ToString();
                    ItemRegistro.Conta = dr["Conta"].ToString();

                    ListaRegistros.Add(ItemRegistro);
                    
                }
                conexao.Close();
                
            }
            return ListaRegistros;
        }

        public Estabelecimento BuscarPorId(int? Id)
        {
            Estabelecimento registro = new Estabelecimento();

            using (SqlConnection conexao = new SqlConnection(stringDeConexao))
            {
                SqlCommand comando = new SqlCommand("USP_SelecionaEstabelecimentoPorId", conexao);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Id", Id);
                conexao.Open();
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    Estabelecimento ItemRegistro = new Estabelecimento();
                    registro.Id = Convert.ToInt32(dr["Id"].ToString());
                    registro.RazaoSocial = dr["Razao_Social"].ToString();
                    registro.NomeFantasia = dr["Nome_Fantasia"].ToString();
                    registro.CNPJ = dr["CNPJ"].ToString();
                    registro.Email = dr["Email"].ToString();
                    registro.Endereco = dr["Endereço"].ToString();
                    registro.Cidade = dr["Cidade"].ToString();
                    registro.Estado = dr["Estado"].ToString();
                    registro.Telefone = dr["Telefone"].ToString();
                    registro.DataDeCadastro = Convert.ToDateTime(dr["Data_de_Cadastro"].ToString());
                    registro.Categoria = dr["Categoria"].ToString();
                    registro.Status = dr["Status"].ToString();
                    registro.Agencia = dr["Agencia"].ToString();
                    registro.Conta = dr["Conta"].ToString();
                }

                conexao.Close();

                return registro;
            }
        }

        public void InsereNovo(Estabelecimento novoRegistro)
        {
            using (SqlConnection conexao = new SqlConnection(stringDeConexao))
            {
                SqlCommand comando = new SqlCommand("USP_InsereNovoEstabelecimento", conexao);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@Razao_Social", novoRegistro.RazaoSocial);
                comando.Parameters.AddWithValue("@Nome_Fantasia", novoRegistro.NomeFantasia);
                comando.Parameters.AddWithValue("@CNPJ", novoRegistro.CNPJ);
                comando.Parameters.AddWithValue("@Email", novoRegistro.Email);
                comando.Parameters.AddWithValue("@Endereço", novoRegistro.Endereco);
                comando.Parameters.AddWithValue("@Cidade", novoRegistro.Cidade);
                comando.Parameters.AddWithValue("@Estado", novoRegistro.Estado);
                comando.Parameters.AddWithValue("@Telefone", novoRegistro.Telefone);
                comando.Parameters.AddWithValue("@Data_De_Cadastro", novoRegistro.DataDeCadastro);
                comando.Parameters.AddWithValue("@Categoria", novoRegistro.Categoria);
                comando.Parameters.AddWithValue("@Status", novoRegistro.Status);
                comando.Parameters.AddWithValue("@Agencia", novoRegistro.Agencia);
                comando.Parameters.AddWithValue("@Conta", novoRegistro.Conta);
                conexao.Open();
                comando.ExecuteNonQuery();
                conexao.Close();

            }
        }

        public void Atualiza(Estabelecimento novoRegistro)
        {
            using (SqlConnection conexao = new SqlConnection(stringDeConexao))
            {
                SqlCommand comando = new SqlCommand("USP_AtualizaEstabelecimento", conexao);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@Id", novoRegistro.Id);
                comando.Parameters.AddWithValue("@Razao_Social", novoRegistro.RazaoSocial);
                comando.Parameters.AddWithValue("@Nome_Fantasia", novoRegistro.NomeFantasia);
                comando.Parameters.AddWithValue("@CNPJ", novoRegistro.CNPJ);
                comando.Parameters.AddWithValue("@Email", novoRegistro.Email);
                comando.Parameters.AddWithValue("@Endereço", novoRegistro.Endereco);
                comando.Parameters.AddWithValue("@Cidade", novoRegistro.Cidade);
                comando.Parameters.AddWithValue("@Estado", novoRegistro.Estado);
                comando.Parameters.AddWithValue("@Telefone", novoRegistro.Telefone);
                comando.Parameters.AddWithValue("@Categoria", novoRegistro.Categoria);
                comando.Parameters.AddWithValue("@Status", novoRegistro.Status);
                comando.Parameters.AddWithValue("@Agencia", novoRegistro.Agencia);
                comando.Parameters.AddWithValue("@Conta", novoRegistro.Conta);
                conexao.Open();
                comando.ExecuteNonQuery();
                conexao.Close();

            }
        }

        public void Deletar(int? Id)
        {
            using (SqlConnection conexao = new SqlConnection(stringDeConexao))
            {
                SqlCommand comando = new SqlCommand("USP_DeletaEstabelecimento", conexao);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@Id", Id);
 
                conexao.Open();
                comando.ExecuteNonQuery();
                conexao.Close();

            }
        }
    }
}
