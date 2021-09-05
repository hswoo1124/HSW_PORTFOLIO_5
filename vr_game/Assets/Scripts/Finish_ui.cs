using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Finish_ui : MonoBehaviour
{
    public Text score_board;
    public float score_load;
    // Start is called before the first frame update
    void Start()
    {
        score_board.text = PlayerPrefs.GetFloat("player_score", score_load) + "";
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.GetFloat("player_score", score_load);
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 100;
        Debug.DrawRay(transform.position, forward, Color.green);
        if (Physics.Raycast(transform.position, forward, out hit))
        {
            switch (hit.collider.tag.ToLower())
            {

                case "ui":
                    hit.transform.GetComponent<Button>().onClick.Invoke();
                    break;
            }
        }
    }

    public void game_start()
    {
        SceneManager.LoadScene("new");
    }
    public void game_quit()
    {
        Application.Quit();
    }
}
