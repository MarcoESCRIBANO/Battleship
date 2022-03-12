using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public void changeScene(string SceneToLoad)
    {
        SceneManager.LoadScene(SceneToLoad);
    }

    public void QuitGame()  
    {
        Application.Quit();
    }

    public void RotationBateauxUI()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();

        rectTransform.eulerAngles += new Vector3(0, 0, 90);
    }
}
