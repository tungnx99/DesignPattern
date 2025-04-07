namespace DesignPattern.Controllers.BehavioralPatterns.Memento
{
    public interface IArticleRepository
    {
        ArticleModel? GetById(Guid id);
        bool Add(ArticleModel article);
        void Update(ArticleModel article);
    }

    public class ArticleRepository : IArticleRepository
    {
        private readonly List<ArticleModel> _articles = new();

        public ArticleModel? GetById(Guid id) => _articles.FirstOrDefault(a => a.Id == id);

        public bool Add(ArticleModel article)
        {
            article.Id = Guid.NewGuid();
            _articles.Add(article);
            return true;
        }

        public void Update(ArticleModel article)
        {
            var index = _articles.FindIndex(a => a.Id == article.Id);
            if (index >= 0)
                _articles[index] = article;
        }
    }

}
