using MAP_lab10v2.Entities;
using MAP_lab10v2.repos;
using MAP_lab10v2.services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace MAP_lab10v2
{
	class Program
	{
		static void Main(string[] args)
		{
			creareEntitati creator = new creareEntitati();
			//creator.initEntitati();
			MeciRepo meciRepo = new MeciRepo("C:\\Users\\sonia\\source\\repos\\MAP_lab10v2\\MAP_lab10v2\\data\\meciuri.txt");
			JucatorRepo jucatorRepo = new JucatorRepo("C:\\Users\\sonia\\source\\repos\\MAP_lab10v2\\MAP_lab10v2\\data\\jucatori.txt");
			JucatorActivRepo jucatorActivRepo = new JucatorActivRepo("C:\\Users\\sonia\\source\\repos\\MAP_lab10v2\\MAP_lab10v2\\data\\test.txt");
			//creator.initMeciuri(meciRepo, jucatorRepo);
			ServiceFiltrari filtrari = new ServiceFiltrari(meciRepo,jucatorRepo,jucatorActivRepo);
			var jucatori = filtrari.jucatoriEchipa("1");
			foreach (Jucator j in jucatori)
				Console.WriteLine(j);

			var jucatoriActivi = filtrari.jucatoriActiviMeci("1");
			foreach (JucatorActiv j in jucatoriActivi)
				Console.WriteLine(j);

			string pattern = "dd/MM/yyyy";
			DateTime parsedDate1, parsedDate2;
			DateTime.TryParseExact("01/01/1999", pattern, null, DateTimeStyles.None, out parsedDate1);
			DateTime.TryParseExact("01/01/2007", pattern, null, DateTimeStyles.None, out parsedDate2);
			var meciuri = filtrari.meciuriPerioada(parsedDate1,parsedDate2);
			foreach (Meci m in meciuri)
				Console.WriteLine(m);

			Console.WriteLine(filtrari.scor("1"));

			NrJucatori nj1 = new NrJucatori(filtrari.scorMeci);//filtrari.scorMeci("1");
			Console.WriteLine(nj1("1"));

			NrJucatori nj2 = new NrJucatori(filtrari.scorJucator);
			Console.WriteLine(nj2("194"));

			UI ui = new UI(filtrari);
			ui.Run();
		}
	}
}
