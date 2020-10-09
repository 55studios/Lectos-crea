// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:Unlit/Steve,iptp:1,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:32719,y:32712,varname:node_3138,prsc:2|emission-2958-OUT;n:type:ShaderForge.SFN_Tex2d,id:1269,x:32062,y:32580,ptovrint:False,ptlb:Main Texture,ptin:_MainTexture,varname:node_1269,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Add,id:2958,x:32292,y:32789,varname:node_2958,prsc:2|A-517-OUT,B-1638-OUT,C-8325-RGB;n:type:ShaderForge.SFN_Time,id:3347,x:29582,y:32739,varname:node_3347,prsc:2;n:type:ShaderForge.SFN_Tex2d,id:3318,x:30056,y:32016,ptovrint:False,ptlb:Emisive_1,ptin:_Emisive_1,varname:_Emisive_4,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Slider,id:4034,x:30056,y:32311,ptovrint:False,ptlb:Flicker_Velocity_1,ptin:_Flicker_Velocity_1,varname:_Intensity_copy_copy_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:5.748102,max:10;n:type:ShaderForge.SFN_Multiply,id:483,x:30478,y:32315,varname:node_483,prsc:2|A-4034-OUT,B-3347-TDB;n:type:ShaderForge.SFN_RemapRange,id:2805,x:30845,y:32307,varname:node_2805,prsc:2,frmn:0,frmx:0.5,tomn:-1,tomx:1|IN-575-OUT;n:type:ShaderForge.SFN_Sin,id:575,x:30655,y:32315,varname:node_575,prsc:2|IN-483-OUT;n:type:ShaderForge.SFN_SwitchProperty,id:7678,x:31141,y:32167,ptovrint:False,ptlb:Active_1,ptin:_Active_1,varname:node_7678,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-1685-OUT,B-9483-OUT;n:type:ShaderForge.SFN_Vector4,id:1685,x:31141,y:32044,varname:node_1685,prsc:2,v1:0,v2:0,v3:0,v4:0;n:type:ShaderForge.SFN_Add,id:1638,x:31626,y:32799,varname:node_1638,prsc:2|A-7678-OUT,B-4784-OUT,C-9015-OUT;n:type:ShaderForge.SFN_Tex2d,id:8325,x:32271,y:32967,ptovrint:False,ptlb:Static Emissive,ptin:_StaticEmissive,varname:node_8325,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Clamp,id:7222,x:30854,y:32146,varname:node_7222,prsc:2|IN-2805-OUT,MIN-211-OUT,MAX-6152-OUT;n:type:ShaderForge.SFN_Vector1,id:211,x:30576,y:32144,varname:node_211,prsc:2,v1:-1;n:type:ShaderForge.SFN_ValueProperty,id:6152,x:30576,y:32224,ptovrint:False,ptlb:intensity_1,ptin:_intensity_1,varname:node_6152,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5;n:type:ShaderForge.SFN_Multiply,id:9483,x:30841,y:31936,varname:node_9483,prsc:2|A-3318-RGB,B-7222-OUT;n:type:ShaderForge.SFN_Tex2d,id:5682,x:30053,y:32790,ptovrint:False,ptlb:Emisive_2,ptin:_Emisive_2,varname:_Emisive_2,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Slider,id:2882,x:30053,y:33085,ptovrint:False,ptlb:Flicker_Velocity_2,ptin:_Flicker_Velocity_2,varname:_Flicker_Velocity_2,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:5.748102,max:10;n:type:ShaderForge.SFN_Multiply,id:5802,x:30475,y:33089,varname:node_5802,prsc:2|A-2882-OUT,B-3347-TDB;n:type:ShaderForge.SFN_RemapRange,id:1139,x:30842,y:33081,varname:node_1139,prsc:2,frmn:0,frmx:0.5,tomn:-1,tomx:1|IN-3969-OUT;n:type:ShaderForge.SFN_Sin,id:3969,x:30652,y:33089,varname:node_3969,prsc:2|IN-5802-OUT;n:type:ShaderForge.SFN_SwitchProperty,id:4784,x:31138,y:32941,ptovrint:False,ptlb:Active_2,ptin:_Active_2,varname:_Active_2,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-5641-OUT,B-5759-OUT;n:type:ShaderForge.SFN_Vector4,id:5641,x:31138,y:32818,varname:node_5641,prsc:2,v1:0,v2:0,v3:0,v4:0;n:type:ShaderForge.SFN_Clamp,id:2234,x:30851,y:32920,varname:node_2234,prsc:2|IN-1139-OUT,MIN-7346-OUT,MAX-8242-OUT;n:type:ShaderForge.SFN_Vector1,id:7346,x:30573,y:32918,varname:node_7346,prsc:2,v1:-1;n:type:ShaderForge.SFN_ValueProperty,id:8242,x:30573,y:32998,ptovrint:False,ptlb:intensity_2,ptin:_intensity_2,varname:_intensity_2,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5;n:type:ShaderForge.SFN_Multiply,id:5759,x:30838,y:32710,varname:node_5759,prsc:2|A-5682-RGB,B-2234-OUT;n:type:ShaderForge.SFN_Tex2d,id:8858,x:30041,y:33510,ptovrint:False,ptlb:Emisive_3,ptin:_Emisive_3,varname:_Emisive_3,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Slider,id:7093,x:30041,y:33805,ptovrint:False,ptlb:Flicker_Velocity_3,ptin:_Flicker_Velocity_3,varname:_Flicker_Velocity_3,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:5.748102,max:10;n:type:ShaderForge.SFN_Multiply,id:8729,x:30463,y:33809,varname:node_8729,prsc:2|A-7093-OUT,B-3347-TDB;n:type:ShaderForge.SFN_RemapRange,id:3174,x:30830,y:33801,varname:node_3174,prsc:2,frmn:0,frmx:0.5,tomn:-1,tomx:1|IN-5598-OUT;n:type:ShaderForge.SFN_Sin,id:5598,x:30640,y:33809,varname:node_5598,prsc:2|IN-8729-OUT;n:type:ShaderForge.SFN_SwitchProperty,id:9015,x:31126,y:33661,ptovrint:False,ptlb:Active_3,ptin:_Active_3,varname:_Active_3,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-2846-OUT,B-7751-OUT;n:type:ShaderForge.SFN_Vector4,id:2846,x:31126,y:33538,varname:node_2846,prsc:2,v1:0,v2:0,v3:0,v4:0;n:type:ShaderForge.SFN_Clamp,id:7207,x:30839,y:33640,varname:node_7207,prsc:2|IN-3174-OUT,MIN-7432-OUT,MAX-7242-OUT;n:type:ShaderForge.SFN_Vector1,id:7432,x:30561,y:33638,varname:node_7432,prsc:2,v1:-1;n:type:ShaderForge.SFN_ValueProperty,id:7242,x:30561,y:33718,ptovrint:False,ptlb:intensity_3,ptin:_intensity_3,varname:_intensity_3,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5;n:type:ShaderForge.SFN_Multiply,id:7751,x:30826,y:33430,varname:node_7751,prsc:2|A-8858-RGB,B-7207-OUT;n:type:ShaderForge.SFN_Color,id:7205,x:32063,y:32410,ptovrint:False,ptlb:Main Color,ptin:_MainColor,varname:node_7205,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:517,x:32303,y:32627,varname:node_517,prsc:2|A-7205-RGB,B-1269-RGB;proporder:7205-1269-8325-7678-3318-6152-4034-4784-5682-8242-2882-9015-8858-7242-7093;pass:END;sub:END;*/

Shader "UnlitAnimationEmissive" {
    Properties {
        _MainColor ("Main Color", Color) = (0.5,0.5,0.5,1)
        _MainTexture ("Main Texture", 2D) = "white" {}
        _StaticEmissive ("Static Emissive", 2D) = "white" {}
        [MaterialToggle] _Active_1 ("Active_1", Float ) = 0
        _Emisive_1 ("Emisive_1", 2D) = "white" {}
        _intensity_1 ("intensity_1", Float ) = 0.5
        _Flicker_Velocity_1 ("Flicker_Velocity_1", Range(0, 10)) = 5.748102
        [MaterialToggle] _Active_2 ("Active_2", Float ) = 0
        _Emisive_2 ("Emisive_2", 2D) = "white" {}
        _intensity_2 ("intensity_2", Float ) = 0.5
        _Flicker_Velocity_2 ("Flicker_Velocity_2", Range(0, 10)) = 5.748102
        [MaterialToggle] _Active_3 ("Active_3", Float ) = 0
        _Emisive_3 ("Emisive_3", 2D) = "white" {}
        _intensity_3 ("intensity_3", Float ) = 0.5
        _Flicker_Velocity_3 ("Flicker_Velocity_3", Range(0, 10)) = 5.748102
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
            "PreviewType"="Plane"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _MainTexture; uniform float4 _MainTexture_ST;
            uniform sampler2D _Emisive_1; uniform float4 _Emisive_1_ST;
            uniform float _Flicker_Velocity_1;
            uniform fixed _Active_1;
            uniform sampler2D _StaticEmissive; uniform float4 _StaticEmissive_ST;
            uniform float _intensity_1;
            uniform sampler2D _Emisive_2; uniform float4 _Emisive_2_ST;
            uniform float _Flicker_Velocity_2;
            uniform fixed _Active_2;
            uniform float _intensity_2;
            uniform sampler2D _Emisive_3; uniform float4 _Emisive_3_ST;
            uniform float _Flicker_Velocity_3;
            uniform fixed _Active_3;
            uniform float _intensity_3;
            uniform float4 _MainColor;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float4 _MainTexture_var = tex2D(_MainTexture,TRANSFORM_TEX(i.uv0, _MainTexture));
                float4 _Emisive_1_var = tex2D(_Emisive_1,TRANSFORM_TEX(i.uv0, _Emisive_1));
                float4 node_3347 = _Time;
                float4 _Emisive_2_var = tex2D(_Emisive_2,TRANSFORM_TEX(i.uv0, _Emisive_2));
                float4 _Emisive_3_var = tex2D(_Emisive_3,TRANSFORM_TEX(i.uv0, _Emisive_3));
                float4 _StaticEmissive_var = tex2D(_StaticEmissive,TRANSFORM_TEX(i.uv0, _StaticEmissive));
                float3 emissive = ((_MainColor.rgb*_MainTexture_var.rgb)+(lerp( float4(0,0,0,0), (_Emisive_1_var.rgb*clamp((sin((_Flicker_Velocity_1*node_3347.b))*4.0+-1.0),(-1.0),_intensity_1)), _Active_1 )+lerp( float4(0,0,0,0), (_Emisive_2_var.rgb*clamp((sin((_Flicker_Velocity_2*node_3347.b))*4.0+-1.0),(-1.0),_intensity_2)), _Active_2 )+lerp( float4(0,0,0,0), (_Emisive_3_var.rgb*clamp((sin((_Flicker_Velocity_3*node_3347.b))*4.0+-1.0),(-1.0),_intensity_3)), _Active_3 ))+_StaticEmissive_var.rgb).rgb;
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Unlit/Steve"
    CustomEditor "ShaderForgeMaterialInspector"
}
