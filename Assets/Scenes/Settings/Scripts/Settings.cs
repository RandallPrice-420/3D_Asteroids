using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;


public class Settings : MonoBehaviour
{
    // -------------------------------------------------------------------------
    // Public Properties:
    // ------------------
    //   audioSource
    //   guiSkin
    //   AudioClipTestMusic
    //   AudioClipTestSFX
    //   ButtonMusicOff
    //   ButtonMusicOn
    //   ButtonMusicPlay
    //   ButtonMusicStop
    //   ButtonSpaceships
    //   ButtonSFXOff
    //   ButtonSFXOn
    //   ButtonSFXPlay
    //   ButtonSFXStop
    // -------------------------------------------------------------------------

    #region .  Public Properties  .

    public AudioSource  audioSource;
    public GUISkin      guiSkin;
    public AudioClip    AudioClipTestMusic;
    public AudioClip    AudioClipTestSFX;
    public Button       ButtonBackSettings;
    public Button       ButtonMusicOff;
    public Button       ButtonMusicOn;
    public Button       ButtonMusicPlay;
    public Button       ButtonMusicStop;
    public Button       ButtonSave;
    public Button       ButtonSpaceships;
    public Button       ButtonSFXOff;
    public Button       ButtonSFXOn;
    public Button       ButtonSFXPlay;
    public Button       ButtonSFXStop;
    public GameObject   SpaceshipPlaceholder;

    #endregion


    // -------------------------------------------------------------------------
    // Private Properties:
    // -------------------
    //   _buttonPlayImage
    //   _buttonStopImage
    //   _currentSpaceship
    //   _sliderMusicValue
    //   _sliderSFXValue
    //   //_toggleMusic
    //   _toggleSFX
    //   _windowRect
    // -------------------------------------------------------------------------

    #region .  Private Properties  .

    private Button                   _buttonBackSettings;
    private Button                   _buttonMusicOn;
    private Button                   _buttonMusicOff;
    private Button                   _buttonMusicPlay;
    private Button                   _buttonMusicStop;
    private Button                   _buttonSave;
    private Button                   _buttonSpaceships;

    private Texture2D                _buttonPlayImage;
    private Texture2D                _buttonStopImage;
    //private readonly int             _currentSpaceship = 0;
    //private readonly float           _sliderMusicValue = 0.0f;
    //private readonly float           _sliderSFXValue   = 0.0f;
    //private readonly bool            _toggleMusic      = true;
    //private readonly bool            _toggleSFX        = true;

    private readonly string          _assetsPath       = "Assets/Shared/Prefabs/Spaceships";
    private readonly Spaceship       _spaceship;
    private readonly List<Spaceship> _spaceshipsList   = new();

    #endregion


    // -------------------------------------------------------------------------
    // Public Methods:
    // ---------------
    //   PUBLIC_NAME()
    // -------------------------------------------------------------------------

    #region .  PUBLIC_NAME()  .
    // -------------------------------------------------------------------------
    //   Method.......:  PUBLIC_NAME()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    public void PUBLIC_NAME()
    {
        

    }   // PUBLIC_NAME()
    #endregion



    // -------------------------------------------------------------------------
    // Private Methods:
    // ----------------
    //   PRIVATE_NAME()
    //   Start()
    //   Update()
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
        ////if (!GameManager.Instance.IsMainMenuRun)
        //if (!Globals.IsMainMenuCalled)
        //{
        //    SceneManager.LoadScene("MainMenuScene");
        //    return;
        //}

        this._buttonBackSettings = GameObject.Find("ButtonBackSettings").GetComponent<Button>();
        this._buttonMusicOn      = GameObject.Find("ButtonMusicOn"     ).GetComponent<Button>();
        this._buttonMusicOff     = GameObject.Find("ButtonMusicOff"    ).GetComponent<Button>();
        this._buttonMusicPlay    = GameObject.Find("ButtonMusicPlay"   ).GetComponent<Button>();
        this._buttonMusicStop    = GameObject.Find("ButtonMusicStop"   ).GetComponent<Button>();
        this._buttonSave         = GameObject.Find("ButtonSave"        ).GetComponent<Button>();
        this._buttonSpaceships   = GameObject.Find("ButtonSpaceships"  ).GetComponent<Button>();

        this._buttonPlayImage    = Resources.Load<Texture2D>("Shared/Sprites/audio_start");
        this._buttonStopImage    = Resources.Load<Texture2D>("Shared/Sprites/audio_stop");

    }   // Awake()
    #endregion


    #region .  PRIVATE_NAME()  .
    // -------------------------------------------------------------------------
    //   Method.......:  PRIVATE_NAME()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void PRIVATE_NAME()
    {
        

    }	// PRIVATE_NAME()
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
        

    }	// Start()
	#endregion


    #region .  Update()  .
    // -------------------------------------------------------------------------
    //   Method.......:  Update()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void Update()
    {
        

    }	// Update()
	#endregion


}	// class Settings
