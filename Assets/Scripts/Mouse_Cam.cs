using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Mouse_Cam : MonoBehaviour
{
    Vector2 mouseLook;
    Vector2 smoothV;
    public float sensativity = 5.0f;
    public float smoothing = 2.0f;
    [SerializeField] Camera mCam;
    GameObject character;
    public float curx;
    private bool canpick = false;
    private bool redpick = false;
    private bool SeeItem = false;
    [SerializeField] GameObject Pickups;
    [SerializeField] GameObject RedPickups;
    [SerializeField] Text UIText;
    [SerializeField] GameObject TrueFlashlight;
    [SerializeField] GameObject RedFlashlight;
    private string pickupitem;
    public bool TutOver = false;
    public GrabRange pickupgrab;
    private bool Lightset = false;
    public bool redlight = false;
    public int flashcount = 0;
    private bool flashswitch;
    public int curlight = 0;
    public int maxlight;

    void Start()
    {
        character = this.transform.parent.gameObject;
    }

    void Update()
    {
        flashlightequip();
        curx = mCam.transform.rotation.x;
        GenText();
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        md = Vector2.Scale(md, new Vector2(sensativity * smoothing, sensativity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing); mouseLook += smoothV;

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
        pickup();
        pickupUI();
    }

    void flashlightequip()
    {
        maxlight = flashcount;
        if (Input.GetButtonUp("Fire2"))
        {
            curlight++;
        }

        if (curlight == 1)
        {
            TrueFlashlight.SetActive(true);
            RedFlashlight.SetActive(false);
        }

        if (curlight == 2)
        {
            TrueFlashlight.SetActive(false);
            RedFlashlight.SetActive(true);
        }

        if (curlight > maxlight)
        {
            curlight = 1;
        }
    }

    void pickup()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {

            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);

            if (hit.collider.tag == "Pickup")
            {
               canpick = true;
               pickupitem = hit.collider.name;
            }

            else
            {
                canpick = false;
            }
        }
    }

    void pickupUI()
    {
        if (canpick == true)
        {
            if (Input.GetButtonDown("Fire1"))
            {

                if (pickupitem == "Flashlight")
                {
                Destroy(Pickups);
                TrueFlashlight.SetActive(true);
                TutOver = true;
                Lightset = true;
                    flashcount++;
                    curlight = 1;
                }

                if (pickupitem == "Red Flashlight")
                {
                    Destroy(RedPickups);
                    RedFlashlight.SetActive(true);
                    redlight = true;
                    flashcount++;
                    curlight = 2;
                }
                
            }
        }

        if (redpick == true)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Destroy(RedPickups);
                RedFlashlight.SetActive(true);
                redlight = true;
                
            }
        }
    }

    void GenText()
    {
        if (SeeItem == false)
        {
            UIText.text = "Controls:\nWASD : Move\nE : Interact";
        }

        if (canpick == true)
        {
            UIText.text = "Press E to pick up the " + pickupitem;
        }

        if (Lightset == true && canpick == false)
        {
            UIText.text = "The green light reveals written text.";
        }

        if (flashcount == 2 && flashswitch == false)
        {
            UIText.text = "Press \"Q\" to switch equipped flaslights";

            if (Input.GetButtonDown("Fire2"))
            {
                flashswitch = true;
            }
        }
    }

}
