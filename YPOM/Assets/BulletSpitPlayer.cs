﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpitPlayer : MonoBehaviour
{
    Transform target; //цель
    float speed = 10; //скорость полета пули
    //int damage = ; //урон от одной пули
    Vector3 pos;
    public GameObject Puddle;
    bool flag_puddle = true;

    void Start()
    {
        GetComponent<Renderer>().material.color = Color.blue;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, target.position) < 1f) //если пуля достигла цели
        {
            //target.GetComponent<>().TakeDamage(damage); //получение урона
            Destroy(gameObject); //удаление пули
        }
        if (Vector3.Distance(transform.position, pos) > 0.5f) //пока пуля не достигла места назначения
            Move(); //движение пули
        else if (flag_puddle) //если лужи еще нет
        {
            Destroy(gameObject); //удаление пули
            GameObject puddle = Instantiate(Puddle); //создание лужи
            puddle.transform.position = pos; //место появления лужи
            puddle.GetComponent<Renderer>().material.color = Color.blue; //цвет лужи
            flag_puddle = false;
        }
    }

    void Move()
    {
        Vector3 dir = pos - transform.position;
        transform.Translate(dir.normalized * Time.deltaTime * speed); //перемещение
    }
}
