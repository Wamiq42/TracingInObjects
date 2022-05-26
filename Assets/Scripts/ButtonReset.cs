using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonReset : MonoBehaviour
{
    public void ResetScene()
    {
        SceneManager.LoadScene(0);

    }
    public void ClickedOnNumber(string name)
    {
        GameManager.instance.gotShapeName?.Invoke(name);
    }
}
