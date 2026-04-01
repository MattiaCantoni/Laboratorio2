using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSpeseCorrezione.Models
{
    internal class Spesa : VoceBase
    {
		private double _importo;

		public double Importo
		{
			get { return _importo; }
			set { _importo = value; }
		}

        public override string ToRiga()
        {
            return this.Descrizione + ";" +this.Importo;
        }

		//Metodo statico di classe
		public static Spesa FromRiga(string riga) {

			//1. Controllo base: la riga non deve essere vuota
			if (string.IsNullOrWhiteSpace(riga)) return null;

			//Split ritorna i tokens (pezzi) separati per ;
			string[] parti = riga.Split(';');

			//2. Controllo che ci siano almeno Descrizione e importo
			if (parti.Length < 2) return null;

			//3. TryParse: prova a convertire.
			//Se riesce, mette il valore in 'importoValido' e restituisce
			if(double.TryParse(parti[1], out double importoValido))
			{
				return new Spesa
				{
					Descrizione = parti[0],
					Importo = importoValido
				};
			}

			//4. Se il parsing fallisce restituiamo null
			return null;

		}

	}
}
