using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HugeLazerController : MonoBehaviour
{
    public Transform Up;
    public Transform Middle;
    public Transform Down;

    public Transform EndPoint;
    public float maxlength;
    private void Awake()
    {
        maxlength = Mathf.Abs(this.transform.position.x - EndPoint.transform.position.x);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUpLazerLength(float t)
    {
        Up.localScale = new Vector3(Mathf.Lerp(0, maxlength,t), Up.localScale.y, Up.localScale.z);
    }

    public void SetMiddleLazerLength(float t)
    {
        Middle.localScale = new Vector3(Mathf.Lerp(0, maxlength, t), Middle.localScale.y, Middle.localScale.z);
    }

    public void SetDownLazerLength(float t)
    {
        Down.localScale = new Vector3(Mathf.Lerp(0, maxlength, t), Down.localScale.y, Down.localScale.z);
    }
}
