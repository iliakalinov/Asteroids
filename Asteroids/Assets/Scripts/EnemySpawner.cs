using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    [SerializeField] private float spawnRadius = 20;

    [SerializeField] private float spawnTime;

    [SerializeField] private float minEnemySpeed;
    [SerializeField] private float maxEnemySpeed;

    [SerializeField] private float minScale = 0.5f;
    [SerializeField] private float maxScale = 5f;

    [SerializeField] private float delayBeforeGame = 2f;
    [SerializeField] private float lifeTimeEnemy = 20f;

    private Action<bool> scoreGame;

    private GameObject ship;

    private void OnEnable()
    {
        StartCoroutine(SpawnRoutine());
    }
    /// <summary>
    /// рождение объектов и установка значений: вектора для ускарения,подпись на взрыв(Callback)
    /// </summary>
    /// <returns></returns>
    private IEnumerator SpawnRoutine()
    {
        yield return new WaitForSeconds(delayBeforeGame);

        ship = GameObject.FindGameObjectWithTag("ship");

        while (true)
        {
            yield return new WaitForSeconds(spawnTime);

            var scale = UnityEngine.Random.Range(minScale, maxScale);

            var randomPos = new Vector2(UnityEngine.Random.Range(-1.0f, 1.0f), UnityEngine.Random.Range(-1.0f, 1.0f)).normalized * spawnRadius;
            var enemyObject = Instantiate(enemy);

            enemyObject.transform.position = randomPos;
            enemyObject.transform.localScale = new Vector3(scale, scale, 1);

            var enemySpeed = UnityEngine.Random.Range(minEnemySpeed, maxEnemySpeed);
            Vector2 vector2 = ((Vector2)enemyObject.transform.position - (Vector2)ship.transform.position).normalized;
            enemyObject.GetComponent<Enemy>().StartMove(-vector2 ,enemySpeed);

            enemyObject.GetComponent<Enemy>().SetCallback(ScoreGame);

            Destroy(enemyObject, lifeTimeEnemy);
        }
    }

    public void SetCallback(Action<bool> action)
    {
        scoreGame = action;
    }

    private void ScoreGame(bool score)
    {
        scoreGame?.Invoke(true);
    }

}
