using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;
    [SerializeField] private Transform Highpos;
    [SerializeField] private Transform Lowpos;
    private float timer = 0;
    [SerializeField] private float spawnRate = 2f;



    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnRate)
        {      
            SpawnObstacle();
            timer = 0;
        }
       
    }
    private void SpawnObstacle()
    {
        int index = Random.Range(0, obstacles.Length);
        if ( index == 0 || index == 1)
        {
            GameObject obstacle = Instantiate(obstacles[index], Lowpos.position, Quaternion.identity);
        }
        else if (index == 2 )
        {
            GameObject obstacle = Instantiate(obstacles[index], Highpos.position, Quaternion.identity);
        }
        
    }
}
