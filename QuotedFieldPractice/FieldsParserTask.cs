using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace TableParser;

[TestFixture]
public class FieldParserTaskTests
{
    public static void Test(string input, string[] expectedResult)
    {
        var actualResult = FieldsParserTask.ParseLine(input);
        Assert.That(actualResult.Count, Is.EqualTo(expectedResult.Length));
        for (int i = 0; i < expectedResult.Length; ++i)
        {
            Assert.That(actualResult[i].Value, Is.EqualTo(expectedResult[i]));
        }
    }

    [TestCase("text", new[] { "text" })]
    [TestCase("hello world", new[] { "hello", "world" })]
    [TestCase("", new string[0])]
    [TestCase("   ", new string[0])]
    [TestCase(" a ", new[] { "a" })]
    [TestCase("  hello  world  ", new[] { "hello", "world" })]
    [TestCase("'quoted'", new[] { "quoted" })]
    [TestCase("\"double quoted\"", new[] { "double quoted" })]
    [TestCase("'quoted with spaces'", new[] { "quoted with spaces" })]
    [TestCase("text 'quoted' text", new[] { "text", "quoted", "text" })]
    [TestCase("'quoted' text 'another'", new[] { "quoted", "text", "another" })]
    [TestCase("'escaped\\' quote'", new[] { "escaped' quote" })]
    [TestCase("\"escaped\\\" quote\"", new[] { "escaped\" quote" })]
    [TestCase("'quoted '' inside'", new[] { "quoted ' inside" })]
    [TestCase("'unterminated", new[] { "unterminated" })]
    [TestCase("a 'b c' d", new[] { "a", "b c", "d" })]
    [TestCase("'a' b 'c'", new[] { "a", "b", "c" })]
    [TestCase("'a' '' 'c'", new[] { "a", "", "c" })]
    [TestCase("\"a\" \"\" \"c\"", new[] { "a", "", "c" })]
    [TestCase("a,b,c", new[] { "a,b,c" })]
    [TestCase("'a b' c", new[] { "a b", "c" })]
    [TestCase("'a' b 'c d' e", new[] { "a", "b", "c d", "e" })]
    public void TestFieldsParser(string input, string[] expectedResult)
    {
        Test(input, expectedResult);
    }
}

public class FieldsParserTask
{
    public static List<Token> ParseLine(string line)
    {
        var tokens = new List<Token>();
        int currentIndex = 0;

        while (currentIndex < line.Length)
        {
            while (currentIndex < line.Length && char.IsWhiteSpace(line[currentIndex]))
            {
                currentIndex++;
            }

            if (currentIndex >= line.Length)
                break;

            Token token;

            if (line[currentIndex] == '\'' || line[currentIndex] == '"')
            {
                token = ReadQuotedField(line, currentIndex);
            }
            else
            {
                token = ReadSimpleField(line, currentIndex);
            }

            tokens.Add(token);
            currentIndex = token.GetIndexNextToToken();
        }

        return tokens;
    }

    private static Token ReadSimpleField(string line, int startIndex)
    {
        int endIndex = startIndex;

        while (endIndex < line.Length && !char.IsWhiteSpace(line[endIndex]))
        {
            endIndex++;
        }

        string value = line.Substring(startIndex, endIndex - startIndex);
        return new Token(value, startIndex, endIndex - startIndex);
    }

    public static Token ReadQuotedField(string line, int startIndex)
    {
        return QuotedFieldTask.ReadQuotedField(line, startIndex);
    }
}