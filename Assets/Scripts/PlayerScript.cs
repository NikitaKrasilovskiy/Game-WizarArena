using System.Collections;
using UnityEngine;
using TMPro;
public class PlayerScript : MonoBehaviour
{
    [HideInInspector] public float walkSpeed = 3f, runSpeed = 8f;
    float jumpSpeed = 6.0f;
    float gravitu = 20.0f;
    private Animator animator;
    private string anim;
    [HideInInspector] public int hpPlayer = 5, points = 0, pointsReoladet = 1;
    public GameObject[] hp;
    public TextMeshProUGUI score;
    public GameObject zombiMan, predmet, weapons1, weapons2, textDead;
    public GameObject[] spawn;

    CharacterController characterController;
    Vector3 moveDir = Vector3.zero;

    public bool camMove = true;

    public AudioSource deadAudio, runAudio;
    private void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        StartCoroutine(Wolna());
    }
    IEnumerator Wolna()
    {
        yield return new WaitForSeconds(100f);
        spawn[0].SetActive(true);
        yield return new WaitForSeconds(100f);
        spawn[1].SetActive(true);
        yield return new WaitForSeconds(100f);
        spawn[2].SetActive(true);
        yield return new WaitForSeconds(100f);
        spawn[3].SetActive(true);
        spawn[4].SetActive(false);
    }
        private void FixedUpdate()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = camMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = camMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirrectionY = moveDir.y;
        moveDir = (forward * curSpeedX) + (right * curSpeedY);

        if (!Input.anyKey)
        { animator.SetTrigger("Idle"); }

        if (isRunning == true)
        { anim = "Run"; }
        else
        { anim = "Walk"; }

        if (Input.GetAxisRaw("Vertical") > 0 || Input.GetAxisRaw("Vertical") < 0)
        { animator.SetTrigger(anim); }

        if (Input.GetAxisRaw("Horizontal") > 0 || Input.GetAxisRaw("Horizontal") < 0)
        { animator.SetTrigger(anim); }

        if (Input.anyKey && anim == "Run")
        { runAudio.Play(); }

        if (Input.GetButton("Jump") && camMove && characterController.isGrounded)
        {
            moveDir.y = jumpSpeed;
            animator.SetTrigger("Jump");
        }
        else
        { moveDir.y = movementDirrectionY; }

        if (!characterController.isGrounded)
        { moveDir.y -= gravitu * Time.deltaTime; }

        characterController.Move(moveDir * Time.deltaTime);

        if (hpPlayer < 5 && hpPlayer >= 0)
        { hp[hpPlayer].SetActive(false); }

        if (hpPlayer == 0)
        {
            animator.SetTrigger("Dead");
            camMove = false;
            FindObjectOfType<mouseLook>().enabled = false;
            GetComponent<CharacterController>().enabled = false;
            weapons1.SetActive(false);
            weapons2.SetActive(false);
            deadAudio.Play();
            textDead.SetActive(true);
        }

        score.text = ($"{points}");

        if (pointsReoladet == 0)
        {
            predmet.SetActive(false);
        }
        else predmet.SetActive(true);
    }
}