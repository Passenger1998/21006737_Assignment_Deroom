using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_GamePlay_Manager : MonoBehaviour
{
    M_Scene_Manager scene_Manager;
    [SerializeField] int itemCollect_count = 0;

    private void Awake()
    {
        scene_Manager = scene_Manager = FindObjectOfType<M_Scene_Manager>().gameObject.GetComponent<M_Scene_Manager>();
    }

    private void OnTriggerEnter(Collider col)
    {
        L_SwallowableItems_Locals SwallowableItems_Locals = col.gameObject.GetComponent<L_SwallowableItems_Locals>();
        if (SwallowableItems_Locals != null)
        {
            SwallowableItems_Locals.isSwallowed = true;

            ItemCollect_Add();
        }
    }

    void ItemCollect_Add()
    {
        itemCollect_count += 1;
    }

    public int ItemCollect_Count_Get()
    {
        return itemCollect_count;
    }

    public void Scene_Manager_Update()
    {

    }
}
