namespace TrainingBrain.Articles;

public abstract class ArticleBase
{
    public abstract string Name { get; }
    
    public virtual Task RunAsync() =>  Task.CompletedTask;
}