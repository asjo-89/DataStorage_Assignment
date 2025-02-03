using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class RoleRepository(DataContext context) : BaseRepository<RoleEntity>(context), IRoleRepository
{
}
