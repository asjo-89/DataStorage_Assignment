using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class EmailAddressRepository(DataContext context) : BaseRepository<EmailAddressEntity>(context), IEmailAddressRepository
{
}
