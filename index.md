# Animator + ParticleSystem in the Unity Editor

There is an inconvenience, that you can't play an animation with a particle system
in the Editor. A particle system just won't work when you preview an animation.

I tried to find a simple solution and I wrote this helper.

You just need to add the component ParticleSystemAnimationHelper 
to the game object and select the particle systems in the scene tree
when you are previewing an animation.

Take a look at the example in [github](localhost).

I consider that the Unity Editor should allow playing particle systems 
in animation out of the box! So, developers of Unity - pay attention to this helper.