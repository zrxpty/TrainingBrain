namespace TrainingBrain.Services;

public class Car
{
    public string Id { get; }
    
    public Car(string id)
    {
        Id = id;
    }
    
    public async Task ParkAsync(SemaphoreSlim parkingSemaphore)
    {
        await parkingSemaphore.WaitAsync();

        try
        {
            Console.WriteLine($"Машина {Id} припарковалась.");
            // имитация времени на парковку/остановку
            await Task.Delay(Random.Shared.Next(1000, 4000));
            Console.WriteLine($"Машина {Id} уехала.");
        }
        finally
        {
            parkingSemaphore.Release();
        }
    }
}