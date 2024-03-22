using UnityEngine;
using UnityEngine.UI;

// Original Author: Andy Wang
// Upon click, show a popup containing text
public class ShowPopupOnClick : MonoBehaviour
{
    [SerializeField] string title;
    [SerializeField] string description;
    [SerializeField] string closeText;

    void Start() {
        // If on an object with a button component, assign it automatically
        Button btn = GetComponent<Button>();

        if (btn) {
            btn.onClick.AddListener(() => {
                PopupManager.QueuePopup(title, description, closeText, true);
            });
        }
    }
}