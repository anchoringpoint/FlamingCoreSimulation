using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Trajectory : MonoBehaviour
{
   private Scene _simulationScene;
   private PhysicsScene _simulationPhysicsScene;
   [SerializeField] private Transform _ObstacleTransform;
   
   
   private void Start()
   {
      CreatePhysicsScene();
   }
   void CreatePhysicsScene()
   {
      _simulationScene = SceneManager.CreateScene("SimulationScene", new CreateSceneParameters(LocalPhysicsMode.Physics3D));
      _simulationPhysicsScene = _simulationScene.GetPhysicsScene();
      
      // Add the obstacle to the simulation scene
      foreach (Transform obj in _ObstacleTransform)
      {
         var ghostObj = Instantiate(obj.gameObject, obj.position, obj.rotation);
         ghostObj.GetComponent<Renderer>().enabled= false;
         SceneManager.MoveGameObjectToScene(ghostObj, _simulationScene);
      }
   }
   
   [SerializeField] private  LineRenderer _lineRenderer;
  [SerializeField] private int _maxPhysicsFrameIterations = 3;
   public void SimulateTrajectory(BallBouncer ballPrefab,Vector3 pos,Vector3 velocity)
   {
      var ghostObj = Instantiate(ballPrefab, pos, Quaternion.identity);
      ghostObj.GetComponent<Renderer>().enabled= false;
      SceneManager.MoveGameObjectToScene(ghostObj.gameObject, _simulationScene);
      
      ghostObj.init(velocity,true);
      
      _lineRenderer.positionCount = _maxPhysicsFrameIterations;
      
      for (int i = 0; i < _maxPhysicsFrameIterations; i++)
      {
         _simulationPhysicsScene.Simulate(Time.fixedDeltaTime);
         
         
         _lineRenderer.SetPosition(i, ghostObj.transform.position);
      }
      
      Destroy(ghostObj.gameObject);
   }
   
}
