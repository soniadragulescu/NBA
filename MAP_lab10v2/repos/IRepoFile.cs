using MAP_lab10v2.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAP_lab10v2.repos
{
	public interface IRepoFile<ID,E> where E:Entity<ID>
	{
		void readFromFile();
		void writeToFile();
	}
}
