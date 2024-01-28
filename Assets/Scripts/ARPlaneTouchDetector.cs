using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using TMPro;
using System.Collections.Generic;

public class ARPlaneTouchDetector : MonoBehaviour
{
    //public TMP_Text touchResultText; // Asigna el componente TextMeshProUGUI del Canvas a trav�s del Inspector
    public ARRaycastManager aRRaycastManager;
    public ARPlaneManager aRPlaneManager;
    public List<ARRaycastHit> hits = new List<ARRaycastHit>();
    public GameObject prefab;
    public TextMeshProUGUI text;
    private Camera arCamera;


    private bool prefabInstantiated = false;

    void Start()
    {
        aRRaycastManager = GetComponent<ARRaycastManager>();
        aRPlaneManager = GetComponent<ARPlaneManager>();
        hits = new List<ARRaycastHit>();
    }

    void Update()
    {
        /*if (Input.touchCount > 0 && !prefabInstantiated)
        {
            Debug.Log("here");
            
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = touch.position;

            if (aRRaycastManager != null /*&& touchResultText != null *//*)
            {
                if (aRRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
                {
                    // Se ha detectado un plano
                    //touchResultText.text = "Tocaste un plano";
                    
                    foreach (ARRaycastHit hit in hits)
                    {
                        Pose pose = hit.pose;
                        GameObject obj = Instantiate(prefab, pose.position, pose.rotation);
                        Debug.Log(hit.trackable.gameObject.tag);
                    }

                    // Marcamos que ya se ha instanciado el prefab
                    prefabInstantiated = true;

                    // Desactivar AR Plane Manager y trackables
                    if (aRPlaneManager != null)
                    {
                        aRPlaneManager.enabled = false; // Desactiva AR Plane Manager
                        foreach (var plane in aRPlaneManager.trackables)
                        {
                            plane.gameObject.SetActive(false); // Desactiva cada plano individual
                        }
                    }
                }
                else
                {
                    // No se ha detectado un plano
                    ///touchResultText.text = "No tocaste un plano";
                }
            }
        }*/
        
        if (Input.touchCount == 0)
            return;

        Touch touch = Input.GetTouch(0);

        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        if (aRRaycastManager.Raycast(touch.position, hits))
        {
            // Raycast hits an AR plane or tracked image
            Pose hitPose = hits[0].pose;

            // Perform a traditional raycast from the camera to the hit position
            RaycastHit hitInfo;
            if (Physics.Raycast(arCamera.ScreenPointToRay(touch.position), out hitInfo))
            {
                // Check if the raycast hit a GameObject
                GameObject hitObject = hitInfo.collider.gameObject;

                // Retrieve the tag of the hit GameObject
                string objectTag = hitObject.tag;
                Debug.Log("Hit object tag: " + objectTag);
            }
        }
        
    }
}