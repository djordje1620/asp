using AutoMapper;
using Rentaly.Application.DTOs;
using Rentaly.Domain.Entities;

namespace Rentaly.Implementation.Mappings;

public class ReviewProfile : Profile
{
    public ReviewProfile()
    {
        CreateMap<CreateReviewDto, Review>();
    }
}