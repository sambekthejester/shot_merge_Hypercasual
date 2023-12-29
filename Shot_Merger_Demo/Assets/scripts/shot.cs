using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shot : MonoBehaviour
{
    [SerializeField] GameObject _bullet;
    [SerializeField] GameObject _gunExit;
    float _delayBullet;
    [SerializeField] float _deleteBulletTime = 3f;
    [SerializeField] float _bulletSpeed;
    public GameObject BulletClone;
    float _currentDelayTime = 0f;
    

    public cubeController CubeController;


    private void Awake()
    {
        CubeController = GetComponent<cubeController>();
        _delayBullet = GameManager.Instance.FireRate;
    }

    void Update()
    {
        _delayBullet = GameManager.Instance.FireRate;
        _currentDelayTime += Time.deltaTime;

       
            if (_currentDelayTime > _delayBullet && GameManager.Instance.AllowFire)
            {
                CreateBullet();
                _currentDelayTime = 0f;

            }
        
        
    }

    void CreateBullet()
    {
        
        BulletClone=Instantiate(_bullet, _gunExit.transform.position, Quaternion.identity);
        BulletClone.GetComponent<Rigidbody>().velocity = (Vector3.forward * _bulletSpeed * Time.fixedDeltaTime);
        DeleteBullet();
    }
    void DeleteBullet()
    {
        Destroy(BulletClone, _deleteBulletTime);
    }
}
