using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Animator animator;
    int cameraState = 0;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessZoom();
        ProcessRotation();
        ProcessPosition();
    }

    private void ProcessRotation()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            cameraState++;
            if (cameraState == 4) cameraState = 0;
            animator.SetInteger("CameraPos", cameraState);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            cameraState--;
            if (cameraState == -1) cameraState = 3;
            animator.SetInteger("CameraPos", cameraState);
        }
    }

    private void ProcessZoom() => 
        transform.localScale += Vector3.one * Input.GetAxis("Zoom") * Time.deltaTime;

    private void ProcessPosition() =>
       transform.localScale = new Vector3(transform.localScale.x + Input.GetAxis("Left") * Time.deltaTime,
                                          transform.localScale.y + Input.GetAxis("Up") * Time.deltaTime,
                                          transform.localScale.z + Input.GetAxis("Right") * Time.deltaTime);

}
