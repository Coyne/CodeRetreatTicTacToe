using NUnit.Framework;
using System.Linq;

namespace TicTacToeCodeRetreatPart2
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GameCreated_EachPlayerHasDifferentCharacter()
        {
            var game = new Game();

            Assert.That(game.Players.Select(player => player.Character), Is.EquivalentTo(game.Players.Select(player => player.Character).Distinct()));
        }

        [Test]
        public void GameCreated_HasOneActivePlayer()
        {
            var game = new Game();

            Assert.That(game.ActivePlayer, Is.Not.Null);
        }

        [Test]
        public void GameCreated_AllSpotsAvailable()
        {
            var game = new Game();

            Assert.That(game.Spots.All(spot => spot.Available), Is.True);
        }

        [Test]
        public void GameCreated_SpotsMakeUp3By3Grid()
        {
            var game = new Game();

            Assert.That(game.Spots, Is.EquivalentTo(new[]
            {
                new Spot() { Row = 1, Column = 1},
                new Spot() { Row = 1, Column = 2},
                new Spot() { Row = 1, Column = 3},
                new Spot() { Row = 2, Column = 1},
                new Spot() { Row = 2, Column = 2},
                new Spot() { Row = 2, Column = 3},
                new Spot() { Row = 3, Column = 1},
                new Spot() { Row = 3, Column = 2},
                new Spot() { Row = 3, Column = 3},
            }));
        }
    }

    public class Game
    {
        public Player[] Players { get; }
        public Player ActivePlayer { get; }

        public Spot[] Spots { get; }

        public Game()
        {
            ActivePlayer = new Player("x");
            Players = new Player[] {  ActivePlayer, new Player("o") };
            Spots = CreateBoard();
        }

        private static Spot[] CreateBoard()
        {
            return new Spot[] {
                new Spot(1,1), new Spot(1,2), new Spot(1,3),
                new Spot(2,1), new Spot(2,2), new Spot(2,3),
                new Spot(3,1), new Spot(3,2), new Spot(3,3)
            };
       
        }
    }

    public class Player
    {
        public string Character { get; }

        public Player(string character)
        {
            Character = character;
        }
    }

    public class Spot
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public Spot(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public Spot() { }

        public override bool Equals(object obj)
        {
            var spot = obj as Spot;
            if (spot == null) return false;

            if (Row == spot.Row && Column == spot.Column)
            {
                return true;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return (Row << 2) ^ Column;
        }

        public bool Available => true;
    }
}