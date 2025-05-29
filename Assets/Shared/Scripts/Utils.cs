using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class Utils : MonoBehaviour
{
    // -------------------------------------------------------------------------
    // Public Methods:
    // ----------------
    //   GetMouseWorldPosition3D()
    //   LoadAssets()
    //   LoadAsteroidAssets()
    //   LoadSpaceshipAssets()
    //   RandomDirection3D()
    //   RandomVector3D()
    //   RecalculateTangents()
    //   SetZToZero()
    // -------------------------------------------------------------------------

    #region .  GetMouseWorldPosition3D()  .
    // -------------------------------------------------------------------------
    //  Method.......:  GetMouseWorldPosition3D()
    //
    //  Description..:  Get the mouse position and use a RayCast and a Layer
    //                  Mask to convert the position to 3D WorldPosition.
    //
    //  Parameters...:  Camera
    //                  LayerMask
    //
    //  Returns......:  Vector3 (x, y, z) of the hit position if the ray hits
    //                  the layer mask, else returns Vector3.zero (0, 0, 0).
    // -------------------------------------------------------------------------
    public static Vector3 GetMouseWorldPosition3D(Camera camera, LayerMask layer)
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, layer))
        {
            return hit.point;
        }

        return Vector3.zero;

    }   // GetMouseWorldPosition3D
    #endregion


    #region .  LoadAssets()  .
    // -------------------------------------------------------------------------
    //  Method.......:  LoadAssets()
    //  Description..:  
    //  Parameters...:  label
    //  Returns......:  Nothing
    // --------------------------------------------------------------------------
    public static List<GameObject> LoadAssets(string assetsPath)
    {
        List<GameObject> assetsList = new List<GameObject>();

        string[] guids = AssetDatabase.FindAssets("t:prefab", new string[] { assetsPath });

        foreach (string guid in guids)
        {
            string     path  = AssetDatabase.GUIDToAssetPath(guid);
            GameObject asset = AssetDatabase.LoadAssetAtPath<GameObject>(path);
            assetsList.Add(asset);
        }

        return assetsList;

    }   // LoadAssets()
    #endregion


    #region .  LoadAsteroidAssets()  .
    // -------------------------------------------------------------------------
    //  Method.......:  LoadAsteroidAssets()
    //  Description..:  
    //  Parameters...:  label
    //  Returns......:  Nothing
    // --------------------------------------------------------------------------
    public static List<Asteroid> LoadAsteroidAssets(string assetsPath)
    {
        List<Asteroid> assetsList = new List<Asteroid>();

        string[] guids = AssetDatabase.FindAssets("t:prefab", new string[] { assetsPath });

        foreach (string guid in guids)
        {
            string   path  = AssetDatabase.GUIDToAssetPath(guid);
            Asteroid asset = AssetDatabase.LoadAssetAtPath<Asteroid>(path);
            assetsList.Add(asset);
        }

        return assetsList;

    }   // LoadAsteroidAssets()
    #endregion


    #region .  LoadSpaceshipAssets()  .
    // -------------------------------------------------------------------------
    //  Method.......:  LoadSpaceshipAssets()
    //  Description..:  
    //  Parameters...:  label
    //  Returns......:  Nothing
    // --------------------------------------------------------------------------
    public static List<Spaceship> LoadSpaceshipAssets(string assetsPath)
    {
        List<Spaceship> assetsList = new List<Spaceship>();

        string[] guids = AssetDatabase.FindAssets("t:prefab", new string[] { assetsPath });

        foreach (string guid in guids)
        {
            string    path  = AssetDatabase.GUIDToAssetPath(guid);
            Spaceship asset = AssetDatabase.LoadAssetAtPath<Spaceship>(path);
            assetsList.Add(asset);
        }

        return assetsList;

    }   // LoadSpaceshipAssets()
    #endregion


    #region .  RandomDirection3D()  .
    // -------------------------------------------------------------------------
    //  Method.......:  RandomDirection3D()
    //  Description..:  
    //  Parameters...:  None
    //  Returns......:  Nothing
    // --------------------------------------------------------------------------
    public static Vector3 RandomDirection3D()
    {
        Vector3 randomDirection = Random.onUnitSphere;  //.normalized;

        return randomDirection;

    }   // RandomDirection3D()
    #endregion


    #region .  RandomVector3D()  .
    // -------------------------------------------------------------------------
    //  Method.......:  RandomVector3D()
    //  Description..:  
    //  Parameters...:  None
    //  Returns......:  Nothing
    // --------------------------------------------------------------------------
    public static Vector3 RandomVector3D(float min, float max)
    {
        var x = Random.Range(min, max);
        var y = Random.Range(min, max);
        var z = Random.Range(min, max);

        return new Vector3(x, y, z).normalized;

    }   // RandomVector3D()
    #endregion


    #region .  RecalculateTangents()  .
    // -------------------------------------------------------------------------
    //   Method.......:  RecalculateTangents()
    //   Description..:  
    //   Parameters...:  GameObject - the GameObject containing a meshFilter that
    //                   has normals and UVs.
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    public static void RecalculateTangents(GameObject gameObject)
    {
        // Get the MeshFilter component attached to the GameObject.
        MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();

        if (meshFilter != null && meshFilter.sharedMesh != null)
        {
            Mesh mesh = meshFilter.sharedMesh;

            // Ensure the mesh has normals and UVs before recalculating tangents.
            if (mesh.normals.Length > 0 && mesh.uv.Length > 0)
            {
                // Recalculate tangents.
                mesh.RecalculateTangents();
                Debug.Log("Tangents recalculated successfully!");
            }
            else
            {
                Debug.LogWarning("Mesh must have normals and UVs to recalculate tangents.");
            }
        }
        else
        {
            Debug.LogError("No MeshFilter or Mesh found on this GameObject.");
        }

    }   // RecalculateTangents()
    #endregion


    #region .  SetZToZero()  .
    // -------------------------------------------------------------------------
    //   Method.......:  SetZToZero()
    //
    //   Description..:  Sets the z coordinate of the transform position to zero.
    //
    //   Parameters...:  Transform - the transform of the object to set.
    //
    //   Returns......:  Vector3 with the z coordinate set to zero.
    // -------------------------------------------------------------------------
    public static Vector3 SetZToZero(Transform transform)
    {
        Vector3 currentPosition = transform.position;   // Get the current position
        currentPosition.z = 0.0f;                 // Set the z value to zero
        transform.position = currentPosition;      // Apply the updated position back to the transform

        return currentPosition;

    }   // SetZToZero()
    #endregion


}   // class Utils
