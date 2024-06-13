using DesiMart.Models;
using DesiMart.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesiMart.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IReview _reviewService;
        private readonly IProductService _productService;

        public ReviewController(IReview reviewService,IProductService  iProductService)
        {
            _reviewService = reviewService;
            _productService = iProductService;
        }

        [HttpPost]
        public async Task<IActionResult> AddReview([FromBody] Review review)
        {
            var response = await _reviewService.AddReview(review);
            if (response.Success)
            {   
                await _productService.AddReview(review.ProductId, review);
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(string id)
        {
            var response = await _reviewService.DeleteReview(id);
            if (response.Success)
            {
                return Ok(response);
            }
            return NotFound(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReviewById(string id)
        {
            try
            {
                var review = await _reviewService.GetReviewById(id);
                if (review == null)
                {
                    return NotFound(new ResponseModel("Review not found", false, null));
                }
                return Ok(review);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseModel($"Error fetching review: {ex.Message}", false, null));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetReviews()
        {
            try
            {
                var reviews = await _reviewService.GetReviews();
                return Ok(reviews);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseModel($"Error fetching reviews: {ex.Message}", false, null));
            }
        }

        [HttpGet("customer/{customerId}")]
        public async Task<IActionResult> GetReviewsByCustomerId(string customerId)
        {
            try
            {
                var reviews = await _reviewService.GetReviewsByCustomerId(customerId);
                return Ok(reviews);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseModel($"Error fetching reviews by customer ID: {ex.Message}", false, null));
            }
        }

        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetReviewsByProductId(string productId)
        {
            try
            {
                var reviews = await _reviewService.GetReviewsByProductId(productId);
                return Ok(reviews);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResponseModel($"Error fetching reviews by product ID: {ex.Message}", false, null));
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReview([FromBody] Review review, string id)
        {
            var response = await _reviewService.UpdateReview(review, id);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
