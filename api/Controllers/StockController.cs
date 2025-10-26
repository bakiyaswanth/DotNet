using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTos.stock;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/Stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDbcontext _context;
        private readonly IStockRepository _stockRepository;
        public StockController(ApplicationDbcontext context,IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
            _context = context;

        }

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var stocks = await _stockRepository.GetAllAsync();
            var stockdto= stocks.Select(s => s.ToStockDto());

            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public async  Task<IActionResult> GetById([FromRoute] int id)
        {
            var stock = await _stockRepository.GetByIdAsync(id);

            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock.ToStockDto());
        }
        [HttpPost("single")]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDto)
        {
            var stockModel = stockDto.ToStockFromCreateDto();
            await _stockRepository.CreateAsync(stockModel);           
            return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToStockDto());

        }

        [HttpPost]
        public async Task<IActionResult> CreateMulti([FromBody] CreateStocksRequestDto stockDto)
        {
            var stockModel = stockDto.StockDto.ToStocksFromCreateDto().ToList();
            await _stockRepository.CreateMultiAsync(stockModel);            
            var createdStocks =stockModel.Select(s => s.ToStockDto()).ToList();

            return Ok(createdStocks);

        }

        [HttpPut]

        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updatestockdto)
        {
            var stockModel = await _stockRepository.UpdateAsync(id, updatestockdto);
            if (stockModel == null)
            {
                return NotFound();
            }
           return Ok(stockModel);

        }

        [HttpDelete]
        [Route("{id}")]

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var stockModel = await _stockRepository.DeleteAsync(id);
            if (stockModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}