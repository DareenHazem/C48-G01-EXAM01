using ExaminationSystem.Models.Exam;
using ExaminationSystem.Models.Questions;
using System.Diagnostics;

namespace ExaminationSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Subject Input
            bool isparsed;
            int Examtype;
            do
            {
                Console.WriteLine("Enter the type of exam (1 for Practical, 2 for Final):  ");
                int.TryParse(Console.ReadLine(), out Examtype);
                isparsed = (Examtype == 1 || Examtype == 2);
            } while (!isparsed);

            TimeSpan examTime;
            do
            {
                Console.WriteLine("Please enter the time for the exam (30 to 180 minutes): ");
                int.TryParse(Console.ReadLine(), out int time);
                isparsed = (time >= 30 && time <= 180);
                examTime = TimeSpan.FromMinutes(time);
            } while (!isparsed);

            int NumberOfQuestions;
            do
            {
                Console.WriteLine("Please enter the number of questions: ");
                int.TryParse(Console.ReadLine(), out NumberOfQuestions);
                isparsed = NumberOfQuestions > 0;
            } while (!isparsed);

            // Create Subject object
            Subject subject = new Subject(1, "Math");
            Console.Clear();
            #endregion


            #region Exam Input
            Exam exam; // It will be assigned later as final or practical
            Question[] Questions = new Question[NumberOfQuestions];

            if (Examtype == 1)  // Practical - MCQ ONLY
            {
                for (int i = 0; i < NumberOfQuestions; i++)  // BODY - MARK - CHOICES - CORRECT ANSWER
                {
                    Console.WriteLine($"Enter details for question {i + 1}:");

                    Console.WriteLine("Please enter the question body:");
                    string body = Console.ReadLine() ?? "No Question Provided!!!";

                    int mark;
                    do
                    {
                        Console.WriteLine("Please enter the question mark: ");
                        int.TryParse(Console.ReadLine(), out mark);
                        isparsed = mark > 0;
                    } while (!isparsed);

                    MCQ mcq = new MCQ("Practical Exam", body, mark); // MCQ Object

                    Console.WriteLine($"Choices of question {i + 1}:");
                    for (int j = 0; j < 4; j++)
                    {
                        Console.WriteLine($"Please enter choice number {j + 1}");

                        string answerText = Console.ReadLine() ?? "No Choice Provided!!!";

                        mcq.AnswerList[j] = new Answers(j + 1, answerText);
                    }

                    int CorrectID;
                    do
                    {
                        Console.WriteLine("Please enter the ID of the correct answer (1 to 4):");
                        int.TryParse(Console.ReadLine(), out CorrectID);
                        isparsed = CorrectID >= 1 && CorrectID <= 4;
                    } while (!isparsed);

                    mcq.SetCorrectAnswerID(CorrectID);
                    Questions[i] = mcq;
                    Console.Clear();
                }
                exam = subject.CreateExam(Examtype, examTime, NumberOfQuestions, Questions); // Exam Object from subject Method
            }
            else //Final 
            {
                for (int i = 0; i < NumberOfQuestions; i++)
                {
                    Console.WriteLine($"Enter details for question {i + 1}:  ");
                    int Questiontype;
                    do
                    {
                        Console.WriteLine("Choose question type: 1 for MCQ, 2 for True / False:");
                        int.TryParse(Console.ReadLine(), out Questiontype);
                        isparsed = (Questiontype == 1 || Questiontype == 2);
                    } while (!isparsed);

                    if (Questiontype == 1) //MCQ
                    {
                        Console.WriteLine("Please enter the question body:");
                        string body = Console.ReadLine() ?? "No Question Provided!!!";

                        int mark;
                        do
                        {
                            Console.WriteLine("Please enter the question mark: ");
                            int.TryParse(Console.ReadLine(), out mark);
                            isparsed = mark > 0;
                        } while (!isparsed);

                        MCQ mcq = new MCQ("Final Exam", body, mark); // MCQ Object

                        Console.WriteLine($"Choices of question {i + 1}:");

                        for (int j = 0; j < 4; j++)
                        {
                            Console.WriteLine($"Please enter choice number {j + 1}");

                            string answerText = Console.ReadLine() ?? "No Choice Provided!!!";

                            mcq.AnswerList[j] = new Answers(j + 1, answerText);
                        }

                        int CorrectID;
                        do
                        {
                            Console.WriteLine("Please enter the ID of the correct answer (1 to 4):");
                            int.TryParse(Console.ReadLine(), out CorrectID);
                            isparsed = CorrectID >= 1 && CorrectID <= 4;
                        } while (!isparsed);

                        mcq.SetCorrectAnswerID(CorrectID);
                        Questions[i] = mcq;

                    }
                    else // True / False
                    {
                        Console.WriteLine("Please enter the question body:");
                        string body = Console.ReadLine() ?? "No Question Provided!!!";

                        int mark;
                        do
                        {
                            Console.WriteLine("Please enter the question mark: ");
                            int.TryParse(Console.ReadLine(), out mark);
                            isparsed = mark > 0;
                        } while (!isparsed);

                        int CorrectID;
                        do
                        {
                            Console.WriteLine("Please enter the ID of the correct answer (1 for True, 2 for False): ");
                            int.TryParse(Console.ReadLine(), out CorrectID);
                            isparsed = (CorrectID == 1 || CorrectID == 2);
                        } while (!isparsed);

                        Questions[i] = new TrueOrFalse(body, mark, CorrectID);
                    }
                    Console.Clear();
                }

                // Create the final Exam Object from subject Method - Start Point
                exam = subject.CreateExam(Examtype, examTime, NumberOfQuestions, Questions);
            }

            #endregion


            #region Start the Exam
            string answer;
            do
            {
                Console.WriteLine("Do You Want To Start Exam (Y | N)");
                answer = Console.ReadLine()!;
                isparsed = (answer is not null) && (answer.ToUpper() == "Y" || answer.ToUpper() == "N");
            } while (!isparsed);

            if (answer!.ToUpper() == "N")
            {
                Environment.Exit(0);
            }
            else // User want to start the exam
            {
                Console.Clear();
                Stopwatch sw = new Stopwatch();
                sw.Start();
                Console.WriteLine(Examtype == 1 ? "Practical Exam" : "Final Exam");
                int[] UserAnswers = new int[NumberOfQuestions];// To Store the useranswers he will input

                bool outOfTime = false;
                for (int i = 0; i < NumberOfQuestions; i++) // Display the questions and take values from user
                {
                    if (sw.Elapsed > examTime) // Make sure first that the user didn't exceed the time
                    {
                        outOfTime = true;
                        break;
                    }

                    exam.Questions[i].DisplayQuestion();
                    do
                    {
                        Console.WriteLine("Enter your answer ID:");
                        int.TryParse(Console.ReadLine(), out UserAnswers[i]);
                        isparsed = (1 <= UserAnswers[i] && UserAnswers[i] <= 4);
                    } while (!isparsed);
                }
                sw.Stop();
                Console.Clear();


                if (outOfTime)
                {
                    Console.WriteLine("You are out of Time!!!!");
                    Console.WriteLine($"Time: {sw.Elapsed}\nBetter luck next time");

                }
                else
                {
                    exam.ExamFunctionality(UserAnswers);// Grading the exam 
                    Console.WriteLine($"Time: {sw.Elapsed}\nThank you");
                }


            }

            #endregion

        }
    }
}
