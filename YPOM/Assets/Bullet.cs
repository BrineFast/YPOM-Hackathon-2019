﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Transform target; //цель
    float speed = 10; //скорость полета пули
    //int damage = ; //урон от одной пули
    Vector3 pos;
    public GameObject Puddle;
    bool flag_puddle = true;
    HealthPoints stats;

    void Start()
    {
        GetComponent<Renderer>().material.color = Color.blue;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, target.position) < 1f) //если пуля достигла цели
        {
            stats = target.GetComponent<HealthPoints>();
            stats.healthp--;
            Destroy(gameObject); //удаление пули
        }
        if (Vector3.Distance(transform.position, pos) > 0.5f) //пока пуля не достигла места назначения
            Move(); //движение пули
        else
            Destroy(gameObject); //удаление пули
    }

    public void SetTarget(Transform enemy) //установка цели
    {
        target = enemy;
        pos = target.position; //позиция объекта (на момент выстрела)
        pos.y -= 0.5f; //высота персонажа
    }

    void Move()
    {
        Vector3 dir = pos - transform.position;
        transform.Translate(dir.normalized * Time.deltaTime * speed); //перемещение
    }
}
