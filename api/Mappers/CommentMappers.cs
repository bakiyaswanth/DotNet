using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTos.Comment;
using api.models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace api.Mappers
{
    public static class CommentMappers
    {
        public static CommentDto TocommentDto(this Comment commentModel)
        {
            return new CommentDto
            {
                Id = commentModel.Id,
                Tittle = commentModel.Tittle,
                Content = commentModel.Content,
                CreatedOn = commentModel.CreatedOn,
                StockId = commentModel.StockId
            };
        }
        public static Comment ToCommentFromCreate( this CreateCommentDto commentModel,int stockid)
        {
            return new Comment
            {
                
                Tittle = commentModel.Tittle,
                Content = commentModel.Content,
                
                StockId = stockid
            };
        }
    }
}