# Unity Portfolio Project

Unity 기반 모바일 RPG 클라이언트 구조를 구현한 포트폴리오 프로젝트입니다.

Addressables 리소스 관리, Firebase/Google 로그인, 테이블 기반 데이터 로딩, FSM 기반 씬 전환, UI Prefab 구조 설계 등 실제 게임 클라이언트 개발에서 필요한 기능들을 직접 구현하고 정리했습니다.

## 주요 구현

- Addressables 기반 리소스 다운로드 및 로딩
- Firebase / Google Sign-In 로그인 연동
- FSM 기반 씬 상태 관리
- 테이블 데이터 기반 게임 데이터 관리
- 공통 UI Manager 및 Panel/Component 구조
- 캐릭터, 인벤토리, 상점, 가챠, 미션, 공지 UI
- UniTask 기반 비동기 처리

## 프로젝트 목적

이 프로젝트는 Unity 클라이언트 개발자로서의 코드 구조 설계, 데이터 관리 방식, UI Prefab 구성, 외부 SDK 연동 경험을 보여주기 위한 포트폴리오입니다.

## 특이사항

- 테이블 관련 클래스와 데이터는 별도 테이블 저장소에서 관리합니다. [Unity Portfolio Project Tables](https://github.com/GyoolTomato/UnityPortfolioProjectTables)
- 프로젝트 실행 시 Firebase 설정 파일은 직접 추가해야 합니다.

## Version

- 0.1
