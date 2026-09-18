using ExaminationSystem.Models.Questions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExaminationSystem.Models.Exam
{
    public abstract class Exam
    {
        public TimeSpan Time { get; set; }
        public int NumberOfQuestions { get; set; }

        public Question[] Questions;

        public Exam(TimeSpan time, int numberOfQuestions, Question[] questions)
        {
            Time = time;
            NumberOfQuestions = numberOfQuestions;
            Questions = questions;
        }

        public abstract void ExamFunctionality(int[] Answers);

        protected abstract int CalculateGrade(int[] UserAnswer);

    }
}
