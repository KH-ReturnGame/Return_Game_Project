using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 엔티티들의 생성과 같은 기능 담당
/// </summary>
/// <returns></returns>
public class Entity_Manager : MonoBehaviour
{
    //플레이어 인스턴스
    private Player _player;

    private Enemy testEnemy;
    
    //플레이어 Prefab
    [SerializeField]
    private GameObject playerPrefab;
    //테스트 에너미 Prefab
    [SerializeField]
    private GameObject enemyPrefab;
    
    //제일 처음 한번 호출
    private void Awake()
    {
        //플레이어 생성
        GameObject clone = Instantiate(playerPrefab);
        _player = clone.GetComponent<Player>();
        _player.Setup(100f);
        
        //테스트 에너미 생성
        GameObject clone_enemy = Instantiate(enemyPrefab);
        testEnemy = clone_enemy.GetComponent<Enemy>();
        testEnemy.Setup(100f);
    }

    private void Update()
    {
        _player.Updated();
        testEnemy.Updated();
    }
}