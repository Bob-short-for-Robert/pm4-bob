using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class BuildingSelectUI : MonoBehaviour
{
    [SerializeField] private List<BuildingSO> _buildingSOList;
    [SerializeField] private SpawnTower _spawnTower;
    
    private Dictionary<int, Transform> _buildingElementDictionary;
    private int lastButton = 0;

    private KeyCode[] hotbarKeys = new KeyCode[]
    {
        KeyCode.Alpha1,
        KeyCode.Alpha2,
        KeyCode.Alpha3,
        KeyCode.Alpha4,
        KeyCode.Alpha5,
        KeyCode.Alpha6,
    };

    private void Awake()
    {
        Transform buildingElementTemplate = transform.Find("UIElement");
        buildingElementTemplate.gameObject.SetActive(false);

        _buildingElementDictionary = new Dictionary<int, Transform>();

        for (int index = 0; index < _buildingSOList.Count && index < hotbarKeys.Length; index++)
        {
            Transform buildingElement = Instantiate(buildingElementTemplate, transform);
            buildingElement.gameObject.SetActive(true);

            buildingElement.GetComponent<RectTransform>().anchoredPosition += new Vector2(-(_buildingSOList.Count * 3) + index * 6, 0);
            buildingElement.Find("Image").GetComponent<Image>().sprite = _buildingSOList[index].sprite;
            buildingElement.Find("SlotNumber").GetComponent<Text>().text = (index + 1).ToString();

            _buildingElementDictionary[index] = buildingElement;
        }
        
        UpdateSelectedVisual();
    }

    private void Update()
    {
        for (int index = 0; index < _buildingSOList.Count && index < hotbarKeys.Length; index++)
        {
            if (Input.GetKeyDown(hotbarKeys[index]))
            {
                _spawnTower.SetObjToSpawn(_buildingSOList[index]);
                lastButton = index;
                UpdateSelectedVisual();
            }
        }
    }
    
    private void UpdateSelectedVisual()
    {
        foreach (int lastButton in _buildingElementDictionary.Keys)
        {
            _buildingElementDictionary[lastButton].Find("Selected").gameObject.SetActive(false);
        }

        _buildingElementDictionary[lastButton].Find("Selected").gameObject.SetActive(true);
    }
}
