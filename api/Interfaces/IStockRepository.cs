using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTos.stock;
using api.models;

namespace api.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync();
        Task<Stock?> GetByIdAsync(int id);
        Task<Stock> CreateAsync(Stock stockModel);
        Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockRequestDto);
        Task<Stock?> DeleteAsync(int id);
        Task<List<Stock>> CreateMultiAsync(List<Stock> stockModels);
        Task<bool> StockExists(int id);
    }
}