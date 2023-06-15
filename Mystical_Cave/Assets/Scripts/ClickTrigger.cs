using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ClickTrigger : MonoBehaviour
{
    public IntValue ClickCount;
    
   
    public void Awake()
    {
     
    }

    private void OnMouseDown()
    {
        Hit();
      
    }
    private void Hit()
    {
        ClickCount.value += 1;
        Debug.Log("pain");
    }


}