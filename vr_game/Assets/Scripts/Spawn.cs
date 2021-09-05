using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    private int SpawningID = 0;
    private const int KSpawningMax = 100;
    private GameObject[] spawning_object;  //원하는 갯수 설정해서 넣기가능
    public GameObject[] PrefabsObject;
    public bool spawning;
    public float spawning_time;
    private Scene_Control scene_control;
    private Coroutine spawningRoutine;  //코루틴을 컨트롤 하기위한 선언

    private IEnumerator Start()                     //스폰 실행
    {
        yield return new WaitForSeconds(spawning_time);
        spawningRoutine = StartCoroutine(GenerateItem(spawning_time));
        /*yield return new WaitForSeconds(3f);
        StopCoroutine(spawningRoutine);               3초뒤 스폰 멈춤*/   
    }
    private void Update()     // 스페이스바로 누르면 멈추게하기
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StopCoroutine(spawningRoutine);
            spawning = false;
        }
    }
    private void Awake()
    {
        scene_control = GameObject.FindObjectOfType<Scene_Control>();
        spawning_object = new GameObject[KSpawningMax];
        for (int i = 0; i < spawning_object.Length; ++i)
        {
            spawning_object[i] = Instantiate(PrefabsObject[Random.Range(0, PrefabsObject.Length)], transform.position, transform.rotation) as GameObject;
            spawning_object[i].transform.parent = transform;

            spawning_object[i].name = "SpawnedObj_" + i;
            spawning_object[i].AddComponent<Rigidbody>();
            spawning_object[i].GetComponent<Rigidbody>().useGravity = true;
            spawning_object[i].AddComponent<BoxCollider>();
            spawning_object[i].AddComponent<HitItem>();
            spawning_object[i].layer = LayerMask.NameToLayer("HitItem");
            spawning_object[i].SetActive(false);
        }
    }
    IEnumerator GenerateItem(float sec)
    {
        spawning = true;
        int itemCount = spawning_object.Length;
        int generateCount = 0;
        while (spawning)
        {
            if (100 < generateCount++)
                break;
            /* if (100 < generateCount++)
                 break;
             var item = Instantiate(spawning_object[Random.Range(0, itemCount)], transform.position, transform.rotation) as GameObject;
             item.AddComponent<Rigidbody>();   //스폰된 오브젝트가 리지드바디를 갖음
             item.GetComponent<Rigidbody>().useGravity = true;  // 스폰된 옵젝트가 중력영향 받음
             item.AddComponent<BoxCollider>();  // 콜라이더 설정
             // Destroy(item, 3f);
             item.AddComponent<HitItem>(); // 히트아이템 스크립트를 갖음
             item.layer = LayerMask.NameToLayer("HitItem");*/
            var go = GetNextObject();
            go.SetActive(true);
            yield return new WaitForSeconds(sec);
        }
      /*  yield return new WaitForSeconds(1f); 신넘기기
        scene_control.SwitchToNext();*/
    }
    private GameObject GetNextObject()  
    {
        if(!spawning_object[SpawningID].activeSelf)
        {
            var go = spawning_object[SpawningID];

            SetNextID();
            return go;
        }
        else
        {
            SetNextID();
            return GetNextObject();  //재귀함수
        }
    }
    private void SetNextID()
    {
      
        if (spawning_object.Length - 1 < ++SpawningID)
            SpawningID = 0;
    }
         
    
}
