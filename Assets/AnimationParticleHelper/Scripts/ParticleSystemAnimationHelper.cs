using UnityEngine;
using System.Linq;
#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteInEditMode]
public class ParticleSystemAnimationHelper : MonoBehaviour {
#if UNITY_EDITOR
  private ParticleSystem particleSystem = new ParticleSystem();
  private bool useRandomSeed;

  private float startTime;
  private AnimationWindow animationWindow;
  private GameObject lastSelected;
  private bool isInAnimation;
  private bool previewing => isInAnimation && windowPreviewing;
  private float previewingTime => (!previewing || startTime < 0) ? 0f : (animationWindow.time - startTime);
  private bool windowPreviewing => animationWindow != null && animationWindow.previewing;
  
  private void OnEnable() {
    if (!Application.isPlaying) {
      UpdateState();
      if (!previewing) {
        return;
      }
      startTime = animationWindow.time;
      StartParticleSystemSimulation();
    }
  }

  private void OnDisable() {
    if (!Application.isPlaying) {
     EditorApplication.update -= Update;
      particleSystem.Stop();
      particleSystem.useAutoRandomSeed = useRandomSeed;
    }
  }

  private void Update() {
    if (!Application.isPlaying) {
      UpdateState();
      if (!previewing) return;
      UpdateParticleSystemSimulation(previewingTime);
    }
  }

  private void UpdateState() {
    if (particleSystem == null) {
      particleSystem = GetComponent<ParticleSystem>();
    }
    UpdateCurrentAnimationWindow();
    UpdateIsInAnimation();
  }
  
  private void UpdateCurrentAnimationWindow() {
    var window = EditorWindow.focusedWindow as AnimationWindow;
    if (window != null) {
      animationWindow = window;
    }
  }

  private void UpdateIsInAnimation() {
    var obj = Selection.activeGameObject;
    if (obj == null || lastSelected == gameObject) {
      return;
    }
    lastSelected = obj;
    var animator = obj.GetComponentInParent<Animator>();
    if (animator == null) {
      isInAnimation = false;
      return;
    }
    var parent = animator.transform;
    if (!transform.GetComponentsInParent<Transform>().Contains(parent)) {
      isInAnimation = false;
      return;
    }
    isInAnimation = true;
  }

  private void UpdateParticleSystemSimulation(float time) {
    var delta = time-particleSystem.time*particleSystem.main.simulationSpeed;
    
    if (delta < -1f/100) {
      particleSystem.Simulate(0, false, true, false);
      particleSystem.Pause();
      particleSystem.Simulate(time*particleSystem.main.simulationSpeed, false, false, false);
    } else if (delta > 0) {
      particleSystem.Pause();
      particleSystem.Simulate(delta, false, false, false);
    }

  }
  private void StartParticleSystemSimulation() {
    particleSystem.Stop();
    useRandomSeed = particleSystem.useAutoRandomSeed;
    particleSystem.useAutoRandomSeed = false;
    particleSystem.randomSeed = (uint) (int.MaxValue * Random.value);
    particleSystem.Simulate(0, false, true, false);
    particleSystem.Pause();
  }
#endif
}
