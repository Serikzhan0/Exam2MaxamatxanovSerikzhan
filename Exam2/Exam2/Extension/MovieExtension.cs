namespace Exam2.Extension;

public static class MovieExtension 
{
    {
    public static double ToDto(this MovieDto movie)
        {
            return new Movie
            {
                Title = movie.Title,
                Director = movie.Director,
                DurationMinutes = movie.DurationMinutes,
                Rating = movie.Rating,
                BoxOfficeEranings = movie.BoxOfficeEranings,
                ReleaseDate = movie.ReleaseDate
            };
        }
        
        public static double GetDurationInHours(this Movie movie)
        {
            return movie.DurationMinutes / 60.0;
        }
        
        public static long GetTotalBoxOffice(this List<Movie> movies)
        {
            long sum = 0;
            foreach (var movie in movies)
                sum += movie.BoxOfficeEranings;

            return sum;
        }
    }
}