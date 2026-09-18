using System;
using System.Collections.Generic;
using System.Text;

namespace ExaminationSystem.Models.Questions
{
    public class TrueOrFalse : Question
    {
        public TrueOrFalse(string body, int mark, int correctAnswerId) : base("Final Exam", body, mark, correctAnswerId)
        {
            AnswerList =
            [
               new Answers(1,"True"),
               new Answers(2,"False")
            ];
        }

        public override void DisplayQuestion()
        {
            Console.WriteLine($"True | False Question :  Mark {Mark}");
            Console.WriteLine($"True /False Question: {Body}");
            Console.WriteLine($"1- True\n2- False");
        }
    }
}
