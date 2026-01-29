using Exam2.Dtos;

namespace Exam2.Services;

public interface IMovieService
{
    List<MovieDtos> GetallMovieByDirector(string director);

    List<MovieDtos> GetTopRatedMovie();

    List<MovieDtos> GetMoviesReleasedAfterYear(int year);

    List<MovieDtos> GetHighestGrossingMovie();

    List<MovieDtos> SearchMoviesByTitle(string keyword);

    List<MovieDtos> GetMoviesWithinDurationRange(int minMinutes, int maxMinutes);

    List<MovieDtos> GetTotalBoxOfficeEarningByDirector(string director);

    List<MovieDtos> GetMoviesSortedByRating();

    List<MovieDtos> GetRecenMovies(int years);
}