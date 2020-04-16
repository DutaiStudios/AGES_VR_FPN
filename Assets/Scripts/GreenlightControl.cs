using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenlightControl : MonoBehaviour
{
    [SerializeField] GameObject SignText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Greenlight")
        {
            SignText.SetActive(true);
        }

        else if (other.tag != "Greenlight")
        {
            SignText.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Greenlight")
        {
            SignText.SetActive(false);
        }
    }


}
