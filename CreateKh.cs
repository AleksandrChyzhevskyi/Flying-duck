using UnityEngine;
using System.Collections;

public class CreateKh : MonoBehaviour
{
    public float waitTime = 1f;
    public GameObject kh;
    private bool isSpawn;
    private Coroutine spawn;

    private void Update()
    {
        if (StartGame.isStart && !isSpawn)
        {
            spawn = StartCoroutine(spawnKh());
            isSpawn = true;
        }
    }
    IEnumerator spawnKh()
    {
        while(true)
        {
            if (StartGame.isStart)
            {
                Instantiate(kh, new Vector2(8.9f, Random.Range(-4f, 0f)), Quaternion.Euler(new Vector3(0, 0, -45f)));                
            }
            else
            {
                StopCoroutine(spawn); 
            }
            yield return new WaitForSeconds(waitTime);
        }
    }

}
