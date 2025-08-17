namespace TrainingBrain.Articles;

public class TestArticle : ArticleBase
{
    public override string Name  => "TestArticle";

    public override Task RunAsync()
    {
        Console.WriteLine("Выполняюсь");
        return Task.CompletedTask;
    }
}