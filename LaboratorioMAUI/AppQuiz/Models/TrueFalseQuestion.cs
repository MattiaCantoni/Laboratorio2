using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppQuiz.Models
{
	// ':' serve a estendere/implementare la classe/interfaccia 
    internal class TrueFalseQuestion : QuestionBase
    {

		private bool _correctAnswer;

		public bool CorrectAnswer
		{
			get 
			{ 
				return _correctAnswer; 
			}
			set 
			{ 
				_correctAnswer = value; 
			}
		}

		//Instanziare un costruttore con una sottoclasse
		public TrueFalseQuestion(string text, int points, string imgName,bool correctAnswer)
			: base (text, points, imgName)
		{
			CorrectAnswer = correctAnswer;
		}


        public override bool CheckAnswer(string userAnswer)
        {
            return userAnswer.Equals(CorrectAnswer);
        }
    }
}
