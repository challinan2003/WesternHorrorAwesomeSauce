using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using static PlayerFootsteps;

public class PlayerFootsteps : MonoBehaviour
{
    //public enum Current_Terrain { Dirt, Wood, Metal }
    //[SerializeField]
    //private Current_Terrain currentTerrain;
    //private EventInstance PlayerFootSteps;

    //// Start is called once before the first execution of Update after the MonoBehaviour is created
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
    //private void PlayWalkEvent(int terrain)
    //{
    //    EventInstance PlayerWalkSteps = RuntimeManager.CreateInstance("event:/PlayerSteps");
    //    PlayerWalkSteps.setParameterByName("Terrain", terrain);
    //    //PlayerFootSteps.setParameterByName("WalkRun", 1, false);
    //    PlayerWalkSteps.set3DAttributes(RuntimeUtils.To3DAttributes(playerModel.gameObject));
    //    PlayerWalkSteps.start();
    //    PlayerWalkSteps.release();
    //}
    //private void PlayRunEvent(int terrain)
    //{
    //    EventInstance PlayerRunSteps = RuntimeManager.CreateInstance("event:/PlayerSteps");
    //    PlayerRunSteps.setParameterByName("Terrain", terrain);
    //    //PlayerFootSteps.setParameterByName("WalkRun", 1, false);
    //    PlayerRunSteps.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(playerModel.gameObject));
    //    PlayerRunSteps.start();
    //    PlayerRunSteps.release();
    //}
    //private void DetermineTerrain()
    //{
    //    RaycastHit[] hit;

    //    hit = Physics.RaycastAll(transform.position, Vector3.down, 10.0f);

    //    foreach (RaycastHit rayhit in hit)
    //    {
    //        if (rayhit.transform.gameObject.layer == LayerMask.NameToLayer("Gravel"))
    //        {
    //            currentTerrain = CURRENT_TERRAIN.GRAVEL;
    //            break;
    //        }
    //        else if (rayhit.transform.gameObject.layer == LayerMask.NameToLayer("Wood"))
    //        {
    //            currentTerrain = CURRENT_TERRAIN.WOOD_FLOOR;
    //            break;
    //        }
    //        else if (rayhit.transform.gameObject.layer == LayerMask.NameToLayer("Grass"))
    //        {
    //            currentTerrain = CURRENT_TERRAIN.GRASS;
    //        }
    //        else if (rayhit.transform.gameObject.layer == LayerMask.NameToLayer("Water"))
    //        {
    //            currentTerrain = CURRENT_TERRAIN.WATER;
    //        }
    //    }
    }
