using AutoMapper;
using Rentaly.Application.DTOs;
using Rentaly.Domain.Entities;


namespace Rentaly.Implementation.Mappings;
public class AuditLogProfile : Profile
{
    public AuditLogProfile()
    {

        CreateMap<AuditLog, AuditLogDto>();

    }
}
