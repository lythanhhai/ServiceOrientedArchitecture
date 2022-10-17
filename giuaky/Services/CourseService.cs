using giuaky.Models;
using giuaky.Services;
using giuaky.DTOs;

namespace giuaky.Services
{
    public class CourseService : ICourseService
    {
        private readonly DataContext _context;
        public CourseService(DataContext context)
        {
            _context = context;
        }
        public List<Course> GetCourses()
        {
            return _context.Courses.ToList();
        }

        public List<Course> GetCoursesByType(int type)
        {
            var listResult = new List<Course>();
            foreach (var course in _context.Courses.ToList())
            {
                if (course.TypeCourseId == type)
                {
                    listResult.Add(course);
                }
            }
            return listResult;
        }
        List<Course> ICourseService.Sort(Sort sortType)
        {
            var listResult = new List<Course>();
            if (String.Equals("Name", sortType.typeSort))
            {
                listResult = _context.Courses.OrderBy(c => c.Name).ToList();
            }
            if (String.Equals("Type", sortType.typeSort))
            {
                listResult = _context.Courses.OrderBy(c => c.TypeCourseId).ToList();
            }

            return listResult;
        }
        List<Course> ICourseService.GetCoursesBySearch(SearchObject Data)
        {
            var listCourse = GetCoursesByType(Data.typeCourse);
            var listResult = new List<Course>();

            if (Data.Search == null)
            {
                return listCourse;
            }
            foreach (var course in listCourse)
            {
                if (course.Name.Contains(Data.Search) || course.Slug.Contains(Data.Search) || course.Content.Contains(Data.Search))
                {
                    listResult.Add(course);
                }
            }
            return listResult;
        }
        public Course? GetCourseById(int Id)
        {
            // return _context.Products.Find(Id);
            return _context.Courses.FirstOrDefault(p => p.Id == Id);
        }

        void ICourseService.CreateCourse(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        void ICourseService.UpdateCourse(Course course)
        {
            var existedCourse = GetCourseById(course.Id);
            if (existedCourse == null) return;
            existedCourse.Name = course.Name;
            existedCourse.Slug = course.Slug;
            existedCourse.TypeCourseId = course.TypeCourseId;
            existedCourse.Overall = course.Overall;
            existedCourse.Content = course.Content;
            existedCourse.Image = course.Image;
            _context.Courses.Update(existedCourse);
            _context.SaveChanges();
        }

        public void DeleteCourse(int Id)
        {
            // throw new NotImplementedException();
            var course = GetCourseById(Id);
            if (course == null) return;
            // Console.WriteLine("oke");
            _context.Courses.Remove(course);
            _context.SaveChanges();
        }

        List<TypeCourse> ICourseService.GetTypeCourses()
        {
            return _context.TypeCourse.ToList();
        }
    }
}