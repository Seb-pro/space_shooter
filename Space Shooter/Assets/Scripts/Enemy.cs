using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _enemySpeed;
    [SerializeField] private float _rightXPosition;
    [SerializeField] private float _leftXPosition;

    private float _randomXPositon;

    void Start()
    {

    }

    void Update()
    {
        SpwanEnemy();
    }

    private void SpwanEnemy()
    {
        transform.Translate(Vector3.down * _enemySpeed * Time.deltaTime);

        if (transform.position.y < -6f)
        {
            _randomXPositon = Random.Range(_leftXPosition, _rightXPosition);
            transform.position = new Vector3(_randomXPositon, 7f, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();

            if (player != null)
            {
                player.Damage();
            }

            Destroy(this.gameObject);
        }


        if (other.gameObject.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
