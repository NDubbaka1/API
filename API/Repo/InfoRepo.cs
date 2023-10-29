using API.Data;
using API.Model.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace API.Repo
{
    public class InfoRepo : IInfoRepo
    {
        private APIDBContext aPIDBContext;
        public InfoRepo(APIDBContext aPIDBContext)
        {

            this.aPIDBContext = aPIDBContext;
        }

        public async Task<IEnumerable<Info>> GetAllInfoAsync()
        {
            return await aPIDBContext.Info.ToListAsync();
        }





        public async Task<Info> GetInfoById(int id)
        {
            return await aPIDBContext.Info.FirstOrDefaultAsync(x => x.id == id);
        }


        public async Task<Info> AddInfo(Info info)
        {
            await aPIDBContext.Info.AddAsync(info);
            await aPIDBContext.SaveChangesAsync();
            return info;
        }

        public async Task<Info> DeleteInfoById(int id)
        {
            var info = await aPIDBContext.Info.FirstOrDefaultAsync(x => x.id == id);
            if (info != null)
            {
                aPIDBContext.Info.Remove(info);
                await aPIDBContext.SaveChangesAsync();
                return info;
            }

            return null;
        }


        public async Task<Info> UpdateInfoById(int id, Info info)
        {
            var exitingInfo = await aPIDBContext.Info.FirstOrDefaultAsync(x => x.id == id);



            if (exitingInfo == null)
            {
                return null;
            }


            exitingInfo.id = info.id;
            exitingInfo.FirstName = info.FirstName;
            exitingInfo.LastName = info.LastName;

            await aPIDBContext.SaveChangesAsync();
            return exitingInfo;

        }

    }
}
