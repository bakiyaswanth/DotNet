using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTos.Comment
{
    public class CreateCommentDto
    {
        public string Tittle { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
    }
}