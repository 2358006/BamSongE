using UnityEngine;

public class BamSongEController : MonoBehaviour
{
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // 던져요
    public void Shoot(Vector3 dir)
    {
        GetComponent<Rigidbody>().AddForce(dir);
        Game_Manager.instance.isShoot = true;
        Invoke("ShootOut", 0.7f);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("target"))
        {
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<ParticleSystem>().Play();
            Game_Manager.instance.UpScore();
            Destroy(this.gameObject, 2f);
        }

        if (collision.collider.CompareTag("ground"))
        {
            Destroy(this.gameObject, 2f);
        }
    }

    // 다시 던질 준비
    void ShootOut()
    {
        Game_Manager.instance.isShoot = false;
        Debug.Log("다시 던져봅시다");
    }
}