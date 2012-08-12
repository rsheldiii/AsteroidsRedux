using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WindowsGame1
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        LineBatch lineBatch;
        Texture2D blank;
        Line line1;
        Line line2;
        Ship ship1;
        SpriteFont spritefont;
        KeyboardState oldState = Keyboard.GetState();
        AstObj[] enemies = new AstObj[1];

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            line1 = new Line(new Vector2(50, 50), 50.0, 0);
            line2 = new Line(new Vector2(10, 10), new Vector2(50, 50));
            ship1 = new Ship(new Vector2(300, 300), 1);
            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            Vector2 centerForEnemy = new Vector2(300,300);
            // TODO: Add your initialization logic here
            Dictionary<string,Line> linesForEnemy = new Dictionary<string,Line>();
            linesForEnemy.Add("right", new Line( centerForEnemy, 50, (150 / 180.0) * Math.PI));
            linesForEnemy.Add("left",new Line( centerForEnemy,50, (30/180.0)*Math.PI));
            linesForEnemy.Add("back",new Line(centerForEnemy,50, -(90/180.0)*Math.PI));


            List<string[]> connectionsForEnemy = new List<string[]>();
            connectionsForEnemy.Add(new string[] {"right","left"});
            connectionsForEnemy.Add(new string[] {"left","back"});
            connectionsForEnemy.Add(new string[] {"back","right"});
            enemies[0] = new AstObj(centerForEnemy, 50, linesForEnemy, connectionsForEnemy, true);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.


            blank = new Texture2D(GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            blank.SetData(new[] { Color.White });
            lineBatch = new LineBatch(GraphicsDevice,blank);
            spritefont = Content.Load<SpriteFont>("SpriteFont1");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            updateInput();
            line1.Angle += .1;
            ship1.update();
            // TODO: Add your update logic here
            base.Update(gameTime);


            enemies[0].Lines["right"].Angle += .1;
            enemies[0].Lines["left"].Angle += .1;
        }

        private void updateInput()
        {
            KeyboardState newState = Keyboard.GetState();

            // Is the SPACE key down?
            if (newState.IsKeyDown(Keys.Left))
            {
                ship1.rotate(-.05);
                // If not down last update, key has just been pressed.
                /*if (!oldState.IsKeyDown(Keys.Space))
                {
                    
                }*/
            }
            if (newState.IsKeyDown(Keys.Right))
            {
                ship1.rotate(.05);
                // If not down last update, key has just been pressed.
                /*if (!oldState.IsKeyDown(Keys.Space))
                {
                    
                }*/
            } 
            if (newState.IsKeyDown(Keys.Up))
            {
                ship1.increaseThrust(.1);
                // If not down last update, key has just been pressed.
                /*if (!oldState.IsKeyDown(Keys.Space))
                {
                    
                }*/
            }
            if (newState.IsKeyDown(Keys.Down))
            {
                ship1.decreaseThrust(.1);
                // If not down last update, key has just been pressed.
                /*if (!oldState.IsKeyDown(Keys.Space))
                {
                    
                }*/
            }
            else if ( this.oldState.IsKeyDown(Keys.Space))
            {
                // Key was down last update, but not down now, so
                // it has just been released.
            }

            // Update saved state.
            this.oldState = newState;
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            lineBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            ship1.Draw(gameTime, lineBatch);
            enemies[0].Draw(gameTime, lineBatch);
            lineBatch.DrawLine(1.0f, Color.White, line1);
            lineBatch.DrawLine(1.0f, Color.White, line2);
            lineBatch.DrawString(spritefont, "", new Vector2(150, 150), Color.White);
            lineBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }


    }
}
