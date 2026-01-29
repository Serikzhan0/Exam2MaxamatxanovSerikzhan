using Exam2.Models;

namespace Exam2.Services;

public class MovieService : IMovieService

{
    private List<Movie> movies = new List<Movie>();
    
    public void Create(Movie movie)
    {
        movies.Add(movie);
    }

    public void Update(Movie movie)
    {
        for (int i = 0; i < movies.Count; i++)
        {
            if (movies[i].Id == movie.Id)
            {
                movies[i] = movie;
                return;
            }
        }
    }

    public void Delete(Guid id)
    {
        for (int i = 0; i < movies.Count; i++)
        {
            if (movies[i].Id == id)
            {
                movies.RemoveAt(i);
                return;
            }
        }
    }
    
    public List<Movie> GetAllMoviesByDirector(string director)
    {
        List<Movie> result = new List<Movie>();

        foreach (var movie in movies)
        {
            if (movie.Director == director)
                result.Add(movie.ToDto());
        }

        return result;
    }

    public Movie GetTopRetedMovie()
    {
        Movie top = movies[0];

        foreach (var movie in movies)
        {
            if (movie.Rating > top.Rating)
                top = movie;
        }

        return top.ToDto();
    }

    public List<Movie> GetMoviesReleasedAfterYear(int year)
    {
        List<Movie> result = new List<Movie>();

        foreach (var movie in movies)
        {
            if (movie.ReleaseDate.Year > year)
                result.Add(movie.ToDto());
        }

        return result;
    }

    public Movie GetHighestGrossingMovie()
    {
        Movie max = movies[0];

        foreach (var movie in movies)
        {
            if (movie.BoxOfficeEarnings > max.BoxOfficeEarnings)
                max = movie;
        }

        return max.ToDto();
    }

    public List<Movie> SearchMovieByTitle(string keyword)
    {
        List<Movie> result = new List<Movie>();

        foreach (var movie in movies)
        {
            if (movie.Title.ToLower().Contains(keyword.ToLower()))
                result.Add(movie.ToDto());
        }

        return result;
    }

    public List<Movie> GetMoviesWithDurationRange(int minMinutes, int maxMinutes)
    {
        List<Movie> result = new List<Movie>();

        foreach (var movie in movies)
        {
            if (movie.DurationMinutes >= minMinutes &&
                movie.DurationMinutes <= maxMinutes)
                result.Add(movie.ToDto());
        }

        return result;
    }

    public long GetTotalBoxOfficeEarnningsByDirector(string director)
    {
        long sum = 0;

        foreach (var movie in movies)
        {
            if (movie.Director == director)
                sum += movie.BoxOfficeEarnings;
        }

        return sum;
    }

    public List<Movie> GetMoviesSortedByRating()
    {
        List<Movie> temp = new List<Movie>(movies);

        for (int i = 0; i < temp.Count - 1; i++)
        {
            for (int j = i + 1; j < temp.Count; j++)
            {
                if (temp[i].Rating < temp[j].Rating)
                {
                    var t = temp[i];
                    temp[i] = temp[j];
                    temp[j] = t;
                }
            }
        }

        List<Movie> result = new List<Movie>();
        foreach (var movie in temp)
            result.Add(movie.ToDto());

        return result;
    }

    public List<Movie> GetRecentMovies(int year)
    {
        List<Movie> result = new List<Movie>();

        foreach (var movie in movies)
        {
            if (movie.ReleaseDate.Year >= year)
                result.Add(movie.ToDto());
        }

        return result;
    }
}