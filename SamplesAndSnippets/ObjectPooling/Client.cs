using System;
using System.Threading;
using System.Threading.Tasks;

namespace ObjectPooling
{
	internal class Client
	{
		private readonly string _id;
		private readonly ObjectPool _pool;

		public Client(ObjectPool pool, string id)
		{
			_pool = pool;
			_id = id;
		}


		public Task DoWorkAsync()
		{
			return Task.Run(new Action(DoWork));
		}

		private void DoWork()
		{
			var instance = _pool.GetAvailableInstanceOrNull();
			if (instance == null)
			{
				var count = 0;
				while (instance == null)
				{
					Console.WriteLine($"{_id}: Waiting for available instance...");
					Thread.Sleep(500);
					count++;
					instance = _pool.GetAvailableInstanceOrNull();
				}

				Console.WriteLine($"{_id}: Got an instance after {count} requests. Now doing work...");
				Thread.Sleep(3000);
				Console.WriteLine($"{_id}: Done!");
			}
			else
			{
				Console.WriteLine($"{_id}: Got an instance on the first try. Doing work...");
				Thread.Sleep(3000);
				Console.WriteLine($"{_id}: Done!");
			}
		}
	}
}
