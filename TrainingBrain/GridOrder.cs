namespace TrainingBrain;

public class GridOrder
{
    public string Symbol { get; set; }
    public string Side { get; set; }   // "Buy" или "Sell"
    public decimal Price { get; set; }
    public decimal Quantity { get; set; }
}
