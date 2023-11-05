using Common.Application.Handlers;
using Institutions.Domain.Institutions;
using Institutions.Domain.Students;

namespace Institutions.Application.Students.ImportStudents;

public sealed class ImportStudentsBatchCommandHandler : ICommandHandler<ImportStudentsBatchCommand, int>
{
    private readonly IInstitutionRepository _institutionRepository;
    private readonly IStudentRepository _studentRepository;

    public ImportStudentsBatchCommandHandler(IInstitutionRepository institutionRepository, IStudentRepository studentRepository)
    {
        _institutionRepository = institutionRepository;
        _studentRepository = studentRepository;
    }

    public async Task<int> Handle(ImportStudentsBatchCommand request, CancellationToken cancellationToken)
    {
        var institutionId = new InstitutionId(request.InstitutionId);
        var institution = await _institutionRepository.FindAsync(institutionId);
        if (institution.IsDefault())
        {
            return 0;
        }

        var students = request
            .Students
            .Select(s => Student.Create(institutionId, s.Name, s.Faculty, institution.Code(), s.RegistrationNumber));

        var insertTasks = students.Select(async s => await InsertStudent(s));

        await Task.WhenAll(insertTasks);

        return await Commit();
    }

    private async Task InsertStudent(Student student)
    {
        try
        {
            await _studentRepository.AddAsync(student);
        }
        catch (Exception ex)
        {
            //
        }
    }

    private async Task<int> Commit()
    {
        try
        {
            return await _studentRepository.Commit();
        }
        catch (Exception ex)
        {
            return 0;
        }
    }
}