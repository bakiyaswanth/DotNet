using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.models;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace api.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllSync();
        Task<Comment?> GetbyIdAsync(int id);

        Task<Comment> CreateAsync(Comment comment);
    }
}