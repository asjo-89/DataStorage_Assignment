using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class UnitRepository(DbContext context) : BaseRepository<UnitEntity>(context), IUnitRepository
{
}
