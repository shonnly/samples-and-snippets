using System;

namespace ObjectPooling
{
	internal class ExpensiveObject
    {
		private readonly ObjectPool _objectPool = null;

		public ExpensiveObject(ObjectPool objectPool)
		{
			_objectPool = objectPool;
		}

		~ExpensiveObject()
		{
			_objectPool.ReturnBackToPool(this);
			GC.ReRegisterForFinalize(this);
		}
	}
}
