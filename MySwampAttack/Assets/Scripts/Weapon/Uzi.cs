using System.Collections;
using UnityEngine;

public class Uzi : Weapon
{
    private float _delay = 0.1f;
    private int _countBullet = 3;
    
    public override void Shoot(Transform shootPoint)
    {
        var firingBurstBullet = FiringBurst(shootPoint);

        StartCoroutine(firingBurstBullet);
    }

    private IEnumerator FiringBurst(Transform spawnPoint)
    {
        var _delayForSpawn = new WaitForSeconds(_delay);
        
        for (int i = 0; i < _countBullet; i++)
        {
            Instantiate(Bullet, spawnPoint.position, Quaternion.identity);
            yield return _delayForSpawn;
        }
        
        StopAllCoroutines();
    }
}
