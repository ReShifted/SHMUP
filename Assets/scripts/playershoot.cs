using UnityEngine;

public class playershoot : MonoBehaviour
{

    public GameObject BulletPrefab;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(BulletPrefab, transform.position, Quaternion.identity);
        }
    }
}
