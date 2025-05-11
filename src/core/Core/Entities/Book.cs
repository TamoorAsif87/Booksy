namespace Core.Entities;

public class Book:BaseEntity
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string[] AuthorNames  { get; set; }
    public required string BookCoverPhoto { get; set; }
    public required decimal Price { get; set; }
    public float AverageRating { get; set; }
    public int TotalReviews { get; set; }
    public string[] Genres { get; set; } = [];
    public Guid CategoryId { get; set; }
    public Category? Category { get; set; }


    public static Book Create(string title, string description, string[] authorNames, string bookCoverPhoto, decimal price, float averageRating, int totalReviews, string[] genres, Guid categoryId)
    {
        return new Book
        {
            Title = title,
            Description = description,
            AuthorNames = authorNames,
            BookCoverPhoto = bookCoverPhoto,
            Price = price,
            AverageRating = averageRating,
            TotalReviews = totalReviews,
            Genres = genres,
            CategoryId = categoryId
        };
    }

    public void UpdateBook(string title, string description, string[] authorNames, string bookCoverPhoto, decimal price, float averageRating, int totalReviews, string[] genres)
    {
        Title = title;
        Description = description;
        AuthorNames = authorNames;
        BookCoverPhoto = bookCoverPhoto;
        Price = price;
        AverageRating = averageRating;
        TotalReviews = totalReviews;
        Genres = genres;
    }

}


