using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class StatusInformationRepository(DataContext context) : BaseRepository<StatusInformationEntity>(context), IStatusInformationRepository
{
}
