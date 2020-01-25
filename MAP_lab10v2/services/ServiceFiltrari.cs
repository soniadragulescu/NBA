using MAP_lab10v2.Entities;
using MAP_lab10v2.repos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

delegate int NrJucatori(string s);
namespace MAP_lab10v2.services
{
	class ServiceFiltrari
	{
		private MeciRepo meciRepo;
		private JucatorRepo jucatorRepo;
		private JucatorActivRepo jucatorActivRepo;

		public ServiceFiltrari(MeciRepo meciRepo, JucatorRepo jucatorRepo, JucatorActivRepo jucatorActivRepo)
		{
			this.meciRepo = meciRepo;
			this.jucatorRepo = jucatorRepo;
			this.jucatorActivRepo = jucatorActivRepo;
		}

		public IEnumerable<Jucator> jucatoriEchipa(string echipa)
		{
			IEnumerable<Jucator> jucatori = jucatorRepo.findAll();
			var rez = jucatori
				.Where(j => j.IdEchipa == echipa)
				.Select(j => j);
			return rez;
		}

		public IEnumerable<JucatorActiv> jucatoriActiviMeci(string meci)
		{
			IEnumerable<JucatorActiv> jucatori = jucatorActivRepo.findAll();
			var rez = jucatori
				.Where(j => j.IdMeci == meci && (j.Tip==Tip.Participant||j.Tip==Tip.Rezeva))
				.Select(j => j);
			return rez;
		}

		public IEnumerable<Meci> meciuriPerioada(DateTime start, DateTime finish)
		{
			IEnumerable<Meci> meciuri = meciRepo.findAll();
			var rez = meciuri
				.Where(m => m.Data<=finish&& m.Data>=start)
				.Select(m => m);
			return rez;
		}

		public string scor(string meci)
		{
			IEnumerable<JucatorActiv> jucatori = jucatorActivRepo.findAll();
			IEnumerable<JucatorActiv> jucatori2 = jucatorActivRepo.findAll();
			Meci m = meciRepo.findOne(meci);
			string echipa1 = m.Echipa1;
			string echipa2 = m.Echipa2;
			var rez1 = jucatori2
				.Where(j=> j.IdMeci==meci&&jucatorRepo.findOne(j.Id).IdEchipa==echipa1)
				.Select( j=> j.NrPuncteInscrise);
			var rez2 = jucatori
				.Where(j => j.IdMeci == meci && jucatorRepo.findOne(j.Id).IdEchipa == echipa2)
				.Select(j => j.NrPuncteInscrise);
			int scor1 = 0,scor2=0;
			foreach (int i in rez1)
				scor1 += i;
			foreach (int i in rez2)
				scor2 += i;
			return "Echipa1: "+scor1.ToString()+" - Echipa2: "+scor2.ToString();
		}

		public int scorMeci(string meci)
		{
			IEnumerable<JucatorActiv> jucatori = jucatorActivRepo.findAll();
			var rez = jucatori
				.Where(j => j.IdMeci == meci)
				.Select(j => j.NrPuncteInscrise);
			int scor = 0;
			foreach (int i in rez)
				scor += i;
			return scor;
		}

		public int scorJucator(string id)
		{
			IEnumerable<JucatorActiv> jucatori = jucatorActivRepo.findAll();
			var rez = jucatori
				.Where(j => j.Id == id)
				.Select(j => j.NrPuncteInscrise);
			int scor = 0;
			foreach (int i in rez)
				scor += i;
			return scor;
		}
	}
}
