using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class EmailAddressRepository(DbContext context) : BaseRepository<EmailAddressEntity>(context), IEmailAddressRepository
{
}
