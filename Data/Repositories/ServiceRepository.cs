using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repositories;

public class ServiceRepository(DataContext context) : BaseRepository<ServiceEntity>(context), IServiceRepository
{
}
