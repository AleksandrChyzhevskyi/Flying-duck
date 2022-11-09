using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 targetPos;
    public GameObject player;
    public float speed = 5f;

    private void Update()
    { if (StartGame.isStart)
      {
        #if UNITY_ANDROID

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Moved)
                {
                    targetPos = Camera.main.ScreenToWorldPoint(touch.position);
                    Debug.Log(targetPos);
                }
            }
        #endif

        #if UNITY_EDITOR
            if (Input.GetMouseButton(0))
            {
                targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);                  
            }
        #endif
            float step = speed * Time.deltaTime;

            if(targetPos.y < -4f)            
                targetPos.y = -4f;
            
            if (targetPos.y > 0f)            
                targetPos.y = 0f;
            
            if (targetPos.x > 2.16f)            
                targetPos.x = 2.16f;
            
            if (targetPos.x < -2.44f)            
                targetPos.x = -2.44f;
            

            player.transform.position = Vector3.MoveTowards(
                player.transform.position,
                new Vector3 (targetPos.x, targetPos.y, player.transform.position.z),
                step
                );
      }
    }
}
