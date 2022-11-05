using System;

namespace Ex_Cadastro_Funcionarios.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        public string Erro { get; set; }
        public ErrorViewModel()
        {

        }
        public ErrorViewModel(string erro)
        {
            Erro = erro;
        }
    }
}
