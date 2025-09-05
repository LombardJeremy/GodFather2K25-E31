using MoreMountains.Feedbacks;
using Unity.VisualScripting;
using UnityEngine;

public class JuiceTrigger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private int nbOrange;
    public GameObject Jus1;
    public GameObject Jus2;
    public GameObject Jus3;

    private void Start()
    {
        nbOrange = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Orange")
        {
            nbOrange += 1;
            Destroy(collision.gameObject);
        }

        if (nbOrange == 1)
        {
            Jus1.SetActive(true);
        }

        if (nbOrange == 2)
        {
            Jus2.SetActive(true);
        }

        if (nbOrange == 3)
        {
            Jus3.SetActive(true);
            GameManager.Instance.UpdateGameState(GameState.Win);
        }

    }
}
