using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeLoopHelper.Data;

namespace TimeLoopHelper.Services
{
  public class ChallengeService
  {
    private readonly ApplicationDbContext _db;

    public ChallengeService(ApplicationDbContext db)
    {
      _db = db;
    }

    public async Task<string> GetCurrentChallengeValue()
    {
      var challengeValue = await _db.Challenges
        .Where(x => x.ValidOnStartUtc >= DateTime.UtcNow)
        .Where(x => x.ValidOnEndUtc < DateTime.UtcNow)
        .Select(x => x.Value)
        .FirstOrDefaultAsync();

      return challengeValue;
    }
  }
}
