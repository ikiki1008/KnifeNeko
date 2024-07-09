using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monsters;
    private float[] arrPosX = {-1.98f, -1.11f, 0f, 1.07f, 2.04f};

    void Start(){
       StartEnemyRoutine();
    }

    void StartEnemyRoutine() {
        StartCoroutine("MonsterRoutine");
    }

    public void RestartRoutine() {
        StartCoroutine("MonsterRoutine");
    }

    public void StopEnemyRoutine() {
        Debug.Log("set game stop!!!!");
        StopCoroutine("MonsterRoutine");
    }

    IEnumerator MonsterRoutine() {
        yield return new WaitForSeconds(1.5f);
        int spawnCount = 0;
        int monsterIndex = 0;
        int baseMonsterCount = 5; //초기 몬스터 수
        float moveSpeed = 0.3f;

       while (true) {
            int currentMonsterCount = Mathf.RoundToInt(baseMonsterCount * Mathf.Pow(1.5f, spawnCount / 3.0f)); // 현재 레벨의 몬스터 수 계산
            float[] selectedPositions = SelectRandomPositions(currentMonsterCount);

            foreach (float posX in selectedPositions) {
                spawnMonster(posX, monsterIndex, moveSpeed);
            }

            spawnCount += 1;
            if (spawnCount % 3 == 0) {
                monsterIndex += 1;
            }

            yield return new WaitForSeconds(4f);
        }    
    }

    void spawnMonster(float posX, int index, float speed) {
        Vector3 spawnPos = new Vector3(posX, transform.position.y, transform.position.z);

        if(Random.Range(0,2) == 0){ //monster 레벨 올리기, 100에서 50의 확률로 한단계 높은 레벨의 몬스터소환
            index += 1;
        }

        if (index >= monsters.Length) {
            index = monsters.Length - 1; //index 가 아무리 크더라도 최대 몬스터 index값에서 하나를 빼서 무한반복 되도록 한다
        }

        GameObject monsterOb = Instantiate(monsters[index], spawnPos, Quaternion.identity);
        Monster monster = monsterOb.GetComponent<Monster>();
        monster.setMoveSpeed(speed); //레벨이 오를수록 스피드가 빨라진다
    }

    float[] SelectRandomPositions(int count) {
        List<float> positions = new List<float>(arrPosX);
        float[] selectedPositions = new float[count];

        for (int i = 0; i < count; i++) {
            if (positions.Count == 0) {
                positions.AddRange(arrPosX); // 사용할 위치가 부족하면 초기 위치 리스트를 다시 추가
            }

            int randomIndex = Random.Range(0, positions.Count);
            selectedPositions[i] = positions[randomIndex];
            positions.RemoveAt(randomIndex); // 선택한 위치는 제거하여 중복되지 않도록 함
        }

        return selectedPositions;
    }
}
