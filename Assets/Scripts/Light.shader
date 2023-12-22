Shader "Custom/Light"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" { }
        _Radius ("Radius", Range(0, 1)) = 0.5
        _FadePower ("Fade Power", Range(0, 10)) = 2
    }

    SubShader
    {
        Tags { "Queue" = "Overlay" }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 pos : POSITION;
                float2 uv : TEXCOORD0;
            };

            sampler2D _MainTex;
            fixed _Radius;
            fixed _FadePower;

            v2f vert(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.vertex.xy; // Pass UV as position for a 2D effect
                return o;
            }

            fixed4 frag(v2f i) : COLOR
            {
                // Calculate distance from the center
                fixed d = distance(i.uv, 0.5);

                // Calculate alpha based on distance and fade power
                fixed alpha = 1.0 - pow(saturate(d / _Radius), _FadePower);

                // Use the texture as color with calculated alpha
                fixed4 col = (d, d, d, 1);//tex2D(_MainTex, i.uv);
                col.a = d;

                return col;
            }
            ENDCG
        }
    }

    FallBack "Diffuse"
}
