using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSpawner : MonoBehaviour
{
    public Mouse_Cam mcam;
    private int SceneCheck = 0;
    private bool sceneset1 = false;
    private bool sceneset2 = false;
    private bool sceneset3 = false;

    [SerializeField] GameObject Set1;
    [SerializeField] GameObject Set2;
    [SerializeField] GameObject Set3;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mcam.curlight == 1)
        {
            Set1.SetActive(true);
        }

        if (mcam.curlight == 2)
        {
            Set2.SetActive(true);
        }
    }

}
