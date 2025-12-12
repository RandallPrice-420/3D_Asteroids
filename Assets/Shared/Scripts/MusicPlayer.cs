using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
class MusicPlayer : Singleton<MusicPlayer>
{
    // -------------------------------------------------------------------------
    // Public Properties:
    // ------------------
    //   AssetsPath
    //   audioSource
    // -------------------------------------------------------------------------

    #region .  Public Properties  .

    public string      AssetsPath = "Assets/Shared/Audio/Music/";
    public AudioSource audioSource;

    #endregion


    // -------------------------------------------------------------------------
    // Public Methods:
    // --------------
    //   Play()
    //   Stop()
    // -------------------------------------------------------------------------

    #region .  Play()  .
    // -------------------------------------------------------------------------
    //  Method.......:  Play()
    //  Description..:  
    //  Parameters...:  None
    //  Returns......:  Nothing
    // --------------------------------------------------------------------------
    public void Play(AudioClip audioClip)
    {
        this.audioSource.PlayOneShot(audioClip);

    }   // Play()
    #endregion


    #region .  PlayRandom()  .
    // -------------------------------------------------------------------------
    //  Method.......:  PlayRandom()
    //  Description..:  
    //  Parameters...:  None
    //  Returns......:  Nothing
    // --------------------------------------------------------------------------
    public void PlayRandom()
    {
        this.audioSource.PlayOneShot(this.GetRandomClip());

    }   // PlayRandom()
    #endregion


    #region .  Stop()  .
    // -------------------------------------------------------------------------
    //  Method.......:  Stop()
    //  Description..:  
    //  Parameters...:  None
    //  Returns......:  Nothing
    // --------------------------------------------------------------------------
    public void Stop()
    {
        this.audioSource.Stop();

    }   // Stop()
    #endregion


    // -------------------------------------------------------------------------
    // Private Methods:
    // ----------------
    //   Awake()
    //   GetRandomClip()
    // -------------------------------------------------------------------------

    #region .  Awake()  .
    // -------------------------------------------------------------------------
    //   Method.......:  Awake()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

    }   // Awake()
    #endregion


    #region .  GetRandomClip()  .
    // -------------------------------------------------------------------------
    //   Method.......:  GetRandomClip()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    private AudioClip GetRandomClip()
    {
        List<AudioClip> audioClips = Utils.LoadAssets<AudioClip>(this.AssetsPath, "t:audioclip");
        if (audioClips.Count > 0)
        {
            return audioClips[Random.Range(0, audioClips.Count - 1)];
        }

        Debug.LogWarning($"No audio clips found in {this.AssetsPath}");

        return null;

    }   // GetRandomClip()
    #endregion


}   // class MusicPlayer
