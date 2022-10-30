
using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealt { get; private set; }
    private Animator anim;
    private bool dead;


    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberofflashes;
    private SpriteRenderer spriteRend;

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
            //Player dead
            
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            TakeDamage(1);
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
