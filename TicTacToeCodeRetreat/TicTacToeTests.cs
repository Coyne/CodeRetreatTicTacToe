using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToeCodeRetreat
{
    [TestFixture]
    public class TicTacToeTests
    {
        private Game _game;

        [SetUp]
        public void Setup()
        {
            _game = new Game();
        }

        [Test]
        public void Game_WhenCreating_HasTwoPlayers()
        {
            Assert.That(_game.Players.Count, Is.EqualTo(2));
        }

        [Test]
        public void Game_WhenCreating_EachPlayerHasDifferentCharacter()
        {
            Assert.That(_game.Players.Select(player => player.Character), Is.EquivalentTo(_game.Players.Select(player => player.Character).Distinct()));
        }

        [Test]
        public void Game_WhenCreating_AssignsCurrentPlayer()
        {
            Assert.That(_game.CurrentPlayer, Is.Not.Null);
        }

        [Test]
        public void Game_WhenCreating_InitializedABoard()
        {
            Assert.That(_game.Board, Is.Not.Null);
        }

        [Test]
        public void Game_WhenCreating_InitializedBoardIsEmpty()
        {
            Assert.That(_game.Board.Slots, Is.EquivalentTo(new string[3,3]));
        }

        [Test]
        public void Game_StartTurn_PutsACharacterOnTheBoard()
        {
            _game.StartTurn();

            Assert.That(_game.Board.Slots, Is.Not.EquivalentTo(new string[3, 3]))
        }

        [Test]
        public void Game_StartTurn_PutsTheCurrentPlayersCharacterOnTheBoard()
        {
            _game.StartTurn();

            Assert.That(_game.Board.Slots., Is.Not.EquivalentTo(new string[3, 3]))
        }
    }

    public class Game
    {
        public Game()
        {
            CreatePlayers();
            SetCurrentPlayer();
            InitializeBoard();
        }

        public void StartTurn()
        {
            ExecuteMove();

        }

        public void ExecuteMove()
        {
            var posX = new System.Random().Next(0, 2);
            var posY = new System.Random().Next(0, 2);

            if (!Board.TryAddCharacter(posX, posY, CurrentPlayer.Character))
                ExecuteMove();
        }


        private void SetCurrentPlayer()
        {
            CurrentPlayer = Players.First();
        }

        private void CreatePlayers()
        {
            Players = new List<Player>
            {
                new Player("O"),
                new Player("X")
            };
        }

        private void InitializeBoard()
        {
            Board = new Board();
        }

        

        public Board Board { get; private set; }
        public List<Player> Players { get; private set; }
        public Player CurrentPlayer { get; private set;  }
    }

    public class Board
    {
        public string[,] Slots { get; private set; }

        public Board()
        {
            Slots = new string[3,3];
        }

        public bool TryAddCharacter(int posX, int posY, string character)
        {
            if (Slots[posX, posY] != null) return false;

            Slots[posX, posY] = character;
            return true;
        }
    }

    public struct Player
    {
        public string Character { get; }

        public Player(string character)
        {
            Character = character;
        }
    }
}
