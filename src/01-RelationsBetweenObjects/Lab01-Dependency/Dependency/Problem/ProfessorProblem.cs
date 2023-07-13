namespace Dependency.Problem
{
    public class Professor
    {
        //Here the Professor class "depends" on the "Course" class
        private readonly Course course;

        //And also here the Professor class "depends" on the "Course" class
        public Professor(Course course)
        {
            this.course = course;
        }

        public void PrintCourseInfo(){
            Console.WriteLine($"The course with id {course.Id} has a price of {course.CalculatePriceAfterTax()}");
        }
    }

    public class Course
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public decimal CalculatePriceAfterTax()
        {
            return Price * 1.14M;
        }
    }
}
