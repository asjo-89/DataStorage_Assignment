using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Interfaces;

public class PhoneNumberRepository(DbContext context) : BaseRepository<PhoneNumberEntity>(context), IPhoneNumberRepository
{
    private readonly DbContext _context = context;
}
