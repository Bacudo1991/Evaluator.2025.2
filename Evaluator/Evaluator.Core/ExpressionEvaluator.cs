namespace Evaluator.Core;
    public class ExpressionEvaluator
    {
        public static double Evaluate(string infix)
        {
            var postfix = InfixToPostfix(infix);
            Console.WriteLine(postfix);
            return 0;
            //return Calulate(postfix);
        }

        private static string InfixToPostfix(string infix)
        {
            var stack = new Stack<char>();
            var postfix = string.Empty;
            foreach (char item in infix)
            {
                if (IsOperator(item))
                {
                    if (item == ')')
                    {
                        do
                        {
                            postfix += stack.Pop();
                        } while (stack.Peek() != '(');
                        stack.Pop();
                    }
                    else
                    {
                        if (stack.Count > 0)
                        {
                            if (PriorityInfix(item) > PriorityStack(stack.Peek()))
                            {
                                stack.Push(item);
                            }
                            else
                            {
                                postfix += stack.Pop();
                                stack.Push(item);
                            }
                        }
                        else
                        {
                            stack.Push(item);
                        }
                    }
                }
                else
                {
                    postfix += item;
                }
            }
            while (stack.Count > 0)
            {
                postfix += stack.Pop();
            }
            return postfix;
        }

        private static bool IsOperator(char item) => item is '^' or '/' or '*' or '%' or '+' or '-' or '(' or ')';

        private static int PriorityInfix(char op) => op switch
        {
            '^' => 4,
            '*' or '/' or '%' => 2,
            '-' or '+' => 1,
            '(' => 5,
            _ => throw new Exception("Invalid expression."),
        };

        private static int PriorityStack(char op) => op switch
        {
            '^' => 3,
            '*' or '/' or '%' => 2,
            '-' or '+' => 1,
            '(' => 0,
            _ => throw new Exception("Invalid expression."),
        };

    }

