using UnityEngine;

public class NloPresenter : Presenter
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject);
        if (collision.gameObject.CompareTag("Bullet"))
        {
            DestroyCompose();
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            DestroyCompose();
        }
    }
}
