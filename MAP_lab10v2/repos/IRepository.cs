using MAP_lab10v2.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAP_lab10v2.repos
{
	public interface IRepository<ID,E> where E:Entity<ID>
	{


		E findOne(ID id);
		IEnumerable<E> findAll();

		E save(E entity);

		E delete(ID id);

		E update(E entity);
	}
}
