using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Threading.Tasks;

namespace api.models
{
    public class Comment
    {
        public int Id { get; set; }
        public int? StockId { get; set; }

        public string Tittle { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public Stock? stock { get; set; }
    }
}