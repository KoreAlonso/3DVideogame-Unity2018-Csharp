using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {
    public Transform target;
    public Transform camera;
    public Transform initialPositionCamera;
    Vector3 cameraForward, move; 
    public static MoveCamera sharedInstance;
    float movementSmoothness = 2f;
    float rotationSmoothness = 1.5f;
    float vertical, horizontal;
    float minDistance = 0.09f;
   

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    private void Start()
    {
        sharedInstance = this;
       
    }
    


    private void LateUpdate()
    {
        if(this.transform.parent == null)
        {
            moveCamera(); 

        }if (Vector3.Distance(camera.transform.position, target.transform.position) < minDistance)
        {
            persecutePj();
        }
    }
   public void moveCamera()
    {
        if (GameManager.sharedInstance.menuCanvas.isActiveAndEnabled)
        {
            transform.position = initialPositionCamera.position;
        }
        else if (GameManager.sharedInstance.inGameCanvas.isActiveAndEnabled)
        {
            transform.position = Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime * movementSmoothness);
            transform.rotation = Quaternion.Slerp(transform.rotation, target.transform.rotation, Time.deltaTime * rotationSmoothness);
        }
    }
    
    void persecutePj()
    {
        this.transform.SetParent(target.transform);
        this.transform.position = target.transform.position;
    }
}

