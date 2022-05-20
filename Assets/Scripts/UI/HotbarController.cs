using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotbarController : MonoBehaviour
{
    [SerializeField] private List<GameObject> towers = new List<GameObject>();

    private KeyCode[] hotbarKeys =
        {KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6};
   
    private SpawnTower _spawnTower;

    // Start is called before the first frame update
    void Start()
    {
        setSlotSprites();
        _spawnTower = GameObject.Find("Player").GetComponent<SpawnTower>();
        _spawnTower.setTower(towers[0]);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < hotbarKeys.Length - 1; i++)
        {
            if (Input.GetKeyDown(hotbarKeys[i]) && i < towers.Count)
            {
                _spawnTower.setTower(towers[i]);
            }
        }
    }
    
    private void setSlotSprites()
    {
        int i = 0;
        foreach (Transform child in GameObject.Find("Hotbar").transform)
        {
            child.Find("ItemSprite").GetComponent<Image>().sprite = towers[i].transform.Find("WaffenlaufFeuer").GetComponent<SpriteRenderer>().sprite;
            i++;
        };
    }
}