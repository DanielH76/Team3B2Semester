using System;
using System.Collections.Generic;
using System.Linq;
using TheMovies.Models;
using System.Data.SqlClient;
using System.Data;

namespace TheMovies.Repos
{
    public class CinemaMovieShowBookingRepo : IRepository<CinemaMovieShowBooking>
    {
        private List<CinemaMovieShowBooking> entries;

        SqlConnection sqlConnect = new SqlConnection();

        public string connectionString = "Server=10.56.8.35;Database=B_DB07_2020;User Id=B_STUDENT07;Password=B_OPENDB07";

        public CinemaMovieShowBookingRepo()
        {
            sqlConnect.ConnectionString = connectionString;
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
            foreach (CinemaMovieShowBooking c in entries)
            {
                if (c.BookingID == (int)id)
                    return c;
            }
            return null;
        }

        public void Add(CinemaMovieShowBooking obj)
        {
            if (obj.CinemaName != default)
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
            sqlConnect.Open();
            SqlCommand command = new SqlCommand("Select * FROM CinemaMovieShowBooking", sqlConnect);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                var entry = new CinemaMovieShowBooking();
                entry.BookingID = reader.GetInt32(0);
                entry.CinemaName = reader.IsDBNull(1) != true ?  reader.GetString(1) : default;
                entry.CinemaTown = reader.IsDBNull(2) != true ? reader.GetString(2) : default;
                entry.MovieTitle = reader.IsDBNull(3) != true ? reader.GetString(3) : default; 
                entry.MovieGenre = reader.IsDBNull(4) != true ? reader.GetString(4) : default;
                entry.MovieDuration = reader.IsDBNull(5) != true ? reader.GetInt32(5) : default;
                entry.MovieDirector = reader.IsDBNull(6) != true ? reader.GetString(6) : default;
                entry.MovieReleaseDate = reader.IsDBNull(7) != true ? reader.GetDateTime(7) : default;
                entry.ShowDateTime = reader.IsDBNull(8) != true ? reader.GetDateTime(8) : default;
                entry.BookingMail = reader.IsDBNull(9) != true ? reader.GetString(9) : default;
                entry.BookingPhone = reader.IsDBNull(10) != true ? reader.GetString(10) : default;
                entries.Add(entry);
            }
        }
        private void SaveRepo()
        {
            string commandTextInsert = "INSERT INTO CinemaMovieShowBooking(CinemaName,CinemaTown,ShowDateTime,MovieTitle,MovieGenre,MovieDuration,MovieDirector,MovieReleaseDate,BookingMail,BookingPhone)" +
                "VALUES (@CinemaName,@CinemaTown,@ShowDateTime,@MovieTitle,@MovieGenre,@MovieDuration,@MovieDirector,@MovieReleaseDate,@BookingMail,@BookingPhone)";
            string commandTextUpdate = "UPDATE CinemaMovieShowBooking SET CinemaName = @CinemaName, CinemaTown = @CinemaTown, ShowDateTime = @ShowDateTime, MovieTitle = @MovieTitle, MovieGenre = @MovieGenre " +
                "WHERE BookingID = @BookingID;  ";
            string commandReturnID = "SELECT @@Identity";
            SqlCommand command;
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();
                foreach (var c in entries)
                {
                    if (c.BookingID == 0)
                        command = new SqlCommand(commandTextInsert, connect);
                    else
                    {
                        command = new SqlCommand(commandTextUpdate, connect);
                        command.Parameters.AddWithValue("@BookingID", c.BookingID);
                    }
                    command.Parameters.AddWithValue("@CinemaName", c.CinemaName != default ? (object)c.CinemaName : DBNull.Value);
                    command.Parameters.AddWithValue("@CinemaTown", c.CinemaTown != default ? (object)c.CinemaTown : DBNull.Value);
                    command.Parameters.AddWithValue("@ShowDateTime", c.ShowDateTime.ToString(@"yy-M-d hh:mm") != default ? (object)c.ShowDateTime.ToString(@"yy-M-d hh:mm") : DBNull.Value);
                    command.Parameters.AddWithValue("@MovieTitle", c.MovieTitle != default ? (object)c.MovieTitle : DBNull.Value);
                    command.Parameters.AddWithValue("@MovieGenre", c.MovieGenre != default ? (object)c.MovieGenre : DBNull.Value);
                    command.Parameters.AddWithValue("@MovieDuration", c.MovieDuration != default ? (object)c.MovieDuration : DBNull.Value);
                    command.Parameters.AddWithValue("@MovieDirector", c.MovieDirector != default ? (object)c.MovieDirector : DBNull.Value);
                    command.Parameters.AddWithValue("@MovieReleaseDate", c.MovieReleaseDate.ToString(@"yy-M-d") != default ? (object)c.MovieReleaseDate.ToString(@"yy-M-d") : DBNull.Value);
                    command.Parameters.AddWithValue("@BookingMail", c.BookingMail != default ? (object)c.BookingMail : DBNull.Value);
                    command.Parameters.AddWithValue("@BookingPhone", c.BookingPhone != default ? (object)c.BookingPhone : DBNull.Value);
                    try
                    {
                        command.ExecuteNonQuery();
                        if(c.BookingID == 0)
                        {
                            SqlCommand newCommand = new SqlCommand(commandReturnID, connect);

                            SqlDataReader reader = newCommand.ExecuteReader();

                            while (reader.Read())
                            {
                                c.BookingID = (int)reader.GetDecimal(0);
                                Console.WriteLine(c.BookingID);
                            }
                        }
                        
                    }

                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }

                }
            }
        }
    }
}
