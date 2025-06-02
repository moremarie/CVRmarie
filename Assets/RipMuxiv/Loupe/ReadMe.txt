simple Loupe Shader:
     The simple magnifier shader has some magnifying glass effects, but does not support high magnification, for reasons explained later.
     OpaqueTexture must be enabled to use the shader, as the shader works by sampling the OpaqueTexture and scaling the Uvs to sample it. 
So it doesn't really have the function of a real-life magnifying glass, due to the nature of OpaqueTexture, in some cases, it will appear 
abnormal, for example, when something appears between the magnifying glass and you, you find that the outline of the object also appears 
in the imaging of the magnifying glass, which is unavoidable, this magnifying glass shader is intended to enrich the effect of the 
magnifying glass as a scene prop, and is not suitable as a handheld prop for the player, unless you don't care about these anomalies.
      If you need a more realistic magnifier, you may need to add a camera and set the camera's render target to a RenderTexture,and place 
it in the appropriate position under the magnifying glass model, and adjust the value of the Fov to achieve the effect, which is more 
suitable for the effect of the magnifier held by the player.In this package, there is an example to demonstrate how to create a more realistic
magnifying glass, but it also has its flaws. But this is not the focus of this package, it is just a presence similar to a gift, so we will not 
discuss its issues.
      This pack comes with a magnifying glass model, a transparent magnifying shader, and a frame shader.
       OpaqueTexture must be enabled to use the shader!
       OpaqueTexture must be enabled to use the shader!
       OpaqueTexture must be enabled to use the shader!

       
      