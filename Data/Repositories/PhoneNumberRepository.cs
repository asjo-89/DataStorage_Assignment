using Data.Contexts;
using Data.Entities;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Interfaces;

public class PhoneNumberRepository(DataContext context) : BaseRepository<PhoneNumberEntity>(context), IPhoneNumberRepository
{
}
