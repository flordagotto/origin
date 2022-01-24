using AutoMapper;
using Origin.DataContext;
using Origin.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Origin.Helpers
{
    public class DomainToDtoProfile : Profile
    {
        public DomainToDtoProfile()
        {
            CreateMap<Tarjeta, TarjetaDto>()
                .ForMember(mapTo => mapTo.Numero, mapFrom => mapFrom.MapFrom(entity => entity.Numero))
                .ForMember(mapTo => mapTo.Balance, mapFrom => mapFrom.MapFrom(entity => entity.Balance))
                .ForMember(mapTo => mapTo.Bloqueada, mapFrom => mapFrom.MapFrom(entity => entity.Bloqueada))
                .ForMember(mapTo => mapTo.Pin, mapFrom => mapFrom.MapFrom(entity => entity.Pin))
                ;

            CreateMap<Balance, BalanceDto>()
                .ForMember(mapTo => mapTo.IdOperacion, mapFrom => mapFrom.MapFrom(entity => entity.IdOperacion))
                .ForMember(mapTo => mapTo.Hora, mapFrom => mapFrom.MapFrom(entity => entity.Hora))
                .ForMember(mapTo => mapTo.IdTarjeta, mapFrom => mapFrom.MapFrom(entity => entity.IdTarjeta))
                ;

            CreateMap<Retiro, RetiroDto>()
                .ForMember(mapTo => mapTo.IdOperacion, mapFrom => mapFrom.MapFrom(entity => entity.IdOperacion))
                .ForMember(mapTo => mapTo.Hora, mapFrom => mapFrom.MapFrom(entity => entity.Hora))
                .ForMember(mapTo => mapTo.IdTarjeta, mapFrom => mapFrom.MapFrom(entity => entity.IdTarjeta))
                .ForMember(mapTo => mapTo.Cantidad, mapFrom => mapFrom.MapFrom(entity => entity.Cantidad))
                ;
        }
    }
}
