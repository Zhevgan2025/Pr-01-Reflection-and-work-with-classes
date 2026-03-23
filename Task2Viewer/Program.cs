using System;
using System.Reflection;

namespace Task2Viewer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Assembly assembly = Assembly.LoadFrom(
                    @"C:\Users\dubic\OneDrive\Desktop\c#learn\ClassLibrary1\bin\Debug\net8.0\ClassLibrary.dll"
                );

                Type pcType = assembly.GetType("ClassLibrary.PC");
                Type manufacturerType = assembly.GetType("ClassLibrary.Manufacturer");

                if (pcType == null)
                {
                    throw new Exception("The PC class was not found in the library.");
                }

                if (manufacturerType == null)
                {
                    throw new Exception("The Manufacturer class was not found in the library.");
                }

                object pcObject = Activator.CreateInstance(pcType);
                object manufacturerObject = Activator.CreateInstance(manufacturerType);

                MethodInfo pcCreateMethod = pcType.GetMethod("Create");
                MethodInfo pcPrintMethod = pcType.GetMethod("PrintObject");

                MethodInfo manufacturerCreateMethod = manufacturerType.GetMethod("Create");
                MethodInfo manufacturerPrintMethod = manufacturerType.GetMethod("PrintObject");

                if (pcCreateMethod == null || pcPrintMethod == null)
                {
                    throw new Exception("The Create or PrintObject method was not found in the PC class.");
                }

                if (manufacturerCreateMethod == null || manufacturerPrintMethod == null)
                {
                    throw new Exception("The Create or PrintObject method was not found in the Manufacturer class.");
                }

                pcCreateMethod.Invoke(pcObject, new object[] { 1, "Lenovo ThinkPad", "SN123456", "Laptop" });
                manufacturerCreateMethod.Invoke(manufacturerObject, new object[] { "Lenovo", "China, Beijing", true });

                Console.WriteLine("Object information:\n");

                pcPrintMethod.Invoke(pcObject, null);
                manufacturerPrintMethod.Invoke(manufacturerObject, null);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Error: The DLL file was not found.");
            }
            catch (TargetInvocationException ex)
            {
                Console.WriteLine("Error while invoking a method: " + ex.InnerException?.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("General error: " + ex.Message);
            }

            Console.ReadKey();
        }
    }
}
