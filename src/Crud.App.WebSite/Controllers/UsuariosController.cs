using Crud.App.Application.Interfaces;
using Crud.App.Application.ViewModels;
using Crud.App.Domain.Core.Notifications;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Crud.App.WebSite.Controllers
{
    public class UsuariosController : BaseController
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public UsuariosController(IUsuarioAppService usuarioAppService, IDomainNotification notifications) : base(notifications)
        {
            _usuarioAppService = usuarioAppService;
        }

        [Route("")]
        [Route("usuarios")]
        public IActionResult Index()
        {
            return View(_usuarioAppService.ObterTodos());
        }
        [Route("dados-do-usuarios/{id:guid}")]
        public IActionResult Details(Guid? id)
        {
            if (id == null) return NotFound();

            var usuarioViewModel = _usuarioAppService.ObterPorId(id.Value);
            if (usuarioViewModel == null) return NotFound();

            return View(usuarioViewModel);
        }

        [Route("novo-usuario")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("novo-usuario")]
        public IActionResult Create(UsuarioViewModel usuarioViewModel)
        {
            if (!ModelState.IsValid) return View(usuarioViewModel);

            _usuarioAppService.Registrar(usuarioViewModel);

            ViewBag.RetornoPost = OperacaoValida() ? "success;Usuário registrado com sucesso!" : "error;Usuário não registrado, verifique as mensagens!";

            return View(usuarioViewModel);
        }

        [Route("editar-usuario/{id:guid}")]
        public IActionResult Edit(Guid? id)
        {
            if (id == null) return NotFound();

            var usuarioViewModel = _usuarioAppService.ObterPorId(id.Value);
            if (usuarioViewModel == null) return NotFound();

            return View(usuarioViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("editar-usuario/{id:guid}")]
        public IActionResult Edit(UsuarioViewModel usuarioViewModel)
        {
            if (!ModelState.IsValid)
                return View(usuarioViewModel);

            _usuarioAppService.Atualizar(usuarioViewModel);

            ViewBag.RetornoPost = OperacaoValida() ? "success;Usuário alterado com sucesso!" : "error;Usuário não alterado, verifique as mensagens!";

            return View(usuarioViewModel);
        }

        [Route("excluir-usuario/{id:guid}")]
        public IActionResult Delete(Guid? id)
        {
            if (id == null) return NotFound();

            var usuarioViewModel = _usuarioAppService.ObterPorId(id.Value);

            if (usuarioViewModel == null) return NotFound();

            return View(usuarioViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("excluir-usuario/{id:guid}")]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var usuarioViewModel = _usuarioAppService.ObterPorId(id);

            _usuarioAppService.Exluir(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
