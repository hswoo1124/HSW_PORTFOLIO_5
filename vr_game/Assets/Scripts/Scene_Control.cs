using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Control : MonoBehaviour
{
    public string nextscenename;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SwitchToNext();
        }
    }
    public void SwitchToNext()
    {
        if (string.IsNullOrEmpty(nextscenename))
            throw new System.Exception("nextscenename is null");
        SceneManager.LoadScene(nextscenename, LoadSceneMode.Single);
    }
   
}
