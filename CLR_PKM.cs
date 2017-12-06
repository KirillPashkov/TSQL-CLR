using System;
using Microsoft.SqlServer.Server;
using System.Text.RegularExpressions;

public class Regex_PKM
{
    [SqlFunction(IsDeterministic = true, IsPrecise = true)]
    public static bool RegExSimpleMatch(string pattern, string matchString)
    {
        Regex r1 = new Regex(pattern.TrimEnd(null));
        return r1.Match(matchString.TrimEnd(null)).Success;
    }
};

public class StringTrim_PKM
{
    [SqlFunction()]
    public static string StringTrim(string pattern, char[] trimChar)
    {
        return pattern.Trim(trimChar);
    }

    [SqlFunction()]
    public static string StringTrimStart(string pattern, char[] trimChar)
    {
        return pattern.TrimStart(trimChar);
    }

    [SqlFunction()]
    public static string StringTrimEnd(string pattern, char[] trimChar)
    {
        return pattern.TrimEnd(trimChar);
    }
};
