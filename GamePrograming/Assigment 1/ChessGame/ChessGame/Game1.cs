﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ChessGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;

        ChessModel chessModel;
        ChessView chessView;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferHeight = 640;
            graphics.PreferredBackBufferWidth = 640;
            graphics.ApplyChanges();

            chessModel = new ChessModel();
            chessModel.CanTakeCommand = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
               // TODO: use this.Content to load your game content here
            chessView = new ChessView(chessModel, Content, GraphicsDevice);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            if (chessModel.CanTakeCommand)
            {

                if (Keyboard.GetState().IsKeyDown(Keys.R))
                {
                    chessModel.TurnTable();
                    chessModel.SetCooldownForCommand();
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.S))
                {
                    graphics.PreferredBackBufferWidth = 320;
                    graphics.PreferredBackBufferHeight = 240;
                    graphics.ApplyChanges();

                    chessModel.SetCooldownForCommand();
                    chessView.UpdateGameResolution(GraphicsDevice);
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.D))
                {
                    graphics.PreferredBackBufferHeight = 640;
                    graphics.PreferredBackBufferWidth = 640;
                    graphics.ApplyChanges();

                    chessModel.SetCooldownForCommand();
                    chessView.UpdateGameResolution(GraphicsDevice);
                }
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            chessView.DrawGame();

            base.Draw(gameTime);
        }
    }
}
