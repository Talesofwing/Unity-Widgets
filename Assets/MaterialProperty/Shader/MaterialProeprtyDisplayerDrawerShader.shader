Shader "_Custom/MaterialPropertyDrawerShader"
{
    Properties
    {
        [Toggle(ColorUsed)] _ColorUsed("Use Color", Float) = 0
        [MaterialPropertyDisplayer(_ColorUsed)] _Color("Color", Color) = (1, 1, 1, 1)
    }

    SubShader
    {
        Tags { "RenderType" = "Opaque" }

        Pass
        {
            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile _ ColorUsed

            #include "UnityCG.cginc"

            fixed4 _Color;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                #if ColorUsed
                    return _Color;
                #else
                    return fixed4(0, 0, 0, 1);
                #endif
            }

            ENDCG
        }
    }
}
