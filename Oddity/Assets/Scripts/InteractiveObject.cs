using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public virtual void OnSomethingEnter(GameObject go){
        print(go.name);
    }
}
