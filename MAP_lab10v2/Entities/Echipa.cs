using System;
using System.Collections.Generic;
using System.Text;

namespace MAP_lab10v2.Entities
{
	class Echipa:Entity<string>
	{
		private string nume;
		public string Nume
		{
			get { return Nume; }
			set { Nume = value; }
		}

		public Echipa(string id, string nume) : base(id)
		{
			this.nume = nume;
		}

		public override string ToString()
		{
			return Id+";"+nume;
		}
	}
}
