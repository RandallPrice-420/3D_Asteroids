using TMPro;


public class UIManager : Singleton<UIManager>
{
    // -------------------------------------------------------------------------
    // Public Properties:
    // ------------------
    //   AsteroidsCreatedValue
    //   AsteroidsDestroyedValue
    //   AsteroidsExistingValue
    //   AsteroidsMissedValue
    //   AsteroidPositionValue
    //   AsteroidRotationValue
    //   SpaceshipPositionValue
    //   SpaceshipRotationValue
    //   LevelValue
    //   LivesValue
    //   ScoreValue
    // -------------------------------------------------------------------------

    #region .  Public Properties  .

    public TMP_Text AsteroidsCreatedValue;
    public TMP_Text AsteroidsDestroyedValue;
    public TMP_Text AsteroidsExistingValue;
    public TMP_Text AsteroidsMissedValue;
    public TMP_Text AsteroidPositionValue;
    public TMP_Text AsteroidRotationValue;
    public TMP_Text SpaceshipPositionValue;
    public TMP_Text SpaceshipRotationValue;
    public TMP_Text LevelValue;
    public TMP_Text LivesValue;
    public TMP_Text ScoreValue;

    #endregion


    // -------------------------------------------------------------------------
    // Private Methods:
    // ----------------
    //   OnAsteroidCreated()
    //   OnAsteroidDestroyed()
    //   OnAsteroidLeavesScreen()
    //   OnAsteroidMoved()
    //   OnDisable()
    //   OnEnable()
    //   OnLevelChanged()
    //   OnLiveLost()
    //   OnSpaceshipMoved()
    //   Start()
    //   UpdateAsteroidsCreated()
    //   UpdateAsteroidsDestroyed()
    //   UpdateAsteroidsExisting()
    //   UpdateAsteroidsMissed()
    //   UpdateAsteroidsMoved()
    //   UpdateLevel()
    //   UpdateLives()
    //   UpdateScore()
    //   UpdateSpaceshipMoved()
    // -------------------------------------------------------------------------

    #region .  OnAsteroidCreated()  .
    // -------------------------------------------------------------------------
    //  Method.......:  OnAsteroidCreated()
    //  Description..:  Updates the asteroids created and asteroids existing UI
    //                  elements.
    //  Parameters...:  Asteroid - the asteroid that was created.
    //  Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void OnAsteroidCreated(Asteroid asteroid)
    {
        this.UpdateAsteroidsCreated();
        this.UpdateAsteroidsExisting();

    }   // OnAsteroidCreated()
    #endregion


    #region .  OnAsteroidDestroyed()  .
    // -------------------------------------------------------------------------
    //  Method.......:  OnAsteroidDestroyed()
    //  Description..:  Updates the asteroids destroyed, asteroids existing and
    //                  asteroids missed UI elements.
    //  Parameters...:  Asteroid - the asteroid that was destroyed.
    //  Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void OnAsteroidDestroyed()
    {
        this.UpdateAsteroidsDestroyed();
        this.UpdateAsteroidsExisting();
        this.UpdateScore();

    }   // OnAsteroidDestroyed()
    #endregion


    #region .  OnAsteroidLeavesScreen()  .
    // -------------------------------------------------------------------------
    //  Method.......:  OnAsteroidLeavesScreen()
    //  Description..:  Updates the asteroids existing and asteroids missed UI
    //                  elements.
    //  Parameters...:  Asteroid - the asteroid that moved off the screen.
    //  Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void OnAsteroidLeavesScreen(Asteroid asteroid)
    {
        this.UpdateAsteroidsExisting();
        this.UpdateAsteroidsMissed();

    }   // OnAsteroidLeavesScreen()
    #endregion


    #region .  OnAsteroidMoved()  .
    // -------------------------------------------------------------------------
    //  Method.......:  OnAsteroidMoved()
    //  Description..:  Updated the asteroid position and rotation UI elements.
    //  Parameters...:  Spaceship
    //  Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void OnAsteroidMoved(Asteroid asteroid)
    {
        this.UpdateAsteroidMoved();

    }   // OnAsteroidMoved()
    #endregion


    #region .  OnDisable()  .
    // -------------------------------------------------------------------------
    //  Method.......:  OnDisable()
    //  Description..:  Unsubscribes to various events.
    //  Parameters...:  None
    //  Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void OnDisable()
    {
        Asteroid   .OnAsteroidCreated         -= this.OnAsteroidCreated;
        Asteroid   .OnAsteroidLeavesScreen    -= this.OnAsteroidLeavesScreen;
        GameManager.OnAsteroidDestroyed_Score -= this.OnAsteroidDestroyed;
        Asteroid   .OnAsteroidMoved           -= this.OnAsteroidMoved;
        GameManager.OnLevelChanged            -= this.OnLevelChanged;
        Spaceship  .OnSpaceshipMoved          -= this.OnSpaceshipMoved;

        //GameManager.OnLiveLost       -= this.OnLiveLost;

    }   // OnDisable()
    #endregion


    #region .  OnEnable()  .
    // -------------------------------------------------------------------------
    //  Method.......:  OnEnable()
    //  Description..:  Subscribes to various events.
    //  Parameters...:  None
    //  Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void OnEnable()
    {
        Asteroid   .OnAsteroidCreated         += this.OnAsteroidCreated;
        Asteroid   .OnAsteroidLeavesScreen    += this.OnAsteroidLeavesScreen;
        GameManager.OnAsteroidDestroyed_Score += this.OnAsteroidDestroyed;
        Asteroid   .OnAsteroidMoved           += this.OnAsteroidMoved;
        GameManager.OnLevelChanged            += this.OnLevelChanged;
        Spaceship  .OnSpaceshipMoved          += this.OnSpaceshipMoved;

        //GameManager.OnLiveLost       += this.OnLiveLost;

    }   // OnEnable()
    #endregion


    #region .  OnLevelChanged()  .
    // -------------------------------------------------------------------------
    //  Method.......:  OnLevelChanged()
    //  Description..:  Updates the Level UI element.
    //  Parameters...:  None
    //  Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void OnLevelChanged()
    {
        this.UpdateLevel();

    }   // OnLevelChanged()
    #endregion


    #region .  OnLiveLost()  .
    // -------------------------------------------------------------------------
    //  Method.......:  OnLiveLost()
    //  Description..:  Updates the Lives UI element.
    //  Parameters...:  None
    //  Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void OnLiveLost()
    {
        this.UpdateLives();

    }   // OnLiveLost()
    #endregion


    #region .  OnSpaceshipMoved()  .
    // -------------------------------------------------------------------------
    //  Method.......:  OnSpaceshipMoved()
    //  Description..:  Updated the spaceship position and rotation UI elements.
    //  Parameters...:  Spaceship
    //  Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void OnSpaceshipMoved(Spaceship spaceship)
    {
        this.UpdateSpaceshipMoved();

    }   // OnSpaceshipMoved()
    #endregion


    #region .  Start()  .
    // -------------------------------------------------------------------------
    //  Method.......:  Start()
    //  Description..:  Sets the various UI elements to their dfault values.
    //  Parameters...:  None
    //  Returns......:  Nothing
    // --------------------------------------------------------------------------
    private void Start()
    {
        this.UpdateAsteroidsCreated();
        this.UpdateAsteroidsDestroyed();
        this.UpdateAsteroidsExisting();
        this.UpdateAsteroidsMissed();
        this.UpdateLevel();
        this.UpdateLives();
        this.UpdateScore();

    }   // Start()
    #endregion


    #region .  UpdateAsteroidsCreated()  .
    // -------------------------------------------------------------------------
    //  Method.......:  UpdateAsteroidsCreated()
    //  Description..:  Updates the asteroids Created UI element.
    //  Parameters...:  None
    //  Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void UpdateAsteroidsCreated()
    {
        this.AsteroidsCreatedValue.text = AsteroidManager.Instance.CountAsteroidsCreated.ToString();

    }   // UpdateAsteroidsCreated()
    #endregion


    #region .  UpdateAsteroidsDestroyed()  .
    // -------------------------------------------------------------------------
    //  Method.......:  UpdateAsteroidsDestroyed()
    //  Description..:  Updates the asteroids Destroyed UI element.
    //  Parameters...:  None
    //  Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void UpdateAsteroidsDestroyed()
    {
        this.AsteroidsDestroyedValue.text = AsteroidManager.Instance.CountAsteroidsDestroyed.ToString();

    }   // UpdateAsteroidsDestroyed()
    #endregion


    #region .  UpdateAsteroidsExisting()  .
    // -------------------------------------------------------------------------
    //  Method.......:  UpdateAsteroidsExisting()
    //  Description..:  Updates the asteroids Existing UI element.
    //  Parameters...:  None
    //  Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void UpdateAsteroidsExisting()
    {
        this.AsteroidsExistingValue.text = AsteroidManager.Instance.CouhtAsteroidsExisting.ToString();

    }   // UpdateAsteroidsExisting()
    #endregion


    #region .  UpdateAsteroidsMissed()  .
    // -------------------------------------------------------------------------
    //  Method.......:  UpdateAsteroidsMissed()
    //  Description..:  Updates the asteroids Missed UI element.
    //  Parameters...:  None
    //  Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void UpdateAsteroidsMissed()
    {
        this.AsteroidsMissedValue.text = AsteroidManager.Instance.CountAsteroidsMissed.ToString();

    }   // UpdateAsteroidsMissed()
    #endregion


    #region .  UpdateAsteroidMoved()  .
    // -------------------------------------------------------------------------
    //  Method.......:  UpdateAsteroidMoved()
    //  Description..:  
    //  Parameters...:  None
    //  Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void UpdateAsteroidMoved()
    {
        this.AsteroidPositionValue.text = Asteroid.Instance.gameObject.transform.position.ToString();
        this.AsteroidRotationValue.text = Asteroid.Instance.gameObject.transform.rotation.ToString();

    }   // UpdateAsteroidMoved()
    #endregion


    #region .  UpdateLevel()  .
    // -------------------------------------------------------------------------
    //  Method.......:  UpdateLevel()
    //  Description..:  Updates the Level UI element.
    //  Parameters...:  None
    //  Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void UpdateLevel()
    {
        this.LevelValue.text = GameManager.Instance.Level.ToString();

    }   // UpdateLevel()
    #endregion


    #region .  UpdateLives()  .
    // -------------------------------------------------------------------------
    //  Method.......:  UpdateLives()
    //  Description..:  Updates the Lives UI element.
    //  Parameters...:  None
    //  Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void UpdateLives()
    {
        this.LivesValue.text = GameManager.Instance.Lives.ToString();

    }   // UpdateLives()
    #endregion


    #region .  UpdateScore()  .
    // -------------------------------------------------------------------------
    //  Method.......:  UpdateScore()
    //  Description..:  Updates the Score UI element.
    //  Parameters...:  None
    //  Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void UpdateScore()
    {
        this.ScoreValue.text = GameManager.Instance.Score.ToString();

    }   // UpdateScore()
    #endregion


    #region .  UpdateSpaceshipMoved()  .
    // -------------------------------------------------------------------------
    //  Method.......:  UpdateSpaceshipMoved()
    //  Description..:  
    //  Parameters...:  None
    //  Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void UpdateSpaceshipMoved()
    {
        this.SpaceshipPositionValue.text = Spaceship.Instance.gameObject.transform.position.ToString();
        this.SpaceshipRotationValue.text = Spaceship.Instance.gameObject.transform.rotation.ToString();

    }   // UpdateSpaceshipMoved()
    #endregion


}   // class UIManager
