using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraShake : MonoBehaviour
{
    [SerializeField] GameObject camera;
    
    

    public void Shake()
    {
        camera.transform.DOShakePosition(2f,0.8f, 6);
    }
}

