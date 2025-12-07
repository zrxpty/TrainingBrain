namespace TrainingBrain;

public class GridSpotConfigure
{
    public string Symbol { get; set; } = "BTCUSDT"; 
    public decimal StartPrice { get; set; }          // стартовая цена
    public decimal EndPrice { get; set; }            // конечная цена
    public int Levels { get; set; } = 20;            // количество уровней
    public decimal Quantity { get; set; }            // объём в базовой валюте (BTC)
    public decimal CommissionRate { get; set; } = 0.0018m; // комиссия (0.18%
    public decimal? TargetProfitPercent { get; set; }
}