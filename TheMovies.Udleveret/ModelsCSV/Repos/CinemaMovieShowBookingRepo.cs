using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TheMovies.Models;

namespace TheMovies.Repos
{
    public class CinemaMovieShowBookingRepo : IRepository<CinemaMovieShowBooking>
    {
        private List<CinemaMovieShowBooking> entries;

        private string path = @"TheMovies.CSV";

        public CinemaMovieShowBookingRepo()
        {
            entries = new List<CinemaMovieShowBooking>();
            LoadRepo();
        }

        public IEnumerable<CinemaMovieShowBooking> GetAll()
        {
            // Return a copy of the internal datastructure

            return entries.ToList();
        }

        public CinemaMovieShowBooking GetById(object id)
        {
            // return entries.Find(o => o.CinemaName == (string)id);
            for (int i = 0; i < entries.Count; i++)
            {
                if (i == (int)id)
                    return entries[i];
            }
            return null;

        }

        public void Add(CinemaMovieShowBooking obj)
        {
            if (obj.CinemaName != default)
            {
                bool doesItExist = entries.Any(x => x.ToString() == obj.ToString() && x.ToString() == obj.ToString());
                if (doesItExist)
                {
                    throw new Exception();
                }
                else
                {
                    entries.Add(obj);
                    SaveRepo();
                }
            }
            else if (obj.MovieTitle != default)
            {
                bool doesItExist = entries.Any(x => x.ToString() == obj.ToString());
                if (doesItExist)
                {
                    throw new Exception();
                }
                else
                {
                    entries.Add(obj);
                    SaveRepo();
                }
            }
            else if (obj.ShowDateTime != default)
            {
                bool doesItExist = entries.Any(x => x.ToString() == obj.ToString());
                if (doesItExist)
                {
                    throw new Exception();
                }
                else
                {
                    entries.Add(obj);
                    SaveRepo();
                }
            }
            else
            {
                bool doesItExist = entries.Any(x => x.ToString() == obj.ToString());
                if (doesItExist)
                {
                    throw new Exception();
                }
                else
                {
                    entries.Add(obj);
                    SaveRepo();
                }
            }


        }

        public void Delete(CinemaMovieShowBooking obj)
        {

            if (obj.CinemaName != default && obj.CinemaTown != default)
            {
                for (int i = 0; i < entries.Count; i++)
                {
                    if (entries[i].CinemaName == obj.CinemaName)
                    {
                        entries.RemoveAll(c => c.CinemaName == obj.CinemaName && c.CinemaTown == obj.CinemaTown);
                        SaveRepo();
                    }

                }
            }
            else if (obj.MovieTitle != default)
            {
                for (int i = 0; i < entries.Count; i++)
                {
                    if (entries[i].MovieTitle == obj.MovieTitle)
                    {
                        entries.RemoveAll(c => c.MovieTitle == obj.MovieTitle);
                        SaveRepo();
                    }
                }
            }
            else if (obj.ShowDateTime != default)
            {
                for (int i = 0; i < entries.Count; i++)
                {
                    if (entries[i].ShowDateTime == obj.ShowDateTime)
                    {
                        entries.RemoveAll(c => c.ShowDateTime == obj.ShowDateTime);
                        SaveRepo();

                    }
                }
            }
            else
                for (int i = 0; i < entries.Count; i++)
                {
                    if (entries[i].BookingMail == obj.BookingMail)
                    {
                        entries.RemoveAll(c => c.BookingMail == obj.BookingMail);
                        SaveRepo();

                    }
                }
        }

        public void Update(CinemaMovieShowBooking obj, CinemaMovieShowBooking newValues)
        {
            if (obj.CinemaName != default)
            {
                foreach (CinemaMovieShowBooking c in entries)
                {
                    if (c.CinemaName == obj.CinemaName && c.CinemaTown == obj.CinemaTown)
                    {
                        c.CinemaName = newValues.CinemaName;
                        c.CinemaTown = newValues.CinemaTown;
                    }
                }
            }
            else if (obj.MovieTitle != default)
            {
                foreach (CinemaMovieShowBooking c in entries)
                {
                    if (c.MovieTitle == obj.MovieTitle)
                    {
                        c.MovieTitle = newValues.MovieTitle;
                        c.MovieGenre = newValues.MovieGenre;
                        c.MovieDuration = newValues.MovieDuration;
                        c.MovieDirector = newValues.MovieDirector;
                        c.MovieReleaseDate = newValues.MovieReleaseDate;
                    }
                }
            }
            else if (obj.ShowDateTime != default)
            {
                foreach (CinemaMovieShowBooking c in entries)
                {
                    if (c.ShowDateTime == obj.ShowDateTime)
                        c.ShowDateTime = newValues.ShowDateTime;
                }
            }
            else
                foreach (CinemaMovieShowBooking c in entries)
                {
                    if (c.BookingMail == obj.BookingMail)
                    {
                        c.BookingMail = newValues.BookingMail;
                        c.BookingPhone = newValues.BookingPhone;
                    }
                }
            SaveRepo();
        }

        private void LoadRepo()
        {
            using (var sr = new StreamReader(path))
            {
                var firstLine = sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    var valueArray = line.Split(';');
                    var timeArray = valueArray[5].Split(':');
                    var @object = new CinemaMovieShowBooking();
                    @object.CinemaName = valueArray[0];
                    @object.CinemaTown = valueArray[1];
                    @object.ShowDateTime = DateTime.Parse(valueArray[2]);
                    @object.MovieTitle = valueArray[3];
                    @object.MovieGenre = valueArray[4];
                    @object.MovieDuration = (int.Parse(timeArray[0]) * 60) + int.Parse(timeArray[1]);
                    @object.MovieDirector = valueArray[6];
                    @object.MovieReleaseDate = DateTime.Parse(valueArray[7]);
                    @object.BookingMail = valueArray[8];
                    @object.BookingPhone = valueArray[9];
                    entries.Add(@object);
                }
            }
        }
        private void SaveRepo()
        {
            using (var sw = new StreamWriter(path, false))
            {
                sw.WriteLine("Biograf;By;Forestillingstidspunkt;Filmtitel;Filmgenre;Filmvarighed;Filminstruktør;Premieredato;Bookingmail;Bookingtelefonnummer");
                foreach (CinemaMovieShowBooking c in entries)
                {
                    var timeInActual = string.Empty;
                    if (c.MovieDuration > 120)
                    {
                        timeInActual = "02" + ":" + (c.MovieDuration % 120);
                    }
                    else
                    {
                        timeInActual = "01" + ':' + (c.MovieDuration % 60);
                    }

                    sw.WriteLine($"{c.CinemaName};{c.CinemaTown};{c.ShowDateTime.ToString(@"yy-M-d hh:mm")};{c.MovieTitle};{c.MovieGenre};{timeInActual};{c.MovieDirector};{c.MovieReleaseDate.ToString(@"yy-M-d")};{c.BookingMail};{c.BookingPhone}");
                }
            }
        }
    }
}
