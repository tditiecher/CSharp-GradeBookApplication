using System;
using System.Linq;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        private const int MinimumNumberOfStudents = 5;

        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < MinimumNumberOfStudents)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < MinimumNumberOfStudents)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStudentStatistics(name);
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < MinimumNumberOfStudents)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }

            var numberOfStudentsAboveGrade = Students.Count(x => x.AverageGrade >= averageGrade);

            switch (100 * numberOfStudentsAboveGrade / Students.Count)
            {
                case int pct when pct <= 20:
                    return 'A';
                case int pct when pct <= 40:
                    return 'B';
                case int pct when pct <= 60:
                    return 'C';
                case int pct when pct <= 80:
                    return 'D';
                default:
                    return 'F';
            }
        }
    }
}