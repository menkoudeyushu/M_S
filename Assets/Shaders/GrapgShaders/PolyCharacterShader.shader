Shader "Unlit/PolyCharacterShader"
{
    Properties
    {
        _Color_Primary("Color_Primary", Color) = (0.2431373,0.4196079,0.6196079,0)
		_Color_Secondary("Color_Secondary", Color) = (0.8196079,0.6431373,0.2980392,0)
		_Color_Leather_Primary("Color_Leather_Primary", Color) = (0.282353,0.2078432,0.1647059,0)
		_Color_Metal_Primary("Color_Metal_Primary", Color) = (0.5960785,0.6117647,0.627451,0)
		_Color_Leather_Secondary("Color_Leather_Secondary", Color) = (0.372549,0.3294118,0.2784314,0)
		_Color_Metal_Dark("Color_Metal_Dark", Color) = (0.1764706,0.1960784,0.2156863,0)
		_Color_Metal_Secondary("Color_Metal_Secondary", Color) = (0.345098,0.3764706,0.3960785,0)
		_Color_Hair("Color_Hair", Color) = (0.2627451,0.2117647,0.1333333,0)
		_Color_Skin("Color_Skin", Color) = (1,0.8000001,0.682353,1)
		_Color_Stubble("Color_Stubble", Color) = (0.8039216,0.7019608,0.6313726,1)
		_Color_Scar("Color_Scar", Color) = (0.9294118,0.6862745,0.5921569,1)
		_Color_BodyArt("Color_BodyArt", Color) = (0.2283196,0.5822246,0.7573529,1)
		[HideInInspector]_Texture_Color_Metal_Primary("Texture_Color_Metal_Primary", 2D) = "white" {}
		_Texture("Texture", 2D) = "white" {}
		[HideInInspector]_Texture_Base_Secondary("Texture_Base_Secondary", 2D) = "white" {}
		[HideInInspector]_Texture_Metal_Secondary("Texture_Metal_Secondary", 2D) = "white" {}
		[HideInInspector]_Texture_Color_Metal_Dark("Texture_Color_Metal_Dark", 2D) = "white" {}
		[HideInInspector]_Texture_BodyArt("Texture_BodyArt", 2D) = "white" {}
		[HideInInspector]_Mask_Primary("Mask_Primary", 2D) = "white" {}
		[HideInInspector]_Mask_Secondary("Mask_Secondary", 2D) = "white" {}
		[HideInInspector]_Texture_Base_Primary("Texture_Base_Primary", 2D) = "white" {}
		[HideInInspector]_Texture_Hair("Texture_Hair", 2D) = "white" {}
		[HideInInspector]_Texture_Skin("Texture_Skin", 2D) = "white" {}
		[HideInInspector]_Texture_Stubble("Texture_Stubble", 2D) = "white" {}
		[HideInInspector]_Texture_Scar("Texture_Scar", 2D) = "white" {}
		_Smoothness("Smoothness", Range( 0 , 1)) = 0
		_BodyArt_Amount("BodyArt_Amount", Range( 0 , 1)) = 0
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
    }
    SubShader
    {
        Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry" }
        Cull Back
        HLSLINCLUDE
           #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"   
         CBUFFER_START(UnityPerMaterial)

			uniform float4 _Color_BodyArt;
			uniform float4 _Color_Primary;
			uniform sampler2D _Mask_Primary;
			uniform float4 _Mask_Primary_ST;
			uniform float4 _Color_Secondary;
			uniform sampler2D _Mask_Secondary;
			uniform float4 _Mask_Secondary_ST;
			uniform float4 _Color_Leather_Primary;
			uniform sampler2D _Texture_Base_Primary;
			uniform float4 _Texture_Base_Primary_ST;
			uniform float4 _Color_Leather_Secondary;
			uniform sampler2D _Texture_Base_Secondary;
			uniform float4 _Texture_Base_Secondary_ST;
			uniform float4 _Color_Metal_Primary;
			uniform sampler2D _Texture_Color_Metal_Primary;
			uniform float4 _Texture_Color_Metal_Primary_ST;
			uniform float4 _Color_Metal_Secondary;
			uniform sampler2D _Texture_Metal_Secondary;
			uniform float4 _Texture_Metal_Secondary_ST;
			uniform float4 _Color_Metal_Dark;
			uniform sampler2D _Texture_Color_Metal_Dark;
			uniform float4 _Texture_Color_Metal_Dark_ST;
			uniform float4 _Color_Hair;
			uniform sampler2D _Texture_Hair;
			uniform float4 _Texture_Hair_ST;
			uniform float4 _Color_Skin;
			uniform sampler2D _Texture_Skin;
			uniform float4 _Texture_Skin_ST;
			uniform float4 _Color_Stubble;
			uniform sampler2D _Texture_Stubble;
			uniform float4 _Texture_Stubble_ST;
			uniform float4 _Color_Scar;
			uniform sampler2D _Texture_Scar;
			uniform float4 _Texture_Scar_ST;
			uniform sampler2D _Texture_BodyArt;
			uniform float4 _Texture_BodyArt_ST;
			uniform float _BodyArt_Amount;
			uniform float _Smoothness;




         CBUFFER_END
        ENDHLSL
        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
			#pragma fragmentoption ARB_precision_hint_fastes

			TEXTURE2D(_Texture);
            SAMPLER(sampler_Texture);
            float4 _Texture_ST;

            struct Attributes
            {
                float4 positionOS : POSITION;
                float2 texcoord : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionHCS : SV_POSITION;
                float2 texcoord : TEXCOORD0;
                float4 color    : COLOR;
            };

            sampler2D _MainTex;

            Varyings vert (Attributes IN)
            {
                Varyings OUT;
                OUT.positionHCS = TransformObjectToHClip(IN.positionOS.xyz);
                OUT.texcoord = TRANSFORM_TEX(IN.texcoord, _Texture);
                return OUT;
            }

            float4 frag (Varyings IN) : SV_Target
            {
					
			
				return (1,1,1,1);
		

			

            }
            ENDHLSL
        }
    }
	Fallback "Diffuse"
}
