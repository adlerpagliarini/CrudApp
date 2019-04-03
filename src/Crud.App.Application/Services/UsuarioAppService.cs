using AutoMapper;
using Crud.App.Application.Interfaces;
using Crud.App.Application.ViewModels;
using Crud.App.Domain.Usuarios;
using Crud.App.Domain.Usuarios.Service;
using System;
using System.Collections.Generic;

namespace Crud.App.Application.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioService _usuarioService;

        public UsuarioAppService(IMapper mapper, IUsuarioService usuarioService)
        {
            _mapper = mapper;
            _usuarioService = usuarioService;
        }

        public void Registrar(UsuarioViewModel usuarioViewModel)
        {
            var usuario = _mapper.Map<Usuario>(usuarioViewModel);
            _usuarioService.RegistrarUsuario(usuario);
        }

        public void Atualizar(UsuarioViewModel usuarioViewModel)
        {
            var usuario = _mapper.Map<Usuario>(usuarioViewModel);
            _usuarioService.AtualizarUsuario(usuario);
        }

        public IEnumerable<UsuarioViewModel> ObterTodos()
        {
            return _mapper.Map<IEnumerable<UsuarioViewModel>>(_usuarioService.SelecionarTodosUsuarios());
        }

        public UsuarioViewModel ObterPorId(Guid id)
        {
            return _mapper.Map<UsuarioViewModel>(_usuarioService.SelecionarUsuarioPorId(id));
        }

        public void Exluir(Guid id)
        {
            _usuarioService.ExcluirUsuario(id);
        }
    }
}
