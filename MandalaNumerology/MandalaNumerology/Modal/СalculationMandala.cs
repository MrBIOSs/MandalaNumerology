
using System.Collections.Generic;

namespace MandalaNumerology.Modal
{
    internal class СalculationMandala
    {
        public List<int> Arcanes = new List<int>();
        public int Arcane { get; private set; }
        public int DayBirth { get; private set; }
        public int MonthBirth { get; private set; }
        public int YearBirth { get; private set; }
        public int Platform { get; private set; }
        public int Tutorial { get; private set; }
        public int Examination { get; private set; }
        public int GuideStar { get; private set; }
        public int SmallCircle1 { get; private set; }
        public int SmallCircle2 { get; private set; }
        public int SmallCircle3 { get; private set; }
        public int SmallCircle4 { get; private set; }
        public int Cube1 { get; private set; }
        public int Cube2 { get; private set; }
        public int Sum1 { get; private set; }
        public int Sum2 { get; private set; }
        public int Sum3 { get; private set; }
        public int Sum4 { get; private set; }

        private int ArcaneIdentify(string date)
        {
            int result = 0;

            for (int i = 0; i < date.Length; i++)
            {
                result += int.Parse(date.Substring(i, 1));
            }

            ArcaneCalculation(ref result);

            return result;
        }

        private void ArcaneCalculation(ref int number)
        {
            if (number > 22)
            {
                number -= 22;
            }
        }

        public void YearForecast(string year, int dayBirth, int monthBirth, string yearBirth)
        {
            Arcanes.Clear();

            Arcane = ArcaneIdentify(year);

            ArcaneBirth(dayBirth, monthBirth, yearBirth);

            EnterArcanes();
        }

        public void MonthForecast(string year, string month, int dayBirth, int monthBirth, string yearBirth)
        {
            Arcanes.Clear();

            Arcane = ArcaneIdentify(year + month);

            ArcaneBirth(dayBirth, monthBirth, yearBirth);

            EnterArcanes();
        }

        private void EnterArcanes()
        {
            for (int i = 0; i < 6; i++)
            {
                AddArcane(Arcane);
            }

            AddArcane(DayBirth);
            AddArcane(MonthBirth);
            AddArcane(YearBirth);

            Platform = ArcanePointCalculation(Platform, DayBirth, Arcane);
            Tutorial = ArcanePointCalculation(Tutorial, MonthBirth, Arcane);
            Examination = ArcanePointCalculation(Examination, YearBirth, Arcane);
            Sum1 = ArcanePointCalculation(Sum1, DayBirth, MonthBirth);
            Sum2 = ArcanePointCalculation(Sum2, MonthBirth, YearBirth);
            Sum3 = ArcanePointCalculation(Sum3, Sum1, Sum2);
            GuideStar = ArcanePointCalculation(GuideStar, Sum3, Arcane);
            Sum4 = ArcanePointCalculation(Sum4, GuideStar, Tutorial);
            Cube1 = ArcanePointCalculation(Cube1, Platform, Tutorial);
            Cube2 = ArcanePointCalculation(Cube2, Tutorial, Examination);
            SmallCircle1 = ArcanePointCalculation(SmallCircle1, Arcane, Sum1);
            SmallCircle2 = ArcanePointCalculation(SmallCircle2, Arcane, Sum2);
            SmallCircle3 = ArcanePointCalculation(SmallCircle3, SmallCircle1, Cube1);
            SmallCircle4 = ArcanePointCalculation(SmallCircle4, SmallCircle2, Cube2);

            AddArcane(Examination);
            AddArcane(Tutorial);
            AddArcane(Platform);
            AddArcane(SmallCircle1);
            AddArcane(GuideStar);
            AddArcane(SmallCircle2);
        }

        private void ArcaneBirth(int dayBirth, int monthBirth, string yearBirth)
        {
            ArcaneCalculation(ref dayBirth);
            ArcaneCalculation(ref monthBirth);

            DayBirth = dayBirth;
            MonthBirth = monthBirth;
            YearBirth = ArcaneIdentify(yearBirth);
        }

        private void AddArcane(int arcane)
        {
            Arcanes.Add(arcane);
        }

        private int ArcanePointCalculation(int result, int point1, int point2)
        {
            result = point1 + point2;

            ArcaneCalculation(ref result);

            AddArcane(result);

            return result;
        }
    }
}
