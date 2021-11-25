using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    public List<Text> GameUI = new List<Text>();
    public List<Text> DeathUI = new List<Text>();
    private bool GameStarted = false;
    public GameObject Ghost;
    // Start is called before the first frame update
    void Start()
    {
        if (!GameStarted) {
            SwitchUI(0);
            GameStarted = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Ghost.GetComponent<Ghost>().Death) {
            SwitchUI(1);
            if (Input.GetKeyDown(KeyCode.R)) {
                SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex ) ;
            } 
        }
        
    }

    public void SwitchUI(int num) {
        // 0 is GameUI and 1 is DeathUI
        if (num == 0) {
            foreach (Text i in DeathUI) {
                i.enabled = false;
            }
            foreach (Text i in GameUI) {
                i.enabled = true;
            }
        } else {
            foreach (Text i in GameUI) {
                i.enabled = false;
            }
            foreach (Text i in DeathUI) {
                i.enabled = true;
            }
        }
    }
}
