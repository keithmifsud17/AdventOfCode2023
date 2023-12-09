using Spectre.Console;

namespace AdventOfCode2023.Tasks.Day7
{
    internal record Game(string Hand, int Winnings)
    {
        private Lazy<IEnumerable<int>>? lazyScores;
        private Lazy<IEnumerable<int>>? lazyJokerScores;

        public IEnumerable<int> Scores => (lazyScores ??= new(() => CalculateScores(Hand))).Value;

        public IEnumerable<int> JokerScores => (lazyJokerScores ??= new(CalculateJokerScores)).Value;

        private IEnumerable<int> CalculateJokerScores()
        {
            var aggregatedHand = AggregateHand(Hand);

            if (aggregatedHand.TryGetValue('J', out int joker))
            {
                var currentScores = aggregatedHand.Where(x => x.Key != 'J').OrderByDescending(x => x.Value).ToDictionary();
                
                if (currentScores.Count == 0)
                {
                    return CalculateScores(aggregatedHand, GetJokerPriority);
                }
                else if (currentScores.Count == 1) // Five of a kind with Joker
                {
                    currentScores[currentScores.Keys.First()] = 5;
                    return CalculateScores(currentScores, GetJokerPriority);
                }
                else if (currentScores.ContainsValue(3) || joker == 3) // Four of a kind 
                {
                    currentScores[currentScores.Keys.First()] = 4;
                    return CalculateScores(currentScores, GetJokerPriority);
                }
                else if (joker == 2 && currentScores.ContainsValue(2)) // Four of a kind 
                {
                    currentScores[currentScores.Keys.First()] = 4;
                    return CalculateScores(currentScores, GetJokerPriority);
                }
                else if (currentScores.Values.All(x => x == 2)) // Full House
                {
                    currentScores[currentScores.Keys.First()] = 3;
                    return CalculateScores(currentScores, GetJokerPriority);
                }
                else if (currentScores.ContainsValue(2) || joker == 2) // Three of a kind
                {
                    currentScores[currentScores.Keys.First()] = 3;
                    return CalculateScores(currentScores, GetJokerPriority);
                }

                currentScores[currentScores.Keys.First()] = 2;
                return CalculateScores(currentScores, GetJokerPriority);
            }

            return CalculateScores(aggregatedHand, GetJokerPriority);
        }

        private IEnumerable<int> CalculateScores(string hand)
        {
            var aggregatedHand = AggregateHand(hand);

            return CalculateScores(aggregatedHand, GetPriority);
        }

        private IEnumerable<int> CalculateScores(Dictionary<char, int> aggregatedHand, Func<char, int> getPriority)
        {
            if (aggregatedHand.ContainsValue(5)) // Five of a kind
            {
                return Enumerable.Range(0, 5).Select(i => (6 * 15) + getPriority(Hand[i]));
            }
            else if (aggregatedHand.ContainsValue(4)) // Four of a kind
            {
                return Enumerable.Range(0, 5).Select(i => (5 * 15) + getPriority(Hand[i]));
            }
            else if (aggregatedHand.ContainsValue(2) && aggregatedHand.ContainsValue(3)) // Full House
            {
                return Enumerable.Range(0, 5).Select(i => (4 * 15) + getPriority(Hand[i]));
            }
            else if (aggregatedHand.ContainsValue(3)) // Three of a kind
            {
                return Enumerable.Range(0, 5).Select(i => (3 * 15) + getPriority(Hand[i]));
            }
            else if (aggregatedHand.Values.Where(x => x == 2).Count() == 2) // Two Pair
            {
                return Enumerable.Range(0, 5).Select(i => (2 * 15) + getPriority(Hand[i]));
            }
            else if (aggregatedHand.ContainsValue(2)) // Pair
            {
                return Enumerable.Range(0, 5).Select(i => (1 * 15) + getPriority(Hand[i]));
            }
            return Enumerable.Range(0, 5).Select(i => getPriority(Hand[i]));
        }

        private static Dictionary<char, int> AggregateHand(string hand) => hand.Aggregate(
            new Dictionary<char, int>(),
            (d, c) =>
            {
                if (d.TryGetValue(c, out int value))
                {
                    d[c] = ++value;
                }
                else
                {
                    d[c] = 1;
                }

                return d;
            });

        private static int GetPriority(char v) => v switch
        {
            'A' => 13,
            'K' => 12,
            'Q' => 11,
            'J' => 10,
            'T' => 9,
            '9' => 8,
            '8' => 7,
            '7' => 6,
            '6' => 5,
            '5' => 4,
            '4' => 3,
            '3' => 2,
            '2' => 1,
            _ => 0,
        };

        private static int GetJokerPriority(char v) => v switch
        {
            'A' => 13,
            'K' => 12,
            'Q' => 11,
            'T' => 10,
            '9' => 9,
            '8' => 8,
            '7' => 7,
            '6' => 6,
            '5' => 5,
            '4' => 4,
            '3' => 3,
            '2' => 2,
            'J' => 1,
            _ => 0,
        };

        public override string ToString()
        {
            return string.Format("Hand: {0}; Winnings: {1}; Scores: {2}; Joker Scores: {3}", Hand, Winnings, string.Join(',', Scores), string.Join(',', JokerScores));
        }
    }
}
