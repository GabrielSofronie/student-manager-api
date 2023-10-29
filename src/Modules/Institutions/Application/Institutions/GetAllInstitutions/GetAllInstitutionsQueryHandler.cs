using Common.Application.Handlers;
using Institutions.Application.Data;
using Microsoft.EntityFrameworkCore;

namespace Institutions.Application.Institutions.GetAllInstitutions;

public sealed class GetAllInstitutionsQueryHandler : IQueryHandler<GetAllInstitutionsQuery, InstitutionsDto>
{
    private readonly IInstitutionsDbContext _ctx;

    public GetAllInstitutionsQueryHandler(IInstitutionsDbContext ctx) => _ctx = ctx;

    public async Task<InstitutionsDto> Handle(GetAllInstitutionsQuery request, CancellationToken cancellationToken)
    {
        var institutions = await _ctx.Institutions
            .Select(i => new InstitutionDto(i.Name(), i.Code()))
            .ToListAsync(cancellationToken);

        return new InstitutionsDto(institutions);
    }
}