using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room : MonoBehaviour
{
    public bool isGhostRoom;
    public float temperature;
    public bool containsGhost;
    public Material material;
    public Text textObject;
    public Text EvidenceText;

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.name=="FPPlayer"){
            print("player is in " + gameObject.name);
            print(temperature);
            textObject.text = "Room Temperature: " + (Mathf.Ceil(temperature) + Random.Range(-3, 3));
            if (isGhostRoom) {
                int Chance = Random.Range(0,10);
                if (Chance <= 3) {
                    GiveEvidence();
                }  
            }
        }
        if(other.gameObject.name=="Ghost"){
            print("ghost is in " + gameObject.name);  
        }
    }
    private void OnTriggerExit(Collider other){
        if(other.gameObject.name=="FPPlayer"){
            print("player has left " + gameObject.name);
        }
        if(other.gameObject.name=="Ghost"){
            print("ghost has left " + gameObject.name);
        }
    }
    private void DecreaseTemperature () {
        if (GetComponent<Room>().temperature > -5)
        GetComponent<Room>().temperature /= 1.00058f;
    }
    private void RegainTemperature() {
        float difference = 19 - GetComponent<Room>().temperature;
        if(difference > 0) {
            GetComponent<Room>().temperature *= 1.0058f;
        }
    }
    private void OnTriggerStay (Collider col){
        if(col.gameObject.name=="Ghost"){
            DecreaseTemperature();
        } else {
            RegainTemperature();
        }
    }
    private void GiveEvidence() {
        if (GameObject.Find("Ghost").GetComponent<Ghost>().EMF) {
            EvidenceText.text = "Evidence: EMF";
        }
        if (GameObject.Find("Ghost").GetComponent<Ghost>().Orb) {
            EvidenceText.text = "Evidence: Ghost Orb";
        }
    }
    void Update() {
        if(GameObject.Find("Ghost").GetComponent<Ghost>().Hunt) {
            GiveEvidence();
        }
    }
}
