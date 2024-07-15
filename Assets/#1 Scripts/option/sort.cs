using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sort : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gen, vid, snd, cont, rec, sel;

    public void selected(int a)
    {
        gen.gameObject.SetActive(false);
        vid.gameObject.SetActive(false);
        snd.gameObject.SetActive(false);
        cont.gameObject.SetActive(false);
        rec.gameObject.SetActive(false);
        switch (a)
        {
            case 1:
                gen.gameObject.SetActive(true);
                //sel.transform.position = Vector3.MoveTowards(sel.gameObject.transform.position, gen.targetPosition.transform.position, 0.1f);
                break;
            case 2:
                vid.gameObject.SetActive(true);
                //sel.transform.position = Vector3.MoveTowards(sel.gameObject.transform.position, vid.targetPosition.transform.position, 0.1f);
                break;
            case 3:
                snd.gameObject.SetActive(true);
                //sel.transform.position = Vector3.MoveTowards(sel.gameObject.transform.position, snd.targetPosition.transform.position, 0.1f);
                break;
            case 4:
                cont.gameObject.SetActive(true);
                //sel.transform.position = Vector3.MoveTowards(sel.gameObject.transform.position, cont.targetPosition.transform.position, 0.1f);
                break;
            case 5:
                rec.gameObject.SetActive(true);
                //sel.transform.position = Vector3.MoveTowards(sel.gameObject.transform.position, rec.targetPosition.transform.position, 0.1f);
                break;

        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
