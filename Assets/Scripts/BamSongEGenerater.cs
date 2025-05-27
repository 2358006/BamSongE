using UnityEngine;
using UnityEngine.UI;
public class BamSongEGenerater : MonoBehaviour
{
    public GameObject bamsongEPrefab;         // 발사할 밤송이 프리팹
    public float minPower = 1000f;            // 최소 파워 값
    public float maxPower = 3000f;            // 최대 파워 값
    public float chargeSpeed = 5000f;         // 충전 속도 (왕복 속도)
    private float currentPower = 0f;          // 현재 충전된 파워

    private bool isCharging = false;          // 현재 충전 중인지 여부
    private bool isPowerIncreasing = true;    // 파워가 증가 중인지 감소 중인지 여부

    public Slider powerSlider;                // UI 파워 슬라이더

    void Start()
    {
        // 슬라이더가 존재하면 초기값 설정
        if (powerSlider != null)
        {
            powerSlider.minValue = minPower;
            powerSlider.maxValue = maxPower;
            powerSlider.value = minPower;
        }

        currentPower = minPower; // 시작 시 최소 파워로 초기화
    }

    void Update()
    {
        // 마우스 왼쪽 버튼 누르면 충전 시작 (게임이 활성화된 상태일 때만)
        if (Input.GetMouseButtonDown(0) && Game_Manager.instance.isPlaying)
        {
            isCharging = true;
            isPowerIncreasing = true; // 처음엔 증가 방향부터 시작
        }

        if (isCharging)
        {
            // 충전 로직 (파워를 왕복 증가/감소)
            float delta = chargeSpeed * Time.deltaTime;

            if (isPowerIncreasing)
            {
                currentPower += delta;
                if (currentPower >= maxPower)
                {
                    currentPower = maxPower;
                    isPowerIncreasing = false; // 최대치 도달시 감소로 전환
                }
            }
            else
            {
                currentPower -= delta;
                if (currentPower <= minPower)
                {
                    currentPower = minPower;
                    isPowerIncreasing = true; // 최소치 도달시 증가로 전환
                }
            }

            // 슬라이더 UI에 현재 파워 값 반영
            if (powerSlider != null)
            {
                powerSlider.value = currentPower;
            }
        }

        // 마우스 왼쪽 버튼을 뗐을 때 발사 (발사된 상태가 아닐 시)
        if (Input.GetMouseButtonUp(0) && isCharging && !Game_Manager.instance.isShoot)
        {
            Fire(currentPower); // 현재 파워로 발사
            isCharging = false; // 충전 종료
            currentPower = minPower; // 파워 초기화

            // UI 초기화
            if (powerSlider != null)
            {
                powerSlider.value = minPower;
            }
            // 발사 횟수 감소
            Game_Manager.instance.GameTurn();
        }
    }

    // 밤송이를 발사하는 메서드
    void Fire(float power)
    {
        // 밤송이 프리팹 인스턴스화
        GameObject bamsongi = Instantiate(bamsongEPrefab);

        // 마우스 위치 기준으로 방향 설정
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 worldDir = ray.direction;

        // 지정된 방향과 힘으로 발사
        bamsongi.GetComponent<BamSongEController>().Shoot(worldDir.normalized * power);
    }
}


// public GameObject bamsongePrefab;
//     public float minPower = 1000f;            // 최소 파워 값
//     public float maxPower = 3000f;            // 최대 파워 값
//     public float chargeSpeed = 500f;         // 현재 파워
//     float currentPower = 0f;          // 현재 충전된 파워

//     bool isCharging = false;          // 현재 충전 중인지 여부
//     bool isPowerIncreasing = true;    // 파워가 증가 중인지 감소 중인지 여부

//     public Slider powerSlider;                // UI 파워 슬라이더

//     void Awake()
//     {
//         // 슬라이더가 존재하면 초기값 설정
//         if (powerSlider != null)
//         {
//             powerSlider.minValue = minPower;
//             powerSlider.maxValue = maxPower;
//             powerSlider.value = minPower;
//         }

//         currentPower = minPower; // 시작 시 최소 파워로 초기화
//     }

//     void Update()
//     {
//         // 마우스 왼쪽 버튼 누르면 충전 시작 (게임이 활성화된 상태일 때만)
//         if (Input.GetMouseButtonDown(0) && Game_Manager.instance.isPlaying)
//         {
//             isCharging = true;
//             isPowerIncreasing = true; // 처음엔 증가 방향부터 시작
//         }

//         if (isCharging)
//         {
//             // 충전 로직 (파워를 왕복 증가/감소)
//             float delta = chargeSpeed * Time.deltaTime;

//             if (isPowerIncreasing)
//             {
//                 currentPower += delta;
//                 if (currentPower >= maxPower)
//                 {
//                     currentPower = maxPower;
//                     isPowerIncreasing = false; // 최대치 도달시 감소로 전환
//                 }
//             }
//             else
//             {
//                 currentPower -= delta;
//                 if (currentPower <= minPower)
//                 {
//                     currentPower = minPower;
//                     isPowerIncreasing = true; // 최소치 도달시 증가로 전환
//                 }
//             }

//             // 슬라이더 UI에 현재 파워 값 반영
//             if (powerSlider != null)
//             {
//                 powerSlider.value = currentPower;
//             }
//             Debug.Log($"현재 파워 {currentPower}");
//         }

//         // 마우스 왼쪽 버튼을 뗐을 때 발사 (발사된 상태가 아닐 시)
//         if (Input.GetMouseButtonUp(0) && isCharging && !Game_Manager.instance.isShoot)
//         {
//             // 현재 파워로 발사
//             Fire(1000f);
//             isCharging = false; // 충전 종료
//             currentPower = minPower; // 파워 초기화

//             // UI 초기화
//             if (powerSlider != null)
//             {
//                 powerSlider.value = minPower;
//             }
//             // 발사 횟수 감소
//             Game_Manager.instance.GameTurn();
//         }
//     }

//     // 밤송이 발사 
//     void Fire(float power)
//     {
//         if (Input.GetMouseButtonDown(0) && !Game_Manager.instance.isShoot)
//         {
//             // 프리팹 인스턴스화
//             GameObject bamsonge = Instantiate(bamsongePrefab);

//             // 마우스 위치 기준으로 방향 설정
//             Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//             Vector3 worldDir = ray.direction;

//             // 지정된 방향과 힘으로 발사
//             bamsonge.GetComponent<BamSongEController>().Shoot(worldDir.normalized * power);
//         }
//     }