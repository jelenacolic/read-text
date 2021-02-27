using System;

namespace ReadTextClient.ReadMethods
{
    class ConsoleReadMethod : IReadMethod
    {
        public string Read()
        {
            Console.WriteLine("Enter text for sending:");

            string line; 
            string text = string.Empty;


            while (!string.IsNullOrEmpty(line = Console.ReadLine()))
            {
                text += Environment.NewLine + line;
            }

            return text;
        }
    }
}
