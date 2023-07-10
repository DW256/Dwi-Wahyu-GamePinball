using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractButton : MonoBehaviour
{
    public void retryStage()
    {
        SceneManager.LoadScene("pinball");
    }
}
