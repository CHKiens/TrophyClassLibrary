using System.Diagnostics.Contracts;

namespace TrophyClassLibrary
{
    public class Trophy
    {
        public int Id { get; set; }
        private string _competition;
        private int _year;

        public string Competition
        {
            get => _competition;
            set
            {
                if ( value == null)
                {
                    throw new ArgumentNullException("Competition name cannot be null.");
                }

                if (value.Length < 3)
                {
                    throw new ArgumentException("Competition name must be at least 3 characters long.");
                }
                _competition = value;
            }
        }

        public int Year
        {
            get => _year;
            set
            {
                if (value < 1970 || value > 2025)
                {
                    throw new ArgumentOutOfRangeException("Year must be between 1975 and 2025.");
                }
                _year = value;
            }
        }

        public Trophy(int id, string competition, int year)
        {
            Id = id;
            Competition = competition;
            Year = year;
        }

        public Trophy() : this(0, "Unknown", 2000) { }


        public override string ToString()
        {
            return $"Trophy: {Id}, {Competition} - {Year}";
        }
    }
}
