using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedlightControl : MonoBehaviour
{
    [SerializeField] GameObject trueself;
    private bool cansee = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Redlight")
        {
            cansee = true;
        }

        if (cansee == true)
        {
            trueself.SetActive(true);
        }

        else if (other.tag != "Redlight")
        {
            trueself.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Redlight")
        {
            trueself.SetActive(false);
        }
    }

}
