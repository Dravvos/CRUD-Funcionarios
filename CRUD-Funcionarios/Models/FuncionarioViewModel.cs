using System;
using Ex_Cadastro_Funcionarios.Enums;

namespace Ex_Cadastro_Funcionarios.Models
{
    public class FuncionarioViewModel
    {
        public int Id { get;set; }
        public string Nome { get;set; }
        public FuncTipo Tipo { get; set; }
        public bool Ativo { get; set; }
    }
}
