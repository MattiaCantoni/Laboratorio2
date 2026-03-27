using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSpese.Models
{
    internal class Spesa : VoceBase
    {
        private string _descrizione;

        public string Descrizione
        {
            get { return _descrizione; }
            set { _descrizione = value; }
        }

        private string _importo;

        public string Importo
        {
            get { return _importo; }
            set { _importo = value; }
        }

        public override string ToRiga()
        {
            return this.Descrizione + ";" + this.Importo;
        }

        public static Spesa FromRiga(string riga)
        {
            string[] parti = riga.Split(';');
            if (parti.Length < 2) 
            {
                return null;
            }
            Spesa spesa = new Spesa(parti[0], parti[1]);
            return spesa;

        }

        public Spesa(string descrizione, string importo) : base()
        {
            Descrizione = descrizione;
            Importo = importo;
        }
    }
}
