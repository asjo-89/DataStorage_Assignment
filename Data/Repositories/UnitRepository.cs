using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class UnitRepository(DbContext context) : BaseRepository<UnitEntity>(context), IUnitRepository
{
    private readonly DbContext _context = context;
}
