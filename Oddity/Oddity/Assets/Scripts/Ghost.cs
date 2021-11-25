using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    private Material GhostRoomMaterial;
    private float GhostRoom;
    private bool RoomIsChosen = false;
    private float RoomAmount = 10f;
    private GameObject GhostRoomObject;
    public Transform target;
    public GameObject SanityTarget;
    public LayerMask mask;
    public float speed = 12f;
    Rigidbody rig;
    public bool EMF = false;
    public bool Orb = false;
    public bool Hunt = false;
    public bool Death = false;

    // Start is called before the first frame update
    void Start()
    {
        if (!RoomIsChosen){
            GhostRoom = Mathf.Ceil(Random.Range(0f, RoomAmount));
            GhostRoomObject= GameObject.Find("Room"+GhostRoom);
            GhostRoomObject.GetComponent<Room>().isGhostRoom = true;
            transform.position = GhostRoomObject.transform.position;
            int evidenceType = Random.Range(0, 2);
            if(evidenceType == 1) {
                EMF = true;
            } else {
                Orb = true;
            }
            RoomIsChosen = true;
        }
        rig = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other){
        InteractiveObject io = other.gameObject.GetComponent<InteractiveObject>();
        if(io != null){
            io.OnSomethingEnter(gameObject);
        }
    }

    void OnCollisionEnter(Collision col) {
        if(col.gameObject.name == "FPPlayer" & Hunt){
            Death = true;
        }
    }

    // Update is called once per frame
    void Update()
    {   //Raycasting
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;
        float Sanity = SanityTarget.GetComponent<Sanity>().SanityLevel;

        if (Physics.Raycast(ray, out hitInfo, 100, mask)) {
            if (hitInfo.collider.gameObject.name == "FPPlayer") {
                if(GetComponent<Renderer>().enabled) {    
                    print("ghost is visible");
                    Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                    rig.MovePosition(pos);
                }              
            }
            Debug.DrawLine (ray.origin, hitInfo.point, Color.red);
            } else {
                Debug.DrawLine (ray.origin, ray.origin + ray.direction * 100, Color.green);
            }
            transform.LookAt(target);
            if(Sanity >= 50) {
                SanityTarget.GetComponent<Sanity>().SanityLevel /= 1.00008f;
            } else {
                GetComponent<Renderer>().enabled = true;
                GetComponent<Collider>().enabled = true;
                Hunt = true;
            }
    }
}

