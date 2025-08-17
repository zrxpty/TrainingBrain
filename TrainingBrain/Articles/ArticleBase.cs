namespace TrainingBrain.Articles;

public abstract class ArticleBase
{
    public abstract string Name { get; }
    
    public virtual void Run() { }
    public virtual Task RunAsync() =>  Task.CompletedTask;
}