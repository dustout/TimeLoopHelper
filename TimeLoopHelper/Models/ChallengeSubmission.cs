using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimeLoopHelper.Models
{
  public class ChallengeSubmission
  {
    [Required(AllowEmptyStrings = false, ErrorMessage ="This Field Is Required")]
    public string Value { get; set; }
  }
}
