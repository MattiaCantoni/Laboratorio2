using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzAPP.Models
{
    internal class Pizza
    {
		private string _nome;

		public string Nome
		{
			get { return _nome; }
			set { _nome = value; }
		}

		private float _prezzo;

		public float Prezzo
		{
			get { return _prezzo; }
			set { _prezzo = value; }
		}

		private string _image;

		public string Image
		{
			get { return _image; }
			set { _image = value; }
		}

		private string _ingredienti;

		public string Ingredienti
		{
			get { return _ingredienti; }
			set { _ingredienti = value; }
		}

		
	}
}
