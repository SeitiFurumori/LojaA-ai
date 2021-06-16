using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaAçai.Models
{
    public class CadastrarModels
    {
        private const string conexaoBD = "Server=localhost ; Database=lojaacai; User id = root; Password=2110049a; AllowUserVariables=True";
        private string usuario;
        private string senha;
        private string quantidade;
        private string session;
        private string descricao;
        private string tipo;
        private string preco;
        private string id;
        private string msg;


        public string Username
        {
            get { return usuario; }
            set { usuario = value; }
        }
        public string Senha
        {
            get { return senha; }
            set { senha = value; }
        }
        public string Quantidade 
        {
            get { return quantidade; }
            set { quantidade = value; }
        }
        public string Session
        {
            get { return session; }
            set { session = value; }
        }
        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }
        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        public string Preco
        {
            get { return preco; }
            set { preco = value; }
        }
        public string Codigo
        {
            get { return id; }
            set { id = value; }
        }
        public string logar()
        {
            MySqlConnection con = new MySqlConnection(conexaoBD);
            try
            {
                
                
                con.Open();
                MySqlCommand query = new MySqlCommand("select * from usuario where username=@username and senha=@senha ", con);
                query.Parameters.AddWithValue("@username", Username);
                query.Parameters.AddWithValue("@senha", Senha);
                MySqlDataReader leitor = query.ExecuteReader();
                if(leitor.HasRows)
                {
                    leitor.Read();
                    msg = leitor["codigo"].ToString();
                }
                else
                {
                    msg = null;
                }

            }
            catch(Exception e1)
            {
                msg = "Erro ao conectar" + e1.Message;
            }
            finally
            {
                con.Close();
            }
            return msg;
        }
        public string SalvarM()
        {
            MySqlConnection con = new MySqlConnection(conexaoBD);
            if(usuario == null ||usuario == "" && senha == null || senha == "")
            {
                msg = "Não preencheu todos os campos";
            }
            else {
            
            try
            {
                    con.Open();
                    MySqlCommand query = new MySqlCommand("insert into usuario(username, senha) values(@username, @senha)", con);
                    query.Parameters.AddWithValue("@username", Username);
                    query.Parameters.AddWithValue("@senha", Senha);
                    query.ExecuteNonQuery();
                    msg = "Cadastrado com sucesso";     
            }
            catch (Exception ex2)
            {
                msg = "Não conectou" + ex2.Message;
            }
            finally
            {
                con.Close();
            }
}
            return msg;

        }
        public string ComprarDiversos()
        {
            MySqlConnection con = new MySqlConnection(conexaoBD);
                try
                {
                    con.Open();
                    MySqlCommand query = new MySqlCommand("insert into venda(quantidade, FK_USUARIO_codigo, FK_produto_codigo) values (@quantidade,@session,2);", con);
                    query.Parameters.AddWithValue("@quantidade", Quantidade);
                    query.Parameters.AddWithValue("@session", Session);
                    query.ExecuteNonQuery();
                    msg = "Comprado com sucesso";
                }
                catch (Exception ex2)
                {
                    msg = "Não conectou" + ex2.Message;
                }
                finally
                {
                    con.Close();
                }
            
            return msg;

        }
        public string ComprarCompleto()
        {
            MySqlConnection con = new MySqlConnection(conexaoBD);
            try
            {
                con.Open();
                MySqlCommand query = new MySqlCommand("insert into venda(quantidade, FK_USUARIO_codigo, FK_produto_codigo) values (@quantidade,@session,4);", con);
                query.Parameters.AddWithValue("@quantidade", Quantidade);
                query.Parameters.AddWithValue("@session", Session);
                query.ExecuteNonQuery();
                msg = "Comprado com sucesso";
            }
            catch (Exception ex2)
            {
                msg = "Não conectou" + ex2.Message;
            }
            finally
            {
                con.Close();
            }

            return msg;

        }
        public string ComprarBarca()
        {
            MySqlConnection con = new MySqlConnection(conexaoBD);
            try
            {
                con.Open();
                MySqlCommand query = new MySqlCommand("insert into venda(quantidade, FK_USUARIO_codigo, FK_produto_codigo) values (@quantidade,@session,3);", con);
                query.Parameters.AddWithValue("@quantidade", Quantidade);
                query.Parameters.AddWithValue("@session", Session);
                query.ExecuteNonQuery();
                msg = "Comprado com sucesso";
            }
            catch (Exception ex2)
            {
                msg = "Não conectou" + ex2.Message;
            }
            finally
            {
                con.Close();
            }

            return msg;

        }
        public string ComprarChocolate()
        {
            MySqlConnection con = new MySqlConnection(conexaoBD);
            try
            {
                con.Open();
                MySqlCommand query = new MySqlCommand("insert into venda(quantidade, FK_USUARIO_codigo, FK_produto_codigo) values (@quantidade,@session,1);", con);
                query.Parameters.AddWithValue("@quantidade", Quantidade);
                query.Parameters.AddWithValue("@session", Session);
                query.ExecuteNonQuery();
                msg = "Comprado com sucesso";
            }
            catch (Exception ex2)
            {
                msg = "Não conectou" + ex2.Message;
            }
            finally
            {
                con.Close();
            }

            return msg;

        }
        public List<CadastrarModels> ListarCarrinho()
        {
            MySqlConnection con = new MySqlConnection(conexaoBD);
            List<CadastrarModels> lista = new List<CadastrarModels>();
            try
            {
                con.Open();
                MySqlCommand query = new MySqlCommand("select venda.codigo, venda.quantidade , produto.descricao, produto.tipo, produto.preco from venda inner join produto on venda.FK_produto_codigo = produto.codigo and venda.FK_USUARIO_codigo = @session;", con);
                query.Parameters.AddWithValue("@session", Session);
                MySqlDataReader leitor = query.ExecuteReader();
                while (leitor.Read())
                {
                    CadastrarModels item = new CadastrarModels();
                    item.Codigo = leitor["codigo"].ToString();
                    item.Quantidade = leitor["quantidade"].ToString();
                    item.Descricao = leitor["descricao"].ToString();
                    item.Tipo = leitor["tipo"].ToString();
                    item.Preco = leitor["preco"].ToString();
                    lista.Add(item);
                }
            }
            catch (Exception ex)
            {
                lista = null;
            }
            finally
            {
                con.Close();
            }
            return lista;
        }
        public string Cancelar()
        {
            MySqlConnection con = new MySqlConnection(conexaoBD);
            try
            {
                con.Open();
                MySqlCommand query = new MySqlCommand("delete from venda where codigo =@codigo", con);
                query.Parameters.AddWithValue("@codigo", Codigo);
                query.ExecuteNonQuery();
                msg = "Deletado com sucesso";
            }
            catch (Exception ex1)
            {
                msg = "Falha " + ex1.Message;
            }
            finally
            {
                con.Close();
            }
            return msg;
        }
        public string Comprar()
        {
            MySqlConnection con = new MySqlConnection(conexaoBD);
            try
            {
                con.Open();
                MySqlCommand query = new MySqlCommand("delete from venda where FK_USUARIO_codigo =@session", con);
                query.Parameters.AddWithValue("@session", Session);
                query.ExecuteNonQuery();
                msg = "Comprado com sucesso";
            }
            catch (Exception ex1)
            {
                msg = "Falha " + ex1.Message;
            }
            finally
            {
                con.Close();
            }
            return msg;
        }
    }
}