namespace TrainingBrain.services;

public class SafeCounter
{
      private int Value { get; set; } = 0;
      private object locker = new object();

      public void Increment()
      {
            lock (locker)
                  Value++;
      }

      public void Decrement()
      {
            lock (locker)
                  Value--;
      }

      public int GetValue()
      {
            lock (locker)
            {
                  return Value;
            }
      }
}