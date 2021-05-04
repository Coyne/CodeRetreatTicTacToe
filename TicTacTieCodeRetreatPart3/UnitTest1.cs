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
    }

    public class Game
    {
        public Game()
        {
            IsRunning = true;
        }
        public bool IsRunning { get; set; }
    }
}