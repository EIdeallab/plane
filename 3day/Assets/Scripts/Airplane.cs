using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplane : MonoBehaviour
{
    float vSpeed = 0;
    float hSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        // 6. �ٽ� ����ϵ��� ����
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(new Vector3(-2000, 0, 0));
    }

    // 7. �ε����� �� ���߷� ���¿��� ������ ���ư��� �ʵ��� �߷��� �ݴϴ�.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Terrain")
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.useGravity = true;

            // 9. ���� ��ó��
            var obj = transform.Find("DestroyFlame").gameObject;
            obj.SetActive(true);

            obj = transform.Find("Flame").gameObject;
            obj.SetActive(false);

            obj = transform.Find("Flame2").gameObject;
            obj.SetActive(false);

            for(int i = 0; i < this.transform.childCount; i++)
            {
                GameObject go = this.transform.GetChild(i).gameObject;
                if (go.name == "Main Camera") continue;

                go.AddComponent<Rigidbody>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Transform tr = GetComponent<Transform>();

        // �ε巯�� �������� ���ؼ� �����ϴ� ����� �����ߴ�!
        if (Input.GetKey(KeyCode.UpArrow))
        {
            vSpeed -= Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            vSpeed += Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            hSpeed -= Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            hSpeed += Time.deltaTime;
        }

        // Ű���忡�� ���� ���� ������ õõ�� ȸ���ϵ��� �����Ӹ��� 97% �ӵ��� �����ߴ�.
        if (!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow))
        {
            vSpeed *= 0.97f;
        }

        if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            hSpeed *= 0.97f;
        }

        // 8. ȸ�� �ӵ� ����
        hSpeed = Mathf.Clamp(hSpeed, -Time.deltaTime * 200, Time.deltaTime * 200);
        vSpeed = Mathf.Clamp(vSpeed, -Time.deltaTime * 100, Time.deltaTime * 100);

        tr.Rotate(new Vector3(0, 0, vSpeed));
        tr.Rotate(new Vector3(hSpeed, 0, 0));

        // 6. ����� �ϴܿ� �ӵ��� ����ؼ� ����� �޵��� �ߴ�.
        Rigidbody rb = GetComponent<Rigidbody>();
        var localVelocity = tr.InverseTransformDirection(rb.velocity);
        rb.AddRelativeForce(new Vector3(0, -localVelocity.y * Time.deltaTime * 500, 0));

        // 8. ���� ����� �����.
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(new Vector3(-Time.deltaTime * 300, 0, 0));
        }
    }
}
