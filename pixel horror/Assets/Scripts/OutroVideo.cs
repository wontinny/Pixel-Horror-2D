using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutroVideo : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Mary;
    void Start()
    {
        this.Mary = GameObject.FindWithTag("Mary");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Mary == null)
        {
            print("Mary deleted");
            SceneManager.LoadScene(11, LoadSceneMode.Single);
        }
    }
}
