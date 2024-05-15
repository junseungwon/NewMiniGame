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
    private void AnimationRotation()//룰렛 회전
    {
        isRotation = true;
        animator.speed = 1.7f;
        animator.SetFloat("Rotation", 1.5f);  
    }
    private void StopAnim() // 애니메이션 정지
    {
        isRotation = false;
        animator.speed = 0f;
        int x = ((int)GetComponent<RectTransform>().rotation.eulerAngles.x)/80;
        Debug.Log(ChangeValue(x));
    }
    //1이 0 2가 270 3이 360 4가 90 , 0 3 4 1
    private int ChangeValue(int num) //받아온 값을 순서대로 정렬된 값으로 변경 0 3 4 1 -> 0 1 2 3
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
    public void ChangeUpChildPattern() //90도 돌때마다 ui위치 변경
    {
        //transform.GetChild(transform.childCount - 1).SetAsFirstSibling();
        if(isRotation == false) { StopAnim(); }
    }
    private IEnumerator RandomNumberInstance()//무작위 숫자 생성
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
