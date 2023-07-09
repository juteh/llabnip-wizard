using UnityEngine;

public class AudioManager : MonoBehaviour {

    [Header("Sound: Flipper move")]
    [SerializeField] AudioClip flipperMove;

    [Header("Sound: Ball out")]
    [SerializeField] AudioClip ballOut;

    [Header("Sound: Bumper Collision")]
    [SerializeField] AudioClip bumperCollision;

    [Header("Sounds: Enviroment Collision")]
    [SerializeField] AudioClip enviromentCollision;

    [Header("Sound: Flipper Collision")]
    [SerializeField] AudioClip flipperCollision;

    [Header("Sound: Music")]
    [SerializeField] AudioClip music;

    [Header("Sound: Boost")]
    [SerializeField] AudioClip boost;

    AudioSource flipperMoveAudioSource;
    AudioSource ballOutAudioSource;
    AudioSource bumperCollisionAudioSource;
    AudioSource enviromentCollisionAudioSource;
    AudioSource flipperCollisionAudioSource;
    AudioSource musicAudioSource;
    AudioSource boostAudioSource;

    public static AudioManager Instance {
        get; private set;
    }

    private void Awake() {
        AudioSource[] audioSources = GetComponentsInChildren<AudioSource>();
        foreach (AudioSource audioSource in audioSources) {
            switch (audioSource.name) {
                case "FlipperMoveAudioSource":
                    flipperMoveAudioSource = audioSource;
                    flipperMoveAudioSource.clip = flipperMove;
                    break;
                case "BallOutAudioSource":
                    ballOutAudioSource = audioSource;
                    ballOutAudioSource.clip = ballOut;
                    break;
                case "BumperCollisionAudioSource":
                    bumperCollisionAudioSource = audioSource;
                    bumperCollisionAudioSource.clip = bumperCollision;
                    break;
                case "EnviromentCollisionAudioSource":
                    enviromentCollisionAudioSource = audioSource;
                    enviromentCollisionAudioSource.clip = enviromentCollision;
                    break;
                case "FlipperCollisionAudioSource":
                    flipperCollisionAudioSource = audioSource;
                    flipperCollisionAudioSource.clip = flipperCollision;
                    break;
                case "MusicAudioSource":
                    musicAudioSource = audioSource;
                    musicAudioSource.clip = music;
                    break;
                case "BoostAudioSource":
                    boostAudioSource = audioSource;
                    boostAudioSource.clip = boost;
                    break;
                default:
                    break;
            }
        }
    }

    void Start() {
        Debug.Log("Start");
        if (Instance != null) {
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this);
        PlayMusic();
    }

    public void PlayMusic() {
        musicAudioSource.Play();
    }

    public void BumperCollision() {
        bumperCollisionAudioSource.Play();
    }

    public void PlayEnviromentCollision() {
        enviromentCollisionAudioSource.Play();
    }

    public void PlayFlipperCollision() {
        flipperCollisionAudioSource.Play();
    }

    public void PlayBallOut() {
        ballOutAudioSource.Play();
    }

    public void PlayflipperMove() {
        flipperMoveAudioSource.Play();
    }

    public void PlayBoost() {
        boostAudioSource.Play();
    }
}

