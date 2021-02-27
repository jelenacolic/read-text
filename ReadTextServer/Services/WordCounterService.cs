namespace ReadTextServer.Services
{
    public class WordCounterService : IWordCounterService
    {
        public int CountWords(string text)
        {
            int count = 0;
            int i = 0;

            while (i < text.Length && (char.IsWhiteSpace(text[i]) || char.IsPunctuation(text[i])))
                i++;

            
            while (i < text.Length)
            {
                while (i < text.Length && !char.IsWhiteSpace(text[i]) && !char.IsPunctuation(text[i]))
                    i++;

                count++;

                while (i < text.Length && (char.IsWhiteSpace(text[i]) || char.IsPunctuation(text[i])))
                    i++;
            }

            return count;
        }
    }
}
