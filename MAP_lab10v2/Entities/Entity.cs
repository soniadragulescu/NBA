using System;
using System.Collections.Generic;
using System.Text;

namespace MAP_lab10v2.Entities
{
	public class Entity<T>
	{
		private T id;

		public T Id
		{
			get { return id; }
			set { id = value; }
		}

		public Entity(T id)
		{
			this.id = id;
			//Id = id;
		}

	}
}
