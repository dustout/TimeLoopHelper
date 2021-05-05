using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeLoopHelper.Models
{
  public class VerifiedTimeLoop
  {
    public int Id { get; set; }

    public int ChallengeId { get; set; }
    public Challenge Challenge { get; set; }

    public String Message { get; set; }

  }
}
