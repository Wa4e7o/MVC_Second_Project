
namespace MovieSystem.Services.Actiors
{
    using Microsoft.EntityFrameworkCore;
    using MovieSystem.Data;
    using MovieSystem.Data.Models;
    using MovieSystem.Models.Base;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ActiorsService : EntityBaseRepository<Actior>, IActiorsService
    {
        public ActiorsService(MovieSystemDbContext data) : base(data) { }
    }
}
