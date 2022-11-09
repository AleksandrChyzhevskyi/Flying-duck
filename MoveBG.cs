using UnityEngine;

public class MoveBG : MonoBehaviour
{
    public float speed = 5f;        

    private void Update()
    {
        if (StartGame.isStart)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }
}
