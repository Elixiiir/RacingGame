Shader "Custom/CarColorWithOverlay"
{
    Properties
    {
        _Color ("Base Color", Color) = (1,1,1,1)
        _OverlayTex ("Overlay Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Standard

        sampler2D _OverlayTex;
        fixed4 _Color;

        struct Input
        {
            float2 uv_OverlayTex;
        };

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 overlay = tex2D(_OverlayTex, IN.uv_OverlayTex);
            // Альфа текстуры влияет на силу наложения поверх цвета
            fixed3 finalColor = lerp(_Color.rgb, overlay.rgb, overlay.a);

            o.Albedo = finalColor;
            o.Alpha = 1;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
