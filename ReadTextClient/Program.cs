using ReadTextClient.ReadMethods;
using ReadTextClient.Services;
using System;
using System.Threading.Tasks;

namespace ReadTextClient
{
    class Program
    {
        
        static async Task Main(string[] args)
        {
            ReadMethodFactory factory = new ReadMethodFactory();
            

            Console.WriteLine("Enter read method (number)");
            Console.WriteLine("Valid options are:");
            Console.WriteLine($"{ReadMethodEnum.CONSOLE} - {(int)ReadMethodEnum.CONSOLE}");
            Console.WriteLine($"{ReadMethodEnum.FILE} - {(int)ReadMethodEnum.FILE}");
            Console.WriteLine($"{ReadMethodEnum.DATABASE} - {(int)ReadMethodEnum.DATABASE}");

            string line;
            while (!string.IsNullOrEmpty(line = Console.ReadLine()))
            {
                int selectedInt;
                bool successfullInt = int.TryParse(line, out selectedInt);

                if (successfullInt)
                {
                    if (Enum.IsDefined(typeof(ReadMethodEnum), selectedInt))
                    {
                        ReadMethodEnum selectedEnum = (ReadMethodEnum)selectedInt;

                        IReadMethod reader = factory.GetReadMethod(selectedEnum);

                        string text = reader.Read();

                        if (text != null)
                        {
                            try
                            {
                                int wordCount = await new WordCounterService().SendRequest(text);
                                Console.WriteLine($"Word count is {wordCount}");

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                        }
                    }
                    else
                    {
                        Console.WriteLine("You entered an invalid option.");
                    }
                }

                Console.WriteLine("Enter read method (number)");
            }
        }
    }
}
