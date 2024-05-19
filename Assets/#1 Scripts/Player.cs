using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 플레이어 클래스
/// </summary>
/// <returns></returns>
public class Player : Entity
{
    /// <summary>
    /// Player 클래스의 생성자임, 최대 체력,
    /// </summary>
    /// <returns>
    /// Null
    /// </returns>
    public Player(float hp,GameObject playerPrefab) : base(hp,playerPrefab){}
}
