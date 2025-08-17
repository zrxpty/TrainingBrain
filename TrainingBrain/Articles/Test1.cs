using TrainingBrain.Services;

namespace TrainingBrain.Articles;

public class Test1 : ArticleBase
{
    public override string Name => "Задача: «Парковка на 5 мест»";
    static SemaphoreSlim semaphore = new SemaphoreSlim(5, 5);
    public override async Task RunAsync()
    {
        var tasks = new Task[15];

        for (int i = 0; i < 15; i++)
        {
            int id = i + 1;
            
            tasks[i] = Task.Run(async () =>
            {
                var car = new Car($"{id}_{Thread.CurrentThread.ManagedThreadId}");
                await car.ParkAsync(semaphore);
            });
        }
        
        await Task.WhenAll(tasks);
    }
}