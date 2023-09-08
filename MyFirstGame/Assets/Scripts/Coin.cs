using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private AudioClip _sound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            Instantiate(_effect, gameObject.transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(_sound, gameObject.transform.position);

            Destroy(gameObject);
        }
    }
}