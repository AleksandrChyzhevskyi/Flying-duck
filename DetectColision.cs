using UnityEngine;

public class DetectColision : MonoBehaviour
{
    public GameObject explosion, panelLose;
    public Color deathCokor;
    private SpriteRenderer sr;
    private AudioSource audioLose;


    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        audioLose = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Knife"))
        {
            StartGame.isStart = false;
            Destroy(collision.transform.parent.gameObject);
            sr.color = deathCokor;

            ContactPoint2D contact = collision.contacts[0];
            Vector3 pos = contact.point;
            GameObject exp = Instantiate(explosion, pos, Quaternion.identity) as GameObject;
            Destroy(exp, 1f);
            audioLose.Play();

            panelLose.SetActive(true);
        }
    }
}
