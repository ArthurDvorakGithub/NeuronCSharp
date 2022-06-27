using System;

namespace Neuron_on_CSharp
{
    class Program
    {
        public class Neuron
        {
            private decimal weight = 0.5m;
            public decimal LastError { get; private set; }
            public decimal Smoothing { get; set; } = 0.00001m;
            public decimal ProccesInputData(decimal input)
            {
                return input * weight;
            }

            public decimal RestoreInputData(decimal output)
            {
                return output / weight;
            }

            public void Train(decimal input, decimal exprctedResult)
            {
                var actualResult = input * weight;
                LastError = exprctedResult - actualResult;
                var correction = (LastError / actualResult) * Smoothing;
                weight += correction;
            }
        }
        static void Main(string[] args)
        {
            decimal km = 100;
            decimal miles = 62.1371m;

            Neuron neuron = new Neuron();

            int i = 0;

            do
            {
                i++;
                neuron.Train(km, miles);
                if (i % 1000000 == 0)
                {
                    Console.WriteLine($"Итерация: {i}\tОшибка:\t{neuron.LastError}");
                }
                
            }
            while (neuron.LastError > neuron.Smoothing || neuron.LastError < -neuron.Smoothing);

            Console.WriteLine("now their training is complete");

            Console.WriteLine($"{neuron.ProccesInputData(100)} миль в {100} км");

            Console.WriteLine($"{neuron.ProccesInputData(541)} миль в {541} км");

        }
    }
}
