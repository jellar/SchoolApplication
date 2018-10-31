using SchoolApplication.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Data.Repository
{
    public class CourseRepository : RepositoryBase<Course>, ICourseRepository
    {
        public CourseRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }

    public interface ICourseRepository : IRepository<Course> { }
}
