using TMPro;
using UnityEngine;

public class TransitionTextDialogue : MonoBehaviour
{
    public TextMeshProUGUI dialogueLoading;

    public GameObject duck1;
    public GameObject duck2;
    public GameObject duck3;
    void Start()
    {
        dialogueLoading.text = GameManager.Instance.dialogueTransition[(int)GameManager.Instance.CurrentGame];
        switch (GameManager.Instance.numberOfLife)
        {
            case 3:
                break;
            case 2:
                duck3.SetActive(false);
                break;
            case 1:
                duck3.SetActive(false);
                duck2.SetActive(false);
                break;
            default:
                break;
        }
    }
}
