using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeLoopHelper.Data;

namespace TimeLoopHelper.Services
{
  public class VerifiedTimeLoopService
  {
    private readonly ApplicationDbContext _db;

    public VerifiedTimeLoopService(ApplicationDbContext db)
    {
      _db = db;
    }

    public async Task<int> GetVerifiedTimeLoopersCount()
    {
      return await _db.VerifiedTimeLoops.CountAsync();
    }
  }
}
