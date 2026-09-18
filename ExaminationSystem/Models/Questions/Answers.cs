using System;
using System.Collections.Generic;
using System.Text;

namespace ExaminationSystem.Models.Questions
{
    public class Answers
    {
        public int AnswerId { get; private set; }
        public string AnswerText { get; private set; }

        public Answers(int answerId, string answerText)
        {
            AnswerId = answerId;
            AnswerText = answerText;
        }
    }
}
