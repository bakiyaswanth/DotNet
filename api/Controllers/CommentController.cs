using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTos.Comment;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("Api/Comment")]
    [ApiController]
    public class CommentController:ControllerBase
    {
        private readonly ICommentRepository _CommentRepo;
        private readonly IStockRepository _stockRepo;
        public CommentController(ICommentRepository CommentRepo,IStockRepository stockRepo)
        {
            _CommentRepo = CommentRepo;
            _stockRepo = stockRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Comments = await _CommentRepo.GetAllSync();
            var CommentDto = Comments.Select(s => s.TocommentDto());
            return Ok(CommentDto);
        }
        [HttpGet("{id}")]
        public async  Task<IActionResult> GetById([FromRoute] int id)
        {
            var comment = await _CommentRepo.GetbyIdAsync(id);

            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment.TocommentDto());
        }

        [HttpPost("{stockid}")]
        public async Task<IActionResult> Create ([FromRoute] int stockid, CreateCommentDto createCommentDto)
        {
            if (!await _stockRepo.StockExists(stockid))
            {
                return BadRequest("stock doesnot exists");
            }
            var commentModel = createCommentDto.ToCommentFromCreate(stockid);
            await _CommentRepo.CreateAsync(commentModel);
            return CreatedAtAction(nameof(GetById), new { id = commentModel.Id }, commentModel.TocommentDto());            
        }
    }
}