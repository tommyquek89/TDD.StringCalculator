using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            var delimiters = new List<string> { ",", "\n" };

            if (numbers.StartsWith("//"))
            {
                var splitOnFirstNewLine = numbers.Split(new[] {'\n'}, 2);
                var customDelimiter = splitOnFirstNewLine[0].Replace("//", string.Empty).Trim('[',']').Split(new string[] { "][" }, StringSplitOptions.RemoveEmptyEntries);
                delimiters.AddRange(customDelimiter);
                numbers = splitOnFirstNewLine[1];
            }
            
            var splitNumbers = numbers
                .Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            var negativeNumbers = splitNumbers.Where(x => x < 0).ToList();

            if (negativeNumbers.Any())
            {
                throw new Exception("Negatives not allowed: " + string.Join(",", negativeNumbers));
            }

            return splitNumbers.Where(x => x <= 1000).Sum();
        }
    }
}