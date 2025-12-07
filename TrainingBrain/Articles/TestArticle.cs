namespace TrainingBrain.Articles;

public class TestArticle : ArticleBase
{
    public override string Name  => "TestArticle";

    public override Task RunAsync()
    {
        Console.WriteLine("Выполняюсь");

        var qwe = new GenerateSpotGrid();
        
        var grid = qwe.Generate(new (){
            Symbol = "BTCUSDT",
            StartPrice = 107000m,
            EndPrice = 115000m,
            Levels = 20,
            Quantity = 0.001m,
            CommissionRate = 0.0018m
        });
        
        foreach (var order in grid)
        {
            Console.WriteLine($"{order.Side} {order.Quantity} {order.Symbol} @ {order.Price}");
        }
        
        return Task.CompletedTask;
    }
}