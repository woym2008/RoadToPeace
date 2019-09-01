using UnityEngine;
using System.Collections;
using Entitas;

public class LifetimeObjectController : MonoBehaviour
{
    public float lifetime = 1;
    Contexts _contexts;

    UnityView _viewcontroller;
    // Use this for initialization
    void Start()
    {
        _contexts = Contexts.sharedInstance;

        _viewcontroller = this.gameObject.GetComponent<UnityView>();
    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        if(lifetime <=0)
        {
            if (_viewcontroller.Entity.hasObjectParent)
            {
                _viewcontroller.Entity.RemoveObjectParent();
                _viewcontroller.transform.parent = null;
            }
            _viewcontroller.Entity.isDestroyed = true;
        }

        if(_viewcontroller.Entity != null)
        {
            if(_viewcontroller.Entity.hasObjectParent)
            {
                //_viewcontroller.Entity.position.position = new Vector3(
                //_viewcontroller.Entity.objectParent.parent.position.position.x,
                //_viewcontroller.transform.position.y,
                //_viewcontroller.transform.position.z
                //    );
                if(_viewcontroller.transform != null)
                {
                    _viewcontroller.transform.position = new Vector3(
                    _viewcontroller.Entity.objectParent.parent.position.position.x,
                    _viewcontroller.transform.position.y,
                    _viewcontroller.transform.position.z
                        );
                }

            }
        }
    }
}
