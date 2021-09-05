using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      
        Destroy(gameObject, 4f);
    }

   public void SetInactive()
    {
        gameObject.SetActive(false);
    }
    private IEnumerator InactivatingAfter(float sec)
    {
        yield return new WaitForSeconds(sec);
        gameObject.SetActive(false);
    }
}
