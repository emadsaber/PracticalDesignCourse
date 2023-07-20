namespace Lab02_SingleResponsibility;
class Program{

    public static void Main(string[] args){

        //Problem Test
        var pInvoice = new Problem.Invoice{
            Serial = "INV-2023-07-20-00001",
            EmployeeName = "Moaz",
            EmployeeEmail = "moaz.emad@email.com"
        };

        pInvoice.SendEmail();

        //Solution Test
        var sInvoice = new Solution.Invoice{Serial = "INV-2023-07-20-00002"};
        var sEmployee = new Solution.Employee{Name = "Marawan", Email = "marawan.emad@email.com"};
        var sender = new Solution.EmailSender();

        sender.SendEmail(sInvoice, sEmployee);
    }
}