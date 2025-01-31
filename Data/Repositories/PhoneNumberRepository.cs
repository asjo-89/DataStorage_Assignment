using Data.Entities;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Interfaces;

public class PhoneNumberRepository(DbContext context) : BaseRepository<PhoneNumberEntity>(context), IPhoneNumberRepository
{
}
