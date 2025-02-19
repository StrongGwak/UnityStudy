using UnityEngine;

public class Follow : MonoBehaviour
{
    RectTransform rect;

    void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    void FixedUpdate()
    {
        rect.position = Camera.main.WorldToScreenPoint(GameManager.instance.player.transform.position);
        // 참조 에러가 발생 시 메인 카메라의 태그가 MainCamera인지 확인
        // 씨네머신 카메라는 카메라를 제어할 뿐이고 메인 카메라가 아님을 인지
    }
}
