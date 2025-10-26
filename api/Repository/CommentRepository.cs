using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbcontext _context;
        public CommentRepository(ApplicationDbcontext dbcontext)
        {
            _context = dbcontext;
            
        }

        public async Task<Comment> CreateAsync(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<List<Comment>> GetAllSync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment?> GetbyIdAsync(int id)
        {
            return await _context.Comments.FindAsync(id);
        }
    }
}