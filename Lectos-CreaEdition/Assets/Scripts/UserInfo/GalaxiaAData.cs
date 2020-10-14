using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GalaxiaAData : MonoBehaviour {

    public List<Planets> PlanetsV;

    public void PlanetDataSaved(int m_id, bool m_block, int m_Stars, int m_Porcent) {

        PlanetsV[m_id].Block = m_block;
        PlanetsV[m_id].Stars = m_Stars;
        PlanetsV[m_id].Porcent = m_Porcent;
        Debug.Log(PlanetsV[m_id].Block + " " + PlanetsV[m_id].Stars + " " + PlanetsV[m_id].Porcent);

    }

    public void MoonDataSaved(int m_Planet_Id, int m_Moon_Id, bool m_Block, bool m_Intro, int m_Stars) {

        PlanetsV[m_Planet_Id].moons[m_Moon_Id].Intro = m_Intro;
        PlanetsV[m_Planet_Id].moons[m_Moon_Id].Block = m_Block;
        PlanetsV[m_Planet_Id].moons[m_Moon_Id].Stars = m_Stars;
        Debug.Log(PlanetsV[m_Planet_Id].moons[m_Moon_Id].Block
          + " " + PlanetsV[m_Planet_Id].moons[m_Moon_Id].Stars);
    }

    public void MinigamesDataSaved(int m_Planet_Id, int m_Moon_Id,
        int m_MiniGame_Id, bool m_Tutorial, float m_Time, int m_stars, GameObject m_Reward) {

        PlanetsV[m_Planet_Id].moons[m_Moon_Id].MinigamesList[m_MiniGame_Id].Tutorial = m_Tutorial;
        PlanetsV[m_Planet_Id].moons[m_Moon_Id].MinigamesList[m_MiniGame_Id].TimeRecord = m_Time;
        PlanetsV[m_Planet_Id].moons[m_Moon_Id].MinigamesList[m_MiniGame_Id].stars = m_stars;
        PlanetsV[m_Planet_Id].moons[m_Moon_Id].MinigamesList[m_MiniGame_Id].Reward = m_Reward;
        Debug.Log(PlanetsV[m_Planet_Id].moons[m_Moon_Id].MinigamesList[m_MiniGame_Id].Tutorial + " "
            + PlanetsV[m_Planet_Id].moons[m_Moon_Id].MinigamesList[m_MiniGame_Id].TimeRecord + " "
            + PlanetsV[m_Planet_Id].moons[m_Moon_Id].MinigamesList[m_MiniGame_Id].stars + " "
            + PlanetsV[m_Planet_Id].moons[m_Moon_Id].MinigamesList[m_MiniGame_Id].Reward);
    }
}
[System.Serializable]
public class Planets {

    [SerializeField]
    public bool Block;

    [SerializeField]
    [Range(0, 2)]
    public int Stars;

    [SerializeField]
    [Range(0, 100)]
    public int Porcent;

    [SerializeField]
    public List<Moons> moons;
}

[System.Serializable]
public class Moons {


    [SerializeField]
    public bool Block;

    [SerializeField]
    public bool Intro;

    [SerializeField]
    [Range(0, 2)]
    public int Stars;

    [SerializeField]
    public List<Minigames> MinigamesList;
}

[System.Serializable]
public class Minigames {

    [SerializeField]
    public bool Tutorial;

    [SerializeField]
    public float TimeRecord;

    [SerializeField]
    public int stars;

    [SerializeField]
    public GameObject Reward;
}


