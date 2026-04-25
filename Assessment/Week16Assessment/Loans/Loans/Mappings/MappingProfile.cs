using AutoMapper;
using Loans.DTOs;
using Loans.Models;
namespace Loans.Mappings
{

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LoanRequestDto, LoanApplication>();
            CreateMap<LoanApplication, LoanResponseDto>();
        }
    }

}
