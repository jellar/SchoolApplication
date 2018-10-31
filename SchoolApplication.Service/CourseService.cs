using SchoolApplication.Data;
using SchoolApplication.Data.Infrastructure;
using SchoolApplication.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Service
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository courseRepository;
        private readonly IUnitOfWork unitOfWork;

        public CourseService(ICourseRepository courseRepository, IUnitOfWork unitOfWork)
        {
            this.courseRepository = courseRepository;
            this.unitOfWork = unitOfWork;
        }

       

        public IEnumerable<Course> GetCourses()
        {
            var courses = courseRepository.GetAll().OrderByDescending(c => c.CourseID);
            return courses;
        }
    }

    public interface ICourseService
    {
        IEnumerable<Course> GetCourses();
    }
}
