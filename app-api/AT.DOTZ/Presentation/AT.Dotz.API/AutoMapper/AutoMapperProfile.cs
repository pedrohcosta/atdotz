using AT.Dotz.API.ViewModels;
using AutoMapper;
using Entities.Entities;

namespace AT.Dotz.API.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Account, CreateAccountViewModel>().ReverseMap();
            CreateMap<Account, AccountViewModel>().ReverseMap();
            CreateMap<AccountExtract, AccountExtractViewModel>().ReverseMap();
            CreateMap<AccountCard, AccountCardViewModel>().ReverseMap();
            CreateMap<Payment, PaymentViewModel>().ReverseMap();

        }
    }
}
