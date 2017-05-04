using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;


namespace Lorenz_Attractors
{
   public class InputManager : Microsoft.Xna.Framework.GameComponent
   {
      Keys[] PreviousKeys { get; set; }
      Keys[] CurrentKeys { get; set; }
      KeyboardState CurrentState { get; set; }
      MouseState PreviousMouseState { get; set; }
      MouseState CurrentMouseState { get; set; }

      public InputManager(Game game)
         : base(game)
      { }

      public override void Initialize()
      {
         CurrentKeys = new Keys[0];
         PreviousKeys = CurrentKeys;
         CurrentMouseState = Mouse.GetState();
         PreviousMouseState = CurrentMouseState;
         base.Initialize();
      }

      public override void Update(GameTime gameTime)
      {
         PreviousKeys = CurrentKeys;
         CurrentState = Keyboard.GetState();
         CurrentKeys = CurrentState.GetPressedKeys();
         UpdateMouseState();
      }

      public bool IsKeyboardActivated
      {
         get { return CurrentKeys.Length > 0; }
      }

      public bool IsPressed(Keys key)
      {
         return CurrentState.IsKeyDown(key);
      }

      public bool IsNewKey(Keys key)
      {
         int numKeys = PreviousKeys.Length;
         bool isNewKey = CurrentState.IsKeyDown(key);
         int i = 0;
         while (i < numKeys && isNewKey)
         {
            isNewKey = PreviousKeys[i] != key;
            ++i;
         }
         return isNewKey;
      }

      void UpdateMouseState()
      {
         PreviousMouseState = CurrentMouseState;
         CurrentMouseState = Mouse.GetState();
      }

      public bool IsOldRightClick()
      {
         return CurrentMouseState.RightButton == ButtonState.Pressed && 
                PreviousMouseState.RightButton == ButtonState.Pressed;
      }

      public bool IsOldLeftClick()
      {
         return CurrentMouseState.LeftButton == ButtonState.Pressed && PreviousMouseState.LeftButton == ButtonState.Pressed;
      }

      public bool IsNewRightClick()
      {
         return CurrentMouseState.RightButton == ButtonState.Pressed && PreviousMouseState.RightButton == ButtonState.Released;
      }

      public bool IsNewLeftClick()
      {
         return CurrentMouseState.LeftButton == ButtonState.Pressed && 
                PreviousMouseState.LeftButton == ButtonState.Released;
      }

      public Point GetMousePosition()
      {
         return new Point(CurrentMouseState.X, CurrentMouseState.Y);
      }
   }
}