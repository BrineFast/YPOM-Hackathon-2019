﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_BulletSpit : MonoBehaviour
{
    Transform target; //цель
    float speed = 10; //скорость полета пули
    //int damage = ; //урон от одной пули
    Vector3 pos;
    public GameObject Puddle;
    bool flag_puddle = true;
    Boss_Move player;
    public GameObject enemy;
    public GameObject parent;
    void Start()
    {
        GetComponent<Renderer>().material.color = Color.green;
        player = parent.GetComponent<Boss_Move>();
        enemy = player.min_dist;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, enemy.transform.position) < 1f) //если пуля достигла цели
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
            puddle.GetComponent<Renderer>().material.color = Color.green; //цвет лужи
            flag_puddle = false;
        }
    }
    
    public void SetTarget(GameObject enemy) //установка цели
    {
        pos = enemy.transform.position; //позиция объекта (на момент выстрела)
        pos.y -= 0.5f; //высота персонажа
    }
    
    void Move()
    {
        Vector3 dir = pos - transform.position;
        transform.Translate(dir.normalized * Time.deltaTime * speed); //перемещение
    }
}
