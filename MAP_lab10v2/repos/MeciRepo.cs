using MAP_lab10v2.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace MAP_lab10v2.repos
{
	class MeciRepo : IRepository<string, Meci>, IRepoFile<string, Meci>
	{
		private List<Meci> meciuri = new List<Meci>();
		private string fileName;
		private string v;

		public MeciRepo(string filename)
		{
			this.fileName = filename;
			this.readFromFile();
		}

		public string FileName
		{
			get { return fileName; }
			set { fileName = value; }
		}


		public Meci delete(string id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Meci> findAll()
		{
			return meciuri;
		}

		public Meci findOne(string id)
		{
			foreach(Meci m in meciuri)
			{
				if (m.Id == id)
					return m;
			}
			return null;
		}

		public void readFromFile()
		{
			using (StreamReader reader = new StreamReader(this.fileName))
			{
				string id, idEchipa1, idEchipa2,line;
				string pattern = "dd/MM/yyyy";
				DateTime data, parsedDate;
				while ((line = reader.ReadLine()) != null)
				{
					string[] args = line.Split(";");
					id = args[0];
					idEchipa1 = args[1];
					idEchipa2 = args[2];
					DateTime.TryParseExact(args[3], pattern, null, DateTimeStyles.None, out parsedDate);
					Meci meci = new Meci(id, idEchipa1, idEchipa2, parsedDate);
					meciuri.Add(meci);
				}
			}
		}

		public Meci save(Meci entity)
		{
			throw new NotImplementedException();
		}

		public Meci update(Meci entity)
		{
			throw new NotImplementedException();
		}

		public void writeToFile()
		{
			using (StreamWriter writer = new StreamWriter(fileName))
			{
				writer.Flush();
				foreach (Meci m in meciuri)
				{
					//string line = m.Id + ";" + m.Echipa1 + ";" + m.Echipa2+";"m.Data("dd/MM/yyyy");
					string line = m.ToString();
					writer.WriteLine(line);
				}
			}
		}
	}
}
