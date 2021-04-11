using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    Coroutine switchLevel;
    public void LevelSelector(int lvlNum)
    {
        SceneManager.LoadScene(lvlNum);
        switchLevel = StartCoroutine(SwitchLevel(lvlNum)); 
    }

    public IEnumerator SwitchLevel(int lvlNum)
    {
        AudioManager.Instance.PlaySound(SoundType.ActivateButton);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(lvlNum);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
		 Application.Quit();
#endif
    }
}
