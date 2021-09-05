using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ending_Ui : MonoBehaviour
{
    private Text Point_text;


    // Start is called before the first frame update
    void Start()
    {
        Point_text = GetComponentInChildren<Text>();
        Point_text.text= "" + PlayerPrefs.GetInt("player point");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
