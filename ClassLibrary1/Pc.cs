using System;

namespace ClassLibrary
{
    public class PC
    {
        private int ID { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public string PCType { get; set; }

        public PC()
        {
        }

        public void Create(int id, string model, string serialNumber, string pcType)
        {
            ID = id;
            Model = model;
            SerialNumber = serialNumber;
            PCType = pcType;
        }

        public void PrintObject()
        {
            System.Console.WriteLine($"ID: {ID}, Model: {Model}, SerialNumber: {SerialNumber}, PCType: {PCType}");
        }
    }
}