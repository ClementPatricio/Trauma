Shader "Shaders/ShaderGrey"
{
	Properties{
	_MainTex("Base (RGB)", 2D) = "white" {}
	_MaskTex("Mask texture", 2D) = "white" {}
	_maskBlend("Mask blending", Float) = 0.5
	_maskSize("Mask Size", Float) = 1
	}
		SubShader{
		Pass{
		CGPROGRAM
#pragma vertex vert_img
#pragma fragment frag
#include "UnityCG.cginc"

	uniform sampler2D _MainTex;
	uniform sampler2D _MaskTex;
	uniform float time;
	uniform float height;
	uniform float width;

	fixed _maskBlend;
	fixed _maskSize;

	float rand(float3 myVector) {
		return frac(sin(dot(myVector, float3(12.9898, 78.233, 45.5432))) * 43758.5453);
	}

	fixed4 frag(v2f_img i) : COLOR{
		fixed4 mask = tex2D(_MaskTex, i.uv * _maskSize);
		fixed4 base = tex2D(_MainTex, i.uv);
		//float r = rand(float3(i.pos.x + time, i.pos.y + time,0.0f));
		return lerp(base, mask, _maskBlend);
	}
	ENDCG
	}
	}
}
