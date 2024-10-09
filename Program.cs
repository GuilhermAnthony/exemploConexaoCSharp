using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace exemplo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MySqlConnection conexao;
            MySqlCommand cmd;

            conexao = new MySqlConnection("server=localhost;database=projeto;uid=root;pwd=''"); 

            try
            {
                conexao.Open();
                Console.WriteLine("Conexão bem sucedida\n");
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            string sql;

            Console.WriteLine("INSERIR DADOS \n\n");

            string usuario;
            string senha;

            Console.WriteLine("Digite um novo usuario");
            usuario = Console.ReadLine();

            Console.WriteLine("Digite a senha");
            senha = Console.ReadLine();

            sql = "INSERT INTO usuario (usuario, senha) VALUES (@usuario, @senha)";
            cmd = new MySqlCommand(sql, conexao);

            cmd.Parameters.AddWithValue("@usuario", usuario);
            cmd.Parameters.AddWithValue("@senha", senha);

            try
            {
                int linhasafetadas = cmd.ExecuteNonQuery();

                if (linhasafetadas == 0)
                {
                    throw new Exception("Nenhuma linha foi afetada pela consulta.");
                }
                else
                {
                    Console.WriteLine("Linhas afetadas {0}", linhasafetadas);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: {0}",ex.Message);
            }

            /*sql = "SELECT * FROM usuario";

            cmd = new MySqlCommand(sql, conexao);

            MySqlDataReader rdr;
            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Console.WriteLine("\nId usuario:" + rdr["id"]);
                Console.WriteLine("Usuario:" + rdr["usuario"] + "\nSenha:" + rdr["senha"]);
            }*/

            Console.ReadKey();
        }
    }
}
