using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsLib.Behavioral
{
    public class StateDemo
    {
        public void Show()
        {
            new Game().Update();
        }

        class Game
        {
            private IGameState state;
            public IGameState State
            {
                get => state;
                set
                {
                    state = value;
                    Update();
                }
            }

            public Game()
            {
                state = new MenuState(this);
            }
            public void Update()
            {
                state.Update();
            }

            private List<IGameState> states = new List<IGameState>();

            public void Play()
            {
                foreach (var state in states)
                {
                    if (state is PlayState)
                    {
                        State = state;
                        return;
                    }

                }
                var newState = new PlayState(this);
                states.Add(newState);
                State = newState;
            }
            public void Pause()
            {
                foreach (var state in states)
                {
                    if (state is PauseState)
                    {
                        State = state;
                        return;
                    }

                }
                var newState = new PauseState(this);
                states.Add(newState);
                State = newState;

            }
            public void Menu()
            {
                foreach (var state in states)
                {
                    if (state is MenuState)
                    {
                        State = state;
                        return;
                    }

                }
                var newState = new MenuState(this);
                states.Add(newState);
                State = newState;
            }
            public void GameOver()
            {
                foreach (var state in states)
                {
                    if (state is GameOverState)
                    {
                        State = state;
                        return;
                    }

                }
                var newState = new GameOverState(this);
                states.Add(newState);
                State = newState;
            }

        }

        class MenuState : IGameState
        {
            private readonly Game game;
            public MenuState(Game game)
            {
                this.game = game;
            }
            public void Update()
            {
                Console.WriteLine("Menu: ");
                Console.WriteLine("Any Key: Play");
                Console.ReadKey(true);

                game.Play();
            }
        }

        class PlayState : IGameState
        {
            private readonly Game game;
            public PlayState(Game game)
            {
                this.game = game;
            }
            public void Update()
            {
                ConsoleKeyInfo key;
                do
                {


                    Console.WriteLine("Playing... ");
                    key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.P)
                    {
                        game.Pause();
                        return;
                    }
                    if (key.Key == ConsoleKey.Escape)
                    {
                        game.GameOver();
                        return;
                    }

                } while (key.Key != ConsoleKey.Escape);




            }
        }

        class PauseState : IGameState
        {
            private readonly Game game;
            public PauseState(Game game)
            {
                this.game = game;
            }
            public void Update()
            {
                Console.WriteLine("Paused...");
                Console.WriteLine(" Press Any Key");
                Console.ReadKey(true);
                game.Play();


            }
        }

        class GameOverState : IGameState
        {
            private readonly Game game;
            public GameOverState(Game game)
            {
                this.game = game;
            }
            public void Update()
            {
                Console.WriteLine("GAME OVER");
                game.Menu();
            }
        }

        interface IGameState
        {
            void Update();
        }
    }
}
