using ExemploUnitOfWorkDapper.Infrastructure.Repositories;
using ExemploUnitOfWorkDapper.Infrastructure.UnitOfWorks.Interfaces;
using ExemploUnitOfWorkDapper.Models;
using System;
using System.Web.Mvc;

namespace ExemploUnitOfWorkDapper.Controllers
{
    public class ClienteController : Controller
    {

        private readonly ISqlUnitOfWork _unitOfWork;
        private readonly IClienteRepository _repository;

        public ClienteController(ISqlUnitOfWork unitOfWork, IClienteRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public ActionResult Index()
        {
            _unitOfWork.Connection.Open();

            var clientes = _repository.ObterTodos();

            _unitOfWork.Connection.Close();

            return View(clientes);
        }

        public ActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Adicionar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.BeginTransaction();

                _repository.Adicionar(cliente);

                cliente.Nome += ". Dica: Alterado";

                _repository.Atualizar(cliente);

                _unitOfWork.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(cliente);
        }

    }
}