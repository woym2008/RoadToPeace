using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerShipController : MonoBehaviour
{
    public Transform HugeLazerStartPoint;
    public Transform HugeLazerEndPoint;

    public float maxlength;

    private void Awake()
    {
        maxlength = Mathf.Abs(HugeLazerStartPoint.position.x - HugeLazerEndPoint.position.x);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
