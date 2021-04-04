using System;
using System.Collections.Generic;
using System.Linq;

namespace TextAnalysis
{
    class TextAnalyzer
    {
        private IEnumerable<char> Separators => new[]
            {' ', '.', '?', '!', ',', ':', ';', '(', ')', '[', ']', '{', '}', '\'', '"', '-'};

        private IEnumerable<string> IgnoreList => new[]
        {
            "a", "an", "the", "for", "by", "and", "or", "but", "so", "also", "in", "out", "to", "at", "on", "s", "es",
            "is", "of", "it", "from", "as", "that", "this", "not", "its", "with"
        };

        public string GetStats(string text) =>
            string.Join(Environment.NewLine, text
                .Split(Separators.ToArray(), StringSplitOptions.RemoveEmptyEntries)
                .Where(word => !IgnoreList.Contains(word))
                .GroupBy(word => word.ToLower())
                .OrderByDescending(wordGroup => wordGroup.Count())
                .Select(wordGroup => $"{wordGroup.Key}: {wordGroup.Count()}"));
    }
}