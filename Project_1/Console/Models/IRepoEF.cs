using System;

namespace Models
{
    public interface IRepoEF<T>
    {
        List<T> GetAllTrainers();
    }

    public interface IRepoEF_E<T>
    {
        List<T> GetAllEducation();
    }

    public interface IRepoEF_S<T>
    {
        List<T> GetAllSkills();
    }

    public interface IRepoEF_C<T>
    {
        List<T> GetAllCompanies();
    }
}
