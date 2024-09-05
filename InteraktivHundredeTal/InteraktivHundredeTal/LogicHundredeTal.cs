using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivHundredeTal
{
  internal class LogicHundredeTal
  {
    private Random random = new Random();

    /// <summary>
    /// Generer et tilfældigt tal mellem 1 og 99
    /// </summary>
    /// <returns></returns>
    internal string GetNewCenterNumber()
    {
      var midtal = random.Next(1, 100);
      return midtal.ToString();
    }
  }

}
