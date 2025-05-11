using Core.Entities;

namespace Core.Specifications;

public class BookSpecification : BaseSpecification<Book>
{
    public BookSpecification(BookSpecParams specs) : base(
        x => (string.IsNullOrEmpty(specs.Search) || x.Title.ToLower().Contains(specs.Search)) &&
        (!specs.Genres.Any() || specs.Genres.Any(g => x.Genres.Contains(g))) &&
        (!specs.Authors.Any() || specs.Authors.Any(a => x.AuthorNames.Contains(a)))
        )
    {
        if(specs.IsPaginationEnabled)
        {
            ApplyPaging(specs.PageSize * (specs.PageIndex - 1), specs.PageSize);
        }

        switch (specs.Sort)
        {
            case "priceAsc":
                AddOrderBy(x => x.Price);
                break;
            case "priceDesc":
                AddOrderByDesc(x => x.Price);
                break;
            case "ratingAsc":
                AddOrderBy(x => x.AverageRating);
                break;
            case "ratingDesc":
                AddOrderByDesc(x => x.AverageRating);
                break;
            default:
                AddOrderBy(x => x.Title);
                break;
        }

    }
}
