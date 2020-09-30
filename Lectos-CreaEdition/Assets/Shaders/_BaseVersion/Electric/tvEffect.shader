// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:True,bamd:0,cgin:,lico:0,lgpr:1,limd:0,spmd:1,trmd:1,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:True,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:34539,y:32702,varname:node_3138,prsc:2|emission-5987-OUT,olwid-1902-OUT,olcol-2676-RGB;n:type:ShaderForge.SFN_Slider,id:6729,x:31275,y:33253,ptovrint:False,ptlb:TimeLine,ptin:_TimeLine,varname:node_6729,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:10;n:type:ShaderForge.SFN_Multiply,id:4762,x:31680,y:33245,varname:node_4762,prsc:2|A-6729-OUT,B-6729-OUT,C-9187-OUT;n:type:ShaderForge.SFN_Vector1,id:9187,x:31680,y:33394,varname:node_9187,prsc:2,v1:0.2;n:type:ShaderForge.SFN_Set,id:9559,x:31854,y:33245,varname:Out_timeLine,prsc:2|IN-4762-OUT;n:type:ShaderForge.SFN_Get,id:3117,x:31259,y:32975,varname:node_3117,prsc:2|IN-9559-OUT;n:type:ShaderForge.SFN_Vector1,id:8104,x:31259,y:33030,varname:node_8104,prsc:2,v1:4;n:type:ShaderForge.SFN_Divide,id:6728,x:31505,y:32984,varname:node_6728,prsc:2|A-3117-OUT,B-8104-OUT;n:type:ShaderForge.SFN_ConstantClamp,id:3718,x:31713,y:32984,varname:node_3718,prsc:2,min:1,max:8|IN-6728-OUT;n:type:ShaderForge.SFN_Vector1,id:7323,x:31949,y:33145,varname:node_7323,prsc:2,v1:5;n:type:ShaderForge.SFN_Power,id:6132,x:31949,y:32984,varname:node_6132,prsc:2|VAL-3718-OUT,EXP-7323-OUT;n:type:ShaderForge.SFN_Append,id:8190,x:32186,y:32985,varname:node_8190,prsc:2|A-6132-OUT,B-9450-OUT;n:type:ShaderForge.SFN_Get,id:9450,x:32186,y:33134,varname:node_9450,prsc:2|IN-9559-OUT;n:type:ShaderForge.SFN_Multiply,id:3982,x:32187,y:32836,varname:node_3982,prsc:2|A-3182-OUT,B-8190-OUT;n:type:ShaderForge.SFN_ComponentMask,id:7384,x:32453,y:32837,varname:node_7384,prsc:2,cc1:1,cc2:-1,cc3:-1,cc4:-1|IN-3982-OUT;n:type:ShaderForge.SFN_Length,id:6368,x:32187,y:32679,varname:node_6368,prsc:2|IN-3982-OUT;n:type:ShaderForge.SFN_OneMinus,id:8750,x:32359,y:32679,varname:node_8750,prsc:2|IN-6368-OUT;n:type:ShaderForge.SFN_RemapRange,id:9505,x:32814,y:32680,varname:node_9505,prsc:2,frmn:0.5,frmx:1,tomn:0,tomx:1|IN-8750-OUT;n:type:ShaderForge.SFN_Length,id:1090,x:32442,y:32996,varname:node_1090,prsc:2|IN-7384-OUT;n:type:ShaderForge.SFN_OneMinus,id:5597,x:32634,y:32996,varname:node_5597,prsc:2|IN-1090-OUT;n:type:ShaderForge.SFN_Power,id:2204,x:32813,y:32996,varname:node_2204,prsc:2|VAL-5597-OUT,EXP-7922-OUT;n:type:ShaderForge.SFN_Vector1,id:7922,x:32813,y:33126,varname:node_7922,prsc:2,v1:5;n:type:ShaderForge.SFN_Add,id:3886,x:33052,y:32831,varname:node_3886,prsc:2|A-9505-OUT,B-2204-OUT;n:type:ShaderForge.SFN_RemapRange,id:664,x:33237,y:32831,varname:node_664,prsc:2,frmn:0.1,frmx:0.2,tomn:0,tomx:1|IN-3886-OUT;n:type:ShaderForge.SFN_Clamp01,id:9533,x:33413,y:32831,varname:node_9533,prsc:2|IN-664-OUT;n:type:ShaderForge.SFN_Lerp,id:4268,x:33643,y:32809,varname:node_4268,prsc:2|A-5136-OUT,B-9533-OUT,T-1892-OUT;n:type:ShaderForge.SFN_Floor,id:5347,x:33224,y:33055,varname:node_5347,prsc:2|IN-8321-OUT;n:type:ShaderForge.SFN_Get,id:8321,x:33203,y:33224,varname:node_8321,prsc:2|IN-9559-OUT;n:type:ShaderForge.SFN_Clamp01,id:1892,x:33413,y:33055,varname:node_1892,prsc:2|IN-5347-OUT;n:type:ShaderForge.SFN_RemapRange,id:3182,x:31505,y:32828,varname:node_3182,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-7121-OUT;n:type:ShaderForge.SFN_TexCoord,id:9018,x:30840,y:32149,varname:node_9018,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_TexCoord,id:9720,x:30840,y:32302,varname:node_9720,prsc:2,uv:1,uaff:False;n:type:ShaderForge.SFN_Lerp,id:9268,x:31143,y:32204,varname:node_9268,prsc:2|A-9018-UVOUT,B-9720-UVOUT,T-3147-OUT;n:type:ShaderForge.SFN_Slider,id:3147,x:31065,y:32389,ptovrint:False,ptlb:Switch_Distortion,ptin:_Switch_Distortion,varname:node_3147,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_ComponentMask,id:7121,x:31500,y:32205,varname:node_7121,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-9268-OUT;n:type:ShaderForge.SFN_Set,id:7599,x:31496,y:32390,varname:UCoordinateUCoordinate,prsc:2|IN-7121-R;n:type:ShaderForge.SFN_Set,id:2118,x:31496,y:32443,varname:VCoordinate,prsc:2|IN-7121-G;n:type:ShaderForge.SFN_Multiply,id:1279,x:31496,y:32074,varname:node_1279,prsc:2|A-4585-OUT,B-7121-OUT,C-9917-OUT;n:type:ShaderForge.SFN_Vector1,id:4585,x:31485,y:31988,varname:node_4585,prsc:2,v1:10;n:type:ShaderForge.SFN_ValueProperty,id:9917,x:31258,y:32108,ptovrint:False,ptlb:Noise_Size,ptin:_Noise_Size,varname:node_9917,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:9;n:type:ShaderForge.SFN_Floor,id:66,x:31853,y:32072,varname:node_66,prsc:2|IN-1279-OUT;n:type:ShaderForge.SFN_Add,id:6781,x:31853,y:31945,varname:node_6781,prsc:2|A-2376-OUT,B-66-OUT,C-4505-OUT;n:type:ShaderForge.SFN_Get,id:2376,x:31832,y:31877,varname:node_2376,prsc:2|IN-9559-OUT;n:type:ShaderForge.SFN_Slider,id:4505,x:31608,y:31687,ptovrint:False,ptlb:Idle_Noise,ptin:_Idle_Noise,varname:node_4505,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.2753656,max:1;n:type:ShaderForge.SFN_Noise,id:9819,x:32336,y:31946,varname:node_9819,prsc:2|XY-6781-OUT;n:type:ShaderForge.SFN_Ceil,id:8090,x:32141,y:32159,varname:node_8090,prsc:2|IN-1819-OUT;n:type:ShaderForge.SFN_Get,id:1819,x:32120,y:32313,varname:node_1819,prsc:2|IN-9559-OUT;n:type:ShaderForge.SFN_Clamp01,id:2381,x:32141,y:32380,varname:node_2381,prsc:2|IN-7585-OUT;n:type:ShaderForge.SFN_Get,id:7585,x:32120,y:32536,varname:node_7585,prsc:2|IN-9559-OUT;n:type:ShaderForge.SFN_Clamp01,id:5846,x:32336,y:32159,varname:node_5846,prsc:2|IN-8090-OUT;n:type:ShaderForge.SFN_Multiply,id:3353,x:32521,y:32030,varname:node_3353,prsc:2|A-9819-OUT,B-5846-OUT;n:type:ShaderForge.SFN_OneMinus,id:5866,x:32744,y:32030,varname:node_5866,prsc:2|IN-3353-OUT;n:type:ShaderForge.SFN_Multiply,id:9386,x:32514,y:32288,varname:node_9386,prsc:2|A-2381-OUT,B-2381-OUT;n:type:ShaderForge.SFN_Add,id:9280,x:32954,y:32030,varname:node_9280,prsc:2|A-5866-OUT,B-9386-OUT;n:type:ShaderForge.SFN_Multiply,id:6949,x:33303,y:32008,varname:node_6949,prsc:2|A-5402-OUT,B-9280-OUT,C-2144-OUT;n:type:ShaderForge.SFN_OneMinus,id:6298,x:32514,y:32450,varname:node_6298,prsc:2|IN-2381-OUT;n:type:ShaderForge.SFN_Step,id:2144,x:33273,y:32427,varname:node_2144,prsc:2|A-1959-OUT,B-6298-OUT;n:type:ShaderForge.SFN_RemapRange,id:7413,x:32849,y:32223,varname:node_7413,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-2165-OUT;n:type:ShaderForge.SFN_Get,id:2165,x:32849,y:32403,varname:node_2165,prsc:2|IN-2118-OUT;n:type:ShaderForge.SFN_Abs,id:1959,x:33028,y:32223,varname:node_1959,prsc:2|IN-7413-OUT;n:type:ShaderForge.SFN_Clamp01,id:5136,x:33584,y:32007,varname:node_5136,prsc:2|IN-6949-OUT;n:type:ShaderForge.SFN_Add,id:5402,x:33293,y:31705,varname:node_5402,prsc:2|A-1822-OUT,B-2327-R;n:type:ShaderForge.SFN_Tex2d,id:2327,x:33006,y:31706,ptovrint:False,ptlb:Texture_Tv,ptin:_Texture_Tv,varname:node_2327,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:8d8f3e08e7a57b143ab4734418410328,ntxv:0,isnm:False|UVIN-9180-OUT;n:type:ShaderForge.SFN_Multiply,id:1822,x:33293,y:31484,varname:node_1822,prsc:2|A-9529-OUT,B-1884-OUT;n:type:ShaderForge.SFN_Relay,id:1884,x:32330,y:31504,varname:node_1884,prsc:2|IN-9819-OUT;n:type:ShaderForge.SFN_Append,id:9180,x:32721,y:31685,varname:node_9180,prsc:2|A-7083-OUT,B-8929-OUT;n:type:ShaderForge.SFN_Get,id:8929,x:32690,y:31829,varname:node_8929,prsc:2|IN-2118-OUT;n:type:ShaderForge.SFN_Add,id:7083,x:32711,y:31555,varname:node_7083,prsc:2|A-2559-OUT,B-1847-OUT;n:type:ShaderForge.SFN_Get,id:1847,x:32690,y:31492,varname:node_1847,prsc:2|IN-7599-OUT;n:type:ShaderForge.SFN_Multiply,id:2559,x:32711,y:31333,varname:node_2559,prsc:2|A-3824-OUT,B-4345-OUT,C-1847-OUT,D-9786-OUT;n:type:ShaderForge.SFN_Step,id:9786,x:32383,y:31396,varname:node_9786,prsc:2|A-7195-OUT,B-6240-OUT;n:type:ShaderForge.SFN_Sin,id:3824,x:32699,y:31076,varname:node_3824,prsc:2|IN-5540-OUT;n:type:ShaderForge.SFN_Vector1,id:4345,x:32529,y:31355,varname:node_4345,prsc:2,v1:1;n:type:ShaderForge.SFN_Vector1,id:6240,x:32383,y:31548,varname:node_6240,prsc:2,v1:0.03;n:type:ShaderForge.SFN_Noise,id:7195,x:32121,y:31397,varname:node_7195,prsc:2|XY-5872-OUT;n:type:ShaderForge.SFN_Append,id:5872,x:31940,y:31397,varname:node_5872,prsc:2|A-9701-OUT,B-9701-OUT;n:type:ShaderForge.SFN_Relay,id:9701,x:31791,y:31392,varname:node_9701,prsc:2|IN-3025-OUT;n:type:ShaderForge.SFN_Vector1,id:2373,x:31769,y:31148,varname:node_2373,prsc:2,v1:100;n:type:ShaderForge.SFN_Get,id:8856,x:31759,y:31037,varname:node_8856,prsc:2|IN-2118-OUT;n:type:ShaderForge.SFN_Multiply,id:6637,x:31780,y:30891,varname:node_6637,prsc:2|A-7326-OUT,B-8856-OUT;n:type:ShaderForge.SFN_Multiply,id:964,x:31769,y:31239,varname:node_964,prsc:2|A-2373-OUT,B-9701-OUT;n:type:ShaderForge.SFN_Add,id:5540,x:32088,y:31069,varname:node_5540,prsc:2|A-6637-OUT,B-964-OUT;n:type:ShaderForge.SFN_Abs,id:7580,x:32699,y:30912,varname:node_7580,prsc:2|IN-3824-OUT;n:type:ShaderForge.SFN_Multiply,id:2062,x:32891,y:30892,varname:node_2062,prsc:2|A-2596-OUT,B-7580-OUT;n:type:ShaderForge.SFN_OneMinus,id:7463,x:33293,y:30890,varname:node_7463,prsc:2|IN-2062-OUT;n:type:ShaderForge.SFN_Clamp01,id:7572,x:33290,y:31167,varname:node_7572,prsc:2|IN-7463-OUT;n:type:ShaderForge.SFN_Clamp,id:9529,x:33293,y:30683,varname:node_9529,prsc:2|IN-7019-OUT,MIN-2492-OUT,MAX-9812-OUT;n:type:ShaderForge.SFN_Vector1,id:9812,x:33293,y:30830,varname:node_9812,prsc:2,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:2492,x:33280,y:30617,ptovrint:False,ptlb:Noise_Vis,ptin:_Noise_Vis,varname:node_2492,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.15;n:type:ShaderForge.SFN_Multiply,id:7019,x:33579,y:31481,varname:node_7019,prsc:2|A-7572-OUT,B-1884-OUT;n:type:ShaderForge.SFN_Multiply,id:5987,x:33955,y:32791,varname:node_5987,prsc:2|A-3062-RGB,B-4268-OUT,C-5297-OUT,D-1009-A;n:type:ShaderForge.SFN_ValueProperty,id:5297,x:33955,y:32949,ptovrint:False,ptlb:Color_Mult,ptin:_Color_Mult,varname:node_5297,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:3;n:type:ShaderForge.SFN_Color,id:3062,x:33955,y:32557,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_3062,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.09987804,c2:0.3490566,c3:0,c4:1;n:type:ShaderForge.SFN_VertexColor,id:1009,x:33955,y:33119,varname:node_1009,prsc:2;n:type:ShaderForge.SFN_Time,id:4308,x:31066,y:31200,varname:node_4308,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:4843,x:31300,y:31585,ptovrint:False,ptlb:Time_ANimation,ptin:_Time_ANimation,varname:node_4843,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:20;n:type:ShaderForge.SFN_Add,id:3025,x:31536,y:31498,varname:node_3025,prsc:2|A-4308-TSL,B-4505-OUT,C-4843-OUT;n:type:ShaderForge.SFN_Set,id:5627,x:31277,y:31689,varname:time_A,prsc:2|IN-4843-OUT;n:type:ShaderForge.SFN_ValueProperty,id:3788,x:33788,y:33388,ptovrint:False,ptlb:Out_Line,ptin:_Out_Line,varname:node_3788,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.2;n:type:ShaderForge.SFN_Color,id:2676,x:34204,y:33537,ptovrint:False,ptlb:Outline_color,ptin:_Outline_color,varname:node_2676,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_SwitchProperty,id:1902,x:34129,y:33324,ptovrint:False,ptlb:Outline,ptin:_Outline,varname:node_1902,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-1764-OUT,B-3788-OUT;n:type:ShaderForge.SFN_Vector1,id:1764,x:33788,y:33258,varname:node_1764,prsc:2,v1:0;n:type:ShaderForge.SFN_Slider,id:2596,x:32757,y:30723,ptovrint:False,ptlb:,ptin:_,varname:node_2596,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1.923077,max:5;n:type:ShaderForge.SFN_ValueProperty,id:7326,x:31804,y:30635,ptovrint:False,ptlb:Lines_Amount,ptin:_Lines_Amount,varname:node_7326,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:10;proporder:2327-6729-3147-9917-4505-2596-7326-2492-3062-5297-4843-3788-2676-1902;pass:END;sub:END;*/

Shader "Shader Forge/tvEffect" {
    Properties {
        _Texture_Tv ("Texture_Tv", 2D) = "white" {}
        _TimeLine ("TimeLine", Range(0, 10)) = 0
        _Switch_Distortion ("Switch_Distortion", Range(0, 1)) = 0
        _Noise_Size ("Noise_Size", Float ) = 9
        _Idle_Noise ("Idle_Noise", Range(0, 1)) = 0.2753656
        _ ("", Range(0, 5)) = 1.923077
        _Lines_Amount ("Lines_Amount", Float ) = 10
        _Noise_Vis ("Noise_Vis", Float ) = 0.15
        _Color ("Color", Color) = (0.09987804,0.3490566,0,1)
        _Color_Mult ("Color_Mult", Float ) = 3
        _Time_ANimation ("Time_ANimation", Float ) = 20
        _Out_Line ("Out_Line", Float ) = 0.2
        _Outline_color ("Outline_color", Color) = (0,0,0,1)
        [MaterialToggle] _Outline ("Outline", Float ) = 0
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
            "CanUseSpriteAtlas"="True"
        }
        Pass {
            Name "Outline"
            Tags {
            }
            Cull Front
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float _Out_Line;
            uniform float4 _Outline_color;
            uniform fixed _Outline;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.pos = UnityObjectToClipPos( float4(v.vertex.xyz + v.normal*lerp( 0.0, _Out_Line, _Outline ),1) );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                return fixed4(_Outline_color.rgb,0);
            }
            ENDCG
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            AlphaToMask On
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float _TimeLine;
            uniform float _Switch_Distortion;
            uniform float _Noise_Size;
            uniform float _Idle_Noise;
            uniform sampler2D _Texture_Tv; uniform float4 _Texture_Tv_ST;
            uniform float _Noise_Vis;
            uniform float _Color_Mult;
            uniform float4 _Color;
            uniform float _Time_ANimation;
            uniform float _;
            uniform float _Lines_Amount;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
                float2 texcoord1 : TEXCOORD1;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float2 uv1 : TEXCOORD1;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.uv1 = v.texcoord1;
                o.vertexColor = v.vertexColor;
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float2 node_7121 = lerp(i.uv0,i.uv1,_Switch_Distortion).rg;
                float VCoordinate = node_7121.g;
                float4 node_4308 = _Time;
                float node_9701 = (node_4308.r+_Idle_Noise+_Time_ANimation);
                float node_3824 = sin(((_Lines_Amount*VCoordinate)+(100.0*node_9701)));
                float Out_timeLine = (_TimeLine*_TimeLine*0.2);
                float2 node_6781 = (Out_timeLine+floor((10.0*node_7121*_Noise_Size))+_Idle_Noise);
                float2 node_9819_skew = node_6781 + 0.2127+node_6781.x*0.3713*node_6781.y;
                float2 node_9819_rnd = 4.789*sin(489.123*(node_9819_skew));
                float node_9819 = frac(node_9819_rnd.x*node_9819_rnd.y*(1+node_9819_skew.x));
                float node_1884 = node_9819;
                float UCoordinateUCoordinate = node_7121.r;
                float node_1847 = UCoordinateUCoordinate;
                float2 node_5872 = float2(node_9701,node_9701);
                float2 node_7195_skew = node_5872 + 0.2127+node_5872.x*0.3713*node_5872.y;
                float2 node_7195_rnd = 4.789*sin(489.123*(node_7195_skew));
                float node_7195 = frac(node_7195_rnd.x*node_7195_rnd.y*(1+node_7195_skew.x));
                float2 node_9180 = float2(((node_3824*1.0*node_1847*step(node_7195,0.03))+node_1847),VCoordinate);
                float4 _Texture_Tv_var = tex2D(_Texture_Tv,TRANSFORM_TEX(node_9180, _Texture_Tv));
                float node_2381 = saturate(Out_timeLine);
                float2 node_3982 = ((node_7121*2.0+-1.0)*float2(pow(clamp((Out_timeLine/4.0),1,8),5.0),Out_timeLine));
                float3 emissive = (_Color.rgb*lerp(saturate((((clamp((saturate((1.0 - (_*abs(node_3824))))*node_1884),_Noise_Vis,1.0)*node_1884)+_Texture_Tv_var.r)*((1.0 - (node_9819*saturate(ceil(Out_timeLine))))+(node_2381*node_2381))*step(abs((VCoordinate*2.0+-1.0)),(1.0 - node_2381)))),saturate(((((1.0 - length(node_3982))*2.0+-1.0)+pow((1.0 - length(node_3982.g)),5.0))*10.0+-1.0)),saturate(floor(Out_timeLine)))*_Color_Mult*i.vertexColor.a);
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
