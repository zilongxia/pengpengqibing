using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class play : MonoBehaviour {

    public GameObject player; 
    public float speed = 1F;
    public Transform human;
    public Transform boss;
    private AudioSource music;
    public AudioClip a1;
    public AudioClip a2;
    public AudioClip a3;
    public AudioClip a4;
    public AudioClip a5;
    public AudioClip a6;
    public AudioClip batter;
    public AudioClip batter1;
    public AudioClip batter2;
    private Collider[] aa;
    private int rand;
    private int zz;
    private int bf;
    private int fd;
    // Use this for initialization
    void Start () {
        music = this.GetComponent<AudioSource>();
        zz = 0;
        bf = 0;
        fd = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!music.isPlaying)
        {
            bf = 1;
        }
        if (bf==1&&fd!=1) {
            rand = Random.Range(1, 9);
            if (rand > 1 && rand <= 2)
            {
                music.clip = a1;
                music.Play();
            }
            if (rand > 2 && rand < 4)
            {
                music.clip = a2;
                music.Play();
            }
            if (rand >= 4 && rand <= 5)
            {
                music.clip = a3;
                music.Play();
            }
            if (rand > 5 && rand <= 6)
            {
                music.clip = a4;
                music.Play();
            }
            if (rand > 6 && rand <= 7)
            {
                music.clip = a5;
                music.Play();
            }
            if (rand > 7 && rand <= 9)
            {
                music.clip = a6;
                music.Play();
            }
            bf = 0;

        }
            
        
        int i = 0;
        aa = Physics.OverlapSphere(this.gameObject.transform.position, 200);
        int b = aa.Length;
        fd = 0;
        for (i = 0; i < b; i++)//找到范围内的敌人
        {
            //  Debug.Log(aa[i].transform.gameObject.tag);
            if (aa[i].transform.gameObject.tag == "boss")
            {
                fd = 1;
                if (zz == 0)
                {
                    rand = Random.Range(1, 9);
                    if (rand > 1 && rand <= 3)
                    {
                        music.clip = batter;
                        music.Play();
                    }
                    if (rand > 3 && rand < 6)
                    {
                        music.clip = batter1;
                        music.Play();
                    }
                    if (rand >= 6 && rand <= 9)
                    {
                        music.clip = batter2;
                        music.Play();
                    }
                    zz = 1;

                }
                if (!music.isPlaying)
                {
                    if (fd == 1)
                    {
                        rand = Random.Range(1, 9);
                        if (rand > 1 && rand <= 3)
                        {
                            music.clip = batter;
                            music.Play();
                        }
                        if (rand > 3 && rand < 6)
                        {
                            music.clip = batter1;
                            music.Play();
                        }
                        if (rand >= 6 && rand <= 9)
                        {
                            music.clip = batter2;
                            music.Play();
                        }
                        zz = 1;

                    }
                }
                


            }
      
         }
            if (fd != 1)
            {
                if (zz == 1)
                {
                rand = Random.Range(1, 9);
                if (rand > 1 && rand <= 2)
                {
                    music.clip = a1;
                    music.Play();
                }
                if (rand > 2 && rand < 4)
                {
                    music.clip = a2;
                    music.Play();
                }
                if (rand >= 4 && rand <= 5)
                {
                    music.clip = a3;
                    music.Play();
                }
                if (rand > 5 && rand <= 6)
                {
                    music.clip = a4;
                    music.Play();
                }
                if (rand > 6 && rand <= 7)
                {
                    music.clip = a5;
                    music.Play();
                }
                if (rand > 7 && rand <= 9)
                {
                    music.clip = a6;
                    music.Play();
                }
                zz = 0;
            }
        
        }


        if (human.gameObject.GetComponent<value>().hp < 0)
        {
            music.Stop();

        }
        if (boss.gameObject.GetComponent<value>().hp < 0)
        {
            music.Stop();
        }


        if (player.transform.position.x >940)
        {
            player.transform.position = new Vector3(940, player.transform.position.y, player.transform.position.z);
        }
        if (player.transform.position.x < 94)
        {
            player.transform.position = new Vector3(94, player.transform.position.y, player.transform.position.z);
        }
        if (player.transform.position.z > 910)
        {
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 910);
        }
        if (player.transform.position.z < 66)
        {
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 66);
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            float x = touchDeltaPosition.x;
            float y = touchDeltaPosition.y;
            // player.transform.position = new Vector3((player.transform.position.x + x) * speed, 0, (player.transform.position.y + y) * speed);


            transform.Translate((touchDeltaPosition.x) * speed, 0, (touchDeltaPosition.y) * speed);
            transform.Translate((touchDeltaPosition.x) * speed, 0, (touchDeltaPosition.y) * speed);
            transform.Translate((touchDeltaPosition.x) * speed, 0, (touchDeltaPosition.y) * speed);
            transform.Translate((touchDeltaPosition.x) * speed, 0, (touchDeltaPosition.y) * speed);
            transform.Translate((touchDeltaPosition.x) * speed, 0, (touchDeltaPosition.y) * speed);
            transform.Translate((touchDeltaPosition.x) * speed, 0, (touchDeltaPosition.y) * speed);
            transform.Translate((touchDeltaPosition.x) * speed, 0, (touchDeltaPosition.y) * speed);
            transform.Translate((touchDeltaPosition.x) * speed, 0, (touchDeltaPosition.y) * speed);

        }
    }
}
