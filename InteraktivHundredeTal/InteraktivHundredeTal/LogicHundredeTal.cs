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

    public int CurrentRandomNumber { get; private set; }
    /// <summary>
    /// Generer et tilfældigt tal mellem e4f10 og 99
    /// </summary>
    /// <returns></returns>
    internal string GetNewNumber()
    {
      CurrentRandomNumber = random.Next(10, 80);
      return CurrentRandomNumber.ToString();
    }

    internal bool IsCorrectAddition(string inputNum, int NumericShift)
    {
      try
      {
        int parsedValue = int.Parse(inputNum);
        return parsedValue == CurrentRandomNumber + NumericShift;
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
        return parsedValue - CurrentRandomNumber == targetValue;
      }
      catch (FormatException)
      {
        return false;
      }
    }

  }
}
