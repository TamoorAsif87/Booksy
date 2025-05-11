using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace API.DTO;

public class BookCreationDto
{
    public Guid Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public string[] AuthorNames { get; set; }
    [Required]
    public  string BookCoverPhoto { get; set; }
    [Precision(18, 2)]
    public  decimal Price { get; set; }
    [Range(1, 5,ErrorMessage = "Average rating should be between 1 and 5")]
    public float AverageRating { get; set; }
    public int TotalReviews { get; set; }
    [Required]
    public string[] Genres { get; set; } = [];
    [Required]
    public Guid CategoryId { get; set; }
}
