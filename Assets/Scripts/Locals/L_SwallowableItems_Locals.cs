using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_SwallowableItems_Locals : MonoBehaviour
{

    public bool isSwallowed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isSwallowed)
        {
            Destroy(this.gameObject);
        }
    }
}
