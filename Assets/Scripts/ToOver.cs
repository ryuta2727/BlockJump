using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ToOver : MonoBehaviour
{
    [SerializeField]
    BlockMoving blockMoving;
    public void OnCollisionEnter(Collision collision)
    {
        blockMoving.Explosion();
        StartCoroutine(ToMainScene());
    }
    IEnumerator ToMainScene()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("GameScene");
    }
}
