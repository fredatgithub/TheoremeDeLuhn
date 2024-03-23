using System.Linq;

namespace TheoremeDeLuhn
{
  public static class Luhn
  {
    public static bool LuhnCheck(this string cardNumber)
    {
      return LuhnCheck(cardNumber.Select(c => c - '0').ToArray());
    }

    private static bool LuhnCheck(this int[] digits)
    {
      return GetCheckValue(digits) == 0;
    }

    private static int GetCheckValue(int[] digits)
    {
      return digits.Select((d, i) => i % 2 == digits.Length % 2 ? ((2 * d) % 10) + d / 5 : d).Sum() % 10;
    }

    public static bool IsLuhn(long n)
    {
      long nextdigit, sum = 0;
      bool alt = false;
      while (n != 0)
      {
        nextdigit = n % 10;
        if (alt)
        {
          nextdigit *= 2;
          nextdigit -= (nextdigit > 9) ? 9 : 0;
        }

        sum += nextdigit;
        alt = !alt;
        n /= 10;
      }

      return (sum % 10 == 0);
    }

    public static bool LuhnLinq(long number)
    {
      string s = number.ToString();
      return s.Select((c, i) => (c - '0') << ((s.Length - i - 1) & 1)).Sum(n => n > 9 ? n - 9 : n) % 10 == 0;
    }
  }
}
