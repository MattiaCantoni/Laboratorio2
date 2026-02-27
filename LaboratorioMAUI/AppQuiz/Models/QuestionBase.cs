using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppQuiz.Models
{
    internal abstract class QuestionBase
    {
		private string _text;

		//Proprietà
		public string Text
		{
			get 
			{ 
				return _text; 
			}
			set 
			{ 
				_text = value; 
			}
		}

		private int _points;

        //Proprietà
        public int Points
		{
			get 
			{ 
				return _points;
			}
			set 
			{
				if (value < 0)
				{
					_points = 0;
				}
				else
				{
					_points = (int)value;
				}
				_points = value; 
			}
		}

		private string _imgName;

		public string ImgName
		{
			get 
			{ 
				return _imgName; 
			}
			set 
			{ 
				_imgName = value; 
			}
		}


		//Costruttore
		public QuestionBase(string text, int points, string imgName)
		{
			Text = text;
			Points = points;
		}

		public abstract bool CheckAnswer(string userAnswer);

	}
}
