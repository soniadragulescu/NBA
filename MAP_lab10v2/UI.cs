using MAP_lab10v2.Entities;
using MAP_lab10v2.services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MAP_lab10v2
{
	class UI
	{
		private ServiceFiltrari service;

		public UI(ServiceFiltrari service)
		{
			this.service = service;
		}

		public void Meniu()
		{
			
			Console.WriteLine("1 - Jucatori echipa");
			Console.WriteLine("2 - Jucatori activi meci");
			Console.WriteLine("3 - Meciuri perioada");
			Console.WriteLine("4 - Scor meci");
			Console.WriteLine("0 - Exit");
			Console.Write("Introduceti optiune: ");
		}

		public void Run()
		{
			Meniu();
			string command = Console.ReadLine();
			while (command != "0")
			{
				switch (command)
				{
					case "1":
						jucatoriEchipa();
						break;
					case "2":
						jucatoriActiviMeci();
						break;
					case "3":
						meciuriPerioada();
						break;
					case "4":
						scorMeci();
						break;
					default:
						Console.WriteLine("Invalid command");
						break;
				}
				Meniu();
				command = Console.ReadLine();
			}
		}

		public void jucatoriEchipa()
		{
			
			Console.WriteLine("Echipa cu id-ul: ");

			try
			{
				string idEchipa = Console.ReadLine();
				var jucatori = service.jucatoriEchipa(idEchipa);
				foreach (Jucator j in jucatori)
					Console.WriteLine(j);
			}

			catch (ArgumentOutOfRangeException)
			{
				Console.WriteLine("Invalid team number");
			}
			catch (FormatException)
			{
				Console.WriteLine("Invalid number");
			}
		}

		public void jucatoriActiviMeci()
		{

			Console.WriteLine("Meciul cu id-ul: ");

			try
			{
				string idMeci = Console.ReadLine();
				var jucatori = service.jucatoriEchipa(idMeci);
				foreach (Jucator j in jucatori)
					Console.WriteLine(j);
			}

			catch (ArgumentOutOfRangeException)
			{
				Console.WriteLine("Invalid team number");
			}
			catch (FormatException)
			{
				Console.WriteLine("Invalid number");
			}
		}

		public void meciuriPerioada()
		{
			Console.WriteLine("Data de start(dd/MM/yyyy): ");
			string start = Console.ReadLine();
			Console.WriteLine("Data de finish(dd/MM/yyyy): ");
			string finish = Console.ReadLine();
			string pattern = "dd/MM/yyyy";
			DateTime parsedDate1, parsedDate2;
			DateTime.TryParseExact(start, pattern, null, DateTimeStyles.None, out parsedDate1);
			DateTime.TryParseExact(finish, pattern, null, DateTimeStyles.None, out parsedDate2);
			var meciuri = service.meciuriPerioada(parsedDate1, parsedDate2);
			foreach (Meci m in meciuri)
				Console.WriteLine(m);

		}

		public void scorMeci()
		{
			Console.WriteLine("Id meci: ");
			string idMeci = Console.ReadLine();
		
			Console.WriteLine(service.scor(idMeci));

		}
	}
}
