using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : Singleton<GameManager>
{
    // -------------------------------------------------------------------------
    // Public Events:
    // --------------
    //   OnAsteroidDestroyed_Score
    //   OnLevelChanged
    // -------------------------------------------------------------------------

    #region .  Public Events  .

    public static event Action OnAsteroidDestroyed_Score = delegate { };
    public static event Action OnLevelChanged            = delegate { };

    #endregion


    // -------------------------------------------------------------------------
    // Public Properties:
    // ------------------
    //   AvailableLives
    //   IsGameStarted
    //   IsMainMenuRun
    //   Level
    //   Lives
    //   Score
    //   PanelGameOver
    //   PanelVictory
    // -------------------------------------------------------------------------

    #region .  Public Properties  .

    public bool       IsMainMenuRun;

    public int        AvailableLives = 3;
    public bool       IsGameStarted  = false;
    public int        Level          = 1;
    public int        Lives          = 0;
    public int        Score          = 0;
    //public GameObject PanelGameOver;
    //public GameObject PanelVictory;

    #endregion


    // --------------------------------------------------------------
    // Public Methods:
    // ---------------
    //   RestartGame()
    //   ShowVictoryPanel()
    // --------------------------------------------------------------

    #region .  RestartGame()  .
    // --------------------------------------------------------------
    //  Method.......:  RestartGame()
    //  Description..:  
    //  Parameters...:  None
    //  Returns......:  Nothing
    // --------------------------------------------------------------
    public void RestartGame()
    {
        //PanelGameOver.SetActive(false);
        //PanelVictory .SetActive(false);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    } // RestartGame()
    #endregion


    #region .  ShowVictoryPanel()  .
    // --------------------------------------------------------------
    //  Method.......:  ShowVictoryPanel()
    //  Description..:  
    //  Parameters...:  None
    //  Returns......:  Nothing
    // --------------------------------------------------------------
    public void ShowVictoryPanel()
    {
        //PanelGameOver.SetActive(false);
        //PanelVictory .SetActive(true);

    }   // ShowVictoryPanel()
    #endregion


    // -------------------------------------------------------------------------
    // Private Methods:
    // ----------------
    //   Awake()
    //   OnAsteroidDestroyed()
    //   OnDisable()
    //   OnEnable()
    //   Start()
    // -------------------------------------------------------------------------

    #region .  Awake()  .
    // -------------------------------------------------------------------------
    //  Method.......:  Awake()
    //  Description..:
    //  Parameters...:  None
    //  Returns......:  Nothing
    // --------------------------------------------------------------------------
    private void Awake()
    {
        Screen.SetResolution(1920, 1080, false);

        this.Lives = this.AvailableLives;

    }   // Awake()
    #endregion


    #region .  OnAsteroidDestroyed()  .
    // -------------------------------------------------------------------------
    //  Method.......:  OnAsteroidDestroyed()
    //  Description..:  Increment the score when an asteroid is destroyed.
    //  Parameters...:  Asteroid - the asteroid GameObject that was destroyed.
    //  Returns......:  Nothing
    // --------------------------------------------------------------------------
    private void OnAsteroidDestroyed(Asteroid asteroid)
    {
        this.Score += asteroid.Points;

        OnAsteroidDestroyed_Score?.Invoke();

    }   // OnAsteroidDestroyed()
    #endregion


    #region .  OnDisable()  .
    // -------------------------------------------------------------------------
    //  Method.......:  OnDisable()
    //  Description..:  
    //  Parameters...:  None
    //  Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void OnDisable()
    {
        AsteroidManager.OnAsteroidDestroyed -= this.OnAsteroidDestroyed;

    }   // OnDisable()
    #endregion


    #region .  OnEnable()  .
    // -------------------------------------------------------------------------
    //  Method.......:  OnEnable()
    //  Description..:  
    //  Parameters...:  None
    //  Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void OnEnable()
    {
        AsteroidManager.OnAsteroidDestroyed += this.OnAsteroidDestroyed;

    }   // OnEnable()
    #endregion


    #region .  Start()  .
    // -------------------------------------------------------------------------
    //  Method.......:  Start()
    //  Description..:  
    //  Parameters...:  asteroid
    //  Returns......:  Nothing
    // --------------------------------------------------------------------------
    private void Start()
    {
        if (!Globals.IsMainMenuCalled)
        {
            SceneManager.LoadScene("MainMenuScene");
            return;
        }

    }   // Start()
    #endregion


}   // class GameManager
