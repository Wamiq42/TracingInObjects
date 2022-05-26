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
    public void ClickedOnShapeButton(string name)
    {
        EventManager.instance.gotShapeName?.Invoke(name);
    }
    public void ClickedOnNumberButton(int number)
    {
        EventManager.instance.getNumber?.Invoke(number);
    }
}
