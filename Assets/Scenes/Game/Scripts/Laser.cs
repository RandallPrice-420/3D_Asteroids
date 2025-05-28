using UnityEngine;


public class Laser : MonoBehaviour
{
    // -------------------------------------------------------------------------
    // Private Properties:
    // -------------------
    //   _speed
    // -------------------------------------------------------------------------

    #region .  Private Properties  .

    [SerializeField] private float _speed;

    #endregion


    // -------------------------------------------------------------------------
    // Private Methods:
    // ----------------
    //   Die()
    //   OnDisable()
    //   OnTriggerEnter()
    //   Update()
    // -------------------------------------------------------------------------

    #region .  Die()  .
    // -------------------------------------------------------------------------
    //   Method.......:  Die()
    //   Description..:  Destroy the laser GameObject.
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void Die()
    {
        Destroy(this.gameObject);

    }   // Die()
    #endregion


    #region .  OnDisable()  .
    // -------------------------------------------------------------------------
    //   Method.......:  OnDisable()
    //   Description..:  Calls Die() to be sure the laser is destroyed.  This is
    //                   done to prevent a memory leak.
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void OnDisable()
    {
        this.Die();

    }   // OnDisable()
    #endregion


    #region .  OnTriggerEnter()  .
    // -------------------------------------------------------------------------
    //   Method.......:  OnTriggerEnter()
    //   Description..:  Called when the laser collides wih another GameObject.
    //                   If it is an asteroid, calls Die() to destroy the laser.
    //   Parameters...:  Collider - the GameObject the laser collides with.
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Asteroid"))
        {
            this.Die();
        }

    }   // OnTriggerEnter()
    #endregion


    #region .  Update()  .
    // -------------------------------------------------------------------------
    //   Method.......:  Update()
    //   Description..:  Handles the laser movement, and checks for moving off
    //                   the screen.
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void Update()
    {
        this.transform.Translate(this._speed * Time.deltaTime * Vector3.forward);

        // Check for laser moves offscreen.
        if (ScreenManager.Instance.IsOffScreen(this.transform))
        {
            // If so, destroy it.
            this.Die();
        }

    }   // Update()
    #endregion


}   // class Laser
