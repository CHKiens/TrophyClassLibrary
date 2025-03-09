using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrophyClassLibrary
{
    public class TrophiesRepo
    {
        private readonly List<Trophy> trophies = new List<Trophy>();
        private int _nextId = 1;

        public TrophiesRepo()
        {
            Add(new Trophy { Competition = "Comp A", Year = 2018 });
            Add(new Trophy { Competition = "Comp B", Year = 2019 });
            Add(new Trophy { Competition = "Comp C", Year = 2017 });
            Add(new Trophy { Competition = "Comp D", Year = 2021 });
            Add(new Trophy { Competition = "Comp E", Year = 2020 });
        }
        public Trophy? GetTrophyById(int id)
        {
            return trophies.FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<Trophy> GetTrophies(int? trophyYearBefore = null, int? trophyYearAfter = null, string? orderBy = null)
        {
            IEnumerable<Trophy> result = new List<Trophy>(trophies);

            if (trophyYearBefore != null)
            {
                result = result.Where(t => t.Year < trophyYearBefore);
            }
            if (trophyYearAfter != null)
            {
                result = result.Where(t => t.Year > trophyYearAfter);
            }
            if(orderBy != null)
            {
                orderBy = orderBy.ToLower();
                switch (orderBy)
                {
                    case "competition":
                    case "competition_desc":
                        result = result.OrderByDescending(t => t.Competition);
                        break;
                    case "competition_asc":
                        result = result.OrderBy(t => t.Competition);
                        break;
                    case "year":
                    case "year_desc":
                        result = result.OrderByDescending(t => t.Year);
                        break;
                    case "year_asc":
                        result = result.OrderBy(t => t.Year);
                        break;
                }
            }
            return result;
        }
        public Trophy Add(Trophy trophy)
        {
            trophy.Id = _nextId++;
            trophies.Add(trophy);
            return trophy;
        }

        public Trophy? Remove(int id)
        {
            Trophy? trophy = GetTrophyById(id);
            if (trophy != null)
            {
                trophies.Remove(trophy);
            }
            return trophy;
        }

        public Trophy? Update(int id, Trophy data)
        {
            Trophy? Trophy = GetTrophyById(id);
            if (Trophy != null)
            {
                Trophy.Competition = data.Competition;
                Trophy.Year = data.Year;
            }
            return Trophy;
        }
    }
}
