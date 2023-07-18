class Program
{
    public static void Main(string[] args){
        //Problem Test
        var pCourse = new Dependency.Problem.Course{
            Id = 1,
            Price = 1000,
        };
        var pProfessor = new Dependency.Problem.Professor();
        pProfessor.PrintCourseInfo(pCourse); //Prints => The course with id 1 has a price of 1140.00

        //Solution Test

        var sCourse = new Dependency.Solution.Course{
            Id = 2,
            Price = 2000,
        };
        var sProfessor = new Dependency.Solution.Professor();
        sProfessor.PrintCourseInfo(sCourse); //Prints => The course with id 2 has a price of 2280.00
    }
}