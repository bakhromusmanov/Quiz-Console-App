using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp
{
    internal class Quiz
    {
        int score;

        int currentQuestion;

        Questions[] questions =
        {
            new Questions(CorrectAnswersList(0),QuestionsList(0), AnswersList(0)),
            new Questions(CorrectAnswersList(1),QuestionsList(1), AnswersList(1)),
            new Questions(CorrectAnswersList(2),QuestionsList(2), AnswersList(2)),
            new Questions(CorrectAnswersList(3),QuestionsList(3), AnswersList(3)),
            new Questions(CorrectAnswersList(4),QuestionsList(4), AnswersList(4))
        };

        static int CorrectAnswersList(int index)
        {
            switch (index)
            {
                case 0: return 2;
                case 1: return 1;
                case 2: return 1;
                case 3: return 2;
                case 4: return 0;
                default: return 10;
            }
        }

        static string QuestionsList(int index)
        {
            switch (index)
            {
                case 0:
                    return "What is a correct syntax to output \"Hello World\" in C#?";
                case 1:
                    return "Which data type is used to create a variable that should store text?";
                case 2:
                    return "How do you create a variable with the numeric value 5?";
                case 3:
                    return "Which operator can be used to compare two values?";
                case 4:
                    return "Which property can be used to find the length of a string";
                default:
                    return " ";
            }
        }

        static List<string> AnswersList(int index)
        {
            List<string> allAnswers = new();
            switch (index)
            {
                case 0:
                    allAnswers.Add("print(\"Hello World\");");
                    allAnswers.Add("cout<<\"Hello World\";");
                    allAnswers.Add("Console.WriteLine(\"Hello World\");");
                    allAnswers.Add("System.out.println(\"Hello World\");");
                    return allAnswers;

                case 1:
                    allAnswers.Add("myString");
                    allAnswers.Add("string");
                    allAnswers.Add("Txt");
                    allAnswers.Add("str");
                    return allAnswers;
                case 2:
                    allAnswers.Add("double x=5;");
                    allAnswers.Add("int x=5;");
                    allAnswers.Add("num x = 5;");
                    allAnswers.Add("x=5;");
                    return allAnswers;
                case 3:
                    allAnswers.Add("><");
                    allAnswers.Add("<>");
                    allAnswers.Add("==");
                    allAnswers.Add("=");
                    return allAnswers;
                case 4:
                    allAnswers.Add("Length");
                    allAnswers.Add("getLength()");
                    allAnswers.Add("length()");
                    allAnswers.Add("length");
                    return allAnswers;
                default:
                    return new();
            }
        }
        public void StartQuiz()
        {
            int userInput;
            
            for(int i = 0; i < 5; i++)
            {
                Console.WriteLine();
                DisplayQuestion(i);
                Console.WriteLine("-------------------------------------------------------------------------");
                DisplayAnswer(i);
                Console.WriteLine("-------------------------------------------------------------------------");

                while (true)
                {   
                    Console.Write("Please, enter the correct option: ");

                    string input = Console.ReadLine();

                    userInput = ManageInput(input);

                    if (userInput > 0 && userInput < 5)
                    { 
                        break; 
                    }
                    else 
                    { 
                        Console.WriteLine("\nPlease, enter integers between 1 and 4 only!");
                        Console.WriteLine("-------------------------------------------------------------------------\n");
                    }
                }
                CheckAnswer(i, userInput);
                Console.WriteLine("-------------------------------------------------------------------------\n");
                Console.WriteLine("Please, press any key to continue ");
                Console.ReadLine();
                Console.Clear();

            }
            Console.WriteLine();
            DisplayResult();
            Console.WriteLine("-------------------------------------------------------------------------\n");
        }

        void CheckAnswer(int index, int userInput)
        {
            if(questions[index].CorrectAnswer == (userInput-1))
            {
                Console.WriteLine("\nWelldone, it is correct!");
                score++;
            }
            else 
            {
                Console.WriteLine($"\nUnfortunately, correct answer was: {questions[index].CorrectAnswer+1}");
            }
        }
        int ManageInput(string input)
        {
            int numericInput = 0;

            if(int.TryParse(input, out numericInput))
            {
                return numericInput;
            }
            else
            {
                return 0;
            }
        }
        void DisplayQuestion(int index)
        {
            Console.WriteLine($"Question {index + 1}: " + questions[index].QuestionsText);
            currentQuestion++;
        }
        void DisplayAnswer(int index)
        {
            for(int i = 0; i < 4; i++)
            {
                Console.WriteLine($"{i+1}. " + questions[index].GetAnswer(i));
            }
        }

        void DisplayResult()
        {
            Console.WriteLine($"Congratulations! You have succesfully answered {score} " +
                $"out of {currentQuestion} questions!");
            score = 0;
        }
    }
}
