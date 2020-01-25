using System;
using System.Collections.Generic;
using System.Text;

namespace MAP_lab10v2.Entities
{
	class JucatorActiv : Entity<string>
	{
		private string idMeci;

		public string IdMeci
		{
			get { return idMeci; }
			set { idMeci = value; }
		}

		private int nrPuncteInscrise;

		public int NrPuncteInscrise
		{
			get { return nrPuncteInscrise; }
			set { nrPuncteInscrise = value; }
		}

		private Tip tip;

		public JucatorActiv(string id,string idMeci, int nrPuncteInscrise, Tip tip):base(id)
		{
			IdMeci = idMeci;
			
			NrPuncteInscrise = nrPuncteInscrise;
			
			Tip = tip;
			
		}

		public Tip Tip
		{
			get { return tip; }
			set { tip = value; }
		}

		public override string ToString()
		{
			return this.Id+";"+idMeci+";"+nrPuncteInscrise.ToString()+";"+tip;
		}
	}
}
