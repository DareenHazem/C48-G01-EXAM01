using ExaminationSystem.Models.Questions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExaminationSystem.Models.Exam
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }

        public Exam Exam { get; private set; }
        public Subject(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        }

        public Exam CreateExam(int examType, TimeSpan examTime, int numberOfQuestions, Question[] questions)
        {
            if (examType == 1)
            {
                Exam = new PracticalExam(examTime, numberOfQuestions, questions);
            }
            else
            {
                Exam = new FinalExam(examTime, numberOfQuestions, questions);
            }

            return Exam;
        }

    }
}
