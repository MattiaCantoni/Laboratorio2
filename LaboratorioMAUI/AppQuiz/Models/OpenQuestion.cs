using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppQuiz.Models
{
    internal class OpenQuestion : QuestionBase
    {
        private String _correctAnswer;

        public String CorrectAnswer
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
        public OpenQuestion(string text, int points, string imgName, String correctAnswer)
            : base(text, points, imgName)
        {
            CorrectAnswer = correctAnswer;
        }


        public override bool CheckAnswer(string userAnswer)
        {
            return userAnswer.ToLower().Trim().Equals(CorrectAnswer);
        }
    }
}
