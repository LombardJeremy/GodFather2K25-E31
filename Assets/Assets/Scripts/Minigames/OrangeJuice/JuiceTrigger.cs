using UnityEngine;

public class JuiceTrigger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private int nbOrange;

    private void Start()
    {
        nbOrange = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Wow");

        if (collision.tag == "Orange")
        {
            nbOrange += 1;
            Debug.Log("HAHAHAHAHHAHA");
            Debug.Log(nbOrange);
        }

        if (nbOrange == 3)
        {
            Debug.Log("WIN");
            GameManager.Instance.UpdateGameState(GameState.Win);
            Debug.Log("Jtbz");
        }

    }
}
