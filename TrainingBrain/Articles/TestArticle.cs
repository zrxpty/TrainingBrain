namespace TrainingBrain.Articles;

public class TestArticle : ArticleBase
{
    public override string Name  => "TestArticle";
    
    public override void Run()
    {
        Console.WriteLine("Выполняюсь");
    }
}