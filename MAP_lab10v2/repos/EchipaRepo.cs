using MAP_lab10v2.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MAP_lab10v2.repos
{
	class EchipaRepo : IRepository<string, Echipa>, IRepoFile<string, Echipa>
	{
		private List<Echipa> echipe = new List<Echipa>();
		private string fileName;

		public EchipaRepo(string fileName)
		{
			this.fileName = fileName;
			this.readFromFile();
		}

		public Echipa delete(string id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Echipa> findAll()
		{
			return echipe;
		}

		public Echipa findOne(string id)
		{
			foreach(Echipa e in echipe)
			{
				if (e.Id == id)
					return e;
			}
			return null;
		}

		public void readFromFile()
		{
			using (StreamReader reader = new StreamReader(this.fileName))
			{
				string id, nume, line;
				while ((line = reader.ReadLine()) != null)
				{
					string[] args = line.Split(";");
					id = args[0];
					nume = args[1];
					Echipa echipa = new Echipa(id, nume);
					echipe.Add(echipa);
				}
			}
		}

		public Echipa save(Echipa entity)
		{
			throw new NotImplementedException();
		}

		public Echipa update(Echipa entity)
		{
			throw new NotImplementedException();
		}

		public void writeToFile()
		{
			throw new NotImplementedException();
		}
	}
}
