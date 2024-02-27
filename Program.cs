using System;
using System.Reflection;

namespace AdvancedReflectionExample
{
    class Classes
    {
        public int PublicField;
        private string _privateField;
        protected double ProtectedField;
        internal DateTime InternalField;
        protected internal bool ProtectedInternalField;

        public void PublicMethod(int param1 = 0, string param2 = "")
        {
            Console.WriteLine($"Method1 called with param1: {param1}, param2: {param2}");
        }

        private int PrivateMethod(int arg)
        {
            Console.WriteLine("Method 3 called with argument: " + arg);
            return PublicField + arg;
        }

        protected void ProtectedMethod()
        {
            Console.WriteLine("Method 2 called");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // 1. Creating an instance of MyClass
                var myClassInstance = new Classes();

                // 2. Demonstrating Type and TypeInfo
                Type myClassType = myClassInstance.GetType();
                TypeInfo myClassTypeInfo = myClassType.GetTypeInfo();

                // 3. Demonstrating MemberInfo
                MemberInfo[] members = myClassType.GetMembers(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
                foreach (var member in members)
                {
                    Console.WriteLine($"Member Name: {member.Name}, Member Type: {member.MemberType}");
                }

                // 4. Demonstrating FieldInfo
                FieldInfo[] fields = myClassType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
                foreach (var field in fields)
                {
                    Console.WriteLine($"Field Name: {field.Name}, Field Type: {field.FieldType}");
                }

                // 5. Demonstrating MethodInfo and invoking a method using Reflection
                MethodInfo method = myClassType.GetMethod("PrivateMethod", BindingFlags.NonPublic | BindingFlags.Instance);
                if (method != null)
                {
                    method.Invoke(myClassInstance, new object[] { 10 }); // Передача параметру 10 методу
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.ReadLine();
        }
    }
}
