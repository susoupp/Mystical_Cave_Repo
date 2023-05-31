using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class PickUp : MonoBehaviour
{

    [Header("Pickup Settings")]
    [SerializeField] Transform holdArea;
    public GameObject heldObj;
    public bool isSmthHeld = true;
    public Rigidbody heldObjRB;
    private float throwAmount = 20.0f;


    [Header("Physics Parameters")]
    [SerializeField] private float pickupRange = 5.0f;
    [SerializeField] private float pickupForce = 150.0f;
    [SerializeField] private TextMeshProUGUI itemPickUpText;
   [SerializeField] private LayerMask itemMask;
   

    [Header("Keybinds")]
    public KeyCode resetKey = KeyCode.R;

    [Header("Fixes")]
    private float startScale;


   
    private void Start()
    {
        startScale = transform.localScale.y;
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(heldObj == null)
            {
                RaycastHit hit;
                if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange, itemMask))
                {
                    PickupObject(hit.transform.gameObject);
                    isSmthHeld = true;
                   
                        itemPickUpText.gameObject.SetActive(true);
                    
                    
                    
                  
                    
                }
            }
            
            else
            {
                DropObject();
                isSmthHeld = false;
                itemPickUpText.gameObject.SetActive(false);
             
            }
        }
        if(heldObj != null)
        {
            MoveObject();
            if (Input.GetMouseButtonDown(1))
            {
                ThrowObject();
                isSmthHeld = false;
               
            }
        }

        if (Input.GetKeyDown(resetKey))
        {
            heldObjRB.transform.localScale = Vector3.one;

        }
    }

    void MoveObject()
    {
        if(Vector3.Distance(heldObj.transform.position, holdArea.position) > 0.1f)
        {
            Vector3 moveDirection = (holdArea.position - heldObj.transform.position);
            heldObjRB.AddForce(moveDirection * pickupForce);
        }
    }


    void PickupObject(GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>())
        {
            heldObjRB = pickObj.GetComponent<Rigidbody>();
            heldObjRB.useGravity = false;
            heldObjRB.drag = 10;
            heldObjRB.constraints = RigidbodyConstraints.FreezeRotation;

            heldObjRB.transform.parent = holdArea;
            heldObj = pickObj;
        }
    }

    void DropObject()
    {
            heldObjRB.useGravity = true;
            heldObjRB.drag = 1;
            heldObjRB.constraints = RigidbodyConstraints.None;

            heldObj.transform.parent = null;
            heldObj = null;
    }

    void ThrowObject()
    {
        heldObjRB.useGravity = true;
        heldObjRB.drag = 1;
        heldObjRB.constraints = RigidbodyConstraints.None;
        heldObj.transform.parent = null;

        Vector3 throwDirection = (holdArea.forward);
        heldObjRB.velocity = (throwDirection * throwAmount);

        heldObj = null;
    }
}