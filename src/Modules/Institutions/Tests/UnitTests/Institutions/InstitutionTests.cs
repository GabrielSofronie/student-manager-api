using Institutions.Domain.Institutions;

namespace Institutions.UnitTests.Institutions;

public class InstitutionTests
{
    [Fact]
    public void CreateInstitution_IsSuccessful()
    {
        var institution = Institution.Create(
            "institutionEmail",
            "institutionPasswd",
            "institutionName",
            "institutionCode",
            "institutionCity",
            "institutionAddress",
            "institutionOwnership",
            "institutionType"
        );

        Assert.False(institution.IsDefault());
    }
}