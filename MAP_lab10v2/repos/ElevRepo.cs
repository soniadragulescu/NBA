using MAP_lab10v2.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

delegate Elev elevDelegate(string s);
namespace MAP_lab10v2.repos
{
	class ElevRepo : IRepository<string, Elev>, IRepoFile<string,Elev>
	{
		private List<Elev> elevi=new List<Elev>();
		private string fileName;
		//private fileDelegate del;
		public ElevRepo(string fileName)
		{
			this.fileName = fileName;
			this.readFromFile();
		}

		public string FileName
		{
			get { return fileName; }
			set { fileName = value; }
		}


		public Elev delete(string id)
		{
			Elev elevToRemove = findOne(id);
			if(elevToRemove!=null)
				elevi.Remove(elevToRemove);
			return elevToRemove;
			this.writeToFile();
		}

		public IEnumerable<Elev> findAll()
		{
			return elevi;
		}

		public Elev findOne(string id)
		{
			foreach (Elev e in elevi)
			{
				if (e.Id == id)
				{
					return e;
				}

			}

			return null;
		}

		/*elevDelegate del = delegate (string id)
		{
			Elev elevToRemove = findOne(id);
			if (elevToRemove != null)
				elevi.Remove(elevToRemove);
			this.writeToFile();
			return elevToRemove;

		}*/
		public void readFromFile()
		{
			using (StreamReader reader = new StreamReader(this.fileName))
			{
				string id, nume, scoala, line;
				while ((line = reader.ReadLine()) != null)
				{
					string[] args = line.Split(";");
					id = args[0];
					nume = args[1];
					scoala = args[2];
					Elev elev = new Elev(id, nume, scoala);
					elevi.Add(elev);
				}
			}
		}

		public Elev save(Elev entity)
		{
			Elev elev = findOne(entity.Id);
			if(elev!=null)
				elevi.Add(entity);
			this.writeToFile();
			return elev;
		}

		public Elev update(Elev entity)
		{
			Elev elev = findOne(entity.Id);
			if (elev != null)
			{
				elevi.Remove(entity);
				elevi.Add(entity);
				return null;
			}
			return entity;
			this.writeToFile();
		}

		public void writeToFile()
		{
			using (StreamWriter writer = new StreamWriter(fileName))
			{
				writer.Flush();
				foreach (Elev e in elevi)
				{
					string line = e.Id + ";" + e.Nume + ";" + e.Scoala;
					writer.WriteLine(line);
				}
			}
		}
	}
}
