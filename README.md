# Animator + ParticleSystem in the Unity Editor

There is an inconvenience, that you can't play an animation with a particle system
in the Editor. A particle system just won't work when you preview an animation.
Often, it is crucial when you develop a visual effect which uses both an animation and a particle system.

I tried to find a simple solution and I wrote this helper.


[
*>watch the video<*
![Watch the video.](https://github.com/dgolovin-dev/unity3d-animation-with-particles/raw/main/screenshot.png)
](https://github.com/dgolovin-dev/unity3d-animation-with-particles/raw/main/video.mov)

Check out the source code and see the full example.

There are some important notes:
- you should enable the particle system in your animation
- you shold select the particle systems in the Hierarchy when you are playing the animation (otherwise editor won't render the particle systems)
- set the correct duration for the particle system
- this helper works only in edit mode

I consider that the Unity Editor should allow playing particle systems 
in animation out of the box!

**So, the developers of Unity - pay attention to this helper.**

Other guys - feel free to copy and modify [this script](Assets/AnimationParticleHelper/Scripts/ParticleSystemAnimationHelper.cs).
