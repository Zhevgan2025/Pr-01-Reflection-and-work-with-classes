using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Task1
{
    class Program1
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter a class name: ");
                string className = Console.ReadLine();

                Console.Write("Enter a method name: ");
                string methodName = Console.ReadLine();

                Console.Write("Enter arguments separated by commas: ");
                string inputArgs = Console.ReadLine();

                Assembly assembly = Assembly.GetExecutingAssembly();

                Type type = assembly.GetTypes()
                    .FirstOrDefault(t => t.Name.Equals(className, StringComparison.OrdinalIgnoreCase));

                if (type == null)
                {
                    throw new Exception("Class not found");
                }

                object obj = Activator.CreateInstance(type);

                MethodInfo method = type.GetMethods()
                    .FirstOrDefault(m => m.Name.Equals(methodName, StringComparison.OrdinalIgnoreCase));

                if (method == null)
                {
                    throw new Exception("Method not found.");
                }

                ParameterInfo[] parameters = method.GetParameters();
                string[] enteredArgs;

                if (string.IsNullOrWhiteSpace(inputArgs))
                {
                    enteredArgs = new string[0];
                }
                else
                {
                    enteredArgs = inputArgs.Split(',');
                }

                if (parameters.Length != enteredArgs.Length)
                {
                    throw new Exception("The number of arguments does not match the number of method parameters.");
                }

                object[] convertedArgs = new object[parameters.Length];

                for (int i = 0; i < parameters.Length; i++)
                {
                    string value = enteredArgs[i].Trim();
                    Type paramType = parameters[i].ParameterType;

                    convertedArgs[i] = Convert.ChangeType(value, paramType);
                }

                method.Invoke(obj, convertedArgs);
            }
            catch (TargetInvocationException ex)
            {
                Console.WriteLine("Error executing method: " + ex.InnerException?.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Invalid argument format.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.ReadKey();
        }
    }
}
