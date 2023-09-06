Shader "Battlefield/NoGoZoneShader"
{
    Properties
    {
         //[PerRendererData]
         _MainTex ("Texture", 2D) = "white" {}
        _Alpha ("Alpha", float) = 1.0
        _ShowDistance ("ShowDistance", float) = 100.0
        _Feather ("Feather", float) = 5.0
        _ActivePlayerPos ("ActivePlayerPos", Vector) = (0, 0, 0, 0)
        _Cutoff  ("Cutoff", Float) = 0.68
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" }
        //Tags { "SurfaceType"="Transparent" }
        //LOD 100
        Blend SrcAlpha OneMinusSrcAlpha
        
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            uniform float _ShowDistance;
            uniform float _Feather;
            uniform float4 _ActivePlayerPos;
            uniform float _Cutoff;

            struct vertexInput
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                                            float2 custom_uv : TEXCOORD0; // cannot start with "uv"
            };

            struct vertexOutput
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 pos : SV_POSITION;
                float3 worldPos : TEXCOORD1;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            vertexOutput vert (vertexInput v)
            {
                vertexOutput o;

                o.worldPos = mul (unity_ObjectToWorld, v.vertex);
                //o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);

                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.custom_uv, _MainTex);

                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }

            fixed4 frag (vertexOutput i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);

                float playerDistance = distance(i.worldPos, _ActivePlayerPos);
                clip(col.a - _Cutoff);

                float showCircle = _ShowDistance - playerDistance;

                                    //return col;

                if (showCircle - _Feather > 0)
                {
                    //col.a = saturate(all - _Feather);
                    col.a = 1;

                    return col;
                }
                else if (showCircle >= 0 & showCircle - _Feather <= 0)
                {
                    col.a = 1 - ((_Feather - showCircle) / _Feather);

                    //col.y = 2;
                    //col.a = 1;
                    return col;
                }
                else
                {
                    col.a = 0;
                    return col;
                }

                float alpha = (playerDistance - _ShowDistance);// / _Feather;
                //clip(alpha - _Cutoff);

                //alpha = alpha;
                alpha = saturate(alpha);

                alpha = 1 - alpha;

                col = fixed4(col.x, col.y, col.z, alpha);


                //if (playerDistance - (_ShowDistance - _Feather) <= 0)
                //{
                //    col = fixed4(col.x, col.y, col.z, alpha);
                //}
                //else
                //{
                //    col = fixed4(1, 1, col.z, _Alpha);
                //}
                                    //col = fixed4(0.5, 0.5, col.z, 0.1);


                // apply fog
                //UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
