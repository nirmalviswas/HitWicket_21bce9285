using UnityEngine;

public class Doofus : MonoBehaviour
{
    public float speed = 3.0f;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
        transform.Translate(Vector3.forward*Time.deltaTime * verticalInput);
        transform.Translate(-Vector3.forward*Time.deltaTime * horizontalInput);

        rb.AddForce(movement * speed);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pulpit"))
        {
            // Update score
            GameManager.instance.UpdateScore();
        }
    }
}
