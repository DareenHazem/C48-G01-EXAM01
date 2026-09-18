using System;
using System.Collections.Generic;
using System.Text;

namespace ExaminationSystem.Models.Questions
{
    public class MCQ : Question
    {
        public MCQ(string header, string body, int mark, int correctAnswerId) : base(header, body, mark, correctAnswerId)
        {
            AnswerList = new Answers[4];
        }
        public MCQ(string header, string body, int mark) : this(header, body, mark, default)
        {
        }

        public void SetCorrectAnswerID(int id)
        {
            CorrectAnswerId = id;
        }

        public override void DisplayQuestion()
        {
            Console.WriteLine($"MCQ Question :  Mark {Mark}");
            Console.WriteLine($"MCQ Question :  {Body}");
            foreach (Answers answer in AnswerList)
            {
                Console.WriteLine($"{answer.AnswerId}- {answer.AnswerText}");
            }
        }
    }
}
