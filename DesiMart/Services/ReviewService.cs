using DesiMart.Models;
using DesiMart.Services.Interfaces;

namespace DesiMart.Services
{
    public class ReviewService : IReview
    {
        public Task<ResponseModel> AddReview(Review review)
        {
            throw new NotImplementedException();
        }

        public Task DeleteReview(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Review> GetReviewById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Review>> GetReviews()
        {
            throw new NotImplementedException();
        }

        public Task<List<Review>> GetReviewsByCustomerId(string customerId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Review>> GetReviewsByProductId(string productId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> UpdateReview(Review review, string id)
        {
            throw new NotImplementedException();
        }
    }
}
