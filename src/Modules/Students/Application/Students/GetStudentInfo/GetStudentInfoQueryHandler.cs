using Common.Application.Exceptions;
using Common.Application.Handlers;
using Microsoft.EntityFrameworkCore;
using Students.Application.Data;

namespace Students.Application.Students.GetStudentInfo;

public sealed class GetStudentInfoQueryHandler : IQueryHandler<GetStudentInfoQuery, StudentInfoDto>
{
    private readonly IStudentsDbContext _ctx;

    public GetStudentInfoQueryHandler(IStudentsDbContext ctx) => _ctx = ctx;

    public async Task<StudentInfoDto> Handle(GetStudentInfoQuery request, CancellationToken cancellationToken)
    {
        var student = await _ctx
            .Students
            .Where(s => s.Id == request.Id)
            .Join(_ctx.Tickets,
                s => s.Id,
                t => t.OwnerId,
                (s, t) => new StudentInfoDto(s.Id, s.Name, s.Faculty, t.Code, t.DiscountType, t.CreatedAt)
            )
            .FirstOrDefaultAsync(cancellationToken);

        return student is null
            ? throw new NotFoundException($"Cannot find student with ID: {request.Id}.")
            : student;
    }
}