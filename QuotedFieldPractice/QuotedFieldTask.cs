using NUnit.Framework;

namespace TableParser;

[TestFixture]
public class QuotedFieldTaskTests
{
    [TestCase("a\"b c d\"f", 1, "b c d", 7)]
    [TestCase("'a \"b\" c'", 0, "a \"b\" c", 9)]
    [TestCase("\"a 'b' c\"", 0, "a 'b' c", 9)]
    [TestCase("\"\\\"\"", 0, "\"", 4)]
    [TestCase("'\\\\'", 0, "\\", 4)]
    [TestCase("\"\"", 0, "", 2)]
    [TestCase("'' ''", 0, "", 2)]
    [TestCase("'' ''", 3, "", 2)]
    [TestCase("\"abc", 0, "abc", 4)]
    [TestCase("'abc", 0, "abc", 4)]
    [TestCase("  \"abc\"", 2, "abc", 5)]
    [TestCase("\t\"abc\"", 1, "abc", 5)]
    [TestCase("x'y'z", 1, "y", 3)]
    [TestCase("\"a\\\"b\\\"c\"", 0, "a\"b\"c", 9)]
    public void Test(string line, int startIndex, string expectedValue, int expectedLength)
    {
        var actualToken = QuotedFieldTask.ReadQuotedField(line, startIndex);
        Assert.That(actualToken, Is.EqualTo(new Token(expectedValue, startIndex, expectedLength)));
    }
}

class QuotedFieldTask
{
    public static Token ReadQuotedField(string line, int startIndex)
    {
        if (!IsQuoteStart(line, startIndex, out char quote))
        {
            return new Token("", startIndex, 0);
        }
        return ParseQuoted(line, startIndex, quote);
    }

    private static bool IsQuoteStart(string line, int index, out char quote)
    {
        quote = '\0';
        if (index >= line.Length)
        {
            return false;
        }
        quote = line[index];
        return quote == '\'' || quote == '"';
    }

    private static Token ParseQuoted(string line, int startIndex, char quote)
    {
        var sb = new System.Text.StringBuilder();
        int i = startIndex + 1;

        while (i < line.Length)
        {
            char c = line[i];

            if (c == quote)
            {
                if (i + 1 < line.Length && line[i + 1] == quote)
                {
                    sb.Append(quote);
                    i += 2;
                    continue;
                }
                return new Token(sb.ToString(), startIndex, i - startIndex + 1);
            }

            if (c == '\\' && i + 1 < line.Length && (line[i + 1] == quote || line[i + 1] == '\\'))
            {
                sb.Append(line[i + 1]);
                i += 2;
                continue;
            }

            sb.Append(c);
            i++;
        }

        return new Token(sb.ToString(), startIndex, line.Length - startIndex);
    }
}