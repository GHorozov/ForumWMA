namespace ForumWMA.Services.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface ITagService
    {
        IEnumerable<T> All<T>(int? count = null);

        Task<string> Create(string name);

        Task<bool> Edit(string id, string name);

        Task<T> GetTagById<T>(string id);
    }
}
