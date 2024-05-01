using System;
using MySql.Data.MySqlClient;

namespace WinFormsApp1
{
    internal class Movie
    {
        private readonly Sql SqlInstance = new Sql();

        public int MovieId { get; private set; }
        public string Title { get; private set; }
        public string ReleaseDate { get; private set; }
        public string Description { get; private set; }
        public string TrailerURL { get; private set; }
        public string PosterImage { get; private set; }
        public string WidePosterImage { get; private set; }
        public int AverageRating { get; private set; }
        public string Video { get; private set; }

        public Movie(int id)
        {
            string[] movieData = SqlInstance.GetMovieDataById(id);

            if (movieData != null && movieData.Length == 9)
            {
                MovieId = id;
                Title = movieData[0];
                ReleaseDate = movieData[1];
                Description = movieData[2];
                TrailerURL = movieData[3];
                PosterImage = movieData[4];
                WidePosterImage = movieData[5];
                AverageRating = Convert.ToInt32(movieData[6]);
                Video = movieData[7];
            }
            else
            {
                throw new ArgumentException("Movie data not found for the provided id.");
            }
        }
    }
}
