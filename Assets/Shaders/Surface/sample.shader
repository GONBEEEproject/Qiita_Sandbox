Shader "Custom/sample"
{
    Properties{
        _BaseColor("Base Color",COLOR)=(1,1,1,1)
        _Alpha("Alpha",Range(0,1))=1
        _Ice("Ice",Float)=1
    }
    SubShader{
        Tags{"Queue"="Transparent"}
        LOD 200

        CGPROGRAM
        #pragma surface surf Standard alpha:fade
        #pragma target 3.0

        struct Input{
            float3 worldNormal;
            float3 viewDir;
            float2 uv_MainTex;
        };

        fixed4 _BaseColor;
        float _Alpha;
        float _Ice;

        void surf(Input IN,inout SurfaceOutputStandard o)
        {
            o.Albedo = _BaseColor.rgb;
            float alpha=1-(abs(dot(IN.viewDir,IN.worldNormal)));
            o.Alpha=alpha*_Ice;
        }
        ENDCG


    }
    FallBack "Diffuse"
}
