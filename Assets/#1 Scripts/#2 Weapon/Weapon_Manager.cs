using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Weapon_Manager : MonoBehaviour
{
    //무기 과열관련 변수
    private static float MaxOverheating = 200f;
    private float Overheating=200f;
    private float DecreaseTime = 15;
    private Slider OverheatSlider;
    
    public void Start()
    {
        //슬라이더 가져오기
        OverheatSlider = transform.GetChild(0).transform.GetChild(0).GetComponent<Slider>();
        
        //과열 감소 메서드 실행
        StartCoroutine(DecreaseOverheating());
    }

    //과열 자동 감소
    IEnumerator DecreaseOverheating()
    {
        if (Overheating > 0 && Overheating <= MaxOverheating)
        {
            Overheating--;
            OverheatSlider.value = Overheating / MaxOverheating;
        }

        yield return new WaitForSeconds(DecreaseTime/MaxOverheating);

        StartCoroutine(DecreaseOverheating());
    }
}