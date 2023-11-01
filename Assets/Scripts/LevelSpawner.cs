using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public int Waves = 4;
    int currentWave;
    public int totalPointsToSpendWithSpawn;
    [SerializeField] GameObject[] enemies;
    [SerializeField] Transform [] spawnPoints;
     int[] enemiesSpawnCost;
     [SerializeField] GameObject MutationCell;

    public static List<GameObject> enemiesActiveInScene = new List<GameObject>();
    void Start()
    {
       
        //seta o tamanho da lista de preço de inimigos para o tamanho da lista de inimgos
        enemiesSpawnCost = new int[enemies.Length];
        for (int i = 0; i < enemies.Length; i++)
        {
            //pega o script dos inimigos e coloca a variavel custo para ser spawnado em uma lista de preços para cada inimigo
            //(serve so para processamento, pois dessa forma evitamos que a cada vez que spawnar um inimigo eu tenha que ficar pegando o 
            // script dele e acessando a variavel preço, desse jeito acessamos os scripits uma unica vez durante toda a fase)

            enemiesSpawnCost[i] = enemies[i].GetComponent<InimigoBase>().custoParaSerSpawnado;
        }
        StartSpawning();

    }

    // Update is called once per frame
    void Update()
    {
  
        //se nao tiver inimigos vivos na cena, spawna uma nova quantia deles
      if(enemiesActiveInScene.Count ==0 && currentWave <= Waves)
      {
        
        StartSpawning();     
     
      }
   
    }
    void StartSpawning()
    {
        if(currentWave == Waves/2 || currentWave >=Waves)
        {
            SpawnMutationCell();
        }else
        {
            SpawnEnemies();
        }
           currentWave++;   
  
    }
    void SpawnMutationCell()
    {
         GameObject cell = Instantiate(MutationCell,spawnPoints[0].position,Quaternion.identity);
        enemiesActiveInScene.Add(cell);
    }
    void SpawnEnemies()
    {
     int spawnPointId = 0;

            for (int currentSpentPoints = 0; currentSpentPoints < totalPointsToSpendWithSpawn;currentSpentPoints +=0 )
            {
                //pega um inimigo aleatório para spawnar
                int randomEnemyId = Random.Range(0,enemiesSpawnCost.Length);

                // se o custo de spawn desse inimigo não excecer o tanto de pontos que pode gastar com o spawn, ele é instanciado na cena
                if(currentSpentPoints+ enemiesSpawnCost[randomEnemyId] <= totalPointsToSpendWithSpawn){
            currentSpentPoints += enemiesSpawnCost[randomEnemyId];

                // spawna o inimigo no primeiro ponto
            GameObject instantiedEnemy =  Instantiate(enemies[randomEnemyId],spawnPoints[spawnPointId].position,Quaternion.identity);

            //adiciona o inimigo spawnado na lista de inimigos vivos na cena
            enemiesActiveInScene.Add(instantiedEnemy);
                // faz com que o proximo inimigo seja spawnado no proximo ponto da lista (para que nao ocorra de um inimigo spawnar dentro do outro)
            spawnPointId++;
                }
            }
    }
    
}
