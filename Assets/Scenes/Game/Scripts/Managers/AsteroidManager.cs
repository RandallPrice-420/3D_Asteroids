using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;


public class AsteroidManager : Singleton<AsteroidManager>
{
    // -------------------------------------------------------------------------
    // Public Events:
    // --------------
    //   OnAsteroidDestroyed
    // -------------------------------------------------------------------------

    #region .  Public Events  .

    public static event Action<Asteroid> OnAsteroidDestroyed = delegate { };

    #endregion


    // -------------------------------------------------------------------------
    // Public Properties:
    // ------------------
    //   CountAsteroidsCreated
    //   CountAsteroidsDestroyed
    //   CountAsteroidsExisting
    //   CountAsteroidsMissed
    //   MinThrust
    //   MaxThrust
    //   MinTorque
    //   MaxTorque
    //   SpawnInterval
    //   HitEffect
    // -------------------------------------------------------------------------

    #region .  Public Properties  .

    public int        CountAsteroidsCreated   = 0;
    public int        CountAsteroidsDestroyed = 0;
    public int        CouhtAsteroidsExisting  = 0;
    public int        CountAsteroidsMissed    = 0;
    public float      MinThrust               =  10.0f;
    public float      MaxThrust               = 100.0f;
    public float      MinTorque               =  10.0f;
    public float      MaxTorque               = 100.0f;
    public float      SpawnInterval           =   4.0f;

    public GameObject HitEffect;

    #endregion


    // -------------------------------------------------------------------------
    // Private Properties:
    // -------------------
    //   //_maximumScale
    //   //_minimumScale
    //   _asteroidsAssetsPath
    //   _explosionsAssetsPath
    //   _asteroidsList
    //   _explosionsList
    //   _isExploding
    //   _maximumX
    //   _minimumX
    //   _maximumY
    //   _minimumY
    //   _audioClipAsteroidDestroyed
    //   _audioClipLaserHitAsteroid
    // -------------------------------------------------------------------------

    #region .  Private Properties  .

    //[SerializeField] private float  _maximumScale  = 1.5f;
    //[SerializeField] private float  _minimumScale  = 0.5f;

    private readonly string           _asteroidsAssetsPath  = "Assets/Scenes/Game/Prefabs/Asteroids";
    private readonly string           _explosionsAssetsPath = "Assets/3rd-Party/ParticleProFX/Resources/Library/Fire & Explosions";
    private readonly List<Asteroid>   _asteroidsList        = new();
    private readonly List<GameObject> _explosionsList       = new();  

    private bool      _isExploding = false;
    private float     _maximumX;
    private float     _minimumX;
    private float     _maximumY;
    private float     _minimumY;
    private AudioClip _audioClipAsteroidDestroyed;
    private AudioClip _audioClipLaserHitAsteroid;

    #endregion


    // -------------------------------------------------------------------------
    // Public Methods:
    // --------------
    //   LoadAsteroids()
    // -------------------------------------------------------------------------

    #region .  LoadAsteroids()  .
    // -------------------------------------------------------------------------
    //  Method.......:  LoadAsteroids()
    //  Description..:  
    //  Parameters...:  label
    //  Returns......:  Nothing
    // --------------------------------------------------------------------------
    public void LoadAsteroids()
    {
        string[] guids = AssetDatabase.FindAssets("t:prefab", new string[] { this._asteroidsAssetsPath });

        foreach (string guid in guids)
        {
            string   path     = AssetDatabase.GUIDToAssetPath(guid);
            Asteroid asteroid = AssetDatabase.LoadAssetAtPath<Asteroid>(path);

            this._asteroidsList.Add(asteroid);
        }

    }   // LoadAsteroids()
    #endregion


    #region .  LoadExplosions()  .
    // -------------------------------------------------------------------------
    //  Method.......:  LoadExplosions()
    //  Description..:  
    //  Parameters...:  label
    //  Returns......:  Nothing
    // --------------------------------------------------------------------------
    public void LoadExplosions()
    {
        string[] guids = AssetDatabase.FindAssets("t:prefab", new string[] { this._explosionsAssetsPath });

        foreach (string guid in guids)
        {
            string     path      = AssetDatabase.GUIDToAssetPath(guid);
            GameObject explosion = AssetDatabase.LoadAssetAtPath<GameObject>(path);

            this._explosionsList.Add(explosion);
        }

    }   // LoadExplosions()
    #endregion


    // -------------------------------------------------------------------------
    // Private Methods:
    // ----------------
    //   InstantiateAsteroid()
    //   InstantiateRandomAsteroid()  --  COMMENTED OUT
    //   OnAsteroidCollisionEnter()   --  DOES NOTHING YET
    //   OnAsteroidCreated()
    //   OnAsteroidDestroyed()        --  COMMENTED OUT
    //   OnAsteroidLeavesScreen()
    //   OnAsteroidTriggerEnter()
    //   OnDisable()
    //   OnEnable()
    //   SpawnAsteroid()
    //   Start()
    // -------------------------------------------------------------------------

    #region .  InstantiateAsteroid()  .
    // -------------------------------------------------------------------------
    //   Method.......:  InstantiateAsteroid()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void InstantiateAsteroid()
    {
        // Pick a random asteroid and create a random position for it.
        Asteroid randomAsteroid = _asteroidsList[Random.Range(0, _asteroidsList.Count - 1)];
        Vector3  randomPosition = new(Random.Range(ScreenManager.Instance.ScreenLeft,   ScreenManager.Instance.ScreenRight),
                                      Random.Range(ScreenManager.Instance.ScreenBottom, ScreenManager.Instance.ScreenTop  ),
                                      0f);

        // Create the new Asteroid and append it to the name.
        Asteroid newAsteroid = Instantiate<Asteroid>(randomAsteroid, randomPosition, Quaternion.identity);
        newAsteroid.name += $"_{this.CountAsteroidsCreated}";

    }   // InstantiateAsteroid()
    #endregion


    #region .  InstantiateRandomAsteroid()  --  COMMENTED OUT  .
    //// -------------------------------------------------------------------------
    ////   Method.......:  InstantiateRandomAsteroid()
    ////   Description..:  
    ////   Parameters...:  None
    ////   Returns......:  Nothing
    //// -------------------------------------------------------------------------
    //private void InstantiateRandomAsteroid()
    //{
    //    bool  isOverlap = true;
    //    float scale     = Random.Range(this._minimumScale, this._maximumScale);
    //    float spawnX    = 0;
    //    float spawnY    = 0;

    //    do
    //    {
    //        float randomValue = Random.value;

    //        if (randomValue > 0.75f)
    //        {
    //            spawnX = Random.Range(this._minimumX - this._maximumScale - scale, this._minimumX - this._minimumScale - scale);
    //            spawnY = Random.Range(this._minimumY,  this._maximumY);
    //        }
    //        else if (randomValue > 0.50f)
    //        {
    //            spawnX = Random.Range(this._maximumX + this._minimumScale + scale, this._maximumX + this._maximumScale + scale);
    //            spawnY = Random.Range(this._minimumY,  this._maximumY);
    //        }
    //        else if (randomValue > 0.25f)
    //        {
    //            spawnX = Random.Range(this._minimumX,  this._maximumX);
    //            spawnY = Random.Range(this._minimumY - this._maximumScale - scale, this._minimumY - this._minimumScale - scale);
    //        }
    //        else
    //        {
    //            spawnX = Random.Range(this._minimumX,  this._maximumX);
    //            spawnY = Random.Range(this._maximumY + this._minimumScale + scale, this._maximumY + this._maximumScale + scale);
    //        }

    //        //if (spawnX < this._minimumX) spawnX = this._minimumX;
    //        //if (spawnX > this._maximumX) spawnX = this._maximumX;
    //        //if (spawnY < this._minimumY) spawnY = this._minimumY;
    //        //if (spawnY > this._maximumY) spawnY = this._maximumY;

    //        // Avoiding spawning 2 asteroids on top of each other.
    //        Collider[] collidersBuffer = new Collider[16];
    //        int size = Physics.OverlapBoxNonAlloc(new Vector3(spawnX, spawnY, 0.0f), new Vector3(1.0f, 1.0f, 0.0f), collidersBuffer);

    //        isOverlap = (size > 0);

    //    } while (isOverlap);

    //    print($"Asteroid position:  {new Vector3(spawnX, spawnY, 0.0f)}");

    //    int randomIndex = Random.Range(0, this._asteroidPrefabs.Length - 1);

    //    GameObject asteroid = Instantiate(this._asteroidPrefabs[randomIndex], new Vector3(spawnX, spawnY, 0.0f), Quaternion.Euler(0.0f, 0.0f, 0.0f));
    //    asteroid.transform.LookAt(this._screenCenter);
    //    asteroid.transform.localScale = new Vector3(scale, scale, scale);

    //}   // InstantiateRandomAsteroid()
    #endregion


    #region .  OnAsteroidCollisionEnter()  --  DOES NOTHING YET  .
    // -------------------------------------------------------------------------
    //  Method.......:  OnAsteroidCollisionEnter()
    //  Description..:  
    //  Parameters...:  Asteroid
    //  Returns......:  Nothing
    // --------------------------------------------------------------------------
    private void OnAsteroidCollisionEnter(Asteroid asteroid, Collision otherCollision)
    {

    }   // OnAsteroidCollisionEnter()
    #endregion


    #region .  OnAsteroidCreated()  .
    // -------------------------------------------------------------------------
    //  Method.......:  OnAsteroidCreated()
    //  Description..:  
    //  Parameters...:  Asteroid
    //  Returns......:  Nothing
    // --------------------------------------------------------------------------
    private void OnAsteroidCreated(Asteroid asteroid)
    {
        this.CountAsteroidsCreated++;
        this.CouhtAsteroidsExisting++;

    }   // OnAsteroidCreated()
    #endregion


    #region .  OnAsteroidDestroyed()  --  COMMENTED OUT  .
    //// -------------------------------------------------------------------------
    ////  Method.......:  OnAsteroidDestroyed()
    ////  Description..:  
    ////  Parameters...:  Asteroid
    ////  Returns......:  Nothing
    //// --------------------------------------------------------------------------
    //private void OnAsteroidDestroyed(Asteroid asteroid)
    //{
    //    this.AsteroidsDestroyed++;
    //    this.AsteroidsExisting--;

    //}   // OnAsteroidDestroyed()
    #endregion


    #region .  OnAsteroidLeavesScreen()  .
    // -------------------------------------------------------------------------
    //  Method.......:  OnAsteroidLeavesScreen()
    //  Description..:  Destroy the asteroid, decrement the number of existing
    //                  asteroids and increment the number of asteroids muissed.
    //  Parameters...:  Asteroid - the asteroid that moved off the screen.
    //  Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void OnAsteroidLeavesScreen(Asteroid asteroid)
    {
        Destroy(asteroid.gameObject);

        this.CouhtAsteroidsExisting--;
        this.CountAsteroidsMissed++;

    }   // OnAsteroidLeavesScreen()
    #endregion


    #region .  OnAsteroidTriggerEnter()  .
    // -------------------------------------------------------------------------
    //  Method.......:  OnAsteroidTriggerEnter()
    //  Description..:  
    //  Parameters...:  None
    //  Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void OnAsteroidTriggerEnter(Asteroid asteroid, Collider otherCollider)
    {
        this.TakeDamage(asteroid);

    }   // OnAsteroidLeavesScreen()
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
        Asteroid.OnAsteroidCollisionEnter -= this.OnAsteroidCollisionEnter;
        Asteroid.OnAsteroidCreated        -= this.OnAsteroidCreated;
        Asteroid.OnAsteroidLeavesScreen   -= this.OnAsteroidLeavesScreen;
        Asteroid.OnAsteroidTriggerEnter   -= this.OnAsteroidTriggerEnter;

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
        Asteroid.OnAsteroidCollisionEnter += this.OnAsteroidCollisionEnter;
        Asteroid.OnAsteroidCreated        += this.OnAsteroidCreated;
        Asteroid.OnAsteroidLeavesScreen   += this.OnAsteroidLeavesScreen;
        Asteroid.OnAsteroidTriggerEnter   += this.OnAsteroidTriggerEnter;

    }   // OnEnable()
    #endregion


    #region .  SpawnAsteroid()  .
    // -------------------------------------------------------------------------
    //   Method.......:  SpawnAsteroid()
    //   Description..:  Calls InstantiateAsteroid() to spawns a new asteroid.
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    private IEnumerator SpawnAsteroid()
    {
        while (true)
        {
            yield return new WaitForSeconds(this.SpawnInterval);

            this.InstantiateAsteroid();
        }

    }   // SpawnAsteroid()
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
        // Get main camera position.
        Camera  mainCamera     = Camera.main;
        Vector3 cameraPosition = mainCamera.transform.position;

        this._audioClipAsteroidDestroyed = SoundManager.Instance.SoundAudioClips[(int)SoundManager.Sounds.Asteroid_Destroyed].audioClip;
        this._audioClipLaserHitAsteroid  = SoundManager.Instance.SoundAudioClips[(int)SoundManager.Sounds.Laser_Hit_Asteroid].audioClip;

        // Store screen boundaries.
        this._maximumX = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f,          -cameraPosition.z)).x;
        this._minimumX = mainCamera.ScreenToWorldPoint(new Vector3(0.0f,         0.0f,          -cameraPosition.z)).x;
        this._maximumY = mainCamera.ScreenToWorldPoint(new Vector3(0.0f,         Screen.height, -cameraPosition.z)).y;
        this._minimumY = mainCamera.ScreenToWorldPoint(new Vector3(0.0f,         0.0f,          -cameraPosition.z)).y;

        // Get a list of the asteroid and explosion prefabs.
        this.LoadAsteroids();
        this.LoadExplosions();

        // Spawn the first asteroid.
        StartCoroutine(this.SpawnAsteroid());

    }   // Start()
    #endregion


    #region .  TakeDamage()  .
    // -------------------------------------------------------------------------
    //   Method.......:  TakeDamage()
    //   Description..:  
    //   Parameters...:  Asteroid - 
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void TakeDamage(Asteroid asteroid)
    {
        //Instantiate(this.HitEffect, asteroid.transform.position, Quaternion.Euler(0.0f, 0.0f, 0.0f));
        SoundManager.Instance.PlaySound(this._audioClipLaserHitAsteroid);

        asteroid.CurrentHealth -= asteroid.DamagePerHit;

        // Check to explode the asteroid.
        if ((asteroid.CurrentHealth <= 0) && (!this._isExploding))
        {
            this._isExploding = true;

            GameObject explosion = this._explosionsList[Random.Range(0, this._explosionsList.Count - 1)];
            Instantiate(explosion, asteroid.transform.position, Quaternion.Euler(0.0f, 0.0f, 0.0f));
            SoundManager.Instance.PlaySound(this._audioClipAsteroidDestroyed);

            // Destroy the asteroid.
            Destroy(asteroid.gameObject);

            this.CountAsteroidsDestroyed++;
            this.CouhtAsteroidsExisting--;

            // Fire this event.
            OnAsteroidDestroyed?.Invoke(asteroid);

            this._isExploding = false;
        }

    }   // TakeDamage()
    #endregion


}   // class AsteroidManager
