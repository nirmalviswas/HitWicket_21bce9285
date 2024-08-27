using UnityEngine;
public class Pulpit : MonoBehaviour
{
    public float destroyTime = 5.0f;

    private float timer = 0.0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= destroyTime)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Doofus"))
        {
            // Update score
            GameManager.instance.UpdateScore();
        }
    }
}
