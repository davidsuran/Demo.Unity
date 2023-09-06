#ifndef CUSTOM_LIGHTING_INCLUDED
#define CUSTOM_LIGHTING_INCLUDED

struct CustomLightingData
{
	float3 normalWorldSpace;
	float3 albedo;
};

#ifndef SHADERGRAPH_PREVIEW
float3 CustomLightHanding(CustomLightingData data, Light light)
{
	float3 radiance = light.color;

	float diffuse = saturate(dot(data.normalWorldSpace, light.direction));

	float3 color = data.albedo * radiance * diffuse;

	return color;
}
#endif

float3 CalculateCustomLighting(CustomLightingData data)
{
#ifdef SHADERGRAPH_PREVIEW
	float3 lightDirection = float3(0.5, 0.5, 0);
	float intensity = saturate(dot(data.normalWorldSpace, lightDirection));

	return data.albedo * intensity;
#else
	Light mainLight = GetMainLight();

	float3 color = 0;

	color += CustomLightHanding(data, mainLight);

	return color;
#endif
}

void CalculateCustomLighting_float(float3 Albedo, float3 Normal,
	out float3 Color)
{
	CustomLightingData data;
	data.normalWorldSpace = Normal;
	data.albedo = Albedo;

	Color = CalculateCustomLighting(data);
}

#endif
