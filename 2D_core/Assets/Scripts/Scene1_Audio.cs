using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_Audio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Epic Drums");
    }

    
    // Update is called once per frame
    void Update()
    { 
      
    }
}
