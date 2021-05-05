using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeLoopHelper.Data;
using TimeLoopHelper.Models;

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

    public async Task<IEnumerable<VerifiedTimeLoop>> GetAllVerifiedTimeLoopers()
    {
      return await _db.VerifiedTimeLoops.OrderByDescending(x=>x.Id).ToListAsync();
    }

    public async Task RegisterTimeLoop(Challenge passedChallenge, string message)
    {
      var newTimeLoop = new VerifiedTimeLoop()
      {
        ChallengeId = passedChallenge.Id,
        Message = message
      };

      _db.VerifiedTimeLoops.Add(newTimeLoop);

      await _db.SaveChangesAsync();
    }

    public async Task RemoveAll()
    {
      //delete existing challenges
      var existingLoops = _db.VerifiedTimeLoops;
      _db.RemoveRange(existingLoops);

      //save changes
      await _db.SaveChangesAsync();
    }
  }
}
