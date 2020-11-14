using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFade : MonoBehaviour
{
    private static SceneFade instance;
    public bool loading = false;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void FadeIn()
    {
        animator.SetBool("loaded", false);
        animator.SetTrigger("start");
    }

    public void FadeOut()
    {
        animator.SetBool("loaded", true);
        loading = false;
    }
    public void Load(string scene)
    {
        GetComponent<AudioSource>().Play();
        loading = true;
        StartCoroutine(LoadRoutine(scene));
    }

    private IEnumerator LoadRoutine(string scene)
    {
        yield return new WaitForEndOfFrame();
        instance.FadeIn();
        yield return new WaitForSeconds(0.5f);
        yield return SceneManager.LoadSceneAsync(scene);
        instance.FadeOut();
    }

    public static void LoadScene(string scene)
    {
        if (!instance)
        {
            GameObject fader = Instantiate(Resources.Load<GameObject>("fader")) as GameObject;
            instance = fader.GetComponent<SceneFade>();
        }
        if (!instance.loading)
            instance.Load(scene);
    }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

}
