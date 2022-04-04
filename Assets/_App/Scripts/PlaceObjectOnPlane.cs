using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceObjectOnPlane : MonoBehaviour
{
    [SerializeField] GameObject placedPrefab;
    GameObject spawnedObject;

    void OnPlaceObject(InputValue value)
    {
        // get the screen touch position
        Vector2 touchPosition = value.Get<Vector2>();
        // raycast from the touch position into the 3D scene looking for a
        // plane
        // if the raycast hit a plane, then
        ARRaycastManager raycaster = GetComponent<ARRaycastManager>();
        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        if (raycaster.Raycast(touchPosition, hits,
            TrackableType.PlaneWithinPolygon))
        {
            // get the hit point (pose) on the plane
            Pose hitPose = hits[0].pose;

            // if this is the first time placing an object,
            if (spawnedObject = null)
            {
                // instantiate the prefab at the hit position and rotation
                spawnedObject = Instantiate(placedPrefab, hitPose.position,
                    hitPose.rotation);
            }
            else
            {
                // change the position of the previously placed object
                spawnedObject.transform.SetPositionAndRotation(hitPose.position,
                    hitPose.rotation);
            }
        }
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
