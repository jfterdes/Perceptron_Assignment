namespace Perceptron_Terdes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] input = new int[][] { new int[] { 1, 0 }, new int[] { 1, 1 }, new int[] { 0, 1 }, new int[] { 0, 0 } };
            int[] outputs = { 1, 0, 1, 1 };

            Random r = new Random();

            double[] weights = { r.NextDouble(), r.NextDouble(), r.NextDouble() };

            double learning_Rate = 1;
            double total_Error = 1;

            while (total_Error > 0.2)
            {
                total_Error = 0;
                for (int i = 0; i < 4; i++)
                {
                    int output = calculate_Output(input[i][0], input[i][1], weights);

                    int error = outputs[i] - output;

                    weights[0] += learning_Rate * error * input[i][0];
                    weights[1] += learning_Rate * error * input[i][1];
                    weights[2] += learning_Rate * error * 1;

                    total_Error += Math.Abs(error);
                }

            }

            Console.WriteLine("Enter two integers:");
            int input1 = Convert.ToInt32(Console.ReadLine());
            int input2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Results:");
            Console.WriteLine(calculate_Output(input1, input2, weights));

        }

        private static int calculate_Output(double input1, double input2, double[] weights)
        {
            double sum = input1 * weights[0] + input2 * weights[1] + 1 * weights[2];
            return (sum >= 0) ? 1 : 0;
        }
    }
}