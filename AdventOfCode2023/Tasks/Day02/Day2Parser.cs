namespace AdventOfCode2023.Tasks.Day2
{
    internal class Day2Parser
    {
        public static IEnumerable<Game> ParseGames(IEnumerable<string> lines) => lines.Select(ParseGame);

        private static Game ParseGame(string line)
        {
            var x = line.Split(':');
            return new Game()
            {
                Id = int.Parse(x[0].Replace("Game ", "")),
                Bags = x[1].Split(';').Select(ParseBag)
            };
        }

        private static Bag ParseBag(string line)
        {
            var x = line.Split(',');
            return new Bag()
            {
                Red = x.FirstOrDefault(e => e.EndsWith("red")) is string red ? int.Parse(red.Replace(" red", "")) : 0,
                Blue = x.FirstOrDefault(e => e.EndsWith("blue")) is string blue ? int.Parse(blue.Replace(" blue", "")) : 0,
                Green = x.FirstOrDefault(e => e.EndsWith("green")) is string green ? int.Parse(green.Replace(" green", "")) : 0,
            };
        }
    }

    public class Game
    {
        public int Id { get; set; }
        public IEnumerable<Bag> Bags { get; set; }
    }

    public class Bag
    {
        public int Red { get; set; }
        public int Green { get; set; }
        public int Blue { get; set; }
    }
}
