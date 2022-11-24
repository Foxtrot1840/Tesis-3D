// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Circle2d"
{
	Properties
	{
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Transparent+0" "IgnoreProjector" = "True" "IsEmissive" = "true"  }
		Cull Back
		CGINCLUDE
		#include "UnityShaderVariables.cginc"
		#include "UnityPBSLighting.cginc"
		#include "Lighting.cginc"
		#pragma target 3.0
		struct Input
		{
			float2 uv_texcoord;
		};

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 break16_g11 = ( i.uv_texcoord * float2( 1,1 ) );
			float2 appendResult7_g11 = (float2(( break16_g11.x + ( 0.0 * step( 1.0 , ( break16_g11.y % 2.0 ) ) ) ) , ( break16_g11.y + ( 0.0 * step( 1.0 , ( break16_g11.x % 2.0 ) ) ) )));
			float temp_output_2_0_g11 = 1.0;
			float2 appendResult11_g12 = (float2(temp_output_2_0_g11 , temp_output_2_0_g11));
			float temp_output_17_0_g12 = length( ( (frac( appendResult7_g11 )*2.0 + -1.0) / appendResult11_g12 ) );
			float2 break16_g1 = ( i.uv_texcoord * float2( 1,1 ) );
			float2 appendResult7_g1 = (float2(( break16_g1.x + ( 0.0 * step( 1.0 , ( break16_g1.y % 2.0 ) ) ) ) , ( break16_g1.y + ( 0.0 * step( 1.0 , ( break16_g1.x % 2.0 ) ) ) )));
			float temp_output_32_0 = sin( _Time.y );
			float temp_output_2_0_g1 = (0.0 + (temp_output_32_0 - 0.0) * (1.0 - 0.0) / (1.0 - 0.0));
			float2 appendResult11_g2 = (float2(temp_output_2_0_g1 , temp_output_2_0_g1));
			float temp_output_17_0_g2 = length( ( (frac( appendResult7_g1 )*2.0 + -1.0) / appendResult11_g2 ) );
			float2 break16_g3 = ( i.uv_texcoord * float2( 1,1 ) );
			float2 appendResult7_g3 = (float2(( break16_g3.x + ( 0.0 * step( 1.0 , ( break16_g3.y % 2.0 ) ) ) ) , ( break16_g3.y + ( 0.0 * step( 1.0 , ( break16_g3.x % 2.0 ) ) ) )));
			float temp_output_2_0_g3 = (0.0 + (temp_output_32_0 - 0.0) * (0.8 - 0.0) / (1.0 - 0.0));
			float2 appendResult11_g4 = (float2(temp_output_2_0_g3 , temp_output_2_0_g3));
			float temp_output_17_0_g4 = length( ( (frac( appendResult7_g3 )*2.0 + -1.0) / appendResult11_g4 ) );
			float2 break16_g15 = ( i.uv_texcoord * float2( 1,1 ) );
			float2 appendResult7_g15 = (float2(( break16_g15.x + ( 0.0 * step( 1.0 , ( break16_g15.y % 2.0 ) ) ) ) , ( break16_g15.y + ( 0.0 * step( 1.0 , ( break16_g15.x % 2.0 ) ) ) )));
			float temp_output_53_0 = sin( _Time.y );
			float temp_output_2_0_g15 = (0.0 + (temp_output_53_0 - 0.5) * (1.0 - 0.0) / (1.5 - 0.5));
			float2 appendResult11_g16 = (float2(temp_output_2_0_g15 , temp_output_2_0_g15));
			float temp_output_17_0_g16 = length( ( (frac( appendResult7_g15 )*2.0 + -1.0) / appendResult11_g16 ) );
			float2 break16_g13 = ( i.uv_texcoord * float2( 1,1 ) );
			float2 appendResult7_g13 = (float2(( break16_g13.x + ( 0.0 * step( 1.0 , ( break16_g13.y % 2.0 ) ) ) ) , ( break16_g13.y + ( 0.0 * step( 1.0 , ( break16_g13.x % 2.0 ) ) ) )));
			float temp_output_2_0_g13 = (0.0 + (temp_output_53_0 - 0.5) * (0.8 - 0.0) / (1.5 - 0.5));
			float2 appendResult11_g14 = (float2(temp_output_2_0_g13 , temp_output_2_0_g13));
			float temp_output_17_0_g14 = length( ( (frac( appendResult7_g13 )*2.0 + -1.0) / appendResult11_g14 ) );
			float temp_output_50_0 = saturate( ( saturate( ( ( 1.0 - temp_output_17_0_g12 ) / fwidth( temp_output_17_0_g12 ) ) ) * ( ( saturate( ( ( 1.0 - temp_output_17_0_g2 ) / fwidth( temp_output_17_0_g2 ) ) ) - saturate( ( ( 1.0 - temp_output_17_0_g4 ) / fwidth( temp_output_17_0_g4 ) ) ) ) + ( saturate( ( ( 1.0 - temp_output_17_0_g16 ) / fwidth( temp_output_17_0_g16 ) ) ) - saturate( ( ( 1.0 - temp_output_17_0_g14 ) / fwidth( temp_output_17_0_g14 ) ) ) ) ) ) );
			float3 temp_cast_0 = (temp_output_50_0).xxx;
			o.Albedo = temp_cast_0;
			float3 temp_cast_1 = (temp_output_50_0).xxx;
			o.Emission = temp_cast_1;
			o.Alpha = temp_output_50_0;
		}

		ENDCG
		CGPROGRAM
		#pragma surface surf Standard alpha:fade keepalpha fullforwardshadows 

		ENDCG
		Pass
		{
			Name "ShadowCaster"
			Tags{ "LightMode" = "ShadowCaster" }
			ZWrite On
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma target 3.0
			#pragma multi_compile_shadowcaster
			#pragma multi_compile UNITY_PASS_SHADOWCASTER
			#pragma skip_variants FOG_LINEAR FOG_EXP FOG_EXP2
			#include "HLSLSupport.cginc"
			#if ( SHADER_API_D3D11 || SHADER_API_GLCORE || SHADER_API_GLES || SHADER_API_GLES3 || SHADER_API_METAL || SHADER_API_VULKAN )
				#define CAN_SKIP_VPOS
			#endif
			#include "UnityCG.cginc"
			#include "Lighting.cginc"
			#include "UnityPBSLighting.cginc"
			sampler3D _DitherMaskLOD;
			struct v2f
			{
				V2F_SHADOW_CASTER;
				float2 customPack1 : TEXCOORD1;
				float3 worldPos : TEXCOORD2;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};
			v2f vert( appdata_full v )
			{
				v2f o;
				UNITY_SETUP_INSTANCE_ID( v );
				UNITY_INITIALIZE_OUTPUT( v2f, o );
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO( o );
				UNITY_TRANSFER_INSTANCE_ID( v, o );
				Input customInputData;
				float3 worldPos = mul( unity_ObjectToWorld, v.vertex ).xyz;
				half3 worldNormal = UnityObjectToWorldNormal( v.normal );
				o.customPack1.xy = customInputData.uv_texcoord;
				o.customPack1.xy = v.texcoord;
				o.worldPos = worldPos;
				TRANSFER_SHADOW_CASTER_NORMALOFFSET( o )
				return o;
			}
			half4 frag( v2f IN
			#if !defined( CAN_SKIP_VPOS )
			, UNITY_VPOS_TYPE vpos : VPOS
			#endif
			) : SV_Target
			{
				UNITY_SETUP_INSTANCE_ID( IN );
				Input surfIN;
				UNITY_INITIALIZE_OUTPUT( Input, surfIN );
				surfIN.uv_texcoord = IN.customPack1.xy;
				float3 worldPos = IN.worldPos;
				half3 worldViewDir = normalize( UnityWorldSpaceViewDir( worldPos ) );
				SurfaceOutputStandard o;
				UNITY_INITIALIZE_OUTPUT( SurfaceOutputStandard, o )
				surf( surfIN, o );
				#if defined( CAN_SKIP_VPOS )
				float2 vpos = IN.pos;
				#endif
				half alphaRef = tex3D( _DitherMaskLOD, float3( vpos.xy * 0.25, o.Alpha * 0.9375 ) ).a;
				clip( alphaRef - 0.01 );
				SHADOW_CASTER_FRAGMENT( IN )
			}
			ENDCG
		}
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18900
319;73;966;522;2106.795;187.7334;2.677679;True;False
Node;AmplifyShaderEditor.SimpleTimeNode;33;-1482.012,241.6046;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleTimeNode;52;-1473.306,849.5919;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SinOpNode;32;-1280.665,251.5069;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SinOpNode;53;-1271.96,859.4941;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TFHCRemapNode;56;-1110.135,631.7111;Inherit;False;5;0;FLOAT;0;False;1;FLOAT;0.5;False;2;FLOAT;1.5;False;3;FLOAT;0;False;4;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.TFHCRemapNode;57;-1061.046,844.4883;Inherit;False;5;0;FLOAT;0;False;1;FLOAT;0.5;False;2;FLOAT;1.5;False;3;FLOAT;0;False;4;FLOAT;0.8;False;1;FLOAT;0
Node;AmplifyShaderEditor.TFHCRemapNode;34;-1118.84,23.72384;Inherit;False;5;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;4;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.TFHCRemapNode;51;-1069.751,236.5011;Inherit;False;5;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;3;FLOAT;0;False;4;FLOAT;0.8;False;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode;54;-859.3352,846.0551;Inherit;True;Dots Pattern;-1;;13;7d8d5e315fd9002418fb41741d3a59cb;1,22,0;5;21;FLOAT2;0,0;False;3;FLOAT2;1,1;False;2;FLOAT;1;False;4;FLOAT;0;False;5;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode;55;-872.1295,607.7504;Inherit;True;Dots Pattern;-1;;15;7d8d5e315fd9002418fb41741d3a59cb;1,22,0;5;21;FLOAT2;0,0;False;3;FLOAT2;1,1;False;2;FLOAT;1;False;4;FLOAT;0;False;5;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode;29;-868.0408,238.0678;Inherit;True;Dots Pattern;-1;;3;7d8d5e315fd9002418fb41741d3a59cb;1,22,0;5;21;FLOAT2;0,0;False;3;FLOAT2;1,1;False;2;FLOAT;1;False;4;FLOAT;0;False;5;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode;28;-880.835,-0.2368832;Inherit;True;Dots Pattern;-1;;1;7d8d5e315fd9002418fb41741d3a59cb;1,22,0;5;21;FLOAT2;0,0;False;3;FLOAT2;1,1;False;2;FLOAT;1;False;4;FLOAT;0;False;5;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;31;-501.9951,165.2473;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;36;-477.3493,768.5074;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode;47;-292.2928,-67.71951;Inherit;False;Dots Pattern;-1;;11;7d8d5e315fd9002418fb41741d3a59cb;1,22,0;5;21;FLOAT2;0,0;False;3;FLOAT2;1,1;False;2;FLOAT;1;False;4;FLOAT;0;False;5;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;43;-246.7391,479.9687;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;44;-9.455093,339.4012;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;50;237.6939,316.6913;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;441.2487,32.09404;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;Circle2d;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Transparent;5;True;True;0;False;Transparent;;Transparent;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;5;True;2;5;False;-1;10;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;0;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;32;0;33;0
WireConnection;53;0;52;0
WireConnection;56;0;53;0
WireConnection;57;0;53;0
WireConnection;34;0;32;0
WireConnection;51;0;32;0
WireConnection;54;2;57;0
WireConnection;55;2;56;0
WireConnection;29;2;51;0
WireConnection;28;2;34;0
WireConnection;31;0;28;0
WireConnection;31;1;29;0
WireConnection;36;0;55;0
WireConnection;36;1;54;0
WireConnection;43;0;31;0
WireConnection;43;1;36;0
WireConnection;44;0;47;0
WireConnection;44;1;43;0
WireConnection;50;0;44;0
WireConnection;0;0;50;0
WireConnection;0;2;50;0
WireConnection;0;9;50;0
ASEEND*/
//CHKSM=A656D9CFB6CAD0B145AAD25C030CAD57697CE624