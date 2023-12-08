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
    [SerializeField] GameObject boss;
    [SerializeField] Transform [] spawnPoints;
     int[] enemiesSpawnCost;
     [SerializeField] GameObject MutationCell;
    bool bossTime;
    bool bossIsDead = false;
    [SerializeField] public static List<GameObject> enemiesActiveInScene;

    void Start()
    {
       enemiesActiveInScene = new List<GameObject>();
        //seta o tamanho da lista de preço de inimigos para o tamanho da lista de inimgos
        enemiesSpawnCost = new int[enemies.Length];
        for (int i = 0; i < enemies.Length; i++)
        {
            //pega o script dos inimigos e coloca a variavel custo para ser spawnado em uma lista de preços para cada inimigo
            //(serve so para processamento, pois dessa forma evitamos que a cada vez que spawnar um inimigo eu tenha que ficar pegando o 
            // script dele e acessando a variavel preço, desse jeito acessamos os scripits uma unica vez durante toda a fase)

            enemiesSpawnCost[i] = enemies[i].GetComponent<InimigoBase>().custoParaSerSpawnado;
        }
    PriceSpendAjustment();

    }

    void Cheats()
    {
        if(Input.GetKeyDown(KeyCode.X)){
        for (int i = enemiesActiveInScene.Count-1; i >=0; i--)
        {
            if(enemiesActiveInScene[i].tag == "Inimigo"){
            Destroy(enemiesActiveInScene[i]);
                        enemiesActiveInScene.RemoveAt(i);
        
            }
         
        }




       
        if(boss != null&& boss.activeInHierarchy)
        {
        Destroy(boss);            
        }
   
        }
    }
    // Update is called once per frame
    void Update()
    {
        Cheats();
        //se nao tiver inimigos vivos na cena, spawna uma nova quantia deles
      if(enemiesActiveInScene.Count ==0 && currentWave <= Waves)
      {
    
        StartSpawning();
        
     
      }
    
    if(enemiesActiveInScene.Count ==0 && currentWave > Waves )
    {
     
        if(boss != null)
        {
            boss.SetActive(true);
        }else if(!bossIsDead)
        {
            bossIsDead = true;
             Invoke("GoToNextScene",2);
        }
    }
   
   
    }
      
    
    void GoToNextScene()
    {
      GameMananger.instance.GoToNextScene();
    }
    void StartSpawning()
    {
        if(currentWave == Waves/2 || currentWave ==Waves)
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
     int spawnTries = 0;   
            for (int currentSpentPoints = 0; currentSpentPoints < totalPointsToSpendWithSpawn;currentSpentPoints +=0 )
            {
                //pega um inimigo aleatório para spawnar
                int randomEnemyId = Random.Range(0,enemiesSpawnCost.Length);

                // se o custo de spawn desse inimigo não excecer o tanto de pontos que pode gastar com o spawn, ele é instanciado na cena
                if(currentSpentPoints+ enemiesSpawnCost[randomEnemyId] <= totalPointsToSpendWithSpawn && spawnPointId <spawnPoints.Length){
            currentSpentPoints += enemiesSpawnCost[randomEnemyId];

                // spawna o inimigo no primeiro ponto
            GameObject instantiedEnemy =  Instantiate(enemies[randomEnemyId],spawnPoints[spawnPointId].position,Quaternion.identity);

            //adiciona o inimigo spawnado na lista de inimigos vivos na cena
            enemiesActiveInScene.Add(instantiedEnemy);
                // faz com que o proximo inimigo seja spawnado no proximo ponto da lista (para que nao ocorra de um inimigo spawnar dentro do outro)
            spawnPointId++;
                }
                  spawnTries++;
                if(spawnTries >= 60){
                   
                    Debug.LogError("ajuste o preço do inimigo:"+ enemies[randomEnemyId].name + " para par ou impar dependendo do . Pois meu sistema tem um bug e to com preguiça de arrumar ");
                     break;
                }
            }
    }
    void PriceSpendAjustment()
    {
        bool numbersIsOdd;
        numbersIsOdd = totalPointsToSpendWithSpawn%2 ==0;

          for (int i = 0; i < enemiesSpawnCost.Length; i++)
        {   

            if(enemiesSpawnCost[i]%2 == 0 && !numbersIsOdd||enemiesSpawnCost[i]%2 == 1  && numbersIsOdd)
            {
            totalPointsToSpendWithSpawn++;
            Debug.LogWarning("O totalPointsToSpendWithSpawn (pontos para spawnar) foi ajustado pois o custo de algum inimigo é par ou impar mas o totalPointsToSpendWithSpawn nao é do mesmo tipo");
            break;
            }

        }
    
}
}