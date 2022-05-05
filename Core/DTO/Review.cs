namespace OnlineShop.Core.DTO
{
    public record ProductReview(long Id, short Rating, string Comment, UserData User);
}