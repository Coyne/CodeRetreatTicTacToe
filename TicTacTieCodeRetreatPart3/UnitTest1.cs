using NUnit.Framework;

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
            player.MakeMove();

            Assert.That(player.HasWon(), Is.False);
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
        public void MakeMove()
        {

        }

        public bool HasWon()
        {
            return false;
        }
    }
}