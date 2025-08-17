using TrainingBrain.services;

var counter = new SafeCounter();

foreach (var item in Enumerable.Range(1, 1000))
{
    var thread = new Thread((o) =>
        ExecuteSafeCounter(counter));
    
    thread.Start();
}

counter.GetValue();


void ExecuteSafeCounter(SafeCounter counter)
{
    counter.Increment();
    
    Console.WriteLine($"айди потока {Thread.CurrentThread.ManagedThreadId} " +
                      $"число {counter.GetValue()}" +
                      $"");
}