using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_CollectableItems_Locals : MonoBehaviour
{

    [SerializeField] bool isCollected;
    [SerializeField] bool isCollectable;
    [SerializeField] Transform player_trans;
    Rigidbody rb;

    public void isCollected_Set(bool i)
    {
        isCollected = i;
    }

    public void isCollectable_Set(bool i)
    {
        isCollectable = i;
    }

    public void player_trans_Set(Transform i)
    {
        player_trans = i;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isCollected)
        {
            this.gameObject.SetActive(false);
        }

        if (isCollectable && player_trans != null)
        {
            rb.AddForce((player_trans.position - this.transform.position)*5);
            if (this.gameObject.transform.localScale.x >= 0.01)
            {
                this.gameObject.transform.localScale -= Vector3.one * 0.5f * Time.deltaTime;
            }
            
        }

    }
}