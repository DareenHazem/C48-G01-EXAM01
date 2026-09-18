using ExaminationSystem.Models.Questions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExaminationSystem.Models.Exam
{
    public class PracticalExam : Exam
    {
        public PracticalExam(TimeSpan time, int numberOfQuestions, Question[] questions) : base(time, numberOfQuestions, questions) 
        {
        }

        protected override int CalculateGrade(int[] Answers)
        {
            int Grade = 0;

            for (int i = 0; i < Questions.Length; i++)
            {
                if (Answers[i] == Questions[i].CorrectAnswerId)
                {
                    Grade += Questions[i].Mark;
                }
            }
            return Grade;
        }

        public override void ExamFunctionality(int[] Answers)
        {
            int TotalMarks = 0;
            Console.WriteLine("Practical Exam Results: \n");
            for (int i = 0; i < NumberOfQuestions; i++)
            {
                Console.WriteLine($"Question {i + 1}: {Questions[i].Body}");
                Console.WriteLine($"Your Answer => {Questions[i].AnswerList[Answers[i] - 1].AnswerText}");
                Console.WriteLine($"Correct Answer => {Questions[i].AnswerList[Questions[i].CorrectAnswerId - 1].AnswerText}\n");
                TotalMarks += Questions[i].Mark;
            }

            Console.WriteLine($"Your Grade is {CalculateGrade(Answers)} from {TotalMarks}");
        }

    }
}
