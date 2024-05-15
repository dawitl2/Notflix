using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;

namespace WinFormsApp1
{
    internal class Sql
    {
        private string connectionString = "server=localhost;uid=root;pwd=password;database=TestDB";

        public bool AuthenticateUser(string username, string password)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM User WHERE user_name = @username AND password = @password";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    connection.Open();
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        public bool CreateUser(string username, string password, string email, string pfp)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // Check if the username already exists
                string checkQuery = "SELECT COUNT(*) FROM User WHERE user_name = @username";
                using (MySqlCommand checkCommand = new MySqlCommand(checkQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@username", username);

                    connection.Open();
                    int userCount = Convert.ToInt32(checkCommand.ExecuteScalar());

                    if (userCount > 0)
                    {
                        MessageBox.Show("Username is already taken. Please choose a different username.", "Username Taken", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }

                // If username is not taken, proceed to create the user
                string query = "INSERT INTO User (user_name, password, email, pfp) VALUES (@username, @password, @email, @pfp)";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@pfp", pfp);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("User created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error creating user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return rowsAffected > 0;
                }
            }
        }




        public List<(string, string, string)> GetMoviePosters()
        {
            List<(string, string, string)> movieData = new List<(string, string, string)>();

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                string query = "SELECT title, poster_image, duration FROM Movie";
                MySqlCommand cmd = new MySqlCommand(query, con);
                con.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        string title = reader.GetString("title");
                        string posterPath = reader.GetString("poster_image");
                        string duration = reader.GetInt32("duration").ToString(); // Retrieve duration as integer and convert to string
                        //MessageBox.Show($"----: {title}");
                        movieData.Add((title, posterPath, duration));
                    }
                }
            }

            return movieData;
        }

     

        public bool CreateUser(string username, string password, string email)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO User (user_name, password, email) VALUES (@username, @password, @email)";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    command.Parameters.AddWithValue("@email", email);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public List<(string, string, string, List<string>, int)> GetMovieDetailsWithGenresAndRatings()
        {
            List<(string, string, string, List<string>, int)> movieData = new List<(string, string, string, List<string>, int)>();

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                string query = @"
            SELECT 
                m.title, 
                m.wide_poster_image, 
                m.duration, 
                GROUP_CONCAT(DISTINCT g.genre_name SEPARATOR ',') AS genres,
                AVG(r.rating) AS average_rating
            FROM 
                Movie m
            LEFT JOIN 
                MovieGenre mg ON m.movie_id = mg.movie_id
            LEFT JOIN 
                Genre g ON mg.genre_id = g.genre_id
            LEFT JOIN 
                Rating r ON m.movie_id = r.movie_id
            GROUP BY 
                m.movie_id, m.title, m.wide_poster_image, m.duration
        ";

                MySqlCommand cmd = new MySqlCommand(query, con);
                con.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string title = reader.GetString("title");
                        string posterPath = reader.GetString("wide_poster_image");
                        string duration = reader.GetInt32("duration").ToString();
                        string genres = reader.IsDBNull(reader.GetOrdinal("genres")) ? "" : reader.GetString("genres");
                        int averageRating = reader.IsDBNull(reader.GetOrdinal("average_rating")) ? 0 : Convert.ToInt32(reader.GetDouble("average_rating"));
                        List<string> genreList = genres.Split(',').ToList();

                        movieData.Add((title, posterPath, duration, genreList, averageRating));
                    }
                }
            }

            return movieData;
        }


        public List<(string, string, string)> GetMoviePostersByGenre(string genreName)
        {
          
            //MessageBox.Show(genreName);
            List<(string, string, string)> movieData = new List<(string, string, string)>();

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                string query = @"SELECT m.title, m.poster_image, m.duration 
                        FROM Movie m
                        INNER JOIN MovieGenre mg ON m.movie_id = mg.movie_id
                        INNER JOIN Genre g ON mg.genre_id = g.genre_id
                        WHERE g.genre_name = @genreName";

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@genreName", genreName.Trim());

                con.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string title = reader.GetString("title");
                        string posterPath = reader.GetString("poster_image");
                        string duration = reader.GetInt32("duration").ToString(); // Retrieve duration as integer and convert to string
                        //MessageBox.Show($"----: {title}");
                        movieData.Add((title, posterPath, duration));
                    }
                }
            }

            return movieData;
        }

        public List<(string, string, string, string)> FilterMovies(string genre, string releaseDate, string duration, string rating)
        {
            List<(string, string, string, string)> movieData = new List<(string, string, string, string)>();

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                StringBuilder queryBuilder = new StringBuilder(@"SELECT m.title, m.poster_image, m.duration, m.video
                                                        FROM Movie m
                                                        INNER JOIN MovieGenre mg ON m.movie_id = mg.movie_id
                                                        INNER JOIN Genre g ON mg.genre_id = g.genre_id
                                                        LEFT JOIN Rating r ON m.movie_id = r.movie_id
                                                        WHERE 1=1");

                if (!string.IsNullOrEmpty(genre))
                    queryBuilder.Append(" AND g.genre_name = @genreName");

                if (!string.IsNullOrEmpty(releaseDate))
                    queryBuilder.Append(" AND m.release_date = @releaseDate");

                if (!string.IsNullOrEmpty(duration))
                    queryBuilder.Append(" AND m.duration = @duration");

                if (!string.IsNullOrEmpty(rating))
                    queryBuilder.Append(" AND r.rating = @rating");

                MySqlCommand cmd = new MySqlCommand(queryBuilder.ToString(), con);
                if (!string.IsNullOrEmpty(genre)) cmd.Parameters.AddWithValue("@genreName", genre.Trim());
                if (!string.IsNullOrEmpty(releaseDate)) cmd.Parameters.AddWithValue("@releaseDate", releaseDate);
                if (!string.IsNullOrEmpty(duration)) cmd.Parameters.AddWithValue("@duration", duration);
                if (!string.IsNullOrEmpty(rating)) cmd.Parameters.AddWithValue("@rating", rating);

                con.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string title = reader.GetString("title");
                        string posterPath = reader.GetString("poster_image");
                        string movieDuration = reader.GetInt32("duration").ToString();
                        string videoPath = reader.GetString("video");

                        movieData.Add((title, posterPath, movieDuration, videoPath));
                    }
                }
            }

            return movieData;
        }




        public List<(string, string, string)> GetMoviePostersname(string genreName)
        {
          
            //MessageBox.Show(genreName);
            List<(string, string, string)> movieData = new List<(string, string, string)>();

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                string query = @"SELECT title, poster_image, duration 
                        FROM Movie
                        WHERE title = @genreName";

                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@genreName", genreName.Trim());

                con.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string title = reader.GetString("title");
                        string posterPath = reader.GetString("poster_image");
                        string duration = reader.GetInt32("duration").ToString(); // Retrieve duration as integer and convert to string
                        //MessageBox.Show($"----: {title}");
                        movieData.Add((title, posterPath, duration));
                    }
                }
            }

            return movieData;
        }



        public string GetVideoPath(int movieId)
        {
            string videoPath = null;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT video FROM Movie WHERE movie_id = @movieId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@movieId", movieId);

                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            videoPath = reader.GetString("video");
                        }
                    }
                }
            }

            return videoPath;
        }

     

        public string GetMovieIdFromImagePath(string imagePath)
        {
            string movieId = null;

            // Connect to the database and execute the query to retrieve the movie ID
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT movie_id FROM Movie WHERE poster_image = @imagePath"; // Assuming 'id' is the column name for movie ID

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@imagePath", imagePath); // Add parameter to prevent SQL injection

                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        movieId = result.ToString();
                    }
                }
            }

            return movieId;
        }



        public string[] GetMovieDataById(int id)
        {
            string[] movieData = new string[8];

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                string query = "SELECT title, release_date, description, trailer_URL, poster_image, wide_poster_image, average_rating, video " +
                               "FROM Movie " +
                               "WHERE movie_id = @id";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        movieData[0] = reader.GetString("title");
                        movieData[1] = reader.GetDateTime("release_date").ToString("yyyy-MM-dd");
                        movieData[2] = reader.IsDBNull("description") ? null : reader.GetString("description");
                        movieData[3] = reader.IsDBNull("trailer_URL") ? null : reader.GetString("trailer_URL");
                        movieData[4] = reader.IsDBNull("poster_image") ? null : reader.GetString("poster_image");
                        movieData[5] = reader.IsDBNull("wide_poster_image") ? null : reader.GetString("wide_poster_image");
                        movieData[6] = reader.GetInt32("average_rating").ToString();
                        movieData[7] = reader.GetString("video");
                    }
                }
            }

            return movieData;
        }


        public string[] GetMostRatedMovieData()
        {
            string[] movieData = new string[8];

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                string query = "SELECT title, release_date, description, trailer_URL, poster_image, wide_poster_image, average_rating, video " +
                               "FROM Movie " +
                               "ORDER BY average_rating DESC " + // Order by average rating in descending order
                               "LIMIT 1"; // Limit the result to only one row, which will be the highest rated movie
                MySqlCommand cmd = new MySqlCommand(query, con);
                con.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        movieData[0] = reader.GetString("title");
                        movieData[1] = reader.GetDateTime("release_date").ToString("yyyy-MM-dd");
                        movieData[2] = reader.IsDBNull("description") ? null : reader.GetString("description");
                        movieData[3] = reader.IsDBNull("trailer_URL") ? null : reader.GetString("trailer_URL");
                        movieData[4] = reader.IsDBNull("poster_image") ? null : reader.GetString("poster_image");
                        movieData[5] = reader.IsDBNull("wide_poster_image") ? null : reader.GetString("wide_poster_image");
                        movieData[6] = reader.GetInt32("average_rating").ToString();
                        movieData[7] = reader.GetString("video");
             
                    }
                }
               
            }

            return movieData;
        }


        public string GetWideImagePath(int movieId)
        {
            string imagePath = null;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT wide_poster_image FROM Movie WHERE movie_id = @movieId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@movieId", movieId);

                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            imagePath = reader.GetString("wide_poster_image");
                        }
                    }
                }
            }

            return imagePath;
        }
        
        public void PostComment(int movieId, String text, int userId)
        {
            userId = 1;
            string imagePath = null;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO Comment (user_id, movie_id, comment_text) VALUES (@UserId, @MovieId, @Text);";


                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@MovieId", movieId);
                    command.Parameters.AddWithValue("@Text", text);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }

        }

        public List<(string, string, string)> GetCommentsForMovie(int movieid)
        {
            List<(string, string, string)> comments = new List<(string, string, string)>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT c.comment_text, u.user_name, u.pfp " +
                               "FROM Comment c " +
                               "INNER JOIN User u ON c.user_id = u.user_id " +
                               "WHERE c.movie_id = @movieId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@movieId", movieid);

                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string commentText = reader.GetString("comment_text");
                            string username = reader.GetString("user_name");
                            string profilePicture = reader.GetString("pfp");
                            comments.Add((username, profilePicture, commentText));
                        }
                    }
                }
            }

            return comments;
        }


        public List<string[]> GetTopRatedMoviesData()
        {
            List<string[]> topRatedMoviesData = new List<string[]>();

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                string query = "SELECT title, release_date, description, trailer_URL, poster_image, wide_poster_image, average_rating, video " +
                               "FROM Movie " +
                               "ORDER BY average_rating DESC " + // Order by average rating in descending order
                               "LIMIT 7"; // Limit the result to top 3 rated movies
                MySqlCommand cmd = new MySqlCommand(query, con);
                con.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string[] movieData = new string[8];
                        movieData[0] = reader.GetString("title");
                        movieData[1] = reader.GetDateTime("release_date").ToString("yyyy-MM-dd");
                        movieData[2] = reader.IsDBNull("description") ? null : reader.GetString("description");
                        movieData[3] = reader.IsDBNull("trailer_URL") ? null : reader.GetString("trailer_URL");
                        movieData[4] = reader.IsDBNull("poster_image") ? null : reader.GetString("poster_image");
                        movieData[5] = reader.IsDBNull("wide_poster_image") ? null : reader.GetString("wide_poster_image");
                        movieData[6] = reader.GetInt32("average_rating").ToString();
                        movieData[7] = reader.GetString("video");
                        topRatedMoviesData.Add(movieData);
                    }
                }
            }

            return topRatedMoviesData;
        }
        public List<(string, string)> GetMovieDirectorsAndStars(int movieId)
        {
            List<(string, string)> result = new List<(string, string)>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT d.director_name, d.director_image " +
                               "FROM Director d " +
                               "INNER JOIN Movie m ON d.director_id = m.director_id " +
                               "WHERE m.movie_id = @movieId " +
                               "UNION " +
                               "SELECT s.star_name, s.star_image " +
                               "FROM Star s " +
                               "INNER JOIN MovieStar ms ON s.star_id = ms.star_id " +
                               "WHERE ms.movie_id = @movieId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@movieId", movieId);
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = reader.GetString(0); // Name
                            string image = reader.GetString(1); // Image
                            result.Add((name, image));
                        }
                    }
                }
            }

            return result;
        }


        public List<(string, string)> GetMovieTitlesAndImagesByTitle(string searchText)
        {
            List<(string, string)> movieData = new List<(string, string)>();


            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                string query = "SELECT title, poster_image FROM Movie WHERE title LIKE @searchText";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@searchText", "%" + searchText + "%");

                con.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string title = reader.GetString("title");
                        string posterPath = reader.GetString("poster_image");
                        movieData.Add((title, posterPath));
                    }
                }
            }

            return movieData;
        }

        // Add these methods to the Sql class

        public List<string> GetGenres()
        {
            List<string> genres = new List<string>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT genre_name FROM Genre";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string genre = reader.GetString("genre_name");
                            genres.Add(genre);
                        }
                    }
                }
            }

            return genres;
        }

        public List<string> GetReleaseDates()
        {
            List<string> releaseDates = new List<string>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT DISTINCT release_date FROM Movie";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime releaseDate = reader.GetDateTime("release_date");
                            releaseDates.Add(releaseDate.ToString("yyyy-MM-dd"));
                        }
                    }
                }
            }

            return releaseDates;
        }

    }
}
