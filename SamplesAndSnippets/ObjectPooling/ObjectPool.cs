using System.Collections.Generic;

namespace ObjectPooling
{
	public class ObjectPool
    {
		private readonly List<ExpensiveObject> _pool = new List<ExpensiveObject>();

		public ObjectPool()
		{
			_pool.Add(new ExpensiveObject(this));
		}


		internal void ReturnBackToPool(ExpensiveObject expensiveObject)
		{
			_pool.Add(expensiveObject);
		}

		public ExpensiveObject GetAvailableInstanceOrNull()
		{
			if (_pool != null && _pool.Count > 0)
			{
				var obj = _pool[_pool.Count - 1];
				_pool.RemoveAt(_pool.Count - 1);
				return obj;
			}

			return null;
		}
	}
}
