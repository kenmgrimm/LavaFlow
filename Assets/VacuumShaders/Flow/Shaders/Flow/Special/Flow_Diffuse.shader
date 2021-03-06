Shader "VacuumShaders/Flow/Special/Flow_Diffuse" {
	Properties {
		_FlowColor ("Flow Color", Color) = (1, 1, 1, 1)
		_FlowTexture ("Flow Texture (A)", 2D) = ""{}
		_FlowMap ("FlowMap (RG)", 2D) = ""{}
		_Strength ("Noise strength", Range(0, 1)) = 0					
		_Noise ("Flow Noise (R)", 2D) = ""{}		
		_Emission("Flow Emission", Range(0, 2)) = 0
	}
	SubShader {
		Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" "FlowTag"="Flow"}
	    LOD 200
		
		ZWrite Off
		//Blend SrcAlpha OneMinusSrcAlpha
		
		CGPROGRAM
		#pragma surface surf Lambert alpha
		#pragma target 3.0

		fixed4 _FlowColor;
		sampler2D _FlowTexture;
		sampler2D _FlowMap;
		half _Strength;
		sampler2D _Noise;
		half _Emission;
		half _PhaseLength;
		float4 _FlowMapOffset = {0, 0, 1, 1};

		struct Input
		 {
			float2 uv_FlowTexture;
			float2 uv_FlowMap;
			float2 uv_Noise;
			float4 color: Color;
		};

		void surf (Input IN, inout SurfaceOutput o)
		 {
			
			half4 flowMap = tex2D (_FlowMap, IN.uv_FlowMap);
			flowMap.r = flowMap.r * 2.0f - 1.011765;
			flowMap.g = flowMap.g * 2.0f - 1.003922;
			
			float noise = tex2D (_Noise, IN.uv_Noise).r * _Strength;

			half4 t1 = tex2D (_FlowTexture, IN.uv_FlowTexture + flowMap.rg * (_FlowMapOffset.x + noise)); 	

			
			t1.rgb *= _FlowColor.rgb;

			o.Albedo = t1.rgb;
			o.Emission = o.Albedo.rgb * _Emission;
			o.Alpha = t1.a * _FlowColor.a * IN.color.a;
		}
		ENDCG
	} 
	Fallback "Transparent/VertexLit"
}
