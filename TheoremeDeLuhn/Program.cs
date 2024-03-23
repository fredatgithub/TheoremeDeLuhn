using System;

namespace TheoremeDeLuhn
{
  internal class Program
  {
    static void Main()
    {
      long[] testNumbers = { 49927398716, 49927398717, 1234567812345678, 1234567812345670 };
      foreach (var testNumber in testNumbers)
        Console.WriteLine("{0} is {1}valid", testNumber, testNumber.ToString().LuhnCheck() ? "" : "not ");

      Console.WriteLine("Press any key to exit:");
      Console.ReadKey();
    }
  }
}
