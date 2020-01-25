using MAP_lab10v2.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MAP_lab10v2.repos
{
	class JucatorRepo : IRepository<string, Jucator>, IRepoFile<string, Jucator>
	{
		private List<Jucator> jucatori = new List<Jucator>();
		private string fileName;

		public JucatorRepo(string fileName)
		{
			this.fileName = fileName;
			this.readFromFile();
		}

		public Jucator delete(string id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Jucator> findAll()
		{
			return jucatori;
		}

		public Jucator findOne(string id)
		{
			foreach(Jucator j in jucatori)
			{
				if (j.Id == id)
					return j;
			}
			return null;
		}

		public void readFromFile()
		{
			using (StreamReader reader = new StreamReader(fileName))
			{
				string id, nume, scoala, echipa, line;
				while ((line = reader.ReadLine()) != null)
				{
					string[] args = line.Split(";");
					id = args[0];
					nume = args[1];
					scoala = args[2];
					echipa = args[3];
					Jucator jucator = new Jucator(id, nume, scoala, echipa);
					jucatori.Add(jucator);
				}
			}
		}

		public Jucator save(Jucator entity)
		{
			Jucator j=findOne(entity.Id);
			if (entity != null)
			{
				jucatori.Add(entity);
				
			}
			this.writeToFile();
			return entity;

		}

		public Jucator update(Jucator entity)
		{
			throw new NotImplementedException();
		}

		public void writeToFile()
		{
			using (StreamWriter writer = new StreamWriter(fileName))
			{
				string line;
				writer.Flush();
				foreach (Jucator j in jucatori)
				{
					line = j.ToString();
					writer.WriteLine(line);
				}
			}
		}
	}
}
