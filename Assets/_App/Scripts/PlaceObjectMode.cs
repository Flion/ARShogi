using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceObjectMode : MonoBehaviour
{
    [SerializeField] ARRaycastManager raycaster;
    GameObject placedPrefab;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void OnEnable()
    {
        UIController.ShowUI("PlaceObject");
    }

    public void SetPlacedPrefab(GameObject prefab)
    {
        placedPrefab = prefab;
    }

    public void OnPlaceObject(InputValue value)
    {
        Vector2 touchPosition = value.Get<Vector2>();
        PlaceObject(touchPosition);
    }

    void PlaceObject(Vector2 touchPosition)
    {
        Debug.Log("Here we are before the raycast...");
        if (raycaster.Raycast(touchPosition, hits,
            TrackableType.PlaneWithinInfinity))
        {
            Debug.Log("Here we are looking for hits...");
            Pose hitPose = hits[0].pose;
            Instantiate(placedPrefab, hitPose.position, hitPose.rotation);

            InteractionController.EnableMode("Main");
        }
        Debug.Log("Here we are after raycasting ...");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
