namespace QuizApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Quiz programmingQuiz = new Quiz();
            programmingQuiz.StartQuiz();

            Console.WriteLine("Press any key to close the Quiz.");
            Console.ReadLine();
        }
    }
}
