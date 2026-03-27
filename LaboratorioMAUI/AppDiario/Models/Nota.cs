using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDiario.Models
{
    internal class Nota
    {
		private string _titolo;

		public string Titolo
		{
			get 
			{
				return _titolo; 
			}
			set 
			{
				_titolo = value;
			}
		}

		private string _testo;

		public string Testo
		{
			get 
			{ 
				return _testo; 
			}
			set 
			{
                if (String.IsNullOrEmpty(value))
                {
                    value = "";
                }
                _testo = value; 
			}
		}

		


		public static Nota DaRigaAOggetto(string riga)
		{
			string[] parti = riga.Split(";");

			if (parti.Length < 2) 
			{
				return null;
			}

			Nota nuovaNota = new Nota();

            nuovaNota.Titolo = parti[0];
            nuovaNota.Testo = parti[1];

			return nuovaNota;

		}


		public string DaOggettoARiga()
		{
			return this.Titolo + ";" + this.Testo;
		}
    }
}
