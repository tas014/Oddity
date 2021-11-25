using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{
    public GameObject assignedSwitch;
    

    // Update is called once per frame
    void Update()
    {
        GetComponent<Light>().enabled = assignedSwitch.GetComponent<Switch>().power;
       /*if(assignedSwitch.power){
            GetComponent<Light>().enabled=true;
            isOn=true;
        } else {
            GetComponent<Light>().enabled=false;
            isOn=false;
        }*/
    }
}
