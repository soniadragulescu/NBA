using System;
using System.Collections.Generic;
using System.Text;

namespace MAP_lab10v2.Entities
{
	class Jucator:Elev
	{

		private string idEchipa;

		public string IdEchipa
		{
			get { return idEchipa; }
			set { idEchipa = value; }
		}

		public Jucator(string id, string nume, string scoala, string echipa):base(id, nume,scoala)
		{
			this.idEchipa = echipa;
		}

		public override string ToString()
		{
			return base.ToString()+";"+ idEchipa;
		}
	}
}
