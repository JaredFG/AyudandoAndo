using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;

    public AudioClip welcomeSceneMusic;
    public AudioClip modeSelectionScene;
    public AudioClip mainSceneMusic;
    public AudioClip pauseMusic;
    public AudioClip winMusic;
    public AudioClip loseMusic;

    private AudioSource audioSource;
    private AudioClip currentPlayingClip;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayMusicBasedOnScene(scene.name);
    }

    private void PlayMusicBasedOnScene(string sceneName)
    {
        AudioClip clipToPlay = null;

        switch (sceneName)
        {
            case "WelcomeScene":
                clipToPlay = welcomeSceneMusic;
                break;
            case "ModeSelectionScene":
                clipToPlay = modeSelectionScene;
                break;
            case "MainScene":
                clipToPlay = mainSceneMusic;
                break;
        }

        if (clipToPlay != null && clipToPlay != currentPlayingClip)
        {
            StartCoroutine(FadeMusic(clipToPlay));
            currentPlayingClip = clipToPlay;
        }
    }

    public void ChangeMusic(string musicType)
    {
        AudioClip clipToPlay = null;

        switch (musicType)
        {
            case "Pause":
                clipToPlay = pauseMusic;
                break;
            case "Win":
                clipToPlay = winMusic;
                break;
            case "Lose":
                clipToPlay = loseMusic;
                break;
        }

        if (clipToPlay != null && clipToPlay != currentPlayingClip)
        {
            StartCoroutine(FadeMusic(clipToPlay));
            currentPlayingClip = clipToPlay;
        }
    }

    private System.Collections.IEnumerator FadeMusic(AudioClip newClip)
    {
        float fadeDuration = 1f;
        float elapsedTime = 0f;
        float startVolume = audioSource.volume;

        while (elapsedTime < fadeDuration)
        {
            audioSource.volume = Mathf.Lerp(startVolume, 0f, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;

        if (newClip != null)
        {
            audioSource.clip = newClip;
            audioSource.Play();
        }
    }
}
