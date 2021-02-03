using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
public class PlacementIndicatorBehaviourScript : MonoBehaviour
{
    private ARRaycastManager rayManager;
    private GameObject visual;
    // Start is called before the first frame update
    void Start()
    {
        //get the components
        rayManager = FindObjectOfType<ARRaycastManager>();
        visual = transform.GetChild(0).gameObject;

        //hide the placemetn visual
        visual.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        // shoot a raycast from the center of the screen
        List<ARRaycastHit> hits = new List<ARRaycastHit>(); // outputs a list of ARRaycasts hits
        //cast rayccast
        rayManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2),hits, TrackableType.Planes);

        //if we hit an AR plane update the position and rotation of our object
        if (hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;

            if (!visual.activeInHierarchy)
            {
                visual.SetActive(true);
            }

        }

    }
}
