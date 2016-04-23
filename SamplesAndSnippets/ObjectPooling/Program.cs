using System;

namespace ObjectPooling
{
	class Program
	{
		static void Main(string[] args)
		{
			var pool = new ObjectPool();

			var firstClient = new Client(pool, "Client-1");
			var task1 = firstClient.DoWorkAsync();

			var secondClient = new Client(pool, "Client-2");
			var task2 = secondClient.DoWorkAsync();

			var lastClient = new Client(pool, "Client-3");
			var task3 = lastClient.DoWorkAsync();

			Console.WriteLine();
			Console.ReadKey();

			GC.Collect(); // we need this to run destructors on collected objects

			Console.ReadKey();

			GC.Collect(); // we need this to run destructors on collected objects

			Console.ReadKey();
		}
	}
}
