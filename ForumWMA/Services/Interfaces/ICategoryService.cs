using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumWMA.Services.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<T> All<T>(int? count = null);

        T GetByName<T>(string name, int? take = null, int skip = 0);

        Task<string> Create(string name, string title, string description, string imageUrl);
    }
}
