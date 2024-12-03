using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class L_CoversShift_Locals : MonoBehaviour
{

    public List<GameObject> cover_Shade_list;
    public List<GameObject> cover_Normal_list;
    bool isUnderCover;

    private void Awake()
    {
        GameObject[] cover_Normal_array = GameObject.FindGameObjectsWithTag("Scene");
        Debug.Log(cover_Normal_array.Length);
        foreach(GameObject sceneObject in cover_Normal_array)
        {
            if (!cover_Shade_list.Contains(sceneObject))
            {
                cover_Normal_list.Add(sceneObject);
            }
            
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

            foreach (GameObject cover in cover_Normal_list)
            {
                cover.SetActive(false);
            }
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

            foreach (GameObject cover in cover_Normal_list)
            {
                cover.SetActive(true);
            }
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
