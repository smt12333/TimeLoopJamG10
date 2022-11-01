using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeController : MonoBehaviour
{
    [SerializeField] int min, seg;
    [SerializeField] TMP_Text time;
    [SerializeField] int timegiving;

    private float remaining;
    private bool itson;
    private Animator anim;
    private bool dead;

    private void Awake()
    {
        remaining = (min * 60) + seg;
        itson = true;
        anim = GetComponent<Animator>();
        Physics2D.IgnoreLayerCollision(10, 11, false);
    }


    void Start()
    {
        
    }

    
    
    void Update()
    {
       
        
        
        
        if (itson)
        {
            remaining -= Time.deltaTime;
            if (remaining < 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                


            }
            int tempmin = Mathf.FloorToInt(remaining / 60);
            int tempseg = Mathf.FloorToInt(remaining % 60);
            time.text = string.Format("{00:00}:{01:00}", tempmin, tempseg);
        }
   
    }

    
}
