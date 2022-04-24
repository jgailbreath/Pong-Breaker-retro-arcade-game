using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Audio_player_impact : MonoBehaviour
{
    public void Start()
    {
        GetComponent<AudioSource>().Play();
    }
}
