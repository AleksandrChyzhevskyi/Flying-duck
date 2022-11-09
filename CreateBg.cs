using UnityEngine;

public class CreateBg : MonoBehaviour
{
    public GameObject now_Bg, bg_inst;
    private GameObject new_Bg;

    private void Update()
    {
        if (StartGame.isStart)
        {
            if(now_Bg.transform.position.x <= -5f && new_Bg == null)
            {
                CreateNewBg();
            }
            else if (new_Bg != null && new_Bg.transform.position.x <= -5f)
            {
                CreateNewBg();
            }
        }
    }
    void CreateNewBg()
    {
        if (now_Bg.transform.position.x < -13f)
        {
            Destroy(now_Bg);
            now_Bg = new_Bg;
        }

        new_Bg = Instantiate(bg_inst, new Vector2(14f, 0f), Quaternion.identity) as GameObject;   
    }
}
