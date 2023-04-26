using System.Diagnostics;

namespace First_Jason_Project.Model
{
    public class Prediction
    {
        public async Task Predict()
        {

            Port.InitializeClient();
            var realprice = await processor.LoadInformation();
            var timer = Stopwatch.StartNew();


            string address = @"E:\visual studio\Practice\First Jason Project\First Jason Project\data.csv";

            using (StreamWriter sw = new StreamWriter(address))
            {
                int i = 1;
                do
                {
                    realprice = await processor.LoadInformation();

                    sw.WriteLine($"price number {i} : {realprice.buy}");
                    i++;

                    Thread.Sleep(1000);

                } while (timer.ElapsedMilliseconds < 900000);

            }

        }
        public async Task PredictByAverage()
        {

            Port.InitializeClient();
            var realprice = await processor.LoadInformation();
            var timer = Stopwatch.StartNew();
            double sum = 0;

            int i = 0;

            while (true)
            {
                realprice = await processor.LoadInformation();
                i++;
                sum = sum + realprice.buy;

                Console.WriteLine($"real price is : {realprice.buy}");

                if (timer.ElapsedMilliseconds >= 1800000)
                {
                    Console.WriteLine($"prediction is : {sum / i}");
                    Console.WriteLine($"percentage errorv : {((realprice.buy - (sum / i)) / realprice.buy * 100)}");
                    timer.Restart();
                }
                Thread.Sleep(1000);
            }


        }
    }
}
