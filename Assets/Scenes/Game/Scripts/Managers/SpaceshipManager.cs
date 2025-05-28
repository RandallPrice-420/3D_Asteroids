using System.Collections.Generic;
using UnityEngine;


public class SpaceshipManager : MonoBehaviour
{
    // -------------------------------------------------------------------------
    // Private Properties:
    // -------------------
    //   _assetsPath
    //   _spaceship
    //   _spaceshipsList
    // -------------------------------------------------------------------------

    #region .  Private Properties  .

    private readonly string _assetsPath     = "Assets/3rd-Party/Spaceships/Prefabs";
    private Spaceship       _spaceship;
    private List<Spaceship> _spaceshipsList = new();

    #endregion


    // -------------------------------------------------------------------------
    // Private Methods:
    // ----------------
    //   GetRandomSpaceship()
    //   LoadSpaceships()
    //   OnDisable()             --  COMMENTED OUT
    //   OnEnable()              --  COMMENTED OUT
    //   SpaceshipDestroyed()    --  COMMENTED OUT
    //   SpaceshipLeaveScreen()  --  COMMENTED OUT
    //   Start()
    // -------------------------------------------------------------------------

    #region .  GetRandomSpaceship()  .
    // -------------------------------------------------------------------------
    //  Method.......:  GetRandomSpaceship()
    //  Description..:  
    //  Parameters...:  label
    //  Returns......:  Nothing
    // --------------------------------------------------------------------------
    private void GetRandomSpaceship()
    {
        this._spaceship = this._spaceshipsList[Random.Range(0, this._spaceshipsList.Count - 1)];

    }   // GetRandomSpaceship()
    #endregion


    #region .  LoadSpaceships()  .
    // -------------------------------------------------------------------------
    //  Method.......:  LoadSpaceships()
    //  Description..:  
    //  Parameters...:  label
    //  Returns......:  Nothing
    // --------------------------------------------------------------------------
    private void LoadSpaceships()
    {
        this._spaceshipsList = Utils.LoadSpaceshipAssets(this._assetsPath);

    }   // LoadSpaceships()
    #endregion


    #region .  OnDisable()  --  COMMENTED OUT  .
    //// --------------------------------------------------------------
    ////  Method.......:  OnDisable()
    ////  Description..:  
    ////  Parameters...:  None
    ////  Returns......:  Nothing
    //// --------------------------------------------------------------
    //private void OnDisable()
    //{
    //    //Spaceship.OnSpaceshipCollision   -= this.SpaceshipCollision;
    //    //Spaceship.OnSpaceshipCreated     -= this.SpaceshipCreated;
    //    //Spaceship.OnSpaceshipDestroyed   -= this.SpaceshipDestroyed;
    //    //Spaceship.OnSpaceshipLeaveScreen -= this.SpaceshipLeaveScreen;

    //}   // OnDisable()
    #endregion


    #region .  OnEnable()  --  COMMENTED OUT  .
    //// --------------------------------------------------------------
    ////  Method.......:  OnEnable()
    ////  Description..:  
    ////  Parameters...:  None
    ////  Returns......:  Nothing
    //// --------------------------------------------------------------
    //private void OnEnable()
    //{
    //    //Spaceship.OnSpaceshipCollision   += this.SpaceshipCollision;
    //    //Spaceship.OnSpaceshipCreated     += this.SpaceshipCreated;
    //    //Spaceship.OnSpaceshipDestroyed   += this.SpaceshipDestroyed;
    //    //Spaceship.OnSpaceshipLeaveScreen += this.SpaceshipLeaveScreen;

    //}   // OnEnable()
    #endregion


    #region .  SpaceshipDestroyed()  --  COMMENTED OUT  .
    //// -------------------------------------------------------------------------
    ////  Method.......:  SpaceshipDestroyed()
    ////  Description..:  
    ////  Parameters...:  None
    ////  Returns......:  Nothing
    //// -------------------------------------------------------------------------
    //public void SpaceshipDestroyed(Spaceship spaceship)
    //{
    //    //this.Lives--;
    //    //UIManager.Instance.UpdateLivesValue();

    //    //if (this.Lives < 0)
    //    //{
    //    //    this.ShowVictoryPanel();
    //    //}

    //}   // SpaceshipDestroyed()
    #endregion


    #region .  SpaceshipLeaveScreen()  --  COMMENTED OUT  .
    //// -------------------------------------------------------------------------
    ////  Method.......:  SpaceshipLeaveScreen()
    ////  Description..:  When the spaceship leaves the screen, wrap it around to
    ////                  the opposite side.
    ////  Parameters...:  asteroid
    ////  Returns......:  Nothing
    //// --------------------------------------------------------------------------
    //private void SpaceshipLeaveScreen(Spaceship spaceship)
    //{
    //    // Get the asteroid's current position.
    //    float x = spaceship.transform.position.x;
    //    float y = spaceship.transform.position.y;

    //    x = (x < ScreenManager.Instance.ScreenLeft) ? ScreenManager.Instance.ScreenRight
    //      : (x > ScreenManager.Instance.ScreenRight) ? ScreenManager.Instance.ScreenLeft
    //      : x;

    //    y = (y > ScreenManager.Instance.ScreenTop) ? ScreenManager.Instance.ScreenBottom
    //      : (y < ScreenManager.Instance.ScreenBottom) ? ScreenManager.Instance.ScreenTop
    //      : y;

    //    // Update the spaceship position.
    //    spaceship.transform.position = new Vector3(x, y, 0.0f);

    //}   // SpaceshipLeaveScreen()
    #endregion


    #region .  Start()  .
    // -------------------------------------------------------------------------
    //   Method.......:  Start()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void Start()
    {
        this.LoadSpaceships();
        this.GetRandomSpaceship();

        Instantiate(this._spaceship, new Vector3(0.0f, 0.0f, 0.0f), this._spaceship.transform.rotation);

    }   // Start()
    #endregion


}   // class SpaceshipManager
