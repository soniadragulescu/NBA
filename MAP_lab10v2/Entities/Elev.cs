using System;
using System.Collections.Generic;
using System.Text;

namespace MAP_lab10v2.Entities
{
	class Elev:Entity<string>
	{
		private string nume;

		public string Nume
		{
			get { return nume; }
			set { nume = value; }
		}

		private string scoala;

		public string Scoala
		{
			get { return scoala; }
			set { scoala = value; }
		}

		public Elev(string id, string nume, string scoala): base(id)
		{
			this.nume = nume;
			this.scoala = scoala;
		}

		public override string ToString()
		{
			return Id+ ";" + Nume +";"+Scoala+" ";
		}


	}
}
