Shader "Custom/Fog"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }

    SubShader
    {
        Pass
        {
            HLSLPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct VertData
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            v2f vert(VertData IN)
            {
                v2f OUT;
                OUT.vertex = UnityObjectToClipPos(IN.vertex);
                OUT.uv = IN.uv;
                return OUT;
            }

            sampler2D _MainTex, _CameraDepthTexture;
            float4 _FogColor;
            float _FogDensity, _FogOffset;

            float4 frag(v2f IN) : SV_Target
            {
                int x, y;
                float4 col = tex2D(_MainTex, IN.uv);
                float depth = SAMPLE_DEPTH_TEXTURE(_CameraDepthTexture, IN.uv);
                depth = Linear01Depth(depth);

                float viewDistance = depth * _ProjectionParams.z;

                float fogFactor = (_FogDensity / sqrt(log(2))) * max(0.0f, viewDistance - _FogOffset);
                fogFactor = exp2(-fogFactor * fogFactor);

                float4 fogOutput = lerp(_FogColor, col, saturate(fogFactor));

                return fogOutput;
            }
            ENDHLSL
        }
    }
}
