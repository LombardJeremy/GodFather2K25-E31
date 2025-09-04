using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public GameObject optionMenu;
    private bool optionIsActive;

    private void Start()
    {
        optionIsActive = true;
        OptionOpenClose();
    }

    public void OptionOpenClose()
    {
        optionIsActive = !optionIsActive;
        optionMenu.SetActive(optionIsActive);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBGL
            Application.ExternalEval("window.close();");
#elif UNITY_STANDALONE
            Application.Quit();
#else
            Application.Quit();
#endif
    }
}
