# Platformer_Group9
 스파르타 부트캠프 Unity 3D 심화주차 팀 프로젝트
 
팀장 - 박현도

팀원 - 임석규 , 임준혁 , 전영은 , 정우석

프로젝트 기간 : 24.11.15 ~ 24.11.22

장르 : 2D 플랫포머 게임

팀장 박현도

1. 플레이어
      - InputSystem의 입력을 받아 좌,우로 이동 및 점프 가능
      - 대쉬 키 입력시 Player의 Gravity 와 velocity를 0 으로 만든 후 , AddForce를 하여 순간 대쉬 구현
      - 위 아래 입력시 Raycast로 LadderLayer를 체크하여 X축값을 제한하고 위아래 이동 구현
      - 사다리로 올라갔을때 Ground가 있을 경우 Raycast로 체크하여 Player 및 Ground 일시적 Enable(false)
2. 체력관리 시스템
      - CharacterStatHandler 와 Stat을 작성하고, 이를 ScriptableObject로 관리
      - ChracaterStatHandler 에서 값을 받아와서 피격시 상대 Collider를 체크한 후 , SO에 작성된 데미지만큼 체력 감소
      - 체력이 0 이하로 떨어질경우 Death
4. 공격 로직
      - 각 캐릭터는 고유한 공격범위를 갖고 있고, 애니메이션에 연결하여 일정 프레임이 지나면 해당 공격범위 오브젝트 활성화
      - 해당 공격범위 오브젝트의 콜라이더에서 OnTrigger로 체크하여 대상이 HealthSystem을 갖고있을경우 공격판정 실행
      - 애니메이션 종료 후 다시 공격범위 오브젝트를 Enable(false)로 하여 Ontrigger의 잦은 체크 비활성화
      - 피격시 해당 collider에 addForce를 하여 넉백 구현
