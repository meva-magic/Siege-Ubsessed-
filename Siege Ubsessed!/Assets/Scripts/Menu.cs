using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MenuController : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadSeige() => LoadScene("Seige");

    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Update()
    {
        if (Keyboard.current.mKey.wasPressedThisFrame) LoadSeige(); 
        if (Keyboard.current.rKey.wasPressedThisFrame) ReloadCurrentScene();
    }
}