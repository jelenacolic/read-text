using ReadTextClient.Models;
using ReadTextClient.Repositories;
using System;

namespace ReadTextClient.ReadMethods
{
    class DBReadMethod : IReadMethod
    {
        private Repository<TextModel> _repository;

        public DBReadMethod()
        {
            _repository = Repository<TextModel>.Instance;
        }

        public string Read()
        {
            bool successfull = false;
            string text = null;
            int id = -1;

            while (!successfull)
            {
                Console.WriteLine("Enter entity id:");
                string idStr = Console.ReadLine();

                successfull = int.TryParse(idStr, out id);

                if (successfull)
                {
                    TextModel tm = _repository.Get(id);

                    if (tm == null)
                    {
                        Console.WriteLine($"Record with id = {id} doesn't exist");
                    } 
                    else
                    {
                        text = tm.Text;
                    }
                    
                }

            }
            return text;

        }
    }
}
