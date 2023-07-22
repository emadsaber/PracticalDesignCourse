namespace Lab03_SingleResponsibility.Solution;
class Invoice
{
    public string Serial { get; set; }

}
class Employee{
    public string Email { get; set; }
    public string Name { get; set; }
}

class EmailSender{
    public void SendEmail(Invoice invoice, Employee employee)
    {
        Console.WriteLine(
            $"Hi {employee.Name}, An invoice with serial {invoice.Serial} "
                + $"was successfully sent to your email: {employee.Email}"
        );
    }
}