using System.Text;

namespace TrainingBrain.Articles;

public class TaskBarrierDemo : ArticleBase
{
    public override string Name => "Barrier Demo";
    static string[] words1 = new string[] { "brown",  "jumps", "the", "fox", "quick"};
    static string[] words2 = new string[] { "dog", "lazy","the","over"};
    static string solution = "the quick brown fox jumps over the lazy dog.";
    static bool success = false;
    
    static Barrier barrier = new Barrier(2, (b) =>
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < words1.Length; i++)
        {
            sb.Append(words1[i]);
            sb.Append(" ");
        }
        for (int i = 0; i < words2.Length; i++)
        {
            sb.Append(words2[i]);
            if (i < words2.Length - 1)
                sb.Append(" ");
        }
        sb.Append(".");

        Console.WriteLine($"\n=== Завершена фаза {barrier.CurrentPhaseNumber} ===");
        Console.WriteLine($"Комбинация: {sb}");

        if (String.CompareOrdinal(solution, sb.ToString()) == 0)
        {
            success = true;
            Console.WriteLine($"\n🎉 Решение найдено за {barrier.CurrentPhaseNumber} фаз(ы)!");
        }
        else
        {
            Console.WriteLine("❌ Решение не совпало, продолжаем поиск...");
        }
    });
    
    public override async Task RunAsync()
    {
        Thread t1 = new Thread(() => Solve(words1));
        Thread t2 = new Thread(() => Solve(words2));
        t1.Start();
        t2.Start();

        // Чтобы окно консоли не закрылось сразу.
        Console.ReadLine();
    }

    // Используем алгоритм перемешивания Кнута — Фишера — Йетса для случайного переставления элементов массива.
    // Для простоты требуется, чтобы оба массива слов были решены в одной и той же фазе.
    // Успех только левой или правой части не сохраняется и не учитывается.
    static void Solve(string[] wordArray)
    {
        while(success == false)
        {
            Random random = new Random();
            for (int i = wordArray.Length - 1; i > 0; i--)
            {
                int swapIndex = random.Next(i + 1);
                string temp = wordArray[i];
                wordArray[i] = wordArray[swapIndex];
                wordArray[swapIndex] = temp;
            }

            // Здесь мы должны остановиться, чтобы проверить результаты
            // работы всех потоков. Это выполняется в делегате «после фазы»,
            // который задаётся в конструкторе Barrier.
            barrier.SignalAndWait();
        }
    }
}
