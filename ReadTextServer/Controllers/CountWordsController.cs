using Microsoft.AspNetCore.Mvc;
using ReadTextServer.Services;
using RESTModels;

namespace ReadTextServer.Controllers
{
    [Route("api/countwords")]
    [ApiController]
    public class CountWordsController : ControllerBase
    {
        private IWordCounterService _wordCounterService;

        public CountWordsController(IWordCounterService wordCounterService)
        {
            _wordCounterService = wordCounterService;
        }

        [HttpPost]
        public ActionResult<GetWordCountResponse> GetWordCount([FromBody] GetWordCountRequest request)
        {
            int wordCount = _wordCounterService.CountWords(request.Text);

            GetWordCountResponse response = new GetWordCountResponse()
            {
                WordCount = wordCount
            };

            return Ok(response);
        }
    }
}