using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [Header("Space between menu items")]
    [SerializeField] Vector2 spacing;

    Button mainButton;
    SettingsMenuItem[] menuItems;
    bool isExpanded = false;

    Vector2 mainButtonPos;
    int itemsCount;

    // Start is called before the first frame update
    void Start()
    {
        itemsCount = transform.childCount - 1;
        menuItems = new SettingsMenuItem[itemsCount];
        // Fills in the items in the settings menu
        for (int i = 0; i < itemsCount; ++i)
        {
            menuItems[i] = transform.GetChild(i + 1).GetComponent<SettingsMenuItem>();
        }

        // Makes the main button always at the top layer so no overlap
        mainButton = transform.GetChild(0).GetComponent<Button>();
        mainButton.onClick.AddListener(ToggleMenu);
        mainButton.transform.SetAsLastSibling();

        mainButtonPos = mainButton.transform.position;

        // Reset all menu items positions to mainButtonPos
        ResetPositions();
    }

    void ResetPositions()
    {
        for (int i = 0; i < itemsCount; ++i)
        {
            menuItems[i].trans.position = mainButtonPos;
        }
    }
    void ToggleMenu()
    {
        isExpanded = !isExpanded;

        if (isExpanded)
        {
            for (int i = 0; i < itemsCount; ++i)
            {
                menuItems[i].trans.position = mainButtonPos + spacing * (i + 1); // +1 to avoid *0 
            }
        }
        else
        {
            for (int i = 0; i < itemsCount; ++i)
            {
                menuItems[i].trans.position = mainButtonPos;
            }
        }
    }

    private void OnDestroy()
    {
        mainButton.onClick.RemoveListener(ToggleMenu);
    }
}
