using UnityEngine;


public class MouseRotation : MonoBehaviour
{
    // -------------------------------------------------------------------------
    // Public Properties:
    // ------------------
    //   HorizontalSpeed
    //   VerticalSpeed
    // -------------------------------------------------------------------------

    #region .  Public Properties  .

    public float HorizontalSpeed = 2.0F;
    public float VerticalSpeed   = 2.0F;

    #endregion


    // -------------------------------------------------------------------------
    // Private Methods:
    // ----------------
	//   Update()
    // -------------------------------------------------------------------------

    #region .  Update()  .
    // -------------------------------------------------------------------------
    //   Method.......:  Update()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void Update()
    {
        float h = this.HorizontalSpeed * Input.GetAxis("Mouse X");
        float v = this.VerticalSpeed   * Input.GetAxis("Mouse Y");

        this.transform.Rotate(v, h, 0);

    }   // Update()
    #endregion


}	// class MouseRotation
