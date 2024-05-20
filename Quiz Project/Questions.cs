using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp
{
    internal class Questions
    {
        int correctAnswer;
        string questionText;
        string[] answerText = new string[4];

        public string QuestionsText { get => questionText; set => questionText = value; }
        public int CorrectAnswer { get => correctAnswer; set => correctAnswer = value; }

        void SetAnswer(int index, string text)
        {
            answerText[index] = text;
        }
        public string GetAnswer(int index)
        {
            return answerText[index];
        }

        public Questions(int correctAnswer, string questionsText, List<string> answersText)
        {
            QuestionsText = questionsText;

            for (int i = 0; i < 4; i++)
            {
                SetAnswer(i, answersText[i]);
            }

            CorrectAnswer = correctAnswer;
        }
    }
}
