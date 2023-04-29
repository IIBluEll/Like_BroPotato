using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Scanner_Upgrade : MonoBehaviour
{
  public float scanRange; // 탐색 범위
  public LayerMask targetLayer; // 타겟 레이어
  public RaycastHit2D[] targets; // 타겟 정보 배열
  public Transform nearestTarget; // 가장 가까운 타겟

  [SerializeField] List<Transform> sortTargets; // 거리별로 정렬된 타겟들
  int currentIndex; // 현재 인덱스
  public float scanInterval = 0.5f; // 타겟 스캔 간격

  public GameObject target_Icon;
  void Start()
  {
    sortTargets = new List<Transform>();

    StartCoroutine(ScanTargets());
  }

  private IEnumerator ScanTargets()
  {
    while (true)
    {
      // 원형 캐스트를 사용하여 타겟 검색
      targets = Physics2D.CircleCastAll(transform.position, scanRange, Vector2.zero, 0, targetLayer);

      // 타겟 목록을 거리에 따라 정렬
      UpdateSortedTargets();

      if(sortTargets.Count == 0) nearestTarget = null;

      if (nearestTarget == null && sortTargets.Count > 0)
      {
        nearestTarget = sortTargets[0];
      }
       // 가장 가까운 타겟이 있을 경우 타겟팅 아이콘 표시
      if (nearestTarget != null)
      {
        target_Icon.transform.SetParent(nearestTarget);
        target_Icon.transform.localPosition = new Vector3(0f, 0.5f, 0f);
        target_Icon.SetActive(true);
      }
      else
      {
        target_Icon.SetActive(false);
      }

      // 지정된 간격동안 대기
      yield return new WaitForSeconds(scanInterval);
    }
  }
  
  // 거리에 따라 정렬
  void UpdateSortedTargets()
  {
    // 리스트 초기화
    sortTargets.Clear();

    // 탐색된 타겟들을 리스트에 추가
    foreach (RaycastHit2D target in targets)
    {
      sortTargets.Add(target.transform);
    }

    // 리스트 내부의 타겟들을 거리에 따라 정렬
    sortTargets.Sort((a, b) => Vector3.Distance(transform.position, a.position).CompareTo(Vector3.Distance(transform.position, b.position)));
  }

  // 버튼을 누를 때마다 다음 가장 가까운 적을 선택
  public void SelectNextTarget()
  {
    // 타겟이 없으면 종료
    if (sortTargets.Count == 0) return;

    // 다음 타겟 인덱스 계산
    currentIndex = (currentIndex + 1) % sortTargets.Count;

    // 계산된 인덱스에 해당하는 타겟 선택
    nearestTarget = sortTargets[currentIndex];
  }
}
