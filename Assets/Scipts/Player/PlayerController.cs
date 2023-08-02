using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    public Transform aimTrans;
    public float speed;
    private Vector2 mouseLook;
    private Vector3 rotationTarget;
    Animator anim;
    private Transform trans;

    public GameObject cam;

    public bool isRolling = false; // Kiểm tra xem nhân vật có đang roll hay không
    public float rollTime = 0.5f; // Thời gian roll
    public float rollSpeed = 10f; // Tốc độ roll

    public void OnMouseLook(InputAction.CallbackContext context)
    {

        mouseLook = context.ReadValue<Vector2>();
    }


    void Start()
    {

        trans = transform;
        SetupAnimator();
   
    }
    void Update()
    {
        if (!isRolling)
        {

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(mouseLook);
            if (Physics.Raycast(ray, out hit))
            {
                rotationTarget = hit.point;
            }
                PlayerMovement();
           
        }
    }


    public void PlayerMovement()
    {
        float y = Input.GetAxis("Vertical");
        Vector3 dir = rotationTarget - trans.position;
        dir.y = 0;
        //dir.Normalize();
        trans.rotation = Quaternion.Slerp(trans.rotation, Quaternion.LookRotation(dir), Time.deltaTime * 6f);

        trans.Translate(Vector3.forward * speed * Time.deltaTime * y);

        anim.SetFloat("Forward", y);
    
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Roll());
        }

    }

    void SetupAnimator()
    {
        anim = GetComponent<Animator>();
        foreach (var childAnimator in GetComponentsInChildren<Animator>())
        {
            if (childAnimator != anim)
            {
                anim.avatar = childAnimator.avatar;
                Destroy(childAnimator);
                break;
            }
        }
    }

    private IEnumerator Roll()
    {
        if (!isRolling)
        {
            isRolling = true;
            float timer = 0f;
            anim.SetBool("IsRolling", true);
            // Lưu vị trí ban đầu và hướng nhìn của nhân vật
            Vector3 initialPosition = trans.position;
            Quaternion initialRotation = trans.rotation;

            while (timer < rollTime)
            {
                // Tính toán di chuyển và quay nhân vật theo hướng roll
                Vector3 rollDirection = trans.forward * rollSpeed * Time.deltaTime;
                trans.position += rollDirection;
                timer += Time.deltaTime;
                yield return null;
            }

            anim.SetBool("IsRolling", false);
            isRolling = false;
            yield return new WaitForSeconds(5f);
        }

    }

}
