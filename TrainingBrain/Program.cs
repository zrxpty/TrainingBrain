int cnt = 0;
var list = Enumerable.Range(0, 10000).ToList();
var options = new ParallelOptions() {MaxDegreeOfParallelism = 8};
Parallel.ForEach(list, options, (element) =>
{

    /*var localCnt = Interlocked.Increment(ref cnt);
    if(localCnt!= cnt)*/
    var localCnt = 0;    
    localCnt++;    
    Console.WriteLine("{0} {1} {2}",cnt, localCnt, Thread.CurrentThread.ManagedThreadId);
});


MyData obj = new MyData() { X = 1 };
MyData newObj = new MyData() { X = 2 };

Interlocked.Exchange(ref obj, newObj); // атомарно меняем ссылку

class MyData { public int X; }