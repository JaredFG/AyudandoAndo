using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using TMPro;
using System.Collections.Generic;

public class ARPlaneTouchDetector : MonoBehaviour
{
    [SerializeField] private float raycastDisntance;
    [SerializeField] private ToolController toolController;
    
    private Vector2 touchPosition = default;
    Camera m_MainCamera;

    private void Start() {
        m_MainCamera = Camera.main;
    }
 
    void Update() 
    {
        if(Input.touchCount > 0) 
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = touch.position;
 
            //Checking to see if the position of the touch is over a UI object in case of UI overlay on screen.

            Ray ray = m_MainCamera.ScreenPointToRay(touchPosition);
            RaycastHit hitObject;

            if (Physics.Raycast(ray, out hitObject)) 
            {
                if (hitObject.distance < raycastDisntance)
                {
                    Debug.Log(hitObject.transform.gameObject.name);
                    Debug.Log(hitObject.transform.gameObject.tag);

                    if (hitObject.transform.gameObject.CompareTag("Interactable"))
                    {
                        hitObject.transform.gameObject.GetComponent<InteractionEnum>().PerformRepairAction();
                    }
                    
                    if (hitObject.transform.gameObject.GetComponent<BreakObject>())
                    {
                        hitObject.transform.gameObject.GetComponent<InteractionEnum>().PerformRepairAction();
                        hitObject.transform.gameObject.GetComponent<BreakObject>().TakeDamage(1, toolController.currentTool);
                    }
                }
            }
        }
    }
}