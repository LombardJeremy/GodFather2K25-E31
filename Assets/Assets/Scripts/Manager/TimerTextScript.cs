using TMPro;
using UnityEngine;

public class TimerTextScript : MonoBehaviour
{
    public TextMeshProUGUI TimerText;

    // Update is called once per frame
    void Update()
    {
        float tmp = GameManager.Instance.minigameTimers[(int)GameManager.Instance.CurrentGame] - GameManager.Instance.CurrentGameTimer;
        tmp = Mathf.FloorToInt(tmp);
        TimerText.text = tmp.ToString();
    }
}
