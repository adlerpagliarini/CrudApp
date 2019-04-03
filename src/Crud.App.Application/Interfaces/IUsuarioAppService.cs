using Crud.App.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Crud.App.Application.Interfaces
{
    public interface IUsuarioAppService
    {
        void Registrar(UsuarioViewModel usuarioViewModel);
        void Atualizar(UsuarioViewModel usuarioViewModel);
        void Exluir(Guid id);
        IEnumerable<UsuarioViewModel> ObterTodos();
        UsuarioViewModel ObterPorId(Guid id);
    }
}
