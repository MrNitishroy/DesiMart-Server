using DesiMart.Models;

namespace DesiMart.Services.Interfaces
{
    public interface IReview
    {
        Task<ResponseModel> AddReview(Review review);
        Task<ResponseModel> UpdateReview(Review review, string id);
        Task<ResponseModel> DeleteReview(string id);
        Task<Review> GetReviewById(string id);
        Task<List<Review>> GetReviewsByProductId(string productId);
        Task<List<Review>> GetReviewsByCustomerId(string customerId);
        Task<List<Review>> GetReviews();
    }
}
