﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    private Vector2 targetpos;
    public float yinc, speed, minheight, maxheight;
    public int health = 1;
    public float pos_x, pos_y;
    public GameObject effect;
    void Start()    
    {
        targetpos = new Vector2(pos_x,pos_y);
    }
    void Update()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        transform.position = Vector2.MoveTowards(transform.position, targetpos, speed * Time.deltaTime);
        if (transform.position.y < maxheight && Input.GetKeyDown(KeyCode.UpArrow))
        {
            GameObject eff1 = Instantiate(effect, transform.position, Quaternion.identity);
            targetpos = new Vector2(transform.position.x, transform.position.y + yinc);
            Destroy(eff1, 1.5f);
        }
        else if (transform.position.y > minheight && Input.GetKeyDown(KeyCode.DownArrow))
        {
            GameObject eff2 = Instantiate(effect, transform.position, Quaternion.identity);
            targetpos = new Vector2(transform.position.x, transform.position.y - yinc);
            Destroy(eff2, 1.5f);
        }
    }
}
