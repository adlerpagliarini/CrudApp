using AutoMapper;
using Crud.App.Application.ViewModels;
using Crud.App.Domain.Usuarios;
using Crud.App.Domain.Usuarios.ValueObjects;

namespace Crud.App.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<UsuarioViewModel, Usuario>()
            .ConstructUsing(c => new Usuario(new NomeCompleto(c.GetPrimeiroNome(), c.GetSegundoNome(), c.GetUltimosNomes()), c.Email, 
            new Telefone(c.Getddd(), c.GetTelefone())))
            .ForMember(d => d.Id, option => option.MapFrom(o => o.Id))
            .ForAllOtherMembers(o => o.Ignore());
        }
    }
}
