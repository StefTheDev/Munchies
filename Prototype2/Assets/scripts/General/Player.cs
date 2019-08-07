using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float distanceFromCenter = 1.0f;

    public int maxFullness = 4;

    public AudioClip[] biteSounds;

    public AudioClip[] spitSounds;

    public Recipe recipe;

    private Vector3 initialPosition;
    private AudioSource audioSource;
    public int currentFullness;

    public CameraShake cameraShake;
    public float shakeMagnitude = 1.0f;
    public float shakeDuration = 0.5f;

    public GameObject mesh;
    private Animator meshAnimator;
    private Animator playerAnimator;

    // The most recent directional key pressed by the player determines their position
    Vector3 movePosition;

    public bool eatenThisBeat = false;

    enum KeyType
    {
        UP = 0,
        DOWN,
        LEFT,
        RIGHT
    }

    private bool[] keys;

    private void Awake()
    {
        initialPosition = this.transform.position;
        keys = new bool[4];
        audioSource = GetComponent<AudioSource>();
        meshAnimator = mesh.GetComponent<Animator>();
        playerAnimator = GetComponent<Animator>();
        currentFullness = maxFullness;
    }

    private void Update()
    {
        UpdateKeys();

    }

    private void FixedUpdate()
    {
        if (eatenThisBeat) { return; }

        this.transform.position = initialPosition + (movePosition * distanceFromCenter);
        this.transform.rotation = Quaternion.Euler(0.0f, Vector3.SignedAngle(Vector3.forward, movePosition, Vector3.up), 0.0f);
    }

    private void UpdateKeys()
    {
        // Change movePosition
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            keys[(int)KeyType.UP] = true;
            movePosition = Vector3.forward;
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
        {
            keys[(int)KeyType.UP] = false;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            keys[(int)KeyType.DOWN] = true;
            movePosition = Vector3.back;
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
        {
            keys[(int)KeyType.DOWN] = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            keys[(int)KeyType.LEFT] = true;
            movePosition = Vector3.left;
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
        {
            keys[(int)KeyType.LEFT] = false;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            keys[(int)KeyType.RIGHT] = true;
            movePosition = Vector3.right;
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
        {
            keys[(int)KeyType.RIGHT] = false;
        }

        if (!keys[(int)KeyType.RIGHT] && !keys[(int)KeyType.LEFT] && !keys[(int)KeyType.UP] && !keys[(int)KeyType.DOWN])
        {
            movePosition = Vector3.zero;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Only eat once per beat
        if (eatenThisBeat) { return; }

        var food = other.GetComponent<Food>();

        // If we are colliding with a food object
        if (food)
        {
            meshAnimator.SetTrigger("Bite");

            if (food.isHealthy)
            {
                GameManager.Instance.AddScore(10);
                recipe.Check(food);
                PlayRandomBite();
            }
            else
            {
                PlayRandomSpit();
                Damage();
            }

            currentFullness = maxFullness;

            Destroy(food.gameObject);

            eatenThisBeat = true;
        }
    }

    public void Beat()
    {
        playerAnimator.SetTrigger("Pulse");

        if (GameManager.Instance.freeBeats > 0) { return; }

        if (currentFullness == 0)
        {
            GameManager.Instance.GameOver();
        }

        currentFullness = Mathf.Clamp(currentFullness - 1, 0, maxFullness);
        
    }

    private void Damage()
    {
        ScoreManager.Instance.AddScore(-10);
    }

    private void PlayRandomBite()
    {
        var biteSound = biteSounds[Random.Range(0, biteSounds.Length)];
        audioSource.pitch = Random.Range(0.7f, 1.0f);
        audioSource.PlayOneShot(biteSound);
    }

    private void PlayRandomSpit()
    {
        var spitSound = spitSounds[Random.Range(0, spitSounds.Length)];
        audioSource.pitch = Random.Range(0.7f, 1.0f);
        audioSource.PlayOneShot(spitSound);
    }
}
