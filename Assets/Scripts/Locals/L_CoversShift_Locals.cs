using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class L_CoversShift_Locals : MonoBehaviour
{

    public List<GameObject> cover_Shade_list;
    public GameObject cover_normal;
    public GameObject cover_shade;
    bool isUnderCover;

    private void Awake()
    {
        foreach (Transform child in cover_shade.transform)
        {
            cover_Shade_list.Add(child.gameObject);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.GetComponent<M_I_Movement_Manager>() != null)
        {
            foreach (GameObject cover in cover_Shade_list)
            {
                cover.SetActive(true);
            }
            cover_normal.SetActive(false);
            isUnderCover = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.GetComponent<M_I_Movement_Manager>() != null)
        {
            foreach (GameObject cover in cover_Shade_list)
            {
                cover.SetActive(false);
            }
            cover_normal.SetActive(true);
            isUnderCover = false;
        }
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
