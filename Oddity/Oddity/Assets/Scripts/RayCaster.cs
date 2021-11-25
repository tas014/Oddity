using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCaster : MonoBehaviour
{
    public LayerMask mask;
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;
        if (Input.GetMouseButtonDown(0)){
            
        }

        if (Physics.Raycast(ray, out hitInfo, 2, mask)) {
            if (hitInfo.collider.gameObject.name == "Ghost") {
                //print("Player is looking at the ghost");
            }
            if (hitInfo.collider.GetComponent<Switch>() != null) {
                print("player is looking at a lightswitch");
                
                if (Input.GetMouseButtonDown(0)){
                    hitInfo.collider.GetComponent<Switch>().power = !hitInfo.collider.GetComponent<Switch>().power;
                }
            }
            Debug.DrawLine (ray.origin, hitInfo.point, Color.red);
        } else {
            Debug.DrawLine (ray.origin, ray.origin + ray.direction * 2, Color.green);
        }
    }
}
