using System.Collections.Generic;
using Player.Building;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI.Hud
{
    public class BuildingSelectUI : MonoBehaviour
    {
        [FormerlySerializedAs("_buildingSOList")] [SerializeField]
        private List<BuildingSO> buildingSoList;

        [FormerlySerializedAs("_spawnTower")] [SerializeField]
        private SpawnTower spawnTower;

        private Dictionary<int, Transform> _buildingElementDictionary;
        private int _lastButton;

        [SerializeField] private KeyCode[] hotBarKeys =
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
            var buildingElementTemplate = transform.Find("UIElement");
            buildingElementTemplate.gameObject.SetActive(false);

            _buildingElementDictionary = new Dictionary<int, Transform>();

            for (var index = 0; index < buildingSoList.Count && index < hotBarKeys.Length; index++)
            {
                var buildingElement = Instantiate(buildingElementTemplate, transform);
                buildingElement.gameObject.SetActive(true);

                buildingElement.GetComponent<RectTransform>().anchoredPosition +=
                    new Vector2(-(buildingSoList.Count * 3) + index * 6, 0);
                buildingElement.Find("Image").GetComponent<Image>().sprite = buildingSoList[index].sprite;
                buildingElement.Find("SlotNumber").GetComponent<Text>().text = (index + 1).ToString();

                _buildingElementDictionary[index] = buildingElement;
            }

            UpdateSelectedVisual();
        }

        private void Update()
        {
            for (var index = 0; index < buildingSoList.Count && index < hotBarKeys.Length; index++)
            {
                if (!Input.GetKeyDown(hotBarKeys[index])) continue;
                spawnTower.ObjToSpawn = buildingSoList[index];
                _lastButton = index;
                UpdateSelectedVisual();
            }
        }

        private void UpdateSelectedVisual()
        {
            foreach (var lastButton in _buildingElementDictionary.Keys)
            {
                _buildingElementDictionary[lastButton].Find("Selected").gameObject.SetActive(false);
            }

            _buildingElementDictionary[_lastButton].Find("Selected").gameObject.SetActive(true);
        }
    }
}
