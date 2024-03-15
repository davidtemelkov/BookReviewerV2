using BookReviewerV2.Data;

namespace BookReviewerV2.Services.Genre;

public class GenreService : IGenreService
{
    private readonly ApplicationDbContext data;

    public GenreService(ApplicationDbContext data)
    {
        this.data = data;
    }

    public IEnumerable<string> GetGenres()
    {
        return this.data
            .Genres
            .Select(g => g.Name)
            .ToList();
    }
}