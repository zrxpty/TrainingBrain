namespace TrainingBrain;

public class GenerateSpotGrid
{
    public  List<GridOrder> Generate(GridSpotConfigure config)
    {
        if (config.StartPrice >= config.EndPrice)
            throw new ArgumentException("StartPrice должен быть меньше EndPrice");

        var orders = new List<GridOrder>();
        decimal step = (config.EndPrice - config.StartPrice) / (config.Levels - 1);

        decimal midPrice = (config.StartPrice + config.EndPrice) / 2;

        for (int i = 0; i < config.Levels; i++)
        {
            decimal price = config.StartPrice + step * i;

            // корректируем с учетом комиссии (чтобы прибыль покрывала fee)
            decimal adjustedPrice = price * (1 + config.CommissionRate);

            string side = price < midPrice ? "Buy" : "Sell";

            orders.Add(new GridOrder
            {
                Symbol = config.Symbol,
                Side = side,
                Price = Math.Round(adjustedPrice, 2), // округляем по нужной точности
                Quantity = config.Quantity
            });
        }

        return orders;
    }
}