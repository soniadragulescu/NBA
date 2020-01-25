using System;
using System.Collections.Generic;
using System.Text;

namespace MAP_lab10v2.Entities
{
	class Meci:Entity<string>
	{
		private string echipa1;

		public string Echipa1
		{
			get { return echipa1; }
			set { echipa1 = value; }
		}

		private string echipa2;

		public string Echipa2
		{
			get { return echipa2; }
			set { echipa2 = value; }
		}

		private DateTime date;

		public DateTime Data
		{
			get { return date; }
			set { date = value; }
		}

		public Meci(string id, string echipa1, string echipa2, DateTime data): base(id)
		{
			this.echipa1 = echipa1;
			this.echipa2 = echipa2;
			this.date = data;
		}

		public override string ToString()
		{
			return this.Id + ";" + echipa1 + ";" + echipa2 + ";" + Data.ToString("dd/MM/yyyy") ;
		}
	}
}
