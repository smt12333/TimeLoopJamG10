
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealt { get; private set; }
    private Animator anim;
    public bool dead;


    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberofflashes;
    private SpriteRenderer spriteRend;

    [Header("GetComponents")]
    [SerializeField] private Behaviour[] components;
    private bool invulnerable;
    private void Awake()
    {
        currentHealt = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealt = Mathf.Clamp(currentHealt - _damage, 0, startingHealth);

        if (currentHealt > 0)
        {
            //player hurt
            anim.SetTrigger("Hurt");
            StartCoroutine(Invurnerability());
            
        }
        else
        {
            if(!dead)
            {
                //Player dead
                anim.SetTrigger("Die");
                GetComponent<PlayerMovement>().enabled = false;
                dead = true;
                
              

            }
            
            

        }
    }
    public void AddHealth(float _value)
    {
        currentHealt = Mathf.Clamp(currentHealt + _value, 0, startingHealth);
    }



    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            StopCoroutine(Invurnerability());
            Physics2D.IgnoreLayerCollision(10, 11, false);
        }
    }


    private IEnumerator Invurnerability()
    {
        Physics2D.IgnoreLayerCollision(10, 11, true);
        for (int i =0; i < numberofflashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration/ (numberofflashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberofflashes * 2));
            

        }
        Physics2D.IgnoreLayerCollision(10, 11, false);
    }


    

}
