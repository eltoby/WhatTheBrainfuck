using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
    static void Main(string[] args)
    {
        string[] inputs = Console.ReadLine().Split(' ');
        int L = int.Parse(inputs[0]);
        int S = int.Parse(inputs[1]);
        int I = int.Parse(inputs[2]);

        var array = new int[S];
        var values = new int[I];

        var pointer = 0;
        var valuesPointer = 0;

        var result = new StringBuilder();

        var program = "";

        var brackets = new Dictionary<int, int>();

        for (int i = 0; i < L; i++)
            program += Console.ReadLine();

        for (int i = 0; i < I; i++)
            values[i] = int.Parse(Console.ReadLine());

        var openBrackets = new Stack<int>();

        for (var i = 0; i < program.Length; i++)
        {
            switch (program[i])
            {
                case '[':
                    openBrackets.Push(i);
                    break;
                case ']':
                    if (openBrackets.Count == 0)
                    {
                        Console.WriteLine("SYNTAX ERROR");
                        break;
                    }

                    var opener = openBrackets.Pop();
                    brackets.Add(opener, i);
                    brackets.Add(i, opener);
                    break;
            }
        }

        if (openBrackets.Count > 0)
        {
            Console.WriteLine("SYNTAX ERROR");
            return;
        }

        var pos = 0;

        while (pos < program.Length)
        {
            var c = program[pos];

            switch (c)
            {
                case '+':
                    array[pointer]++;

                    if (array[pointer] > 255)
                    {
                        Console.WriteLine("INCORRECT VALUE");
                        return;
                    }

                    break;
                case '-':
                    array[pointer]--;

                    if (array[pointer] < 0)
                    {
                        Console.WriteLine("INCORRECT VALUE");
                        return;
                    }

                    break;
                case '.':
                    result.Append(Convert.ToChar(array[pointer]));
                    break;
                case ',':
                    array[pointer] = values[valuesPointer];
                    valuesPointer++;
                    break;
                case '[':
                    if (array[pointer] == 0)
                        pos = brackets[pos];
                    break;
                case ']':
                    if (array[pointer] != 0)

                        pos = brackets[pos];
                    break;
                case '>':
                    if (pointer == S - 1)
                    {
                        Console.WriteLine("POINTER OUT OF BOUNDS");
                        return;
                    }    

                    pointer++;
                    break;
                case '<':
                    if (pointer == 0)
                    {
                        Console.WriteLine("POINTER OUT OF BOUNDS");
                        return;
                    }
                    pointer--;
                    break;
            }

            pos++;
        }

        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(result.ToString());
    }
}