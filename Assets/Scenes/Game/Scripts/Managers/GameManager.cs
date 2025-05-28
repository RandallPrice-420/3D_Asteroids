using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : Singleton<GameManager>
{
    // -------------------------------------------------------------------------
    // Public Events:
    // --------------
    //   OnAsteroidDestroyed
    // -------------------------------------------------------------------------

    #region .  Public Events  .

    public static event Action OnAsteroidDestroyed_2 = delegate { };

    #endregion


    // -------------------------------------------------------------------------
    // Public Properties:
    // ------------------
    //   AvailableLives
    //   IsGameStarted
    //   Lives
    //   Score
    //   PanelGameOver
    //   PanelVictory
    // -------------------------------------------------------------------------

    #region .  Public Properties  .

    public int        AvailableLives = 3;
    public bool       IsGameStarted  = false;
    public int        Lives          = 0;
    public int        Score          = 0;
    public GameObject PanelGameOver;
    public GameObject PanelVictory;

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
        PanelGameOver.SetActive(false);
        PanelVictory .SetActive(false);

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
        PanelGameOver.SetActive(false);
        PanelVictory .SetActive(true);

    }   // ShowVictoryPanel()
    #endregion


    // -------------------------------------------------------------------------
    // Private Methods:
    // ----------------
    //   Awake()
    //   OnAsteroidDestroyed()
    //   OnDisable()
    //   OnEnable()
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

        OnAsteroidDestroyed_2?.Invoke();

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


}   // class GameManager
