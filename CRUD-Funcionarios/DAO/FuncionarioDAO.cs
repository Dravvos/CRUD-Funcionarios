using System;
using System.Data;
using System.Data.SqlClient;
using Ex_Cadastro_Funcionarios.Models;
using Ex_Cadastro_Funcionarios.Enums;
using System.Collections.Generic;

namespace Ex_Cadastro_Funcionarios.DAO
{
    public class FuncionarioDAO
    {
        private SqlParameter[] CriaParametros(FuncionarioViewModel Funcionario)
        {
            SqlParameter[] parametros = new SqlParameter[4];
            parametros[0] = new SqlParameter("func_id", Funcionario.Id);
            parametros[1] = new SqlParameter("func_nome", Funcionario.Nome);
            parametros[2] = new SqlParameter("func_ativo", Funcionario.Ativo);
            parametros[3] = new SqlParameter("func_tipo", (char)Funcionario.Tipo);
            return parametros;
        }
        /// <summary>
        /// Método para inserir um Funcionario no BD
        /// </summary>
        /// <param name="Funcionario">objeto Funcionario com todas os atributos preenchidos</param>
        public void Inserir(FuncionarioViewModel Funcionario)
        {
            string sql =
            "insert into funcionarios(func_id, func_nome, func_ativo, func_tipo)" +
            "values (@func_id, @func_nome, @func_ativo, @func_tipo)";
            HelperDAO.ExecutaSQL(sql, CriaParametros(Funcionario));
        }
        /// <summary>
        /// Altera um Funcionario no banco de dados
        /// </summary>
        /// <param name="Funcionario">objeto Funcionario com todas os atributos preenchidos</param>
        public void Alterar(FuncionarioViewModel Funcionario)
        {
            string sql =
            "update Funcionarios set func_nome=@func_nome, func_tipo=@func_tipo, " +
            "func_ativo=@func_ativo where func_id = @func_id";
            HelperDAO.ExecutaSQL(sql, CriaParametros(Funcionario));
        }
        /// <summary>
        /// Exclui um Funcionario no banco de dados.
        /// </summary>
        /// <param name="id">id do Funcionario</param>
        public void Excluir(int id)
        {
            string sql = "delete Funcionarios where func_id =" + id;
            HelperDAO.ExecutaSQL(sql, null);
        }
        public List<FuncionarioViewModel> Listagem()
        {
            List<FuncionarioViewModel> lista = new List<FuncionarioViewModel>();
            string sql = "select * from Funcionarios";
            DataTable tabela = HelperDAO.ExecutaSelect(sql, null);
            foreach (DataRow registro in tabela.Rows)
                lista.Add(MontaModel(registro));
            return lista;
        }
        public static FuncionarioViewModel MontaModel(DataRow registro)
        {
            FuncionarioViewModel Funcionario = new FuncionarioViewModel();
            Funcionario.Id = Convert.ToInt32(registro["func_id"]);
            Funcionario.Nome= registro["func_nome"].ToString();
            Funcionario.Tipo= (FuncTipo)Convert.ToChar(registro["func_tipo"]);
            Funcionario.Ativo = Convert.ToBoolean(registro["func_ativo"]);
            return Funcionario;
        }
        public FuncionarioViewModel Consulta(int id)
        {
            string sql = "select * from funcionarios where func_id = " + id;
            DataTable tabela = HelperDAO.ExecutaSelect(sql, null);
            if (tabela.Rows.Count == 0)
                return null;
            else
                return MontaModel(tabela.Rows[0]);
        }
        public int ProximoId()
        {
            string sql = "select isnull(max(func_id) +1, 1) as 'MAIOR' from funcionarios";
            DataTable tabela = HelperDAO.ExecutaSelect(sql, null);
            return Convert.ToInt32(tabela.Rows[0]["MAIOR"]);
        }
    }
}
