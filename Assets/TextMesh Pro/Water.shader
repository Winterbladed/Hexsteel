Shader "Custom/MovingTextureLitShader"
{
    Properties
    {
        _MainTex ("Albedo (Texture)", 2D) = "white" {}
        _Color ("Albedo Color", Color) = (1,1,1,1)
        _NormalMap ("Normal Map", 2D) = "bump" {}
        _Smoothness ("Smoothness", Range(0,1)) = 0.5
        _Speed ("Speed", Float) = 1.0
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float3 normal : TEXCOORD1;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _Color;
            sampler2D _NormalMap;
            float _Smoothness;
            float _Speed;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float2 offsetUV = i.uv + float2(_Time.y * _Speed, _Time.y * _Speed);
                fixed4 albedo = tex2D(_MainTex, offsetUV) * _Color;
                fixed4 normalTex = tex2D(_NormalMap, i.uv);
                float3 normal = UnpackNormal(normalTex);
                float smoothness = _Smoothness;
                
                // For simplicity, return albedo combined with normal and smoothness
                return fixed4(albedo.rgb * (1.0 - smoothness), albedo.a);
            }
            ENDCG
        }
    }

    FallBack "Diffuse"
}