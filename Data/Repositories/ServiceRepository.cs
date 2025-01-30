using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class ServiceRepository(DbContext context) : BaseRepository<ServiceEntity>(context), IServiceRepository
{
    private readonly DbContext _context = context;
}
