using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;

    private Camera mainCamera;
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        mainCamera = Camera.main;
    }

    void Update()
    {
        Movement();
        KeepPlayerOnScreen();
    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void KeepPlayerOnScreen()
    {

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 3.8f), 0);

        if (transform.position.x > 11.3f)
        {
            transform.position = new Vector3(-11.3f, transform.position.y, 0);
        }
        else if (transform.position.x < -11.3f)
        {
            transform.position = new Vector3(11.3f, transform.position.y, 0);
        }

    }
}
