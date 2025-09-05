using TMPro;
using UnityEngine;

public class TransitionTextDialogue : MonoBehaviour
{
    public TextMeshProUGUI dialogueLoading;
    void Start()
    {
        dialogueLoading.text = GameManager.Instance.dialogueTransition[(int)GameManager.Instance.CurrentGame];
    }
}
