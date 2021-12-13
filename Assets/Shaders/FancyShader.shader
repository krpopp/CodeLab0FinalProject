// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "CodeLab0/FancyShader"
{
    Properties
    {
        [NoScaleOffset] _MainTex ("Texture", 2D) = "white" {}
        _Rand ("Rand", float) = 0.5
        _Noise ("RandPos", float) = 0.5
        _MouseX ("MousePos", float) = 0.5
    }
    
    SubShader
    {
        Pass
        {
            // indicate that our pass is the "base" pass in forward
            // rendering pipeline. It gets ambient and main directional
            // light data set up; light direction in _WorldSpaceLightPos0
            // and color in _LightColor0
            Tags {"LightMode"="ForwardBase"}
        
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc" // for UnityObjectToWorldNormal
            #include "UnityLightingCommon.cginc" // for _LightColor0
            
            // color from the material
            float _Rand;
            float _Noise;
            float _MouseX;
            
            struct v2f
            {
                float2 uv : TEXCOORD0;
                fixed4 diff : COLOR0; // diffuse lighting color
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata_base v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.texcoord;
                // get vertex normal in world space
                half3 worldNormal = UnityObjectToWorldNormal(v.normal);
                // dot product between normal and light direction for
                // standard diffuse (Lambert) lighting
                half nl = max(0, dot(worldNormal, _WorldSpaceLightPos0.xyz));
                // factor in the light color
                o.diff = nl * _LightColor0;
                
                int m = 1;
                if(v.vertex.y/v.vertex.x > 0){
                    m = -1;
                }
                o.vertex.x = o.vertex.x + _Noise * m; 
                o.vertex.y = o.vertex.y + _Noise * m; 
                
                return o;
            }
            
            sampler2D _MainTex;

            fixed4 frag (v2f i) : SV_Target
            {
                // sample texture
                fixed4 col = tex2D(_MainTex, i.uv);
                
                if(i.vertex.x>_MouseX && i.vertex.x<_MouseX+10)
                    col = fixed4(_Rand,0,1,1);
                
                // multiply by lighting
                col *= i.diff;
             
                
                return col;
            }
            ENDCG
        }
    }
}
