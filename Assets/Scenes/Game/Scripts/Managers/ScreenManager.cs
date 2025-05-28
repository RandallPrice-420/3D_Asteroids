using UnityEngine;


public class ScreenManager : Singleton<ScreenManager>
{
    // -------------------------------------------------------------------------
    // Public Enums:
    // -------------
    //   LeaveAction
    // -------------------------------------------------------------------------

    #region .  Public Enums  .

    public enum LeaveAction
    {
        None = 0,
        Die  = 1,
        Wrap = 2
    }

    #endregion


    // -------------------------------------------------------------------------
    // Public Properties:
    // ------------------
    //   ScreenBottom
    //   ScreenLeft
    //   ScreenRight
    //   ScreenTop
    // -------------------------------------------------------------------------

    #region .  Public Properties  .

    public float ScreenBottom = -12.5f;
    public float ScreenLeft   = -26.0f;
    public float ScreenRight  =  26.0f;
    public float ScreenTop    =  12.5f;

    //public float ScreenBottom = -Screen.height;
    //public float ScreenLeft   = -Screen.width;
    //public float ScreenRight  =  Screen.width;
    //public float ScreenTop    =  Screen.height;

    #endregion


    // -------------------------------------------------------------------------
    // Public Methods:
    // ---------------
    //   GetWrapVector()
    //   IsOffScreen()
    // -------------------------------------------------------------------------

    #region .  GetWrapVector()  .
    // -------------------------------------------------------------------------
    //  Method.......:  GetWrapVector()
    //  Description..:
    //  Parameters...:  transform
    //  Returns......:  True if the ttansform is off thr screen; otherwise, false.
    // --------------------------------------------------------------------------
    public Vector3 GetWrapVector(Transform transform)
    {
        // Get the object's current position.
        float x = transform.position.x;
        float y = transform.position.y;

        x = (x < ScreenManager.Instance.ScreenLeft  ) ? ScreenManager.Instance.ScreenRight
          : (x > ScreenManager.Instance.ScreenRight ) ? ScreenManager.Instance.ScreenLeft
          : x;

        y = (y > ScreenManager.Instance.ScreenTop   ) ? ScreenManager.Instance.ScreenBottom
          : (y < ScreenManager.Instance.ScreenBottom) ? ScreenManager.Instance.ScreenTop
          : y;

        return new Vector3(x, y, 0.0f);

    }   // GetWrapVector()
    #endregion


    #region .  IsOffScreen()  .
    // -------------------------------------------------------------------------
    //  Method.......:  IsOffScreen()
    //  Description..:
    //  Parameters...:  transform
    //  Returns......:  True if the ttansform is off thr screen; otherwise, false.
    // --------------------------------------------------------------------------
    public bool IsOffScreen(Transform transform)
    {
        bool offScreen = (transform.position.x < this.ScreenLeft  )
                      || (transform.position.x > this.ScreenRight )
                      || (transform.position.y < this.ScreenBottom)
                      || (transform.position.y > this.ScreenTop   );

        //Debug.Log($"Off? {offScreen}, Spaceship: {transform.position}, Left: {this.ScreenLeft}, Right: {this.ScreenRight}, Bottom: {this.ScreenBottom}, Top: {this.ScreenTop}");

        return offScreen;

    }   // IsOffScreen()
    #endregion


    // -------------------------------------------------------------------------
    // Private Methods:
    // ----------------
    //   Awake()  --  COMMENTED OUT
    // -------------------------------------------------------------------------

    #region .  Awake()  --  COMMENTED OUT  .
    //// -------------------------------------------------------------------------
    ////  Method.......:  Awake()
    ////  Description..:  Start is called before the first frame update.
    ////  Parameters...:  None
    ////  Returns......:  Nothing
    //// -------------------------------------------------------------------------
    //private void Awake()
    //{
    //    //ScreenBottom = GameManager.Instance.ScreenBottom;
    //    //ScreenLeft   = GameManager.Instance.ScreenLeft;
    //    //ScreenRight  = GameManager.Instance.ScreenRight;
    //    //ScreenTop    = GameManager.Instance.ScreenTop;

    //    ScreenBottom = -Screen.height;
    //    ScreenLeft   = -Screen.width;
    //    ScreenRight  =  Screen.width;
    //    ScreenTop    =  Screen.height;

    //}   // Awake()
    #endregion


}   // class ScreenManager
