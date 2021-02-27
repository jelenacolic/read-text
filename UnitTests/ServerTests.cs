using ReadTextServer.Services;
using Xunit;

namespace UnitTests
{
    public class ServerTests
    {
        private WordCounterService wordCounterService;
        public ServerTests()
        {
            wordCounterService = new WordCounterService();
        }

        [Theory]
        [InlineData("One two three", 3)]
        [InlineData("One,two, three", 3)]
        [InlineData("One. two.three", 3)]
        [InlineData("One?two? three", 3)]
        [InlineData("One! two!three", 3)]
        [InlineData("One;two:three", 3)]
        public void WordCountTests(string text, int countExpected)
        {
            var count = wordCounterService.CountWords(text);

            Assert.Equal(count, countExpected);
        }
    }
}
