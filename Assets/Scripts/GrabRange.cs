using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabRange : MonoBehaviour
{
    public bool inrange = false;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Flashlight")
        {
            inrange = true;
        }
    }
}
