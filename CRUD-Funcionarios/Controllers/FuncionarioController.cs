using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Data.SqlClient;
using Ex_Cadastro_Funcionarios.Models;
using Ex_Cadastro_Funcionarios.DAO;
using Ex_Cadastro_Funcionarios.Enums;
using System.Collections.Generic;

namespace Ex_Cadastro_Funcionarios.Controllers
{
    public class FuncionarioController : Controller
    {
        public IActionResult Index()
        {
            try
            {
                FuncionarioDAO dao = new FuncionarioDAO();
                List<FuncionarioViewModel> lista = dao.Listagem();
                return View(lista);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }
        public IActionResult Create()
        {
            try
            {
                ViewBag.Operacao = "I";
                FuncionarioViewModel Funcionario = new FuncionarioViewModel();

                FuncionarioDAO dao = new FuncionarioDAO();
                Funcionario.Id = dao.ProximoId();

                return View("Form", Funcionario);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }
        public IActionResult Edit(int id)
        {
            try
            {
                ViewBag.Operacao = "A";
                FuncionarioDAO dao = new FuncionarioDAO();
                FuncionarioViewModel Funcionario = dao.Consulta(id);
                if (Funcionario == null)
                    return RedirectToAction("index");
                else
                    return View("Form", Funcionario);
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }
        public IActionResult Delete(int id)
        {
            try
            {
                FuncionarioDAO dao = new FuncionarioDAO();
                dao.Excluir(id);
                return RedirectToAction("index");
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }
        private void ValidaDados(FuncionarioViewModel Funcionario, string operacao)
        {
            ModelState.Clear();
            FuncionarioDAO dao = new FuncionarioDAO();
            if (operacao == "I" && dao.Consulta(Funcionario.Id) != null)
                ModelState.AddModelError("Id", "Código já está em uso.");
            if (operacao == "A" && dao.Consulta(Funcionario.Id) == null)
                ModelState.AddModelError("Id", "Funcionário não existe.");
            if (Funcionario.Id <= 0)
                ModelState.AddModelError("Id", "Id inválido!");
            if (string.IsNullOrEmpty(Funcionario.Nome))
                ModelState.AddModelError("Nome", "Preencha o nome.");
        }
        public IActionResult Salvar(FuncionarioViewModel Funcionario, string Operacao)
        {
            try
            {
                ValidaDados(Funcionario, Operacao);
                if (ModelState.IsValid == false)
                {
                    ViewBag.Operacao = Operacao;
                    return View("Form", Funcionario);
                }
                else
                {
                    FuncionarioDAO dao = new FuncionarioDAO();
                    if (Operacao == "I")
                        dao.Inserir(Funcionario);
                    else
                        dao.Alterar(Funcionario);
                    return RedirectToAction("index");
                }
            }
            catch (Exception erro)
            {
                return View("Error", new ErrorViewModel(erro.ToString()));
            }
        }
    }
}
