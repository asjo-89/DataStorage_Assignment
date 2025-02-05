﻿using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class UnitRepository(DataContext context) : BaseRepository<UnitEntity>(context), IUnitRepository
{
}
