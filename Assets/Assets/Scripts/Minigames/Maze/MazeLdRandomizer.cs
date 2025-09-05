using UnityEngine;

public class MazeLdRandomizer : MonoBehaviour
{

    public GameObject StartPos;
    public GameObject EndPos;
    
    public GameObject ld1;
    public GameObject spawner1;
    public GameObject end1;
    public GameObject ld2;
    public GameObject spawner2;
    public GameObject end2;

    void Start()
    {
        int id = Random.Range(0, 2);
        if (id == 0)
        {
            ld1.SetActive(true);
            ld2.SetActive(false);
            StartPos.transform.position = spawner1.transform.position;
            EndPos.transform.position = end1.transform.position;
        }
        else
        {
            ld1.SetActive(false);
            ld2.SetActive(true);
            StartPos.transform.position = spawner2.transform.position;
            EndPos.transform.position = end2.transform.position;
        }
    }

}
