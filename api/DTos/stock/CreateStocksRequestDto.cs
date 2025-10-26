using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTos.stock
{
    public class CreateStocksRequestDto
    {
        public List<CreateStockRequestDto> StockDto { get; set; } = new List<CreateStockRequestDto>();
    }
}