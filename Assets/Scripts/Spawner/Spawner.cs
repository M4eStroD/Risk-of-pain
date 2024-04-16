using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] protected Transform Container;

    [SerializeField] private float _timeSpawn;

    protected virtual void Spawn() { }

    private void Start()
    {
        Spawn();
        StartCoroutine(TimerSpawn());
    }

    private IEnumerator TimerSpawn()
    {
        WaitForSeconds wait = new WaitForSeconds(_timeSpawn);

        while (true)
        {
            if (transform.childCount == 0)
            {
                Spawn();
                yield return wait;
            }

            yield return null;
        }
    }
}
