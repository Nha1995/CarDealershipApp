using AutoMapper;
using CarDealershipApp.Web.Models;
using CarDealershipDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipApp.Web
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<Client, ClientVm>()
                .IncludeBase<Client, ClientBaseModel>();
            CreateMap<Client, ClientBaseModel>();

            CreateMap<ClientBaseModel, Client>()
                .ForMember(e => e.Cars, _ => _.Ignore())
                .ForMember(e => e.Id, _ => _.Ignore());

            CreateMap<Car, CarVm>()
                .IncludeBase<Car, CarBaseModel>();
            CreateMap<Car, CarBaseModel>();

            CreateMap<CarBaseModel, Car>()
                .ForMember(e => e.Client, _ => _.Ignore())
                .ForMember(e => e.ClientId, _ => _.Ignore())
                .ForMember(e => e.Id, _ => _.Ignore())
                .ForMember(e => e.Sold, _ => _.Ignore());
        }
    }
}