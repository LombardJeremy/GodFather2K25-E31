using TMPro;
using UnityEngine;

public class ScoreFinalScript : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Time remained alive: : " + Mathf.FloorToInt(GameManager.Instance.GlobalGameTimer).ToString();
    }
}
