using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp3
{
    class ExcelFormatter
    {
        Client client;
        public ExcelFormatter(Client client)
        {
            this.client = client;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        public void FillTemplate()
        {
            if (!File.Exists(@"Template\example.xlsx"))
            {
                throw new Exception("There is no template file!");
            }
            using (var package = new ExcelPackage())
            {
                using (var stream = File.OpenRead(@"Template\example.xlsx"))
                {
                    package.Load(stream);
                }

                var sheet = package.Workbook.Worksheets[0];
            
                for(int i = sheet.Dimension.Start.Row; i <= sheet.Dimension.End.Row; i++)
                {
                    for(int j = sheet.Dimension.Start.Column; j <= sheet.Dimension.End.Column; j++)
                    {

                        if(sheet.Cells[i,j].Text.Contains("Дата заполнения"))
                        {
                            sheet.Cells[i, j + 1].Value = DateTime.Now.ToString("dd.MM.yyyy");
                        }

                        string value = "";
                        switch (sheet.Cells[i, j].Text)
                        {
                            case "[ID]":
                                value = client.ID.ToString();break;
                            case "[Name]":
                                value = client.Name;break;
                            case "[BirthDate]":
                                value = client.BirthDate.ToString("dd.MM.yyyy");break;
                            case "[PhoneNumber]":
                                value = client.PhoneNumber;break;
                            case "[Address]":
                                value = client.Address;break;
                            case "[SocialNumber]":
                                value = client.SocialNumber;break;
                        }
                        if(value != "")
                        {
                            sheet.Cells[i, j].Value = value;
                        }
                    }
                }

                try
                {
                    Directory.CreateDirectory("Result");
                    package.SaveAs(new FileInfo(@"Result\result.xlsx"));
                    Console.WriteLine("Work is done");
                }
                catch
                {
                    throw new Exception("Could not create directory!");
                }
            }
        }
    }
}
