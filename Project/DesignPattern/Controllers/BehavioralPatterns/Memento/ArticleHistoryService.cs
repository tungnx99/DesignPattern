namespace DesignPattern.Controllers.BehavioralPatterns.Memento
{
    public interface IArticleHistoryService
    {
        void Save(Guid articleId, ArticleMementoModel memento);
        ArticleMementoModel Undo(Guid articleId);
    }

    public class ArticleHistoryService : IArticleHistoryService
    {
        private readonly Dictionary<Guid, Stack<ArticleMementoModel>> _history = new();

        public void Save(Guid articleId, ArticleMementoModel memento)
        {
            if (!_history.ContainsKey(articleId))
                _history[articleId] = new Stack<ArticleMementoModel>();

            _history[articleId].Push(memento);
        }

        public ArticleMementoModel Undo(Guid articleId)
        {
            if (_history.ContainsKey(articleId) && _history[articleId].Count > 0)
                return _history[articleId].Pop();

            return null;
        }
    }
}
