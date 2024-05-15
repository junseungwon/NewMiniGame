using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class Roulette : MonoBehaviour
{
    private Animator animator;
    private bool isRotation = false;
    private void Start()
    {   
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isRotation)
            {
                StartCoroutine(RandomNumberInstance());          
            }
        }
    }
    private void RotationRulette()
    {
        transform.Rotate(0, -15, 0);
        
    }
    private void AnimationRotation()//�귿 ȸ��
    {
        isRotation = true;
        animator.speed = 1.7f;
        animator.SetFloat("Rotation", 1.5f);  
    }
    private void StopAnim() // �ִϸ��̼� ����
    {
        isRotation = false;
        animator.speed = 0f;
        int x = ((int)GetComponent<RectTransform>().rotation.eulerAngles.x)/80;
        Debug.Log(ChangeValue(x));
    }
    //1�� 0 2�� 270 3�� 360 4�� 90 , 0 3 4 1
    private int ChangeValue(int num) //�޾ƿ� ���� ������� ���ĵ� ������ ���� 0 3 4 1 -> 0 1 2 3
    {
        if (num>2)
        {
            return num-2;
        }
        else if(num ==1)
        {
            return 3;
        }
        else
        {
            return 0;
        }
    }
    public void ChangeUpChildPattern() //90�� �������� ui��ġ ����
    {
        //transform.GetChild(transform.childCount - 1).SetAsFirstSibling();
        if(isRotation == false) { StopAnim(); }
    }
    private IEnumerator RandomNumberInstance()//������ ���� ����
    {   
        float time = 0;
        float randomInt = Random.Range(3.0f, 6.0f);
        AnimationRotation();
        Debug.Log(randomInt);
        while (time < randomInt)
        {
            yield return new WaitForSeconds(0.1f);
            time += 0.1f;
        }
        isRotation = false;
    }
}
