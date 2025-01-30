using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class RoleRepository(DbContext context) : BaseRepository<RoleEntity>(context), IRoleRepository
{
    private readonly DbContext _context = context;
}
