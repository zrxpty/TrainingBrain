using System;
using System.Linq;
using TrainingBrain.Articles;

var tasks = typeof(ArticleBase).Assembly.GetTypes()
    .Where(t => typeof(ArticleBase).IsAssignableFrom(t) && !t.IsAbstract)
    .Select(t => (ArticleBase)Activator.CreateInstance(t)!)
    .ToList();

Console.WriteLine($"Найдено задач: {tasks.Count}\n");

foreach (var task in tasks)
{
    Console.WriteLine($"=== {task.Name} ===");
    
    await task.RunAsync();
    
    Console.WriteLine("====================");
}

Console.WriteLine("Все задачи выполнены!");