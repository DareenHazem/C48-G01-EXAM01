using System;
using System.Collections.Generic;
using System.Text;

namespace ExaminationSystem.Models.Questions
{
    public abstract class Question
    {
        #region Properties & Fields
        public string Header { get; private set; }

        public string Body { get; private set; }

        public int Mark { get; private set; }

        public Answers[] AnswerList;
        public int CorrectAnswerId { get; protected set; }

        #endregion

        #region Constructors
        public Question(string header, string body, int mark, int correctAnswerId)
        {
            Header = header;
            Body = body;
            Mark = mark;
            CorrectAnswerId = correctAnswerId;
        }

        public Question(string body, int mark, int correctAnswerId) : this("", body, mark, correctAnswerId)
        {

        }
        #endregion

        public abstract void DisplayQuestion();

    }
}
