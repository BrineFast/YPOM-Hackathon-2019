﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_atack : MonoBehaviour
{
    HealthPoints bot;
    AI_agr enemy;
    HealthPoints player_stats;
    public float bot_atack_range = 6f;
    public float bot_cast_time = 3f;
    float bot_cast_time_left;
    public float bot_cast_cd = 3f;
    Animation anim;

    void Start()
    {
        anim = GetComponentInChildren<Animation>();
        enemy = gameObject.GetComponent<AI_agr>();
        bot_cast_time_left = bot_cast_time;
        bot = gameObject.GetComponent<HealthPoints>();
    }


    void Update()
    {
        GameObject player = enemy.min_dist;
        if (player == null) return;
        player_stats = player.GetComponent<HealthPoints>();
        if (Vector3.Distance(transform.position, player.transform.position) <= bot_atack_range)
        {
            bot_cast_time_left -= Time.deltaTime;
            CastAnim(bot_cast_time_left);
            if (bot_cast_time_left <= 0)
            {
                player_stats.TakeDamage();
                
                bot_cast_time_left = bot_cast_time;
            }
        }
        else if(Vector3.Distance(transform.position, player.transform.position) > bot_atack_range)
        {
            
            bot_cast_time_left = bot_cast_time;
        }
    }
    void CastAnim(float bot_cast_time_left)
    {
        anim.Play("Take 002");
    }
}
