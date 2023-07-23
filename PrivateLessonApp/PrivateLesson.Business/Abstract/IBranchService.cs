using PrivateLesson.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateLesson.Business.Abstract
{
    public interface IBranchService
    {
        Task CreateAsync(Branch branch);
        Task<Branch> GetByIdAsync(int id);
        Task<List<Branch>> GetAllAsync();
        void Update(Branch branch);
        void Delete(Branch branch);

        Task<List<Branch>> GetBranchesAsync(bool ApprovedStatus);

        Task<List<Branch>> GetAllBranchesFullDataAsync(bool ApprovedStatus);

        Task<List<Branch>> GetBranchesByTeacherAsync(int id);

        Task<Branch> GetBranchFullDataAsync(int id);

        Task<string> GetBranchNameByUrlAsync(string url);
    }
}
