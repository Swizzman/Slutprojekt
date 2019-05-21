using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Characters : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Massa virtuella metoder som kan användas av sub-klasser
    protected virtual void Approach(GameObject target)
    {

    }

    protected virtual void Retreat(GameObject position)
    {

    }
    protected virtual void Shoot(GameObject target)
    {

    }
    public virtual void Hurt(int damage)
    {

    }
}
