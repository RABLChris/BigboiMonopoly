﻿// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "UI/BackgroundShader"
{
	Properties
	{
		_RobotMode("RobotMode", Float) = 0
		[PerRendererData] _MainTex("Sprite Texture", 2D) = "white" {}
	_Color("Tint", Color) = (1,1,1,1)

		_StencilComp("Stencil Comparison", Float) = 8
		_Stencil("Stencil ID", Float) = 0
		_StencilOp("Stencil Operation", Float) = 0
		_StencilWriteMask("Stencil Write Mask", Float) = 255
		_StencilReadMask("Stencil Read Mask", Float) = 255

		_ColorMask("Color Mask", Float) = 15
	}

		SubShader
	{
		Tags
	{
		"Queue" = "Overlay"
		"IgnoreProjector" = "True"
		"RenderType" = "Transparent"
		"PreviewType" = "Plane"
		"CanUseSpriteAtlas" = "True"
	}

		Stencil
	{
		Ref[_Stencil]
		Comp[_StencilComp]
		Pass[_StencilOp]
		ReadMask[_StencilReadMask]
		WriteMask[_StencilWriteMask]
	}

		Cull Off
		Lighting Off
		ZWrite Off
		ZTest Off
		Blend SrcAlpha OneMinusSrcAlpha
		ColorMask[_ColorMask]

		Pass
	{
		CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#include "UnityCG.cginc"

		struct appdata_t
	{
		float4 vertex   : POSITION;
		float4 color    : COLOR;
		float2 texcoord : TEXCOORD0;
	};

	struct v2f
	{
		float4 vertex   : SV_POSITION;
		fixed4 color : COLOR;
		half2 texcoord  : TEXCOORD0;
	};

	fixed4 _Color;
	float _RobotMode;

	v2f vert(appdata_t IN)
	{
		v2f OUT;
		OUT.vertex = UnityObjectToClipPos(IN.vertex);
		OUT.texcoord = IN.texcoord;
#ifdef UNITY_HALF_TEXEL_OFFSET
		OUT.vertex.xy += (_ScreenParams.zw - 1.0)*float2(-1,1);
#endif
		OUT.color = IN.color * _Color;
		return OUT;
	}

	sampler2D _MainTex;

	fixed4 frag(v2f IN) : SV_Target
	{
		half4 color = tex2D(_MainTex, IN.texcoord) * IN.color;			
		fixed4 earthboundBlue = fixed4(0.407, 0.659, 0.847, 1.0);
		fixed4 earthboundGreen = fixed4(0.500, 0.847, 0.565, 1.0);
		fixed2 aspectRatio = fixed2(16, 9) * 3.0f;
		float timeFactor = _Time.x;

		fixed2 uv = (IN.texcoord + fixed2(timeFactor, timeFactor));
		if (_RobotMode > 0)
		{
			earthboundBlue = fixed4(204.0 / 255.0, 80.0 / 255.0, 75.0 / 255.0, 1.0);
			earthboundGreen = fixed4(200.0 / 255.0, 200.0 / 255.0, 200.0 / 255.0, 1.0);
			timeFactor = _Time.y / 10.0f;

			float first = lerp(IN.texcoord.x, IN.texcoord.y, sin(_Time.y * 0.14159f) * 0.5f + 0.5f);
			float second = lerp(1.0f - IN.texcoord.x, 1.0f - IN.texcoord.y, sin(_Time.y * 0.59141f) * 0.5f + 0.5f);
			uv = ((IN.texcoord * lerp(first, second, sin(_Time.y) * 0.5 + 0.5)) + fixed2(timeFactor, timeFactor));
			uv = uv * aspectRatio; //Multiply by the aspect ratio to make our checkerboard squares square
		}
		else
		{
			uv = uv * aspectRatio; //Multiply by the aspect ratio to make our checkerboard squares square
		}

		int xCoordinate = int(round(uv.x));
		int yCoordinate = int(round(uv.y));
		int squareNumber = xCoordinate + (int(aspectRatio.x) * yCoordinate);

		squareNumber += yCoordinate % 2; //Change the colors every other row
		return lerp(earthboundBlue, earthboundGreen, squareNumber % 2);
	}
		ENDCG
	}
	}
}