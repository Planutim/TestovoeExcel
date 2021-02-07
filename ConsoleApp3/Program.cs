using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                //Client client1 = new Client
                //{
                //    Name = "Тестовый клиент1",
                //    BirthDate = DateTime.Parse("1991-03-08"),
                //    PhoneNumber = "123",
                //    Address = "г.Баткен",
                //    SocialNumber = "12345678901234"
                //};
                //Client client2 = new Client
                //{
                //    Name = "Тестовый клиент2",
                //    BirthDate = DateTime.Parse("1996-04-20"),
                //    PhoneNumber = "456",
                //    Address = "г.Бишкек",
                //    SocialNumber = "98765432101234",
                //};
                //Client client3 = new Client
                //{
                //    Name = "Тестовый клиент3",
                //    BirthDate = DateTime.Parse("1995-08-04"),
                //    PhoneNumber = "789",
                //    Address = "г. Нарын",
                //    SocialNumber = "12345543211234"
                //};
                //Client client4 = new Client
                //{
                //    Name = "Тестовый клиент4",
                //    BirthDate = DateTime.Parse("1989-02-25"),
                //    PhoneNumber = "012",
                //    Address = "с. Комсомольское",
                //    SocialNumber = "12345671234567"
                //};
                //db.Clients.AddRange(client1, client2, client3, client4);
                //db.SaveChanges();
                List<Client> clients = db.Clients.ToList();

                foreach(var client in clients)
                {
                    if (client.SocialNumber == "12345678901234")
                    {
                        ExcelFormatter excelFormatter = null;
                        try
                        {
                            excelFormatter = new ExcelFormatter(client);
                            excelFormatter.FillTemplate();
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    }
                }

            }
        }
    }
}
