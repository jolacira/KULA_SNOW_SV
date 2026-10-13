using System.Collections;
using UnityEngine;

public class ScorpionTrigger : MonoBehaviour
{
    AudioSource m_AudioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            m_AudioSource.Play();
            StartCoroutine("Delay");
        }
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}
