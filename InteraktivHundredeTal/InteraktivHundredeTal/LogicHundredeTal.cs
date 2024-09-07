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

    public int StartingValue { get; private set; }
    /// <summary>
    /// Generer et tilfældigt tal mellem 1 og 99
    /// </summary>
    /// <returns></returns>
    internal string GetNewNumber()
    {
      StartingValue = random.Next(22, 78);
      return StartingValue.ToString();
    }

    internal bool IsCorrectAddition(string inputNum, int NumericShift)
    {
      try
      {
        int parsedValue = int.Parse(inputNum);
        return parsedValue == StartingValue + NumericShift;
      }
      catch (FormatException)
      {
        return false;
      }
    }

    internal bool IsCorrectSubtraction(string inputNum, int targetValue)
    {
      try
      {
        int parsedValue = int.Parse(inputNum);
        return parsedValue - StartingValue == targetValue;
      }
      catch (FormatException)
      {
        return false;
      }
    }

  }
}
