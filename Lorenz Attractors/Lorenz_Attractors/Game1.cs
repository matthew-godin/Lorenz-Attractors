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

namespace Lorenz_Attractors
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        const float UpdateInterval = 1/60f;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        const float FPS = 1 / 60f;
        ResourcesManager<Texture2D> TextureManager { get; set; }
        InputManager InputManager { get; set; }
        Camera Camera { get; set; }
        bool Sleep { get; set; }
        TexturedSphere Sphere { get; set; }

        float TimeElpasedSinceUpdate { get; set; }

        float x = 0.01f;
        float y = 0;
        float z = 0;

        float a = 10;
        float b = 28;
        float c = 8 / 3f;

        Vector3 Position;
        Vector3 PreviousPosition;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsFixedTimeStep = false;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            Position = new Vector3(x, y, z);
            PreviousPosition = Position;
            Sleep = false;
            InputManager = new InputManager(this);
            Services.AddService(typeof(InputManager), InputManager);
            TextureManager = new ResourcesManager<Texture2D>(this, "Textures");
            Services.AddService(typeof(ResourcesManager<Texture2D>), TextureManager);
            Services.AddService(typeof(ResourcesManager<SpriteFont>), new ResourcesManager<SpriteFont>(this, "Fonts"));
            Components.Add(InputManager);
            Components.Add(new Displayer3D(this));
            Camera = new CameraJoueur(this, new Vector3(-5, 0, 0), new Vector3(20, 0, 0), Vector3.Up, FPS, 500);
            Services.AddService(typeof(Camera), Camera);
            //Components.Add(new TexturedSphere(this, 1, Vector3.Zero, new Vector3(0, 0, 0), 1, new Vector2(20, 20), "White", FPS));
            Sphere = new TexturedSphere(this, 1, Vector3.Zero, Position, 0.1f, new Vector2(20, 20), "White", FPS);
            Components.Add(Sphere);
            Components.Add(Camera);
            Components.Add(new AfficheurFPS(this, "Arial", Color.Black, UpdateInterval));
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

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
            if (!Sleep)
            {
                // Allows the game to exit
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                    this.Exit();

                // TODO: Add your update logic here

                float timeElapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
                TimeElpasedSinceUpdate += timeElapsed;
                if (TimeElpasedSinceUpdate >= UpdateInterval)
                {
                    PerformUpdate();
                    TimeElpasedSinceUpdate = 0;
                }

                base.Update(gameTime);
            }
        }

        void PerformUpdate()
        {
            float dt = 0.01f;
            float dx = (a * (y - x)) * dt;
            float dy = (x * (b - z) - y) * dt;
            float dz = (x * y - c * z) * dt;
            x = x + dx;
            y = y + dy;
            z = z + dz;

            PreviousPosition = Position;
            Position = new Vector3(x, y, z);

            //Window.Title = Position.ToString();

            Components.Add(new TexturedCylinder(this, 1f, new Vector3(0, 0, 0),
                                    Vector3.Zero, new Vector2(1, 1), new Vector2(20, 20),
                                    "White", UpdateInterval, PreviousPosition,
                                    Position));

            //Sphere.AjouterSphere(Position);

        }

        protected override void OnActivated(object sender, EventArgs args)
        {
            Sleep = false;
            base.OnActivated(sender, args);
            if (Camera != null)
            {
                (Camera as CameraJoueur).EstCameraMouseActivée = true;
            }
            IsMouseVisible = false;
        }

        protected override void OnDeactivated(object sender, EventArgs args)
        {
            Sleep = true;
            base.OnDeactivated(sender, args);
            if (Camera != null)
            {
                (Camera as CameraJoueur).EstCameraMouseActivée = false;
            }
            IsMouseVisible = true;
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
