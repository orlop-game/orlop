Shader "Custom/Translucent" {
	Properties{
		_MainTex("Base (RGB) Trans(A)", 2D) = "white" {}
		_BumpMap("Normal (Normal)", 2D) = "bump" {}
		_Color("Main Color", Color) = (1,1,1,1)
		_SpecColor("Specular Color", Color) = (0.5, 0.5, 0.5, 1)
		_Shininess("Shininess", Range(0.03, 1)) = 0.078125

			//_Thickness = Thickness texture (invert normals, bake AO).
			//_Power = "Sharpness" of translucent glow.
			//_Distortion = Subsurface distortion, shifts surface normal, effectively a refractive index.
			//_Scale = Multiplier for translucent glow - should be per-light, really.
			//_SubColor = Subsurface colour.
			_Thickness("Thickness (R)", 2D) = "bump" {}
			_Power("Subsurface Power", Float) = 1.0
			_Distortion("Subsurface Distortion", Float) = 0.0
			_Scale("Subsurface Scale", Float) = 0.5
			_SubColor("Subsurface Color", Color) = (1.0, 1.0, 1.0, 1.0)
	}
		SubShader{
		Tags{ "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
		Cull Off
		LOD 200

		CGPROGRAM
#pragma surface surf Translucent alpha
				//#pragma surface surf Lambert alpha

					sampler2D _MainTex, _BumpMap, _Thickness;
					float _Scale, _Power, _Distortion;
					fixed4 _Color, _SubColor;
					half _Shininess;

					struct Input {
						float2 uv_MainTex;
					};

					void surf(Input IN, inout SurfaceOutput o) {
						fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
						o.Albedo = c.rgb;
						o.Alpha = c.a;
					}

					inline fixed4 LightingTranslucent(SurfaceOutput s, fixed3 lightDir, fixed3 viewDir, fixed atten)
					{
						half NdotL = dot(s.Normal, lightDir);
						half INdotL = dot(-s.Normal, lightDir);
						// Figure out if we should use the inverse normal or the regular normal based on light direction.
						half diff = (NdotL < 0) ? INdotL : NdotL;
						half4 c;
						c.rgb = s.Albedo * _LightColor0.rgb * (diff * atten);
						c.a = s.Alpha;

						return c;
					}

					ENDCG
			}
				FallBack "Diffuse"
}