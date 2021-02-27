using System;
using System.IO;

namespace ReadTextClient.ReadMethods
{
    class FileReadMethod : IReadMethod
    {
        public string Read()
        {
            bool successfull = false;
            string text = null;

            while (!successfull)
            {
                Console.WriteLine("Enter valid file path:");
                string filePath = Console.ReadLine();

                successfull = File.Exists(filePath);

                if (successfull)
                {
                    text = File.ReadAllText(filePath);
                }
                

            }

            return text;
        }
    }
}
