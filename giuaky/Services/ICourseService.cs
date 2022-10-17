using giuaky.Models;
using giuaky.DTOs;

namespace giuaky.Services
{
    public interface ICourseService
    {
        List<Course> GetCourses();

        List<Course> GetCoursesBySearch(SearchObject Data);

        List<Course> Sort(Sort sortType);

        Course? GetCourseById(int Id);

        void CreateCourse(Course course);

        void UpdateCourse(Course course);

        void DeleteCourse(int Id);

        List<TypeCourse> GetTypeCourses();

    }
}