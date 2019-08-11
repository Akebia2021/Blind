using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainSpawner : MonoBehaviour
{
    [SerializeField] GameObject spawnObject;
    [SerializeField] private float timeBetweenWave;
    [SerializeField] private float timeBetweenObject;
    [SerializeField] private int objectCountInWave;
    [SerializeField] private float direction;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAllWaves());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnAllWaves()
    {
        while (true)
        {
            StartCoroutine(SpawnAllEnemiesInWave());
            yield return new WaitForSeconds(timeBetweenWave);
        }
    }

    //1Wave中ですべての敵をSpawn
    //この関数は単に指定した回数、指定したObjectのInstanceを作成するだけである。
    //Insatanceのその後の挙動には全くタッチしないのでInstanceの挙動自体はEnemyPathスクリプトが行う。
    private IEnumerator SpawnAllEnemiesInWave()
    {
        //waveconfigで設定した敵の数の回数文だけForループを回す
        for (int i=0; i<objectCountInWave; i++)
        {

            var newEnemy = Instantiate(
                spawnObject,
                transform.position,
                Quaternion.identity);
            newEnemy.GetComponent<Train>().SetDirection(direction);
            yield return new WaitForSeconds(timeBetweenObject);
        }
    }
}
