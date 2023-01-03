using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Items")]
public class SpawnObjects : ScriptableObject
{   
    public string Name;
    public int numberOfPrefabsToCreate;
    public Vector3[] spawnPoints;
    public GameObject entityToSpawn;
}
