using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public List<Camera> cameras = new List<Camera>();
    private bool GameStarted = false;
    public GameObject Ghost;
    
    public void SwitchCam (int cam) {
        cameras[cam].enabled=true;
        if (cam == 0) {
            cameras[1].enabled = false; 
        } else {
            cameras[0].enabled = false;
        }
    }

    void Start() {
        if (!GameStarted) {
            SwitchCam (1);
            GameStarted = true;
        }
    }

    void Update() {
        if (Ghost.GetComponent<Ghost>().Death) {
            SwitchCam(0);
        } else {
            SwitchCam(1);
        }
    }
}
