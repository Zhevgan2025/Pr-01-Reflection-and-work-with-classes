using System;

namespace ClassLibrary
{
    public class Manufacturer
    {
        public string Name { get; set; }
        public string Address { get; set; }
        private bool IsAChildCompany { get; set; }

        public Manufacturer()
        {
        }

        public void Create(string name, string address, bool isAChildCompany)
        {
            Name = name;
            Address = address;
            IsAChildCompany = isAChildCompany;
        }

        public void PrintObject()
        {
            System.Console.WriteLine($"Name: {Name}, Address: {Address}, IsAChildCompany: {IsAChildCompany}");
        }
    }
}