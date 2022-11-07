// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Brea"
{
	Properties
	{
		_Speed("Speed", Float) = 1
		_FlowmapT("Flowmap T", 2D) = "white" {}
		_DiffuseMap("Diffuse Map", 2D) = "white" {}
		_Normals("Normals", 2D) = "white" {}
		_Tiling("Tiling", Float) = 1
		_Color0("Color 0", Color) = (0,0,0,0)
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" }
		Cull Back
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 3.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform sampler2D _Normals;
		uniform sampler2D _FlowmapT;
		uniform float4 _FlowmapT_ST;
		uniform float _Speed;
		uniform float _Tiling;
		uniform sampler2D _DiffuseMap;
		uniform float4 _Color0;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv_FlowmapT = i.uv_texcoord * _FlowmapT_ST.xy + _FlowmapT_ST.zw;
			float2 blendOpSrc18 = i.uv_texcoord;
			float2 blendOpDest18 = (tex2D( _FlowmapT, uv_FlowmapT )).rg;
			float2 temp_output_18_0 = ( saturate( (( blendOpDest18 > 0.5 ) ? ( 1.0 - 2.0 * ( 1.0 - blendOpDest18 ) * ( 1.0 - blendOpSrc18 ) ) : ( 2.0 * blendOpDest18 * blendOpSrc18 ) ) ));
			float temp_output_3_0 = ( _Time.y * _Speed );
			float temp_output_1_0_g1 = temp_output_3_0;
			float temp_output_11_0 = (0.0 + (( ( temp_output_1_0_g1 - floor( ( temp_output_1_0_g1 + 0.5 ) ) ) * 2 ) - -1.0) * (1.0 - 0.0) / (1.0 - -1.0));
			float TimeA19 = -temp_output_11_0;
			float2 lerpResult21 = lerp( i.uv_texcoord , temp_output_18_0 , TimeA19);
			float2 temp_cast_0 = (_Tiling).xx;
			float2 uv_TexCoord35 = i.uv_texcoord * temp_cast_0;
			float2 DiffuseTiling36 = uv_TexCoord35;
			float2 FlowA23 = ( lerpResult21 + DiffuseTiling36 );
			float temp_output_1_0_g2 = (temp_output_3_0*1.0 + 0.5);
			float TimeB42 = -(0.0 + (( ( temp_output_1_0_g2 - floor( ( temp_output_1_0_g2 + 0.5 ) ) ) * 2 ) - -1.0) * (1.0 - 0.0) / (1.0 - -1.0));
			float2 lerpResult45 = lerp( i.uv_texcoord , temp_output_18_0 , TimeB42);
			float2 FlowB48 = ( lerpResult45 + DiffuseTiling36 );
			float BlendTime58 = saturate( abs( ( 1.0 - ( temp_output_11_0 / 0.5 ) ) ) );
			float3 lerpResult67 = lerp( UnpackNormal( tex2D( _Normals, FlowA23 ) ) , UnpackNormal( tex2D( _Normals, FlowB48 ) ) , BlendTime58);
			float3 Normals68 = lerpResult67;
			o.Normal = Normals68;
			float4 lerpResult51 = lerp( tex2D( _DiffuseMap, FlowA23 ) , tex2D( _DiffuseMap, FlowB48 ) , BlendTime58);
			float4 Diffuse25 = lerpResult51;
			o.Albedo = ( Diffuse25 * _Color0 ).rgb;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18900
1120.667;72.66667;884.6667;727.6667;1865.857;1250.035;3.55121;False;False
Node;AmplifyShaderEditor.CommentaryNode;31;496.2306,-1859.551;Inherit;False;1787.314;897.6907;Time;20;12;43;58;57;56;55;53;54;19;42;41;14;40;11;39;4;44;3;2;1;Time;1,1,1,1;0;0
Node;AmplifyShaderEditor.SimpleTimeNode;1;560.2307,-1795.551;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;2;560.2307,-1667.551;Inherit;False;Property;_Speed;Speed;0;0;Create;True;0;0;0;False;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;3;816.2307,-1795.551;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ScaleAndOffsetNode;44;975.8979,-1402.83;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;1;False;2;FLOAT;0.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode;4;944.2306,-1795.551;Inherit;False;Sawtooth Wave;-1;;1;289adb816c3ac6d489f255fc3caf5016;0;1;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode;39;1183.898,-1418.83;Inherit;False;Sawtooth Wave;-1;;2;289adb816c3ac6d489f255fc3caf5016;0;1;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TFHCRemapNode;11;1200.23,-1795.551;Inherit;False;5;0;FLOAT;0;False;1;FLOAT;-1;False;2;FLOAT;1;False;3;FLOAT;0;False;4;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.TFHCRemapNode;40;1439.898,-1418.83;Inherit;False;5;0;FLOAT;0;False;1;FLOAT;-1;False;2;FLOAT;1;False;3;FLOAT;0;False;4;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;30;-1826.527,-1784.984;Inherit;False;2140.532;836.0782;FlowMap;13;48;23;33;47;21;38;45;22;18;46;16;17;15;FlowMap UV's;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;37;-221.3574,-714.1817;Inherit;False;678;206;Diffuse Tiling;3;34;35;36;Diffuse Tiling;1,1,1,1;0;0
Node;AmplifyShaderEditor.SamplerNode;15;-1778.527,-1480.984;Inherit;True;Property;_FlowmapT;Flowmap T;1;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;34;-173.3574,-634.1816;Inherit;False;Property;_Tiling;Tiling;4;0;Create;True;0;0;0;False;0;False;1;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.NegateNode;41;1695.898,-1418.83;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.NegateNode;14;1456.23,-1795.551;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;19;1712.231,-1795.551;Inherit;False;TimeA;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;42;1951.898,-1418.83;Inherit;False;TimeB;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;35;-13.35743,-650.1817;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;54;1103.898,-1114.83;Inherit;False;Constant;_05;0.5;7;0;Create;True;0;0;0;False;0;False;0.5;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.ComponentMaskNode;16;-1394.527,-1480.984;Inherit;True;True;True;False;False;1;0;COLOR;0,0,0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;17;-1394.527,-1736.984;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RegisterLocalVarNode;36;226.643,-650.1817;Inherit;False;DiffuseTiling;-1;True;1;0;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.BlendOpsNode;18;-1010.527,-1480.984;Inherit;True;Overlay;True;3;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;2;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.GetLocalVarNode;22;-1010.527,-1672.984;Inherit;False;19;TimeA;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;46;-948.0071,-1147.423;Inherit;False;42;TimeB;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;53;1359.898,-1130.83;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;55;1503.898,-1130.83;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;45;-518.812,-1229.432;Inherit;False;3;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.GetLocalVarNode;38;-546.5269,-1480.984;Inherit;False;36;DiffuseTiling;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.LerpOp;21;-626.5269,-1736.984;Inherit;True;3;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleAddOpNode;47;-276.2904,-1251.491;Inherit;True;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleAddOpNode;33;-295.4466,-1733.773;Inherit;True;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.AbsOpNode;56;1679.898,-1130.83;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;32;-1770.447,-760.2501;Inherit;False;1388.387;909.4473;Diffuse;8;25;24;26;27;49;51;59;50;Diffuse;1,1,1,1;0;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;48;-0.03595948,-1268.521;Inherit;False;FlowB;-1;True;1;0;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SaturateNode;57;1823.898,-1130.83;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;23;-34.52658,-1736.984;Inherit;False;FlowA;-1;True;1;0;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;58;1999.898,-1130.83;Inherit;False;BlendTime;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;61;-1788.969,376.8429;Inherit;False;1388.387;909.4473;Normal;8;69;68;67;66;65;64;63;62;Normals|;1,1,1,1;0;0
Node;AmplifyShaderEditor.GetLocalVarNode;27;-1722.447,-456.2499;Inherit;False;23;FlowA;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TexturePropertyNode;26;-1722.447,-712.25;Inherit;True;Property;_DiffuseMap;Diffuse Map;2;0;Create;True;0;0;0;False;0;False;None;None;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.GetLocalVarNode;50;-1693.316,-173.157;Inherit;False;48;FlowB;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.GetLocalVarNode;59;-1301.381,-44.40853;Inherit;False;58;BlendTime;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;49;-1430.435,-282.3471;Inherit;True;Property;_TextureSample0;Texture Sample 0;6;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.TexturePropertyNode;63;-1740.969,424.843;Inherit;True;Property;_Normals;Normals;3;0;Create;True;0;0;0;False;0;False;None;None;False;white;Auto;Texture2D;-1;0;2;SAMPLER2D;0;SAMPLERSTATE;1
Node;AmplifyShaderEditor.GetLocalVarNode;62;-1740.969,680.8431;Inherit;False;23;FlowA;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.GetLocalVarNode;69;-1711.838,963.9359;Inherit;False;48;FlowB;1;0;OBJECT;;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SamplerNode;24;-1466.447,-712.25;Inherit;True;Property;_Def;Def;3;0;Create;True;0;0;0;False;0;False;-1;None;7a051dbda2d7bc447bee412427cd311e;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;64;-1484.969,424.843;Inherit;True;Property;_TextureSample2;Texture Sample 2;3;0;Create;True;0;0;0;False;0;False;-1;None;7a051dbda2d7bc447bee412427cd311e;True;0;False;white;Auto;True;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LerpOp;51;-1061.493,-471.9731;Inherit;True;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;65;-1448.957,854.7459;Inherit;True;Property;_TextureSample1;Texture Sample 1;6;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;True;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.GetLocalVarNode;66;-1319.903,1092.684;Inherit;False;58;BlendTime;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;67;-1080.015,665.1199;Inherit;True;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;25;-763.7764,-483.2058;Inherit;False;Diffuse;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;28;1068.831,-466.2089;Inherit;False;25;Diffuse;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.ColorNode;72;1050.887,-298.7086;Inherit;False;Property;_Color0;Color 0;5;0;Create;True;0;0;0;False;0;False;0,0,0,0;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RegisterLocalVarNode;68;-782.2992,653.8873;Inherit;False;Normals;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.StickyNoteNode;12;1440.23,-1667.551;Inherit;False;150;100;New Note;;1,1,1,1;Can Add A Negate;0;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;71;1341.887,-405.7086;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.StickyNoteNode;43;1679.898,-1290.83;Inherit;False;150;100;New Note;;1,1,1,1;Can Add A Negate;0;0
Node;AmplifyShaderEditor.GetLocalVarNode;70;1311.715,-186.1911;Inherit;False;68;Normals;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;1602.34,-407.2825;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;Brea;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Opaque;5;True;True;0;False;Opaque;;Geometry;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;3;0;1;0
WireConnection;3;1;2;0
WireConnection;44;0;3;0
WireConnection;4;1;3;0
WireConnection;39;1;44;0
WireConnection;11;0;4;0
WireConnection;40;0;39;0
WireConnection;41;0;40;0
WireConnection;14;0;11;0
WireConnection;19;0;14;0
WireConnection;42;0;41;0
WireConnection;35;0;34;0
WireConnection;16;0;15;0
WireConnection;36;0;35;0
WireConnection;18;0;17;0
WireConnection;18;1;16;0
WireConnection;53;0;11;0
WireConnection;53;1;54;0
WireConnection;55;0;53;0
WireConnection;45;0;17;0
WireConnection;45;1;18;0
WireConnection;45;2;46;0
WireConnection;21;0;17;0
WireConnection;21;1;18;0
WireConnection;21;2;22;0
WireConnection;47;0;45;0
WireConnection;47;1;38;0
WireConnection;33;0;21;0
WireConnection;33;1;38;0
WireConnection;56;0;55;0
WireConnection;48;0;47;0
WireConnection;57;0;56;0
WireConnection;23;0;33;0
WireConnection;58;0;57;0
WireConnection;49;0;26;0
WireConnection;49;1;50;0
WireConnection;24;0;26;0
WireConnection;24;1;27;0
WireConnection;64;0;63;0
WireConnection;64;1;62;0
WireConnection;51;0;24;0
WireConnection;51;1;49;0
WireConnection;51;2;59;0
WireConnection;65;0;63;0
WireConnection;65;1;69;0
WireConnection;67;0;64;0
WireConnection;67;1;65;0
WireConnection;67;2;66;0
WireConnection;25;0;51;0
WireConnection;68;0;67;0
WireConnection;71;0;28;0
WireConnection;71;1;72;0
WireConnection;0;0;71;0
WireConnection;0;1;70;0
ASEEND*/
//CHKSM=09A8D2B47AE248B00CDDA068AAEE1F5F68A9D554