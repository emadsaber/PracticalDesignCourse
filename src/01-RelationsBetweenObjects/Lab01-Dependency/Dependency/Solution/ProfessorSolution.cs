namespace Dependency.Solution
{
    public interface ICourse{
        int Id { get; set; }
        decimal CalculatePriceAfterTax();
    }
    public class Professor
    {
        //Here the professor class depends on ICourse not Course
        private readonly ICourse course;

        //And also here, whenever the Course entity changes, the Professor is safe :D
        public Professor(ICourse course)
        {
            this.course = course;
        }

        public void PrintCourseInfo(){
            Console.WriteLine($"The course with id {course.Id} has a price of {course.CalculatePriceAfterTax()}");
        }
    }

    public class Course : ICourse
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public decimal CalculatePriceAfterTax()
        {
            return Price * 1.14M;
        }
    }
}
