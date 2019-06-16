using System;
using System.Linq;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
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