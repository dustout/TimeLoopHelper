using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimeLoopHelper.Models
{
  public class ChallengeSubmission
  {
    public string NextChallenge { get; set; }

    public string Message { get; set; }
  }
}
