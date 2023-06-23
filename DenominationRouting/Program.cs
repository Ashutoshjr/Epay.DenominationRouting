namespace DenominationRouting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] denominations = { 10, 50, 100 };
            int[] payoutAmounts = { 30, 50, 60, 80, 140, 230, 370, 610, 980 };

            foreach (int amount in payoutAmounts)
            {
                Console.WriteLine("Payout amount: " + amount + " EUR");
                List<List<int>> combinations = CalculateCombinations(amount, denominations);
                PrintCombinations(combinations);
                Console.WriteLine();
            }

            Console.ReadLine();
        }

        static List<List<int>> CalculateCombinations(int amount, int[] denominations)
        {
            List<List<int>> combinations = new List<List<int>>();
            CalculateCombinationsRecursive(amount, denominations, new List<int>(), combinations);
            return combinations;
        }

        static void CalculateCombinationsRecursive(int amount, int[] denominations, List<int> currentCombination, List<List<int>> combinations)
        {
            if (amount == 0)
            {
                combinations.Add(new List<int>(currentCombination));
                return;
            }

            if (amount < 0)
                return;

            for (int i = 0; i < denominations.Length; i++)
            {
                int denomination = denominations[i];
                if (amount >= denomination)
                {
                    currentCombination.Add(denomination);
                    CalculateCombinationsRecursive(amount - denomination, denominations, currentCombination, combinations);
                    currentCombination.RemoveAt(currentCombination.Count - 1);
                }
            }
        }

        static void PrintCombinations(List<List<int>> combinations)
        {
            if (combinations.Count == 0)
            {
                Console.WriteLine("No combinations possible.");
                return;
            }

            foreach (List<int> combination in combinations)
            {
                Console.WriteLine(string.Join(" + ", combination) + " EUR");
            }
        }

    }
}