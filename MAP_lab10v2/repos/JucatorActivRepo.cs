using MAP_lab10v2.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MAP_lab10v2.repos
{
	class JucatorActivRepo : IRepository<string, JucatorActiv>, IRepoFile<string, JucatorActiv>
	{
		private List<JucatorActiv> jucatori = new List<JucatorActiv>();
		private string fileName;

		public JucatorActivRepo(string fileName)
		{
			this.fileName = fileName;
			readFromFile();
		}

		public JucatorActiv delete(string id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<JucatorActiv> findAll()
		{
			return jucatori;
		}

		public JucatorActiv findOne(string id)
		{
			foreach (JucatorActiv j in jucatori)
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
				string id,idMeci,line;
				int nrPuncte;
				Tip tip=Tip.Inactiv;
				while ((line = reader.ReadLine()) != null)
				{
					string[] args = line.Split(";");
					id = args[0];
					idMeci = args[1];
					nrPuncte = Int32.Parse(args[2]);
					switch (args[3])
					{
						case "Participant":
							tip = Tip.Participant;
							break;
						case "Rezerva":
							tip = Tip.Rezeva;
							break;
						default:
							break;
					}

					JucatorActiv jucator = new JucatorActiv(id, idMeci, nrPuncte,tip);
					jucatori.Add(jucator);
				}
			}
		}

		public JucatorActiv save(JucatorActiv entity)
		{
			JucatorActiv j = findOne(entity.Id);
			if (entity != null)
			{
				jucatori.Add(entity);

			}
			this.writeToFile();
			return entity;

		}

		public JucatorActiv update(JucatorActiv entity)
		{
			throw new NotImplementedException();
		}

		public void writeToFile()
		{
			using (StreamWriter writer = new StreamWriter(fileName))
			{
				string line;
				writer.Flush();
				foreach (JucatorActiv j in jucatori)
				{
					line = j.ToString();
					writer.WriteLine(line);
				}
			}
		}
	}
}
