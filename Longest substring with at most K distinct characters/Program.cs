using System;
using System.Collections.Generic;

namespace Longest_substring_with_at_most_K_distinct_characters
{
  class Program
  {
    static void Main(string[] args)
    {
      Solution s = new Solution();
      string str = "abcdaaabbccc";
      int k = 3;
      var answer = s.LengthOfLongestSubstringKDistinct(str, k);
      Console.WriteLine(answer);
    }
  }

  public class Solution
  {
    public int LengthOfLongestSubstringKDistinct(string s, int k)
    {
      // Example - abcdaaabbccc
      int l = 0; int r = 0;
      int length = s.Length;
      var frequency = new Dictionary<char, int>();
      int unique = 0;
      int res = 0;
      while(r < length && length - l > res)
      {
        char c = s[r];
        if (!frequency.ContainsKey(c)) frequency.Add(c, 0);
        frequency[c]++;
        if (frequency[c] == 1) unique++;

        while (unique > k)
        {
          char leftChar = s[l];
          frequency[leftChar]--;

          if (frequency[leftChar] == 0) unique--;
          l++;
        }

        int currentLength = r - l + 1;
        res = Math.Max(res, currentLength);
        r++;
      }
      string sbStr = s.Substring(l, res);
      Console.WriteLine(sbStr);
      return res;
    }
  }
}
