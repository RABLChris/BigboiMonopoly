Shader "Custom/BackgroundShader" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;

			fixed4 earthboundBlue = fixed4(0.407, 0.659, 0.847, 1.0);
			fixed4 earthboundGreen = fixed4(0.500, 0.847, 0.565, 1.0);
			fixed2 aspectRatio = fixed2(16, 9) * 3.0f;
			float timeFactor = 1.0f / 20.0f;

			fixed2 uv = (IN.uv_MainTex + fixed2(timeFactor, timeFactor));
			uv = uv * aspectRatio; //Multiply by the aspect ratio to make our checkerboard squares square

			int xCoordinate = int(round(uv.x));
			int yCoordinate = int(round(uv.y));
			int squareNumber = xCoordinate + (int(aspectRatio.x) * yCoordinate);

			squareNumber += yCoordinate % 2; //Change the colors every other row
			o.Albedo = lerp(earthboundBlue, earthboundGreen, squareNumber % 2);
			//o.Albedo = c.rgb;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
