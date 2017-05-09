//using Lorenz_Attractors;
//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Input;
//using System.Collections.Generic;

//namespace Lorenz_Attractors
//{
//    public class PlayerCamera : Camera
//    {
//        //const float STANDARD_UPDATE_INTERVAL = 1f / 60f;
//        //const float ACCELERATION = 0.001f;
//        //const float INITIAL_ROTATION_SPEED = 5f;
//        //const float INITIAL_TRANSLATION_SPEED = 0.5f;
//        //const float DELTA_YAW = MathHelper.Pi / 180; // 1 degree at a time
//        //const float DELTA_PITCH = MathHelper.Pi / 180; // 1 degree at a time
//        //const float DELTA_ROLL = MathHelper.Pi / 180; // 1 degree at a time
//        //const float COLLISION_RADIUS = 1f;
//        //const int CHARACTER_HEIGHT = 10;

//        //Vector3 Direction { get; set; }
//        //Vector3 Lateral { get; set; }
//        //Grass Grass { get; set; }
//        //float TranslationSpeed { get; set; }
//        //float RotationSpeed { get; set; }

//        //float UpdateInterval { get; set; }
//        //float TimeElapsedSinceUpdate { get; set; }
//        //InputManager InputMgr { get; set; }

//        //bool inZoom;
//        //bool InZoom
//        //{
//        //    get { return inZoom; }
//        //    set
//        //    {
//        //        float aspectRatio = Game.GraphicsDevice.Viewport.AspectRatio;
//        //        inZoom = value;
//        //        if (inZoom)
//        //        {
//        //            CreateViewingFrustum(OBJECTIVE_OPENNES / 2, aspectRatio, NEAR_PLANE_DISTANCE, FAR_PLANE_DISTANCE);
//        //        }
//        //        else
//        //        {
//        //            CreateViewingFrustum(OBJECTIVE_OPENNES, aspectRatio, NEAR_PLANE_DISTANCE, FAR_PLANE_DISTANCE);
//        //        }
//        //    }
//        //}

//        //public PlayerCamera(Game game, Vector3 cameraPosition, Vector3 target, Vector3 orientation, float updateInterval)
//        //   : base(game)
//        //{
//        //    UpdateInterval = updateInterval;
//        //    CreateViewingFrustum(OBJECTIVE_OPENNES, NEAR_PLANE_DISTANCE, FAR_PLANE_DISTANCE);
//        //    CreateLookAt(cameraPosition, target, orientation);
//        //    InZoom = false;
//        //}

//        //public override void Initialize()
//        //{
//        //    RotationSpeed = INITIAL_ROTATION_SPEED;
//        //    TranslationSpeed = INITIAL_TRANSLATION_SPEED;
//        //    TimeElapsedSinceUpdate = 0;
//        //    base.Initialize();
//        //    InputMgr = Game.Services.GetService(typeof(InputManager)) as InputManager;
//        //    Grass = Game.Services.GetService(typeof(Grass)) as Grass;
//        //}

//        //protected override void CreateLookAt()
//        //{
//        //    Vector3.Normalize(Direction);
//        //    Vector3.Normalize(VerticalOrientation);
//        //    Vector3.Normalize(Lateral);

//        //    View = Matrix.CreateLookAt(Position, Position + Direction, VerticalOrientation);

//        //}

//        //protected override void CreateLookAt(Vector3 position, Vector3 target, Vector3 orientation)
//        //{
//        //    Position = position;
//        //    Target = target;
//        //    VerticalOrientation = orientation;

//        //    Direction = target - Position;

//        //    Vector3.Normalize(Target);

//        //    CreateLookAt();
//        //}

//        //public override void Update(GameTime gameTime)
//        //{
//        //    float timeElapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
//        //    TimeElapsedSinceUpdate += timeElapsed;
//        //    ManageKeyboard();
//        //    if (TimeElapsedSinceUpdate >= UpdateInterval)
//        //    {
//        //        if (InputMgr.IsPressed(Keys.LeftShift) || InputMgr.IsPressed(Keys.RightShift))
//        //        {
//        //            ManageAcceleration();
//        //            ManageDisplacement();
//        //            ManageRotation();
//        //            CreateLookAt();
//        //            ManageHeight();
//        //            Game.Window.Title = Position.ToString();
//        //        }
//        //        TimeElapsedSinceUpdate = 0;
//        //    }
//        //    base.Update(gameTime);
//        //}

//        //private void ManageHeight()
//        //{
//        //    Position = Grass.GetPositionAvecHeight(Position, CHARACTER_HEIGHT);
//        //}

//        //#region
//        //private int ManageKey(Keys key)
//        //{
//        //    return InputMgr.IsPressed(key) ? 1 : 0;
//        //}

//        //private void ManageAcceleration()
//        //{
//        //    int accelerationValue = (ManageKey(Keys.Subtract) + ManageKey(Keys.OemMinus)) - (ManageKey(Keys.Add) + ManageKey(Keys.OemPlus));
//        //    if (accelerationValue != 0)
//        //    {
//        //        UpdateInterval += ACCELERATION * accelerationValue;
//        //        UpdateInterval = MathHelper.Max(STANDARD_UPDATE_INTERVAL, UpdateInterval);
//        //    }
//        //}

//        //private void ManageDisplacement()
//        //{
//        //    float displacementDirection = (ManageKey(Keys.W) - ManageKey(Keys.S)) * TranslationSpeed;
//        //    float lateralDisplacement = (ManageKey(Keys.A) - ManageKey(Keys.D)) * TranslationSpeed;

//        //    Direction = Vector3.Normalize(Direction);
//        //    Position += displacementDirection * Direction;

//        //    Lateral = Vector3.Cross(Direction, VerticalOrientation);
//        //    Position -= lateralDisplacement * Lateral;
//        //}

//        //private void ManageRotation()
//        //{
//        //    ManageYaw();
//        //    ManagePitch();
//        //    ManageRoll();
//        //}

//        //private void ManageYaw()
//        //{
//        //    Matrix yawMatrix = Matrix.Identity;

//        //    if (InputMgr.IsPressed(Keys.Left))
//        //    {
//        //        yawMatrix = Matrix.CreateFromAxisAngle(VerticalOrientation, DELTA_YAW*INITIAL_ROTATION_SPEED);
//        //    }
//        //    if(InputMgr.IsPressed(Keys.Right))
//        //    {
//        //        yawMatrix = Matrix.CreateFromAxisAngle(VerticalOrientation, -DELTA_YAW* INITIAL_ROTATION_SPEED);
//        //    }

//        //    Direction = Vector3.Transform(Direction, yawMatrix);
//        //}

//        //private void ManagePitch()
//        //{
//        //    Matrix pitchMatrix = Matrix.Identity;

//        //    if (InputMgr.IsPressed(Keys.Down))
//        //    {
//        //        pitchMatrix = Matrix.CreateFromAxisAngle(Lateral, -DELTA_PITCH* INITIAL_ROTATION_SPEED);
//        //    }
//        //    if(InputMgr.IsPressed(Keys.Up))
//        //    {
//        //        pitchMatrix = Matrix.CreateFromAxisAngle(Lateral, DELTA_PITCH* INITIAL_ROTATION_SPEED);
//        //    }

//        //    Direction = Vector3.Transform(Direction, pitchMatrix);
//        //    //VerticalOrientation = Vector3.Transform(VerticalOrientation, pitchMatrix);
//        //}

//        //private void ManageRoll()
//        //{
//        //    Matrix rollMatrix = Matrix.Identity;

//        //    if (InputMgr.IsPressed(Keys.PageUp))
//        //    {
//        //        rollMatrix = Matrix.CreateFromAxisAngle(Direction, DELTA_ROLL* INITIAL_ROTATION_SPEED);
//        //    }
//        //    if(InputMgr.IsPressed(Keys.PageDown))
//        //    {
//        //        rollMatrix = Matrix.CreateFromAxisAngle(Direction, -DELTA_ROLL* INITIAL_ROTATION_SPEED);
//        //    }

//        //    VerticalOrientation = Vector3.Transform(VerticalOrientation, rollMatrix);
//        //}

//        //private void ManageKeyboard()
//        //{
//        //    if (InputMgr.IsNewKey(Keys.Z))
//        //    {
//        //        InZoom = !InZoom;
//        //    }
//        //}
//        //#endregion


//        const float STANDARD_UPDATE_INTERVAL = 1f / 60f;
//        const float ACCELERATION = 0.001f;
//        const float INITIAL_ROTATION_SPEED = 5f;
//        const float INITIAL_ROTATION_SPEED_SOURIS = 0.1f;
//        const float INITIAL_TRANSLATION_SPEED = 0.5f;
//        const float DELTA_YAW = MathHelper.Pi / 180; // 1 degree at a time
//        const float DELTA_PITCH = MathHelper.Pi / 180; // 1 degree at a time
//        const float DELTA_ROLL = MathHelper.Pi / 180; // 1 degree at a time
//        const float COLLISION_RADIUS = 1f;
//        const int CHARACTER_HEIGHT = -6;

//        Vector3 Direction { get; set; }
//        Vector3 Lateral { get; set; }
//        Maze Maze { get; set; }
//        //Grass Grass { get; set; }
//        Walls Walls { get; set; }
//        float TranslationSpeed { get; set; }
//        float RotationSpeed { get; set; }
//        Point PreviousPositionMouse { get; set; }
//        Point NewMousePosition { get; set; }
//        Vector2 MouseDisplacement { get; set; }

//        float UpdateInterval { get; set; }
//        float TimeElapsedSinceUpdate { get; set; }
//        InputManager InputMgr { get; set; }
//        float Height { get; set; }
//        List<Character> Characters { get; set; }

//        public PlayerCamera(Game game, Vector3 cameraPosition, Vector3 target, Vector3 orientation, float updateInterval)
//           : base(game)
//        {
//            UpdateInterval = updateInterval;
//            CreateViewingFrustum(OBJECTIVE_OPENNES, NEAR_PLANE_DISTANCE, 100); // 500 FAR_PLANE_DISTANCE
//            CreateLookAt(cameraPosition, target, orientation);
//            Height = cameraPosition.Y;
//        }

//        public override void Initialize()
//        {
//            RotationSpeed = INITIAL_ROTATION_SPEED;
//            TranslationSpeed = INITIAL_TRANSLATION_SPEED;
//            TimeElapsedSinceUpdate = 0;
//            base.Initialize();
//            InputMgr = Game.Services.GetService(typeof(InputManager)) as InputManager;
//            Maze = Game.Services.GetService(typeof(Maze)) as Maze;
//            //Grass = Game.Services.GetService(typeof(Grass)) as Grass;
//            //Walls = Game.Services.GetService(typeof(Walls)) as Walls;
//            Characters = Game.Services.GetService(typeof(List<Character>)) as List<Character>;
//            NewMousePosition = new Point(Game.Window.ClientBounds.Width / 2, Game.Window.ClientBounds.Height / 2);
//            PreviousPositionMouse = new Point(NewMousePosition.X, NewMousePosition.Y);
//            Mouse.SetPosition(NewMousePosition.X, NewMousePosition.Y);
//        }

//        protected override void CreateLookAt()
//        {
//            Vector3.Normalize(Direction);
//            Vector3.Normalize(VerticalOrientation);
//            Vector3.Normalize(Lateral);

//            View = Matrix.CreateLookAt(Position, Position + Direction, VerticalOrientation);
//        }

//        protected override void CreateLookAt(Vector3 position, Vector3 target, Vector3 orientation)
//        {
//            Position = position;
//            Target = target;
//            VerticalOrientation = orientation;

//            Direction = target - Position;
//            //Direction = target;

//            Vector3.Normalize(Target);

//            CreateLookAt();
//        }

//        public override void Update(GameTime gameTime)
//        {
//            float timeElapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
//            TimeElapsedSinceUpdate += timeElapsed;
//            if (TimeElapsedSinceUpdate >= UpdateInterval)
//            {
//                MouseFunctions();
//                KeyboardFunctions();

//                ManageHeight();
//                CreateLookAt();




//                Game.Window.Title = Position.ToString();
//                Position = new Vector3(Position.X, Height, Position.Z);
//                TimeElapsedSinceUpdate = 0;
//            }
//            base.Update(gameTime);
//        }

//        //Mouse
//        #region
//        private void MouseFunctions()
//        {
//            PreviousPositionMouse = NewMousePosition;
//            NewMousePosition = InputMgr.GetMousePosition();
//            MouseDisplacement = new Vector2(NewMousePosition.X - PreviousPositionMouse.X,
//                                            NewMousePosition.Y - PreviousPositionMouse.Y);

//            ManageRotationMouse();

//            NewMousePosition = new Point(Game.Window.ClientBounds.Width / 2, Game.Window.ClientBounds.Height / 2);
//            Mouse.SetPosition(NewMousePosition.X, NewMousePosition.Y);

//        }

//        private void ManageRotationMouse()
//        {
//            ManageYawMouse();
//            ManagePitchMouse();
//        }

//        private void ManageYawMouse()
//        {
//            Matrix yawMatrix = Matrix.Identity;

//            yawMatrix = Matrix.CreateFromAxisAngle(VerticalOrientation, DELTA_YAW * INITIAL_ROTATION_SPEED_SOURIS * -MouseDisplacement.X);

//            Direction = Vector3.Transform(Direction, yawMatrix);
//        }

//        private void ManagePitchMouse()
//        {
//            Matrix pitchMatrix = Matrix.Identity;

//            pitchMatrix = Matrix.CreateFromAxisAngle(Lateral, DELTA_PITCH * INITIAL_ROTATION_SPEED_SOURIS * -MouseDisplacement.Y);

//            Direction = Vector3.Transform(Direction, pitchMatrix);
//        }
//        #endregion

//        //Keyboard
//        #region
//        private void KeyboardFunctions()
//        {
//            ManageDisplacement();
//            ManageRotationKeyboard();
//        }

//        private void ManageDisplacement()
//        {
//            float displacementDirection = (ManageKey(Keys.W) - ManageKey(Keys.S)) * TranslationSpeed;
//            float lateralDisplacement = (ManageKey(Keys.A) - ManageKey(Keys.D)) * TranslationSpeed;

//            Direction = Vector3.Normalize(Direction);
//            Lateral = Vector3.Cross(Direction, VerticalOrientation);
//            Position += displacementDirection * Direction;
//            Position -= lateralDisplacement * Lateral;
//            if (Maze.CheckForCollisions(Position))
//            {
//                Position -= displacementDirection * Direction;
//                Position += lateralDisplacement * Lateral;
//            }
//            //Vector3 newDirection = new Vector3(0, 0, 0);
//            //if (Walls.CheckForCollisions(Position, ref newDirection, Direction) || CheckForCharacterCollision())
//            //{
//            //    Position -= displacementDirection * Direction;
//            //    //Position += displacementDirection * newDirection;
//            //    Position += lateralDisplacement * Lateral;
//            //}
//        }

//        const float MAX_DISTANCE = 4.5f;

//        bool CheckForCharacterCollision()
//        {
//            bool result = false;
//            int i;

//            for (i = 0; i < Characters.Count && !result; ++i)
//            {
//                result = Vector3.Distance(Characters[i].GetPosition(), Position) < MAX_DISTANCE;
//            }

//            return result;
//        }

//        private void ManageRotationKeyboard()
//        {
//            ManageYawKeyboard();
//            ManagePitchKeyboard();
//        }

//        private void ManageYawKeyboard()
//        {
//            Matrix yawMatrix = Matrix.Identity;

//            if (InputMgr.IsPressed(Keys.Left))
//            {
//                yawMatrix = Matrix.CreateFromAxisAngle(VerticalOrientation, DELTA_YAW * INITIAL_ROTATION_SPEED);
//            }
//            if (InputMgr.IsPressed(Keys.Right))
//            {
//                yawMatrix = Matrix.CreateFromAxisAngle(VerticalOrientation, -DELTA_YAW * INITIAL_ROTATION_SPEED);
//            }

//            Direction = Vector3.Transform(Direction, yawMatrix);
//        }

//        private void ManagePitchKeyboard()
//        {
//            Matrix pitchMatrix = Matrix.Identity;

//            if (InputMgr.IsPressed(Keys.Down))
//            {
//                pitchMatrix = Matrix.CreateFromAxisAngle(Lateral, -DELTA_PITCH * INITIAL_ROTATION_SPEED);
//            }
//            if (InputMgr.IsPressed(Keys.Up))
//            {
//                pitchMatrix = Matrix.CreateFromAxisAngle(Lateral, DELTA_PITCH * INITIAL_ROTATION_SPEED);
//            }

//            Direction = Vector3.Transform(Direction, pitchMatrix);
//        }
//        #endregion

//        private void ManageHeight()
//        {
//            Position = Maze.GetPositionWithHeight(Position, CHARACTER_HEIGHT);//Grass.GetPositionWithHeight(Position, CHARACTER_HEIGHT);
//        }

//        private int ManageKey(Keys key)
//        {
//            return InputMgr.IsPressed(key) ? 1 : 0;
//        }
//        //const float STANDARD_UPDATE_INTERVAL = 1f / 60f;
//        //const float ACCELERATION = 0.001f;
//        //const float INITIAL_ROTATION_SPEED = 5f;
//        //const float INITIAL_ROTATION_SPEED_SOURIS = 0.1f;
//        //const float INITIAL_TRANSLATION_SPEED = 0.5f;
//        //const float DELTA_YAW = MathHelper.Pi / 180; // 1 degree at a time
//        //const float DELTA_PITCH = MathHelper.Pi / 180; // 1 degree at a time
//        //const float DELTA_ROLL = MathHelper.Pi / 180; // 1 degree at a time
//        //const float COLLISION_RADIUS = 1f;
//        //const int CHARACTER_HEIGHT = 10;

//        //Vector3 Direction { get; set; }
//        //Vector3 Lateral { get; set; }
//        //Grass Grass { get; set; }
//        //float TranslationSpeed { get; set; }
//        //float RotationSpeed { get; set; }
//        //Point PreviousPositionMouse { get; set; }
//        //Point NewMousePosition { get; set; }
//        //Vector2 MouseDisplacement { get; set; }

//        //float UpdateInterval { get; set; }
//        //float TimeElapsedSinceUpdate { get; set; }
//        //InputManager InputMgr { get; set; }

//        //public PlayerCamera(Game game, Vector3 cameraPosition, Vector3 target, Vector3 orientation, float updateInterval)
//        //   : base(game)
//        //{
//        //    UpdateInterval = updateInterval;
//        //    CreateViewingFrustum(OBJECTIVE_OPENNES, NEAR_PLANE_DISTANCE, FAR_PLANE_DISTANCE);
//        //    CreateLookAt(cameraPosition, target, orientation);
//        //}

//        //public override void Initialize()
//        //{
//        //    RotationSpeed = INITIAL_ROTATION_SPEED;
//        //    TranslationSpeed = INITIAL_TRANSLATION_SPEED;
//        //    TimeElapsedSinceUpdate = 0;
//        //    base.Initialize();
//        //    InputMgr = Game.Services.GetService(typeof(InputManager)) as InputManager;
//        //    Grass = Game.Services.GetService(typeof(Grass)) as Grass;
//        //    NewMousePosition = new Point(Game.Window.ClientBounds.Width / 2, Game.Window.ClientBounds.Height / 2);
//        //    PreviousPositionMouse = new Point(NewMousePosition.X, NewMousePosition.Y);
//        //    Mouse.SetPosition(NewMousePosition.X, NewMousePosition.Y);
//        //}

//        //protected override void CreateLookAt()
//        //{
//        //    Vector3.Normalize(Direction);
//        //    Vector3.Normalize(VerticalOrientation);
//        //    Vector3.Normalize(Lateral);

//        //    View = Matrix.CreateLookAt(Position, Position + Direction, VerticalOrientation);
//        //}

//        //protected override void CreateLookAt(Vector3 position, Vector3 target, Vector3 orientation)
//        //{
//        //    Position = position;
//        //    Target = target;
//        //    VerticalOrientation = orientation;

//        //    Direction = target - Position;

//        //    Vector3.Normalize(Target);

//        //    CreateLookAt();
//        //}

//        //public override void Update(GameTime gameTime)
//        //{
//        //    float timeElapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
//        //    TimeElapsedSinceUpdate += timeElapsed;
//        //    if (TimeElapsedSinceUpdate >= UpdateInterval)
//        //    {
//        //        MouseFunctions();
//        //        KeyboardFunctions();

//        //        ManageHeight();
//        //        CreateLookAt();


//        //        ManageGrabbing();

//        //        //Game.Window.Title = Position.ToString();

//        //        TimeElapsedSinceUpdate = 0;
//        //    }
//        //    base.Update(gameTime);
//        //}

//        ////Mouse
//        //#region
//        //private void MouseFunctions()
//        //{
//        //    PreviousPositionMouse = NewMousePosition;
//        //    NewMousePosition = InputMgr.GetMousePosition();
//        //    MouseDisplacement = new Vector2(NewMousePosition.X - PreviousPositionMouse.X,
//        //                                    NewMousePosition.Y - PreviousPositionMouse.Y);

//        //    ManageRotationMouse();

//        //    NewMousePosition = new Point(Game.Window.ClientBounds.Width / 2, Game.Window.ClientBounds.Height / 2);
//        //    Mouse.SetPosition(NewMousePosition.X, NewMousePosition.Y);

//        //}

//        //private void ManageRotationMouse()
//        //{
//        //    ManageYawMouse();
//        //    ManagePitchMouse();
//        //}

//        //private void ManageYawMouse()
//        //{
//        //    Matrix yawMatrix = Matrix.Identity;

//        //    yawMatrix = Matrix.CreateFromAxisAngle(VerticalOrientation, DELTA_YAW * INITIAL_ROTATION_SPEED_SOURIS * -MouseDisplacement.X);

//        //    Direction = Vector3.Transform(Direction, yawMatrix);
//        //}

//        //private void ManagePitchMouse()
//        //{
//        //    Matrix pitchMatrix = Matrix.Identity;

//        //    pitchMatrix = Matrix.CreateFromAxisAngle(Lateral, DELTA_PITCH * INITIAL_ROTATION_SPEED_SOURIS * -MouseDisplacement.Y);

//        //    Direction = Vector3.Transform(Direction, pitchMatrix);
//        //}
//        //#endregion

//        ////Keyboard
//        //#region
//        //private void KeyboardFunctions()
//        //{
//        //    ManageDisplacement();
//        //    ManageRotationKeyboard();
//        //}

//        //private void ManageDisplacement()
//        //{
//        //    float displacementDirection = (ManageKey(Keys.W) - ManageKey(Keys.S)) * TranslationSpeed;
//        //    float lateralDisplacement = (ManageKey(Keys.A) - ManageKey(Keys.D)) * TranslationSpeed;

//        //    Direction = Vector3.Normalize(Direction);
//        //    Position += displacementDirection * Direction;

//        //    Lateral = Vector3.Cross(Direction, VerticalOrientation);
//        //    Position -= lateralDisplacement * Lateral;
//        //}

//        //private void ManageRotationKeyboard()
//        //{
//        //    ManageYawKeyboard();
//        //    ManagePitchKeyboard();
//        //}

//        //private void ManageYawKeyboard()
//        //{
//        //    Matrix yawMatrix = Matrix.Identity;

//        //    if (InputMgr.IsPressed(Keys.Left))
//        //    {
//        //        yawMatrix = Matrix.CreateFromAxisAngle(VerticalOrientation, DELTA_YAW * INITIAL_ROTATION_SPEED);
//        //    }
//        //    if (InputMgr.IsPressed(Keys.Right))
//        //    {
//        //        yawMatrix = Matrix.CreateFromAxisAngle(VerticalOrientation, -DELTA_YAW * INITIAL_ROTATION_SPEED);
//        //    }

//        //    Direction = Vector3.Transform(Direction, yawMatrix);
//        //}

//        //private void ManagePitchKeyboard()
//        //{
//        //    Matrix pitchMatrix = Matrix.Identity;

//        //    if (InputMgr.IsPressed(Keys.Down))
//        //    {
//        //        pitchMatrix = Matrix.CreateFromAxisAngle(Lateral, -DELTA_PITCH * INITIAL_ROTATION_SPEED);
//        //    }
//        //    if (InputMgr.IsPressed(Keys.Up))
//        //    {
//        //        pitchMatrix = Matrix.CreateFromAxisAngle(Lateral, DELTA_PITCH * INITIAL_ROTATION_SPEED);
//        //    }

//        //    Direction = Vector3.Transform(Direction, pitchMatrix);
//        //}
//        //#endregion

//        //private void ManageHeight()
//        //{
//        //    Position = Grass.GetPositionAvecHeight(Position, CHARACTER_HEIGHT);
//        //}

//        //private int ManageKey(Keys key)
//        //{
//        //    return InputMgr.IsPressed(key) ? 1 : 0;
//        //}

//        //private void ManageGrabbing()
//        //{
//        //    //Ray visor = new Ray(Position, Direction);

//        //    //foreach (GrabbableSphere grabbableSphere in Game.Components.Where(composant => composant is SphereRamassable))
//        //    //{
//        //    //    Game.Window.Title = grabbableSphere.IsColliding(visor).ToString();
//        //    //    //if (grabbableSphere.IsColliding(visor) != null)
//        //    //    //{
//        //    //    //    Game.Window.Title = "true";
//        //    //    //}
//        //    //    //else
//        //    //    //{
//        //    //    //    Game.Window.Title = "false";
//        //    //    //}
//        //    //}
//        //}
//    }
//
































using Lorenz_Attractors;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

namespace Lorenz_Attractors
{
    public class PlayerCamera : Camera
    {
        const float STANDARD_UPDATE_INTERVAL = 1f / 60f;
        const float ACCELERATION = 0.001f;
        const float INITIAL_ROTATION_SPEED = 5f;
        const float INITIAL_ROTATION_SPEED_SOURIS = 0.1f;
        protected const float INITIAL_TRANSLATION_SPEED = 4;//0.5f;
        const float DELTA_YAW = MathHelper.Pi / 180; // 1 degree at a time
        const float DELTA_PITCH = MathHelper.Pi / 180; // 1 degree at a time
        const float DELTA_ROLL = MathHelper.Pi / 180; // 1 degree at a time
        const float COLLISION_RADIUS = 1f;
        const int CHARACTER_HEIGHT = 10;
        const int RUN_MAXIMAL_FACTOR = 4;
        const int GRABBING_MINIMAL_DISTANCE = 45;

        public Vector3 Direction { get; private set; }//
        public Vector3 Lateral { get; private set; }//
        //Grass Grass { get; set; }
        protected float TranslationSpeed { get; set; }
        float RotationSpeed { get; set; }
        Point PreviousPositionMouse { get; set; }
        Point NewMousePosition { get; set; }
        public Vector2 MouseDisplacement { get; set; }

        float UpdateInterval { get; set; }
        float TimeElapsedSinceUpdate { get; set; }
        InputManager InputMgr { get; set; }
        //GamePadManager GamePadMgr { get; set; }

        protected bool Jump { get; private set; }
        bool Run { get; set; }
        public bool Grab { get; set; }

        public bool IsMouseCameraActivated { get; set; }
        bool AreKeyboardDisplacementAndOthersActivated { get; set; }
        bool IsKeyboardCameraActivated { get; set; }

        public Ray Visor { get; private set; }

        protected float Height { get; set; }

        //protected LifeBar[] LifeBars { get; set; }
        Vector2 Origin { get; set; }

        public PlayerCamera(Game game, Vector3 cameraPosition, Vector3 target, Vector3 orientation, float updateInterval, float renderDistance) : base(game)
        {
            FarPlaneeDistance = renderDistance;
            UpdateInterval = updateInterval;
            CreateViewingFrustum(OBJECTIVE_OPENNES, NEAR_PLANE_DISTANCE, /*FAR_PLANE_DISTANCE*/FarPlaneeDistance);
            CreateLookAt(cameraPosition, target, orientation);
            Height = cameraPosition.Y;
            Origin = new Vector2(Game.Window.ClientBounds.Width, Game.Window.ClientBounds.Height) / 2;
        }

        public float GetRenderDistance()
        {
            return FarPlaneeDistance;
        }

        public void SetRenderDistance(float renderDistance)
        {
            FarPlaneeDistance = renderDistance;
            CreateViewingFrustum(OBJECTIVE_OPENNES, NEAR_PLANE_DISTANCE, /*FAR_PLANE_DISTANCE*/FarPlaneeDistance);
            //CreateLookAt(Position, Target, Orientation);
        }

        public void InitializeDirection(Vector3 direction)
        {
            Direction = direction;
        }

        public override void Initialize()
        {
            RotationSpeed = INITIAL_ROTATION_SPEED;
            TranslationSpeed = INITIAL_TRANSLATION_SPEED;
            TimeElapsedSinceUpdate = 0;

            AreKeyboardDisplacementAndOthersActivated = true;
            IsKeyboardCameraActivated = true;

            Run = false;
            Jump = false;
            Grab = false;
            ContinueJump= false;
            IsMouseCameraActivated = true;


            Visor = new Ray();

            NewMousePosition = new Point(Game.Window.ClientBounds.Width / 2, Game.Window.ClientBounds.Height / 2);
            PreviousPositionMouse = new Point(NewMousePosition.X, NewMousePosition.Y);
            Mouse.SetPosition(NewMousePosition.X, NewMousePosition.Y);

            base.Initialize();
            LoadContent();

            InitializeJumpComplexObjects();
            Height = Height;//CHARACTER_HEIGHT;
        }

        protected virtual void LoadContent()
        {
            InputMgr = Game.Services.GetService(typeof(InputManager)) as InputManager;
            //GamePadMgr = Game.Services.GetService(typeof(GamePadManager)) as GamePadManager;

            //LifeBars = Game.Services.GetService(typeof(LifeBar[])) as LifeBar[];
        }

        public bool Dead { get; private set; }

        public void Attack(int val)
        {
            //LifeBars[0].Attack(val);
        }

        protected override void CreateLookAt()
        {
            Direction = Vector3.Normalize(Direction); // NEW FROM 4/7/2017 2:30 AM was only Vector3.Normalize(Direction); before ******************************************************************************************************************************************************************
            Vector3.Normalize(VerticalOrientation);
            Vector3.Normalize(Lateral);
            //Position -= new Vector3(Origin.X, 0, Origin.Y);

            View = Matrix.CreateLookAt(Position, Position + Direction, VerticalOrientation);
        }

        protected override void CreateLookAt(Vector3 position, Vector3 target, Vector3 orientation)
        {
            Position = position;
            Target = target;
            VerticalOrientation = orientation;

            Direction = target - Position;

            Vector3.Normalize(Target);

            CreateLookAt();
        }

        public override void Update(GameTime gameTime)
        {
            PopulateCommandsForGrab();
            //ManageGrabbing();
            float timeElapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            TimeElapsedSinceUpdate += timeElapsed;
            if (TimeElapsedSinceUpdate >= UpdateInterval)
            {
                MouseFunctions();
                KeyboardFunctions();

                ManageHeight();
                CreateLookAt();

                PopulateCommands(); // Grab moved to PopulateCommandsForGrab()

                //ManageGrabbing();
                ManageRun();
                ManageJump();

                ManageLifeBars();
                TimeElapsedSinceUpdate = 0;
            }
            base.Update(gameTime);
        }

        protected virtual void ManageLifeBars()
        {
            //if (!LifeBars[1].Water)
            //{
            //    if (Run && !LifeBars[1].Tired && (InputMgr.IsPressed(Keys.W) || InputMgr.IsPressed(Keys.A) || InputMgr.IsPressed(Keys.S) || InputMgr.IsPressed(Keys.D)))
            //    {
            //        LifeBars[1].Attack();
            //    }
            //    else
            //    {
            //        LifeBars[1].AttackNegative();
            //    }
            //}
        }


        //Mouse
        #region
        private void MouseFunctions()
        {
            if (IsMouseCameraActivated)
            {
                PreviousPositionMouse = NewMousePosition;
                NewMousePosition = InputMgr.GetMousePosition();
                MouseDisplacement = new Vector2(NewMousePosition.X - PreviousPositionMouse.X, NewMousePosition.Y - PreviousPositionMouse.Y);

                ManageRotationMouse();

                NewMousePosition = new Point(Game.Window.ClientBounds.Width / 2, Game.Window.ClientBounds.Height / 2);
                Mouse.SetPosition(NewMousePosition.X, NewMousePosition.Y);
            }
            else
            {
                Game.IsMouseVisible = true;
            }
        }

        private void ManageRotationMouse()
        {
            ManageYawMouse();
            ManagePitchMouse();
        }

        private void ManageYawMouse()
        {
            Matrix yawMatrix = Matrix.CreateFromAxisAngle(VerticalOrientation, DELTA_YAW * INITIAL_ROTATION_SPEED_SOURIS * -MouseDisplacement.X);

            Direction = Vector3.Transform(Direction, yawMatrix);
        }

        private void ManagePitchMouse()
        {
            Matrix pitchMatrix = Matrix.CreateFromAxisAngle(Lateral, DELTA_PITCH * INITIAL_ROTATION_SPEED_SOURIS * -MouseDisplacement.Y);

            Direction = Vector3.Transform(Direction, pitchMatrix);
        }
        #endregion

        //Keyboard
        #region
        private void KeyboardFunctions()
        {
            if (AreKeyboardDisplacementAndOthersActivated)
            {
                ManageDisplacement((ManageKey(Keys.W) - ManageKey(Keys.S)),
                             (ManageKey(Keys.A) - ManageKey(Keys.D)));
            }
            if (IsKeyboardCameraActivated)
            {
                ManageRotationKeyboard();
            }
        }

        protected virtual void ManageDisplacement(float direction, float latéral)
        {
            float displacementDirection = direction * TranslationSpeed;
            float lateralDisplacement = latéral * TranslationSpeed;

            Direction = Vector3.Normalize(Direction);
            Position += displacementDirection * Direction;

            Lateral = Vector3.Cross(Direction, VerticalOrientation);
            Position -= lateralDisplacement * Lateral;
        }

        private void ManageRotationKeyboard()
        {
            ManageYawKeyboard();
            ManagePitchKeyboard();
        }

        private void ManageYawKeyboard()
        {
            Matrix yawMatrix = Matrix.Identity;

            if (InputMgr.IsPressed(Keys.Left))
            {
                yawMatrix = Matrix.CreateFromAxisAngle(VerticalOrientation, DELTA_YAW * INITIAL_ROTATION_SPEED);
            }
            if (InputMgr.IsPressed(Keys.Right))
            {
                yawMatrix = Matrix.CreateFromAxisAngle(VerticalOrientation, -DELTA_YAW * INITIAL_ROTATION_SPEED);
            }

            Direction = Vector3.Transform(Direction, yawMatrix);
        }

        private void ManagePitchKeyboard()
        {
            Matrix pitchMatrix = Matrix.Identity;

            if (InputMgr.IsPressed(Keys.Down))
            {
                pitchMatrix = Matrix.CreateFromAxisAngle(Lateral, -DELTA_PITCH * INITIAL_ROTATION_SPEED);
            }
            if (InputMgr.IsPressed(Keys.Up))
            {
                pitchMatrix = Matrix.CreateFromAxisAngle(Lateral, DELTA_PITCH * INITIAL_ROTATION_SPEED);
            }

            Direction = Vector3.Transform(Direction, pitchMatrix);
        }
        #endregion

        private void PopulateCommands()
        {
            Run = (InputMgr.IsPressed(Keys.RightShift) && AreKeyboardDisplacementAndOthersActivated) ||
                      (InputMgr.IsPressed(Keys.LeftShift) && AreKeyboardDisplacementAndOthersActivated) /*||
                      GamePadMgr.PositionsGâchettes.X > 0*/;

            Jump = (InputMgr.IsPressed(Keys.R/*Keys.Space*/) && AreKeyboardDisplacementAndOthersActivated) /*||
                     GamePadMgr.EstEnfoncé(Buttons.A)*/;

            //Grab = InputMgr.IsNewLeftClick() ||
            //           InputMgr.IsOldLeftClick() ||
            //           InputMgr.IsNewKey(Keys.E) && AreKeyboardDisplacementAndOthersActivated ||
            //           GamePadMgr.EstNouveauBouton(Buttons.RightStick);
        }

        private void PopulateCommandsForGrab()
        {
            //Grab = InputMgr.IsNewLeftClick() ||
            //           InputMgr.IsOldLeftClick() ||
            //           InputMgr.IsNewKey(Keys.E) && AreKeyboardDisplacementAndOthersActivated ||
            //           GamePadMgr.EstNouveauBouton(Buttons.RightStick);
        }

        protected virtual void ManageHeight()
        {
            
        }

        private int ManageKey(Keys key)
        {
            return InputMgr.IsPressed(key) ? 1 : 0;
        }

        //private bool Taken()
        //{
        //    bool result = false;
        //    foreach (GrabbableModel grabbableSphere in Game.Components.Where(composant => composant is GrabbableModel))
        //    {
        //        if (grabbableSphere.EstRamassée && !grabbableSphere.Placed)
        //        {
        //            result = true;
        //            break;
        //        }
        //    }
        //    return result;
        //}

        //Saut
        #region
        protected virtual void ManageJump()
        {
            if (Jump)
            {
                InitializeJumpComplexObjects();
                ContinueJump = true;
            }

            if (ContinueJump)
            {
                if (t > 60)
                {
                    InitializeJumpComplexObjects();
                    ContinueJump = false;
                    t = 0;
                }
                Height = ComputeBezier(t * (1f / 60f), ControlPts).Y;
                ++t;
            }
        }

        bool ContinueJump { get; set; }
        float t { get; set; }
        protected float Height { get; set; }

        Vector3 ControlPtsPositions { get; set; }
        Vector3 ControlPtsPositionsPlusOne { get; set; }
        Vector3[] ControlPts { get; set; }

        void InitializeJumpComplexObjects()
        {
            Position = new Vector3(Position.X, Height/*CHARACTER_HEIGHT*/, Position.Z);
            ControlPtsPositions = new Vector3(Position.X, Position.Y, Position.Z);
            ControlPtsPositionsPlusOne = Position + Vector3.Normalize(new Vector3(Direction.X, 0, Direction.Z)) * 25;
            //Position = new Vector3(ControlPtsPositions.X, ControlPtsPositions.Y, ControlPtsPositions.Z);//******
            //Direction = ControlPtsPositionsPlusOne - ControlPtsPositions;//******
            ControlPts = ComputeControlPoints();
        }

        private Vector3[] ComputeControlPoints()
        {
            Vector3[] pts = new Vector3[4];
            pts[0] = ControlPtsPositions;
            pts[3] = ControlPtsPositionsPlusOne;
            pts[1] = new Vector3(pts[0].X, pts[0].Y + 20, pts[0].Z);
            pts[2] = new Vector3(pts[3].X, pts[3].Y + 20, pts[3].Z);
            return pts;
        }

        private Vector3 ComputeBezier(float t, Vector3[] ControlPts)
        {
            float x = (1 - t);
            return ControlPts[0] * (x * x * x) +
                   3 * ControlPts[1] * t * (x * x) +
                   3 * ControlPts[2] * t * t * x +
                   ControlPts[3] * t * t * t;

        }
        #endregion

        const float TIRED_SPEED = 0.1f;

        private void ManageRun()
        {
            TranslationSpeed = Run ? RUN_MAXIMAL_FACTOR * INITIAL_TRANSLATION_SPEED : INITIAL_TRANSLATION_SPEED;
        }
    }
}
