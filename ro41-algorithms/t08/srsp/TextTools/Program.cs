class Program
{
    static void Main()
    {
        RunCountWordsTest("", 0);
        RunCountWordsTest("    ", 0);
        RunCountWordsTest(" a  b ", 2);
        RunCountWordsTest("А роза упала на лапу Азора", 6);
        RunCountWordsTest("Ахметов Ерлан", 2);

        RunIsPalindromeTest("", true);
        RunIsPalindromeTest("    ", true);
        RunIsPalindromeTest(" a  b ", false);
        RunIsPalindromeTest("А роза упала на лапу Азора", true);
        RunIsPalindromeTest("Ахметов Ерлан", false);

        RunInitialsTest("", "");
        RunInitialsTest("    ", "");
        RunInitialsTest(" a  b ", "A. B.");
        RunInitialsTest("А роза упала на лапу Азора", "А. Р. У. Н. Л. А.");
        RunInitialsTest("Ахметов Ерлан Серикұлы", "А. Е. С.");
        RunInitialsTest("Ахметов Ерлан", "А. Е.");

        RunRepeatTest("ab", 3, "ababab");
        RunRepeatTest("", 3, "");
        RunRepeatTest("test", 0, "");
    }

    static void RunCountWordsTest(string input, int expected)
    {
        int actual = TextTools.CountWords(input);
        string status = (actual == expected) ? "OK" : "FAIL";
        System.Console.WriteLine($"CountWords | Вход: \"{input}\" | Ожидалось: {expected} | Фактически: {actual} | [{status}]");
    }

    static void RunIsPalindromeTest(string input, bool expected)
    {
        bool actual = TextTools.IsPalindrome(input);
        string status = (actual == expected) ? "OK" : "FAIL";
        System.Console.WriteLine($"IsPalindrome | Вход: \"{input}\" | Ожидалось: {expected} | Фактически: {actual} | [{status}]");
    }

    static void RunInitialsTest(string input, string expected)
    {
        string actual = TextTools.Initials(input);
        string status = (actual == expected) ? "OK" : "FAIL";
        System.Console.WriteLine($"Initials | Вход: \"{input}\" | Ожидалось: \"{expected}\" | Фактически: \"{actual}\" | [{status}]");
    }

    static void RunRepeatTest(string input, int n, string expected)
    {
        string actual = TextTools.Repeat(input, n);
        string status = (actual == expected) ? "OK" : "FAIL";
        System.Console.WriteLine($"Repeat | Вход: \"{input}\", n={n} | Ожидалось: \"{expected}\" | Фактически: \"{actual}\" | [{status}]");
    }
}

static class TextTools
{
    public static int CountWords(string s)
    {
        if (string.IsNullOrWhiteSpace(s))
        {
            return 0;
        }
        string[] words = s.Split(new char[] { ' ', '\t', '\n', '\r' }, System.StringSplitOptions.RemoveEmptyEntries);
        return words.Length;
    }

    public static bool IsPalindrome(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return true;
        }

        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        foreach (char c in s)
        {
            if (!char.IsWhiteSpace(c))
            {
                sb.Append(char.ToLower(c));
            }
        }

        string cleaned = sb.ToString();
        int left = 0;
        int right = cleaned.Length - 1;

        while (left < right)
        {
            if (cleaned[left] != cleaned[right])
            {
                return false;
            }
            left++;
            right--;
        }

        return true;
    }

    public static string Initials(string fullName)
    {
        if (string.IsNullOrWhiteSpace(fullName))
        {
            return string.Empty;
        }

        string[] parts = fullName.Split(new char[] { ' ', '\t', '\n', '\r' }, System.StringSplitOptions.RemoveEmptyEntries);
        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        for (int i = 0; i < parts.Length; i++)
        {
            if (parts[i].Length > 0)
            {
                sb.Append(char.ToUpper(parts[i][0])).Append(". ");
            }
        }

        if (sb.Length > 0)
        {
            sb.Length--;
        }

        return sb.ToString();
    }

    public static string Repeat(string s, int n)
    {
        if (string.IsNullOrEmpty(s) || n <= 0)
        {
            return string.Empty;
        }

        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        for (int i = 0; i < n; i++)
        {
            sb.Append(s);
        }
        return sb.ToString();
    }
}