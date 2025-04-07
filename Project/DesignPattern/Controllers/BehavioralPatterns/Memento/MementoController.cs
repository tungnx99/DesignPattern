namespace DesignPattern.Controllers.BehavioralPatterns.Memento
{
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Memento is a behavioral design pattern that lets you save and restore the previous state of an object without revealing the details of its implementation.
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MementoController : ControllerBase
    {
        /// <summary>
        /// 
        /// Pros:
        ///     You can produce snapshots of the object’s state without violating its encapsulation.
        ///     You can simplify the originator’s code by letting the caretaker maintain the history of the originator’s state.
        ///     
        /// Cons:
        ///     The app might consume lots of RAM if clients create mementos too often.
        ///     Caretakers should track the originator’s lifecycle to be able to destroy obsolete mementos.
        ///     Most dynamic programming languages, such as PHP, Python and JavaScript, can’t guarantee that the state within the memento stays untouched.
        ///     
        /// Reference:
        ///     https://refactoring.guru/design-patterns/memento
        /// </summary>

        private readonly IArticleService _service;

        public MementoController(IArticleService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var article = _service.GetById(id);
            return article != null ? Ok(article) : NotFound();
        }

        [HttpPost]
        public IActionResult Create([FromBody] ArticleModel updated)
        {
            var result = _service.CreateArticle(updated);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] ArticleModel updated)
        {
            var result = _service.UpdateArticle(id, updated);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPost("{id}/undo")]
        public IActionResult Undo(Guid id)
        {
            var success = _service.UndoLastChange(id);
            return success ? Ok("Undo successful.") : BadRequest("Nothing to undo.");
        }

        public static void Setup(IServiceCollection services)
        {
            services.AddSingleton<IArticleRepository, ArticleRepository>();
            services.AddSingleton<IArticleService, ArticleService>();
            services.AddSingleton<IArticleHistoryService, ArticleHistoryService>();
        }
    }
}
