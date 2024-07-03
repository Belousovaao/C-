using System.Dynamic;
using Task_2._1;

internal class Program
{
    private static void Main(string[] args)
    {
        PostOffice post = new PostOffice();
        Cashier cashier1 = new Cashier("Петрова Марья Михайловна");
        Operator operator1 = new Operator("Соловьёва Василиса Сергеевна");
        Postman postman1 = new Postman("Кузнецов Григорий Петрович");
        postman1.IsBusy = true;
        post.Poll();
        
    }
    
}