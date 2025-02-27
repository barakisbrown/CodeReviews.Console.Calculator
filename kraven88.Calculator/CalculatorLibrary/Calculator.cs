﻿using CalculatorLibrary.Models;

namespace CalculatorLibrary;

public class Calculator
{
    private List<Equation> equations;
    private string filePath;
    public int calulatorUseCount = 0;

    public Calculator(List<Equation> equations, string filePath)
    {
        this.equations= equations;
        this.filePath = filePath;
    }

    public double DoOperation(double num1, double num2, string operation)
    {
        var eq = new Equation()
        {
            A= num1,
            B= num2,
            Operation = operation switch
            {
                "a"     => "Add",
                "s"     => "Subtract",
                "m"     => "Multiply",
                "d"     => "Divide",
                "p"     => "Power",
                "r"     => "Root",
                "sin"   => "Sine",
                "cos"   => "Cosine",
                "tg"    => "Tangent",
                "ctg"   => "Cotangent",
            }
        };

        // Use switch statement to do the math;
        switch (operation)
        {
            case "a":
                eq.Result = num1 + num2;
                break;
            case "s":
                eq.Result = num1 - num2;
                break;
            case "m":
                eq.Result = num1 * num2;
                break;
            case "d":
                if (num2 != 0)
                    eq.Result = num1 / num2;
                break;
            case "p":
                eq.Result = Math.Pow(num1, num2);
                break;
            case "r":
                eq.Result = Math.Pow(num2, 1.0 / num1);
                break;
            case "sin":
                eq.Result = Math.Sin((num1 * (Math.PI * 2)) / 360);     // This converts degrees to radians, so that Math.Sin() will work as intended
                break;
            case "cos":
                eq.Result = Math.Cos((num1 * (Math.PI * 2)) / 360);
                break;
            case "tg":
                eq.Result = Math.Tan((num1 * (Math.PI * 2)) / 360);
                break;
            case "ctg":
                eq.Result = (Math.Cos((num1 * (Math.PI * 2)) / 360) / Math.Sin((num1 * (Math.PI * 2)) / 360)); // Oddly, there is no Math method for cotangent
                break;
            default:
                break;
        }

        equations.Add(eq);
        DataAccess.SaveEquations(equations, filePath);

        return eq.Result;
    }
}
