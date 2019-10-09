Shader "Custom/Rim"
{
    Properties{
        _MainColor("Main Color",COLOR)=(1,1,1,1)
        _RimColor("Rim Color",Color)=(1,1,1,1)
}

    SubShader{
        Tags{"RenderType"="Opaque"}
        LOD 200

        CGPROGRAM
        #pragma surface surf Standard
        #pragma target 3.0

        struct Input{
            float2 uv_MainTex;
            float3 worldNormal;
            float3 viewDir;
        };

        fixed4 _MainColor;
        fixed4 _RimColor;


        void surf(Input IN,inout SurfaceOutputStandard o)
        {
            fixed4 baseColor = _MainColor;
            fixed4 rimColor= _RimColor;

            o.Albedo=baseColor;
            float rim=1-saturate(dot(IN.viewDir,o.Normal));
            o.Emission =rimColor*pow(rim,3);
        }
        ENDCG

    }
    FallBack "Diffuse"
}