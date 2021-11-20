using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private Player_Controller player;
    private Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Controller>();
        slider = GetComponent<Slider>();
        slider.maxValue = player._maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = player._hp;
    }
}
