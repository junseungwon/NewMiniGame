using System.Collections;
using UnityEngine;

public class RotateRoulette : MonoBehaviour
{
    public GameObject rouletteObj;
    private Animator animator;
    private bool isRotation = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        OnOffRoulette();
    }
    public void ChangeChildPos()
    {
        if (isRotation == true)
        {
            rouletteObj.transform.GetChild(rouletteObj.transform.childCount - 1).SetAsFirstSibling();

        }
    }
    public void OnOffRoulette()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isRotation)
            {
                StartCoroutine(RandomNumberInstance());
            }
        }
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
    private void AnimationRotation()//룰렛 회전
    {
        isRotation = true;
        animator.speed = 1.3f;
    }

    public void StopAnim() // 애니메이션 정지
    {
        if (isRotation == false)
        {
            animator.speed = 0f;
            Debug.Log(rouletteObj.transform.GetChild(18).name);
        }
    }


}
