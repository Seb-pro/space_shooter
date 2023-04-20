using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float _laserSpeed;

    void Update()
    {
        SpawnLaser();
    }

    private void SpawnLaser()
    {
        transform.Translate(Vector3.up * _laserSpeed * Time.deltaTime);

        if (transform.position.y > 8f)
        {
            Destroy(this.gameObject);
        }
    }
}
