using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTos.stock;
using api.models;

namespace api.Mappers
{
    public static class StockMappers
    {
        public static StockDto ToStockDto(this Stock stockModel)
        {
            return new StockDto
            {
                Id = stockModel.Id,
                Symbol = stockModel.Symbol,
                CompanyName = stockModel.CompanyName,
                Purchase = stockModel.Purchase,
                LastDiv = stockModel.LastDiv,
                Industry = stockModel.Industry,
                MarketCap = stockModel.MarketCap,
                Comments = stockModel.Comments.Select(c=>c.TocommentDto()).ToList()
            };
        }

        public static Stock ToStockFromCreateDto(this CreateStockRequestDto StockDto)
        {

            return new Stock
            {
                Symbol = StockDto.Symbol,
                CompanyName = StockDto.CompanyName,
                Purchase = StockDto.Purchase,
                LastDiv = StockDto.LastDiv,
                Industry = StockDto.Industry,
                MarketCap = StockDto.MarketCap

            };
        }
        public static IEnumerable<Stock> ToStocksFromCreateDto(this IEnumerable<CreateStockRequestDto> stockDtos)
        {
            return stockDtos.Select(dto => new Stock
                {
                Symbol = dto.Symbol,
                CompanyName = dto.CompanyName,
                Purchase = dto.Purchase,
                LastDiv = dto.LastDiv,
                Industry = dto.Industry,
                MarketCap = dto.MarketCap
                });
        }

        
    }
}