using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class RayCast : MonoBehaviour
{
    public GameObject head;
    public GameObject pos1;
    public GameObject pos2;
    public GameObject pos3;
    public GameObject pos4;
    public GameObject pos5;
    public Text check_text;
    Scene_Control scene_control;
    public Text object_name;
    public GameObject cast_point;
    public Image loading_bar;
    private float loading_count = 0f;
    private float success_point = 0f;
    public Text score_board;
    public Slider time_attack;
   private float time_go = 4000f;



  /*  private void Awake()
    {
        scene_control = GameObject.FindObjectOfType<Scene_Control>();
    }*/

    void Update()
    {
        time_go = time_go - 1f;
        time_attack.value = time_go/4000f;
        switch (success_point)
        {
            case 0:
                score_board.text = "Find 0/3";
                break;
            case 1:
                score_board.text = "Find 1/3";
                break;
            case 2:
                score_board.text = "Find 2/3";
                break;
               case 3:
                score_board.text = "Find 3/3";
                finish();
                break;
        }
    
        loading_bar.fillAmount = loading_count;
        
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 20;
        Debug.DrawRay(transform.position, forward, Color.green);
        if (Physics.Raycast(transform.position, forward, out hit))
        {
            switch (hit.collider.tag.ToLower())
            {

                case "moveitem1":         
                    StartCoroutine(MoveToTarget(pos1));
                    break;

                case "moveitem2":
                    StartCoroutine(MoveToTarget(pos2));
                    break;

                case "moveitem3":
                    StartCoroutine(MoveToTarget(pos3));
                    break;

                case "moveitem4":
                    StartCoroutine(MoveToTarget(pos4));
                    break;

                case "moveitem5":
                    StartCoroutine(MoveToTarget(pos5));
                    break;
                case "gameitem":
                   
                        cast_point.SetActive(false);
                        object_name.text = hit.collider.name;
                        loading_count = loading_count + Time.deltaTime / 3;
                        check_text.text = "Check..";
                    
                  if(loading_count > 1)
                    {
                        check_text.text = "No!!";
                    }
                    break;

                case "untagged":
                    cast_point.SetActive(true);
                    object_name.text = "";
                    loading_count = 0f;
                    check_text.text = "";
                    break;

                case "answer":
                    
                       cast_point.SetActive(false);
                        object_name.text = hit.collider.name;
                        loading_count = loading_count + Time.deltaTime / 3;
                        check_text.text = "Check..";
                   
                     if (loading_count > 1)
                    {
                        check_text.text = "good!";
                        answer_event();
                       hit.collider.gameObject.SetActive(false);

                    }
                    break;
              /*  case "start":
                    hit.transform.GetComponent<Button>().onClick.Invoke();
                    break;
                case "exit":
                    hit.transform.GetComponent<Button>().onClick.Invoke();
                    break;*/
                    
                    // Debug.Log("hit" + hit.collider.name);

                    // Destroy(hit.collider.gameObject);
                    /* var hitItem = hit.collider.GetComponent<HitItem>();
                     hitItem.SetInactive();*/

                    /* int hitpoint = 10 + int.Parse(hitpoint_text.text);
                     hitpoint_text.text = "" + (hitpoint);
                     if (hitpoint > 150)
                     {
                         PlayerPrefs.SetInt("player point", hitpoint);
                         scene_control.SwitchToNext();
                     }*/

            }

            //if (hit.collider.name.ToLower() == "refrigerator") 태그가 아닌 이름으로 찾을때.   tolower은 자동 소문자로 해주는 역활
            /* if (hit.collider.tag.ToLower() == "moveitem")
             {
                 //  Destroy(hit.collider.gameObject);  해당이름의 오브젝트 파괴
                 //StartCoroutine(DestroyObjectAfter(hit, 1f)); 1초 후 파괴
                 switch (hit.collider.name.ToLower())
                 {
                     case "refrigerator":
                         StartCoroutine(MoveToTarget(pos1));
                         break;

                     case "table":
                         StartCoroutine(MoveToTarget(pos2));
                         break;
                     case "tv":
                         StartCoroutine(MoveToTarget(pos3));
                         break;
                 }*/

        }
    }


    /* IEnumerator DestroyObjectAfter(RaycastHit hit, float sec)   1초후 파괴 함수
     {
         yield return new WaitForSeconds(sec);
         Destroy(hit.collider.gameObject);
     }*/
     public void finish()
    {
        SceneManager.LoadScene("Ending");
        PlayerPrefs.SetFloat("player_score", time_go);
    }
   /* public void game_start()
    {

    }
    public void game_exit()
    {
        Application.Quit();
    }*/
    private void answer_event()
    {
      switch (success_point)
        {
            case 0:
                success_point = 1;
                break;
            case 1:
                success_point = 2;
                break;
            case 2:
                success_point = 3;
                break;
        }
    }
   
    IEnumerator MoveToTarget(GameObject pos) //head가 pos로 이동하는 함수 
    {
        while (head.transform.position != pos.transform.position)
        {
            
           head.transform.position = Vector3.MoveTowards(head.transform.position, pos.transform.position, Time.deltaTime * 0.5f);
            yield return null;
        }

    }

  
}
   /* IEnumerator MoveToTarget(GameObject pos) //head가 pos로 이동하는 함수 
    {
        while (head.transform.position != pos.transform.position)
        {
            head.transform.position = Vector3.MoveTowards(head.transform.position, pos.transform.position, Time.deltaTime * 0.5f);
            yield return null;
        }*/
        
    

