using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class RoleRepository(DbContext context) : BaseRepository<RoleEntity>(context), IRoleRepository
{
}
