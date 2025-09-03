using UnityEngine;
using UnityEngine.Rendering;

public class ImageMalusManager : MonoBehaviour
{

    [SerializeField] private GameObject parentOfGlasses;
    [SerializeField] private Transform[] arrayOfGlasses;

    [SerializeField] private Transform[] arrayOfSelectedSpot;
    void Start()
    {
        arrayOfGlasses = parentOfGlasses.GetComponentsInChildren<Transform>();
        GenerateGlassesParentPosition();
        for (int i = 0; i < arrayOfSelectedSpot.Length; i++)
        {
            arrayOfSelectedSpot[i].transform.position = arrayOfGlasses[i].transform.position;
        }
    }
    
    public void GenerateGlassesParentPosition()
    {
        for (int i = 0; i < arrayOfGlasses.Length; i++)
        {
            Transform tmp = arrayOfGlasses[i];
            int randomizeIdOfPos = Random.Range(0, arrayOfGlasses.Length);
            arrayOfGlasses[i] = arrayOfGlasses[randomizeIdOfPos];
            arrayOfGlasses[randomizeIdOfPos] = tmp;
        }
    }
}
