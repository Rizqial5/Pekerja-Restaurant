using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestPR.Core
{
    public class FoodSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject foodObject;
        [SerializeField] private GameObject emptyPlateObject;

        [SerializeField] private Transform[] foodSpawnLocations;

       

        public GameObject SpawnFood(int indexFoodSpawnLocation)
        {
            GameObject spawnedFood = Instantiate(foodObject, foodSpawnLocations[indexFoodSpawnLocation].position, Quaternion.identity);

            

            return spawnedFood;
        }

        public GameObject SpawnEmptyPlate(int indexLocation)
        {
            GameObject spawnedFood = Instantiate(emptyPlateObject, foodSpawnLocations[indexLocation].position, Quaternion.identity);


            return spawnedFood;
        }

        
    }
}
