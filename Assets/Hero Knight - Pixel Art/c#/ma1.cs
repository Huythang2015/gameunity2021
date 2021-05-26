using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ma1 : MonoBehaviour
{
    public static ma1 cma;
    public Animator animma;
    Vector3 scale;
    public Transform poinnhin;
    public BoxCollider2D conma;
    private BoxCollider2D nguoi;
    public float speed = 2.5f; // toc do di chuyen
    public float attackRange = 3.5f;// khoang cach tan cong
    public float targetRange = 6f;// khoang cach truy duoi
    public Rigidbody2D rb;
    Vector3 lastPosition;
    [SerializeField] bool moveToLastPosition;
    bool duoi = true;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        cma = this;
        nguoi = Player.Instance.GetComponent<BoxCollider2D>();
        scale = transform.localScale;
        int danh = Random.Range(1, 3);
        lastPosition = transform.position; // khai bao nhu nay dau co tac dung no chi chay trong ham thoi
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (mauMa <= 0)
        {
            chet();
        }
        float distance = Vector2.Distance(Player.Instance.transform.position, transform.position); // khoang cach tu nhan vat den ma

        // check tan cong
        if (distance < attackRange)
        {
            int danh = Random.Range(1, 5);
            if (danh == 1)
            {

                animma.SetBool("tancong", true);
            }
        }
        else animma.SetBool("tancong", false);

        // di chuyen trai phai
        if (Player.Instance.transform.position.x < transform.position.x)
        {
            scale.x = -Mathf.Abs(scale.x);
            transform.localScale = scale;
        }
        if (Player.Instance.transform.position.x > transform.position.x)
        {
            scale.x = Mathf.Abs(scale.x);
            transform.localScale = scale;
        }



        RaycastHit2D khuvuckiemtra = Physics2D.Raycast(poinnhin.position, Vector3.down, 1.5f);//khu vuc kiem tra


        if (moveToLastPosition) // di chuyển về chỗ cũ
        {
            time -= Time.deltaTime;
            Debug.Log("move to last");
            transform.position = Vector3.MoveTowards(transform.position, lastPosition, Time.deltaTime * speed);
            if (distance <= targetRange && distance > attackRange && time < 0) // sau 2 giây khi trên đường về chỗ cũ mà gặp player thì đuổi player và dừng về chỗ cũ
            {
                moveToLastPosition = false;
                duoi = true;
            }
            if (transform.position == lastPosition) // nếu về chỗ cũ thì ngưng việc về chỗ cũ và cho phép ma phát hiện player
            {
                moveToLastPosition = false;
                duoi = true;
            }
        }
        if (distance <= targetRange && distance > attackRange && duoi == true) // nếu player gần ma khoảng 6f và hơn 3f thì ma đuổi
        {

            if (scale.x > 0) transform.position += Vector3.right * speed * Time.deltaTime;
            else transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (khuvuckiemtra.collider == null && duoi == true) // nếu đuổi xa thì quay lại chỗ cũ
        {
            time = 2f;
            moveToLastPosition = true;
            duoi = false;
        }
        /*
         vấn đề chưa giải quyết là:
         khi về mà gặp player rồi player nó rời đi nhanh quá thì ma không về đc chỗ cũ mà cú đứng giữa đường
         */
    }
    public float mauMa = 100;
    public void trumau(int tru)
    {
        mauMa -= tru;
        Debug.Log("ok");
    }

    public void chet()
    {
        Destroy(gameObject);
    }



    private void Update()
    {




    }





}
