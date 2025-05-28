 using UnityEngine;


public class SoundManager : Singleton<SoundManager>
{
    // --------------------------------------------------------------
    // Public Classes:
    // ---------------
    //  SoundAudioClip
    // --------------------------------------------------------------

    #region .  Public Classes  .

    [System.Serializable]
    public class SoundAudioClip
    {
        public Sounds    sound;
        public AudioClip audioClip;

    }   // class SoundAudioClip

    #endregion


    // -------------------------------------------------------------------------
    // Public Enumerations:
    // --------------------
    //   Sounds
    // -------------------------------------------------------------------------

    #region .  Public Enumerations  .

    public enum Sounds
    {
        Asteroid_Destroyed,
        Asteroid_Hit_Asteroid,
        Laser_Hit_Asteroid,
        Laser_Shoot
    }

    #endregion


    // --------------------------------------------------------------
    // Public Properties:
    // ------------------
    //   AudioSource
    //   SoundAudioClips
    // --------------------------------------------------------------

    #region .  Public Properties  .

    public AudioSource      Audio;
    public SoundAudioClip[] SoundAudioClips;

    #endregion


    // -------------------------------------------------------------------------
    // Public Methods:
    // ---------------
    //   PlaySound() - audioClip
    //   PlaySound() - name
    //   PlaySound() - sound
    // -------------------------------------------------------------------------

    #region .  PlaySound() - audioClip  .
    // -------------------------------------------------------------------------
    //   Method.......:  PlaySound()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    public void PlaySound(AudioClip audioClip)
    {
        Audio.PlayOneShot(audioClip);

    }   // PlaySound()
    #endregion


    #region .  PlaySound() - name  .
    // -------------------------------------------------------------------------
    //   Method.......:  PlaySound()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    public void PlaySound(string name)
    {
        Audio.PlayOneShot(this.GetAudioClip(name));

    }   // PlaySound()
    #endregion


    #region .  PlaySound() - sound  .
    // -------------------------------------------------------------------------
    //   Method.......:  PlaySound()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    public void PlaySound(Sounds sound)
    {
        Audio.PlayOneShot(this.GetAudioClip(sound));

    }   // PlaySound()
    #endregion


    // -------------------------------------------------------------------------
    // Private Methods:
    // ----------------
    //   GetAudioClip() - sound
    //   GetAudioClip() - name
    // -------------------------------------------------------------------------

    #region .  GetAudioClip() - sound  .
    // -------------------------------------------------------------------------
    //  Method.......:  GetAudioClip()
    //  Description..:  
    //  Parameters...:  None
    //  Returns......:  Nothing
    // -------------------------------------------------------------------------
    private AudioClip GetAudioClip(Sounds sound)
    {
        foreach (SoundAudioClip soundAudioClip in Instance.SoundAudioClips)
        {
            if (soundAudioClip.sound == sound)
            {
                return soundAudioClip.audioClip;
            }
        }

        Debug.Log($"Sound {sound} is not found!");
        return null;

    }   // GetAudioClip()
    #endregion


    #region .  GetAudioClip() - name  .
    // -------------------------------------------------------------------------
    //   Method.......:  GetAudioClip()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    private AudioClip GetAudioClip(string name)
    {
        foreach (SoundAudioClip soundAudioClip in Instance.SoundAudioClips)
        {
            if (soundAudioClip.sound.ToString() == name)
            {
                return soundAudioClip.audioClip;
            }
        }

        //Debug.Log($"Sound {name} is not found!");
        return null;

    }   // GetAudioClip()
    #endregion


}   // class SoundManager
