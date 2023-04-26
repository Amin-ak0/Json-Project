﻿// This file was auto-generated by ML.NET Model Builder. 

using System;

namespace MLModel1_ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // predict with default option.
            var modelOutput = MLModel1.Predict();
            Console.WriteLine(string.Join(",", modelOutput.Col4));

            // predict next 5 periods
            modelOutput = MLModel1.Predict(horizon: 5);
            Console.WriteLine(string.Join(",", modelOutput.Col4));

            // update and predict model
            // TBD
        }
    }
}
