using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeLoopHelper.Data;
using TimeLoopHelper.Models;

namespace TimeLoopHelper.Services
{
  public class ChallengeService
  {
    private readonly ApplicationDbContext _db;
    public static TimeSpan ValidForTimeSpan = new TimeSpan(hours:1, 0, 0);

    public ChallengeService(ApplicationDbContext db)
    {
      _db = db;
    }

    public IQueryable<Challenge> GetCurrentChallengeQuery()
    {
      var challengeQuery = _db.Challenges
        .Where(x => x.ValidOnStartUtc <= DateTime.UtcNow)
        .Where(x => x.ValidOnEndUtc > DateTime.UtcNow);

      return challengeQuery;
    }

    public async Task<string> GetCurrentChallengeValue()
    {
      var challengeValue = await GetCurrentChallengeQuery()
        .Select(x => x.Value)
        .FirstOrDefaultAsync();

      return challengeValue;
    }

    public async Task<Challenge> GetChallengeByValue(string value)
    {
      var challenge = await _db.Challenges
        .Where(x => x.Value.ToUpper() == value.ToUpper())
        .FirstOrDefaultAsync();

      return challenge;
    }

    public IQueryable<Challenge> GetNextChallengeQuery()
    {
      var targetDate = DateTime.UtcNow.Add(ValidForTimeSpan);

      var nextChallengeQuery = _db.Challenges
        .Where(x => x.ValidOnStartUtc <= targetDate)
        .Where(x => x.ValidOnEndUtc > targetDate);

      return nextChallengeQuery;
    }

    public async Task<Challenge> GetNextChallenge()
    {
      var nextChallenge = await GetNextChallengeQuery()
        .FirstOrDefaultAsync();

      return nextChallenge;
    }

    public async Task<string> GetNextChallengeValue()
    {
      try
      {
        var nextChallengeValue = await GetNextChallengeQuery()
        .Select(x => x.Value)
        .FirstOrDefaultAsync();

        return nextChallengeValue;
      }
      catch(Exception e)
      {
        throw e;
      }

      return null;
    }

    public async Task RemoveAllChallenges()
    {
      //delete existing challenges
      var existingChallenges = _db.Challenges;
      _db.RemoveRange(existingChallenges);

      //save changes
      await _db.SaveChangesAsync();
    }

    public async Task GenerateChallenges()
    {
      //generate new challenges
      var challengeStartDate = DateTime.UtcNow.Date.AddDays(-1);
      var challengeEndDate = challengeStartDate.AddYears(20);
      var iteratorDateTime = challengeStartDate;

      while(iteratorDateTime < challengeEndDate)
      {
        //create new challenge
        var iteratorChallenge = GenerateChallenge(iteratorDateTime, ValidForTimeSpan);
        _db.Challenges.Add(iteratorChallenge);

        //move forward iterator
        iteratorDateTime += ValidForTimeSpan;
      }

      //save changes
      await _db.SaveChangesAsync();
    }

    public Challenge GenerateChallenge(DateTime start, TimeSpan length)
    {
      return new Challenge()
      {
        ValidOnStartUtc = start,
        ValidOnEndUtc = start + length,
        Value = Guid.NewGuid().ToString().Substring(0, 8).ToUpper()
      };
    }

    public async Task<int> GetChallengeCount()
    {
      return await _db.Challenges.CountAsync();
    }
  }
}
