using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Mathematics;
using UnityEditor;
using UnityEditor.Rendering.Universal.ShaderGUI;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Horizontal")]
    float speed;

    [SerializeField]
    float accelerationSpeed;

    [SerializeField]
    float decelerationSpeed;

    [SerializeField]
    float rollDebreeMultiplier;
    
    float diameter;

    [Header("Vertical")]
    [SerializeField] 
    private float JumpPower;

    [SerializeField] 
    private float fallMultiplier;

    [SerializeField] 
    private float JumpTimer;

    [SerializeField] 
    private float JumpMultiplier;
   
    private bool isJumping;
    private float jumpCounter;

    [Header("Component")]
    public Rigidbody2D rb;

    public LayerMask GroundLayer;
    public CircleCollider2D boxCollider;
    public GameObject deatheffect;
    private AudioManager audiomanager;
    //public GameObject MovementPaticale;

    //ForJump
    //public Vector2 verGravity;

    void Start()
    {
        boxCollider = GetComponent<CircleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        diameter = 2 * Mathf.PI * boxCollider.radius;
        audiomanager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update()
    {
        move();
        Jump();
        deathParticle();
        AnimationUpdate();
    }
    void AnimationUpdate()
    {
        float speed = rb.velocity.magnitude;
        if (speed <= 0)
            return;

        transform.Rotate(0, 0, (speed * -Mathf.Sign(rb.velocity.x) * Time.deltaTime / diameter) * 360f * rollDebreeMultiplier);
        //MovementPaticale.gameObject.transform.Rotate(0,0,((speed*-Mathf.Sign(rb.velocity.x)*Time.deltaTime/diameter)*360f*rollDebreeMultiplier)-180);
    }
    void move()
    {
        float move = SimpleInput.GetAxisRaw("Horizontal");
        if (move == 0)
            return;

        rb.velocity += move * accelerationSpeed * Vector2.right * Time.deltaTime;

        if (rb.velocity.x > speed || rb.velocity.x < -speed)
        {
            rb.velocity = new Vector2(move * speed, rb.velocity.y);
        }
        else if (rb.velocity.x != 0)
        {
            float deceleratedSpeed = Mathf.Lerp(rb.velocity.x, 0, decelerationSpeed * Time.deltaTime);
            rb.velocity = new Vector2(deceleratedSpeed, rb.velocity.y);
        }

    }
    public void JumpButton()
    {
        if (!IsGrounded())
            return;

        rb.velocity += new Vector2(0, JumpPower);
        audiomanager.PlayMusic(audiomanager.JumpClip);
    }

    void Jump()
    {
        if (!Input.GetKeyDown(KeyCode.Space) || !IsGrounded())
            return;

        rb.velocity += new Vector2(0, JumpPower);
        audiomanager.PlayMusic(audiomanager.JumpClip);

        /*if(Input.GetButtonDown("Jump")&&IsGrounded())
        {
            rb.velocity=new Vector2(rb.velocity.x,JumpPower);
            isJumping=true;
            jumpCounter=0;
        }
        if(rb.velocity.y>0&&isJumping)
        {
            jumpCounter+=Time.deltaTime;
            if(jumpCounter>JumpTimer)
                isJumping=false;
            float t =jumpCounter/JumpTimer;
            float currentjump=JumpMultiplier;
            if(t>0.5f)
                currentjump=JumpMultiplier*(1-t);
            rb.velocity+=verGravity*currentjump*Time.deltaTime;
        }
        if(Input.GetButtonUp("Jump"))
        {
            isJumping=false;
            jumpCounter=0;
            if(rb.velocity.y>0)
                rb.velocity=new Vector2(rb.velocity.x,rb.velocity.y*0.6f);         
        }
        if(rb.velocity.y<0)
            rb.velocity-=verGravity*fallMultiplier*Time.deltaTime;*/
    }
    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.01f, GroundLayer);
        return raycastHit.collider != null;
    }
    public void deathParticle()
    {
        if (Input.GetKeyDown(KeyCode.T))
            Instantiate(deatheffect, transform.position, Quaternion.identity);

    }
}
