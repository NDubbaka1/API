using API.Model.Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Repo
{
    public interface IWalkRepo 
    {

        Task<List<Walk>> GetWalk(string? filterOn = null , string? filterQuery = null ,
            string? sortBy = null, bool isAscending = true , int pageNumber = 1, int pageSize = 1000);

        Task<Walk> GetWalkByID(Guid id);

        Task<Walk> AddWalkByID(Walk walk);

        Task<Walk> UpdateWalkById(Guid  id, Walk   walk );

        Task<Walk> deleteWalk(Guid id);

    }
}
