namespace DesignPattern.Controllers.BehavioralPatterns.Memento
{
    public interface IArticleService
    {
        ArticleModel? GetById(Guid id);
        ArticleModel CreateArticle(ArticleModel article);
        ArticleModel? UpdateArticle(Guid id, ArticleModel updated);
        bool UndoLastChange(Guid id);
    }

    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _repo;
        private readonly IArticleHistoryService _history;

        public ArticleService(IArticleRepository repo, IArticleHistoryService history)
        {
            _repo = repo;
            _history = history;
        }

        public ArticleModel? GetById(Guid id) => _repo.GetById(id);

        public ArticleModel CreateArticle(ArticleModel article)
        {
            if (_repo.Add(article))
            {
                return article;
            }
            throw new Exception("Article already exists");
        }

        public ArticleModel? UpdateArticle(Guid id, ArticleModel updated)
        {
            var article = _repo.GetById(id);
            if (article == null) return null;

            _history.Save(id, article.SaveState());

            article.Title = updated.Title;
            article.Content = updated.Content;
            _repo.Update(article);

            return article;
        }

        public bool UndoLastChange(Guid id)
        {
            var article = _repo.GetById(id);
            if (article == null) return false;

            var memento = _history.Undo(id);
            if (memento == null) return false;

            article.RestoreState(memento);
            _repo.Update(article);

            return true;
        }
    }
}
