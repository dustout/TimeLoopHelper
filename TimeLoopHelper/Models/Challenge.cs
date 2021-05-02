using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeLoopHelper.Models
{
  public class Challenge
  {
    public int Id { get; set; }

    public string Value { get; set; }

    public DateTime ValidOn { get; set; }
  }
}
