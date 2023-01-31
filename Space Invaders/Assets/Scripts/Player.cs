using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Projectile laserPrefab; 

    public float speed = 15.0f;

    private bool _laserActive; 

    private void Update()
    {   //player movement script stuff 
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position += Vector3.left * this.speed * Time.deltaTime; 
        }
        else if (Input.GetKey(KeyCode.D))
        {
            this.transform.position += Vector3.right * this.speed * Time.deltaTime; 
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot(); 
        }


    }

    private void Shoot()
    {
        if (!_laserActive)
        {
            Projectile projectile =  Instantiate(this.laserPrefab, this.transform.position, Quaternion.identity);
            projectile.destroyed += LaserDestroyed; 
            _laserActive = true; 
        }
    }
    private void LaserDestroyed()
    {
        _laserActive = false; 
    }
}
