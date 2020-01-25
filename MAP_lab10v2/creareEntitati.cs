using MAP_lab10v2.Entities;
using MAP_lab10v2.repos;
using System;
using System.Collections.Generic;
using System.IO;

namespace MAP_lab10v2
{
	class creareEntitati
	{
		public void initEntitati()
		{
			//64 nume persoane
			List<string> persoane = new List<string>();
			using (StreamReader reader = new StreamReader("C:\\Users\\sonia\\source\\repos\\MAP_lab10v2\\MAP_lab10v2\\data\\persoane.txt"))
			{
				string nume;
				while ((nume = reader.ReadLine()) != null)
				{
					nume.Trim();
					persoane.Add(nume);
					//Console.WriteLine(nume);
				}
			}

			//pt fiecare scoala si echipa adaug 15 jucatori
			var rand = new Random();
			int nrEchipe = 1, idJucatori = 1;
			List<Jucator> jucatori = new List<Jucator>();
			List<Echipa> echipe = new List<Echipa>();
			using (StreamReader reader = new StreamReader("C:\\Users\\sonia\\source\\repos\\MAP_lab10v2\\MAP_lab10v2\\data\\scoli_echipe.txt"))
			{
				string echipa, scoala, line, nume;
				while ((line = reader.ReadLine()) != null)
				{
					string[] values = line.Split(" - ");
					scoala = values[0];
					echipa = values[1];
					Echipa e = new Echipa(nrEchipe.ToString(), echipa);
					echipe.Add(e);
					//Console.WriteLine(scoala);
					//Console.WriteLine(e);
					int i = 1;
					while (i <= 15)
					{
						int nrPersoana = rand.Next() % persoane.Count;
						nume = persoane[nrPersoana];
						Jucator jucator = new Jucator(idJucatori.ToString(), nume, scoala, e.Id);
						//Console.WriteLine(j);
						jucatori.Add(jucator);
						idJucatori++;
						i++;
					}
					nrEchipe++;

				}
			}
			using (StreamWriter writer = new StreamWriter("C:\\Users\\sonia\\source\\repos\\MAP_lab10v2\\MAP_lab10v2\\data\\jucatori.txt"))
			{
				string line;
				writer.Flush();
				foreach (Jucator j in jucatori)
				{
					line = j.ToString();
					writer.WriteLine(line);
				}
			}
			using (StreamWriter writer = new StreamWriter("C:\\Users\\sonia\\source\\repos\\MAP_lab10v2\\MAP_lab10v2\\data\\echipe.txt"))
			{
				string line;
				writer.Flush();
				foreach (Echipa e in echipe)
				{
					line = e.ToString();
					writer.WriteLine(line);
				}
			}

		}

		public void initMeciuri(MeciRepo meciRepo, JucatorRepo jucatorRepo)
		{
			IEnumerable<Meci> meciuri = meciRepo.findAll();
			IEnumerable<Jucator> jucatori = jucatorRepo.findAll();
			List<JucatorActiv> jucatoriActivi = new List<JucatorActiv>();
			foreach(Meci m in meciuri)
			{
				string idMeci = m.Id;
				string idEchipa1 = m.Echipa1;
				string idEchipa2 = m.Echipa2;
				Tip tip = Tip.Inactiv;
				var rand = new Random();
				
					foreach(Jucator j in jucatori)
					{
						if (j.IdEchipa == idEchipa1 || j.IdEchipa== idEchipa2)
						{
							if (rand.Next()%3==1)
							{
								tip = Tip.Participant;
							}
							if (rand.Next() % 3 == 2)
							{
								tip = Tip.Rezeva;
							}
							if (tip == Tip.Participant || tip == Tip.Rezeva)
							{
							JucatorActiv jucatorActiv = new JucatorActiv(j.Id, idMeci, rand.Next() % 30 + 1, tip);
							jucatoriActivi.Add(jucatorActiv);
							}
						}
					}
				
			}
			using (StreamWriter writer = new StreamWriter("C:\\Users\\sonia\\source\\repos\\MAP_lab10v2\\MAP_lab10v2\\data\\test.txt"))
			{
				string line;
				writer.Flush();
				foreach (JucatorActiv j in jucatoriActivi)
				{
					line = j.ToString();
					writer.WriteLine(line);
				}
			}
		}
	}
}
