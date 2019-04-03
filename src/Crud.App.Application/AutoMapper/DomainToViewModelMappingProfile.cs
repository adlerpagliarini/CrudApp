using AutoMapper;
using Crud.App.Application.ViewModels;
using Crud.App.Domain.Usuarios;

namespace Crud.App.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Usuario, UsuarioViewModel>()
                .ForMember(d => d.Nome, option => option.MapFrom(o => $"{o.NomeCompleto.PrimeiroNome} {o.NomeCompleto.SegundoNome} {o.NomeCompleto.UltimoNome}" ))
                .ForMember(d => d.Telefone, option => option.MapFrom(o => $"{o.Telefone.DDD}{o.Telefone.Numero}"));
        }
    }
}
