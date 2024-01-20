using Exam.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Business.Interface
{
    public interface IProductService
    {
        Task<List<ProductDTO>> GetList(int from, int to);
        Task<List<ProductDTO>> GetAllList();
        Task<List<ProductDTO>> SearchAsync(string productName, int from, int to);
        Task<List<ProductDTO>> SortAsync(string sortWith, int from, int to);
        Task<List<ProductDTO>> SearchAllAsync(string productName);
        Task AddAsync (ProductDTO product);
        Task UpdateAsync (ProductDTO product);
        Task EnableDisableAsync (int id);
        Task DeleteAsync (int id);
    }
}
