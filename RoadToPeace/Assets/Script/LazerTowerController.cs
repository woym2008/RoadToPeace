using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerTowerController : MonoBehaviour
{
    public Transform Lazer;
    public float length = 1;
    public float firetime = 0.5f;
    bool _isfire = false;
    float t = 0;
    // Start is called before the first frame update
    void Start()
    {
        _isfire = true;
        t = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(_isfire)
        {
            t += Time.deltaTime;
            if(t>=firetime)
            {
                t = firetime;
                _isfire = false;
            }
            var l = Mathf.Lerp(0, length, t/firetime);

            Lazer.localScale = new Vector3(1,1, l);
        }
    }
}
