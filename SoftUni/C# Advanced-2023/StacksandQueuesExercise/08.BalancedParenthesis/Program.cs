string input = Console.ReadLine();
bool isBalanced = IsParenthesesBalanced(input);
Console.WriteLine(isBalanced ? "YES" : "NO");

static bool IsParenthesesBalanced(string input)
{
    Stack<char> stack = new ();

    foreach (char c in input)
    {
        if (IsOpeningParenthesis(c))
        {
            stack.Push(c);
        }
        else if (IsClosingParenthesis(c))
        {
            if (stack.Count == 0 || !IsMatchingPair(stack.Pop(), c))
            {
                return false;
            }
        }
    }

    return stack.Count == 0;
}

static bool IsOpeningParenthesis(char c)
{
    return c == '(' || c == '{' || c == '[';
}

static bool IsClosingParenthesis(char c)
{
    return c == ')' || c == '}' || c == ']';
}

static bool IsMatchingPair(char opening, char closing)
{
    return (opening == '(' && closing == ')') ||
           (opening == '{' && closing == '}') ||
           (opening == '[' && closing == ']');
}
