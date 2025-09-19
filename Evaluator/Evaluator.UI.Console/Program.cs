
using Evaluator.Core;

Console.WriteLine("Hello, Evaluator");
var infix = "4*5/(4+6)";
var result = ExpressionEvaluator.Evaluate(infix);
Console.WriteLine($"{infix}={result}");
