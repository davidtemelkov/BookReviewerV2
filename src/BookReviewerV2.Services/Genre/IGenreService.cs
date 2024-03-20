namespace BookReviewerV2.Services.Genre;

public interface IGenreService
{
    IEnumerable<string> GetGenres();
}