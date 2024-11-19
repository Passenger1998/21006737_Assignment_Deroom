using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_GamePlay_Manager : MonoBehaviour
{
    M_Scene_Manager SceneManager;
    [SerializeField] int itemCollect_count = 0;

    private void Awake()
    {
        SceneManager = FindObjectOfType<M_Scene_Manager>().gameObject.GetComponent<M_Scene_Manager>();
    }

    private void OnTriggerEnter(Collider col)
    {
        L_CollectableItems_Locals SwallowableItems_Locals = col.gameObject.GetComponent<L_CollectableItems_Locals>();
        if (SwallowableItems_Locals != null)
        {
            SwallowableItems_Locals.isCollected_Set(true);

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
    public struct ItemCollect_Detect_Data
    {
        public List<L_CollectableItems_Locals> collectableItems_Locals_list;
    }


    void ItemCollect_Detect(ItemCollect_Detect_Data data)
    {
        List<L_CollectableItems_Locals> collectableItems_Locals_list = data.collectableItems_Locals_list;
        if (collectableItems_Locals_list.Count > 0)
        {
            foreach (L_CollectableItems_Locals collectableItems_Locals in collectableItems_Locals_list)
            {
                if (Vector3.Distance(collectableItems_Locals.gameObject.transform.position, this.transform.position) <= S_Game_Centre.GameCentre._ScriptableObjects.movementControls._MovementDetects.collectDetectDist)
                {
                    collectableItems_Locals.isCollectable_Set(true);
                    collectableItems_Locals.player_trans_Set(SceneManager._References._Players.player.transform);
                }
            }
        }
    }

    public struct Scene_Manager_Update_Data
    {
        public ItemCollect_Detect_Data itemCollect_Detect_Data;
    }

    public void GamePlayManager_Update(Scene_Manager_Update_Data data)
    {
        ItemCollect_Detect_Data itemCollect_Detect_Data = data.itemCollect_Detect_Data;
        ItemCollect_Detect(itemCollect_Detect_Data);
    }
}
