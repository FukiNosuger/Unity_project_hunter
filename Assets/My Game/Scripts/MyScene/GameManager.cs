using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

/// <summary>
/// ゲームシステムに関わるマネジメントスクリプト
/// </summary>
public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject terrainPrefab = null;
    [SerializeField] GameObject playerPrefab = null;
    [SerializeField] GameObject enemyPrefab = null;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("GameManager.cs started.");
        Instantiate(terrainPrefab, new Vector3(-500,-120,-500), transform.rotation);
        Instantiate(playerPrefab, new Vector3(0, 0, 0), transform.rotation);
        Instantiate(enemyPrefab, new Vector3(0, 0, -50), transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
