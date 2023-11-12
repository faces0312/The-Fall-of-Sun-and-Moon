using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint3_Tuto : MonoBehaviour
{
    public Fail_Tuto fail;
    public GameObject ballon;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Sun" || collision.gameObject.tag == "Moon")
        {
            fail.check_point = 3;
            StartCoroutine(nameof(Up));

            Data.Instance.gameData.stage1_checkpoint = 3;
            if (Data.Instance.gameData.stage1_bestcheck < Data.Instance.gameData.stage1_checkpoint)
            {
                Data.Instance.gameData.stage1_bestcheck = Data.Instance.gameData.stage1_checkpoint;
            }
            Data.Instance.SaveGameData();
        }
    }

    IEnumerator Up()
    {
        for (int i = 0; i < 100; i++)
        {
            ballon.transform.Translate(0, 5 * Time.deltaTime, 0);
            yield return new WaitForSeconds(0.03f);
        }
    }
}
