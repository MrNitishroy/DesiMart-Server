using DesiMart.DbContext;
using DesiMart.Models;
using DesiMart.Services.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesiMart.Services
{
    public class ReviewService : IReview
    {
        private readonly IMongoCollection<Review> _reviewCollection;

        public ReviewService(MongoDbContext mongoDbContext)
        {
            _reviewCollection = mongoDbContext.ReviewDb;
        }

        public async Task<ResponseModel> AddReview(Review review)
        {
            try
            {
                await _reviewCollection.InsertOneAsync(review);
                return new ResponseModel("Review added successfully", true, review);
            }
            catch (Exception ex)
            {
                // Log exception
                return new ResponseModel($"Error adding review: {ex.Message}", false, null);
            }
        }

        public async Task<ResponseModel> DeleteReview(string id)
        {
            try
            {
                var deleteResult = await _reviewCollection.DeleteOneAsync(r => r.Id == id);
                if (deleteResult.DeletedCount == 0)
                {
                    return new ResponseModel("Review not found",false,null);
                }
                return new ResponseModel("Review deleted successfully", true, null);
            }
            catch (Exception ex)
            {
                return    new ResponseModel(ex.Message, false, null);
            }
        }

        public async Task<Review> GetReviewById(string id)
        {
            try
            {
                return await _reviewCollection.Find(r => r.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception($"Error fetching review: {ex.Message}");
            }
        }

        public async Task<List<Review>> GetReviews()
        {
            try
            {
                return await _reviewCollection.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception($"Error fetching reviews: {ex.Message}");
            }
        }

        public async Task<List<Review>> GetReviewsByCustomerId(string customerId)
        {
            try
            {
                return await _reviewCollection.Find(r => r.UserId == customerId).ToListAsync();
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception($"Error fetching reviews by customer ID: {ex.Message}");
            }
        }

        public async Task<List<Review>> GetReviewsByProductId(string productId)
        {
            try
            {
                return await _reviewCollection.Find(r => r.ProductId == productId).ToListAsync();
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception($"Error fetching reviews by product ID: {ex.Message}");
            }
        }

        public async Task<ResponseModel> UpdateReview(Review review, string id)
        {
            try
            {
                var updateResult = await _reviewCollection.ReplaceOneAsync(r => r.Id == id, review);
                if (updateResult.IsAcknowledged && updateResult.ModifiedCount > 0)
                {
                    return new ResponseModel("Review updated successfully", true, review);
                }
                else
                {
                    return new ResponseModel("Review not found or no changes made", false, null);
                }
            }
            catch (Exception ex)
            {
                // Log exception
                return new ResponseModel($"Error updating review: {ex.Message}", false, null);
            }
        }
    }
}
