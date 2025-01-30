using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class StatusInformationRepository(DbContext context) : BaseRepository<StatusInformationEntity>(context), IStatusInformationRepository
{
    private readonly DbContext _context = context;
}
