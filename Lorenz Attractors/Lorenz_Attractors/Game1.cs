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

        float x2 = 0.02f;
        float y2 = 0f;
        float z2 = 0f;

        float a = 10;//2;//10;//10;
        float b = 28;//30;//103;//28;
        float c = 8 / 3f;//40;//50;//8 / 3f;

        Vector3 Position;
        Vector3 PreviousPosition;

        Vector3 Position2;
        Vector3 PreviousPosition2;

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
            Camera = new CameraJoueur(this, new Vector3(-850, 0, 0), new Vector3(20, 0, 0), Vector3.Up, FPS, 10000);
            Services.AddService(typeof(Camera), Camera);
            //Components.Add(new TexturedSphere(this, 1, Vector3.Zero, new Vector3(0, 0, 0), 1, new Vector2(20, 20), "White", FPS));
            Sphere = new TexturedSphere(this, 1, Vector3.Zero, Position, 0.1f, new Vector2(20, 20), "White", FPS);
            Components.Add(Sphere);
            Components.Add(Camera);
            Components.Add(new AfficheurFPS(this, "Arial", Color.Red, UpdateInterval));
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

        int R = 0, G = 0, B = 0;
        double Hu = 0, S = 1, V = 1;

        void PerformUpdate()
        {
            float dt = 0.01f;
            float dx = (a * (y - x)) * dt;
            float dy = (x * (b - z) - y) * dt;
            float dz = (x * y - c * z) * dt;
            x = x + dx;
            y = y + dy;
            z = z + dz;
            
            float dx2 = (a * (y2 - x2)) * dt;
            float dy2 = (x2 * (b - z2) - y2) * dt;
            float dz2 = (x2 * y2 - c * z2) * dt;
            x2 = x2 + dx2;
            y2 = y2 + dy2;
            z2 = z2 + dz2;

            PreviousPosition = Position;
            Position = new Vector3(x, y, z);

            PreviousPosition2 = Position2;
            Position2 = new Vector3(x2, y2, z2);

            HsvToRgb(Hu, S, V, out R, out G, out B);
            Hu += 0.1;
            if (Hu > 255)
            {
                Hu = 0;
            }
            int scaleConstant = 10;


            Components.Add(new TexturedCylinder(this, 1f, new Vector3(0, 0, 0),
                                    Vector3.Zero, new Vector2(1, 1), new Vector2(20, 20),
                                    new Color(R, G, B), UpdateInterval, scaleConstant * PreviousPosition,
                                    scaleConstant * Position));
            //Components.Add(new TexturedCylinder(this, 1f, new Vector3(0, 0, 0),
            //                        Vector3.Zero, new Vector2(1, 1), new Vector2(20, 20),
            //                        new Color(0, 255, 0), UpdateInterval, scaleConstant * PreviousPosition,
            //                        scaleConstant * Position));
            //Components.Add(new TexturedCylinder(this, 1f, new Vector3(0, 0, 0),
            //                        Vector3.Zero, new Vector2(1, 1), new Vector2(20, 20),
            //                        new Color(255, 0, 0), UpdateInterval, scaleConstant * PreviousPosition2,
            //                        scaleConstant * Position2));

            //Sphere.AjouterSphere(Position);

        }

        // HslToRgb
        #region
        void HsvToRgb(double h, double S, double V, out int r, out int g, out int b)
        {
            double H = h;
            while (H < 0) { H += 360; };
            while (H >= 360) { H -= 360; };
            double R, G, B;
            if (V <= 0)
            { R = G = B = 0; }
            else if (S <= 0)
            {
                R = G = B = V;
            }
            else
            {
                double hf = H / 60.0;
                int i = (int)Math.Floor(hf);
                double f = hf - i;
                double pv = V * (1 - S);
                double qv = V * (1 - S * f);
                double tv = V * (1 - S * (1 - f));
                switch (i)
                {

                    // Red is the dominant color

                    case 0:
                        R = V;
                        G = tv;
                        B = pv;
                        break;

                    // Green is the dominant color

                    case 1:
                        R = qv;
                        G = V;
                        B = pv;
                        break;
                    case 2:
                        R = pv;
                        G = V;
                        B = tv;
                        break;

                    // Blue is the dominant color

                    case 3:
                        R = pv;
                        G = qv;
                        B = V;
                        break;
                    case 4:
                        R = tv;
                        G = pv;
                        B = V;
                        break;

                    // Red is the dominant color

                    case 5:
                        R = V;
                        G = pv;
                        B = qv;
                        break;

                    // Just in case we overshoot on our math by a little, we put these here. Since its a switch it won't slow us down at all to put these here.

                    case 6:
                        R = V;
                        G = tv;
                        B = pv;
                        break;
                    case -1:
                        R = V;
                        G = pv;
                        B = qv;
                        break;

                    // The color is not defined, we should throw an error.

                    default:
                        //LFATAL("i Value error in Pixel conversion, Value is %d", i);
                        R = G = B = V; // Just pretend its black/white
                        break;
                }
            }
            r = Clamp((int)(R * 255.0));
            g = Clamp((int)(G * 255.0));
            b = Clamp((int)(B * 255.0));
        }

        /// <summary>
        /// Clamp a value to 0-255
        /// </summary>
        int Clamp(int i)
        {
            if (i < 0) return 0;
            if (i > 255) return 255;
            return i;
        }
        #endregion

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
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
