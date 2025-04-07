namespace DesignPattern.Controllers.BehavioralPatterns.Memento
{
    public class ArticleModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public ArticleMementoModel SaveState()
        {
            return new ArticleMementoModel(Title, Content);
        }

        public void RestoreState(ArticleMementoModel memento)
        {   
            Title = memento.Title;
            Content = memento.Content;
        }
    }

    public class ArticleMementoModel
    {
        public string Title { get; }
        public string Content { get; }

        public ArticleMementoModel(string title, string content)
        {
            Title = title;
            Content = content;
        }
    }

}
