using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICrud<TModel> where TModel : class
    {
        Task<List<TModel>> GetAllAsync();
        Task<bool> AddAsync(TModel model);
        Task<bool> SoftDelete(int id);
        bool Delete(int id);
    }
}
