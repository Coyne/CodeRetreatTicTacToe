using NUnit.Framework;
using System.Collections.Generic;

namespace TicTacTieCodeRetreatPart3
{
    public class Tests
    {
        [Test]
        public void Game_NobodyWon_StillRunning()
        {
            var game = new Game();

            Assert.That(game.IsRunning, Is.True);
        }
        [Test]
        public void Player_NoMoves_HasntWonYet()
        {
            var player = new Player();

            Assert.That(player.HasWon(), Is.False);
        }

        [Test]
        public void Player_MakesOneMove_HasntWonYet()
        {
            var player = new Player();
            player.MakeMove(1);

            Assert.That(player.HasWon(), Is.False);
        }

        [Test]
        public void Player_MakesThreeMoves_Horizontally_Wins()
        {
            var player = new Player();
            player.MakeMove(1);
            player.MakeMove(2);
            player.MakeMove(3);

            Assert.That(player.HasWon(), Is.True);
        }

        [Test]
        public void Player_MakesThreeMoves_HasntWonYet()
        {
            var player = new Player();
            player.MakeMove(1);
            player.MakeMove(2);
            player.MakeMove(4);

            Assert.That(player.HasWon(), Is.False);
        }

        [Test]
        public void Player_MakesThreeMoves_Vertically_Wins()
        {

            var player = new Player();
            player.MakeMove(1);
            player.MakeMove(4);
            player.MakeMove(7);

            Assert.That(player.HasWon(), Is.True);
        }

        [Test]
        public void Player_MakesThreeMoves_Diagonally_Wins()
        {

            var player = new Player();
            player.MakeMove(1);
            player.MakeMove(5);
            player.MakeMove(9);

            Assert.That(player.HasWon(), Is.True);
        }
    }

    public class Game
    {
        public Game()
        {
            IsRunning = true;
        }
        public bool IsRunning { get; set; }
    }

    public class Player
    {
        private List<int> _moves = new List<int>();

        public void MakeMove(int index)
        {
            _moves.Add(index);
        }

        public bool HasWon()
        {
            return (HasHorizontalLine()) || (HasVerticalLine() || HasDiagonalLine());
        }

        private bool HasVerticalLine()
        {
            return _moves.Contains(1) &&
                        _moves.Contains(4) &&
                        _moves.Contains(7);
        }

        private bool HasHorizontalLine()
        {
            return _moves.Contains(1) &&
                        _moves.Contains(2) &&
                        _moves.Contains(3);
        }

        private bool HasDiagonalLine()
        {
            return _moves.Contains(1) &&
                        _moves.Contains(5) &&
                        _moves.Contains(9);
        }
    }
}