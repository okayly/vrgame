//-----------------------------------------------------------------------------
// Copyright 2015-2017 RenderHeads Ltd.  All rights reserverd.
//-----------------------------------------------------------------------------

#if defined (SHADERLAB_GLSL)
	#define HALF2 vec2
	#define HALF3 vec3
	#define HALF4 vec4
	#define FLOAT2 vec2
	#define FLOAT3 vec3
	#define FLOAT4 vec4
#else
	#define HALF2 half2
	#define HALF3 half3
	#define HALF4 half4
	#define FLOAT2 float2
	#define FLOAT3 float3
	#define FLOAT4 float4
#endif

inline bool IsStereoEyeLeft(FLOAT3 worldNosePosition, FLOAT3 worldCameraRight)
{
#if defined(UNITY_SINGLE_PASS_STEREO)
	// Unity 5.4 has this new variable
	return (unity_StereoEyeIndex == 0);
#else

#if UNITY_VERSION >= 500
	return (unity_CameraProjection[0][2] <= 0.0);
#else
	// worldNosePosition is the camera positon passed in from Unity via script
	// We need to determine whether _WorldSpaceCameraPos (Unity shader variable) is to the left or to the right of _cameraPosition
	float dRight = distance(worldNosePosition + worldCameraRight, _WorldSpaceCameraPos);
	float dLeft = distance(worldNosePosition - worldCameraRight, _WorldSpaceCameraPos);
	return (dRight > dLeft);
#endif
#endif
}

#if defined(STEREO_TOP_BOTTOM) | defined(STEREO_LEFT_RIGHT)
FLOAT4 GetStereoScaleOffset(bool isLeftEye)
{
	FLOAT2 scale = FLOAT2(1.0, 1.0);
	FLOAT2 offset = FLOAT2(0.0, 0.0);

	// Top-Bottom
#if defined(STEREO_TOP_BOTTOM)

	scale.y = 0.5;
	offset.y = 0.0;

	if (!isLeftEye)
	{
		offset.y = 0.5;
	}

	// UNITY_UV_STARTS_AT_TOP is for directx
#if !defined(SHADERLAB_GLSL) 
#if !defined(UNITY_UV_STARTS_AT_TOP)
	offset.y = 0.5 - offset.y;
#endif
#endif

	// Left-Right 
#elif defined(STEREO_LEFT_RIGHT)

	scale.x = 0.5;
	offset.x = 0.0;
	if (!isLeftEye)
	{
		offset.x = 0.5;
	}

#endif

	return FLOAT4(scale, offset);
}
#endif

#if defined(STEREO_DEBUG)
inline FLOAT4 GetStereoDebugTint(bool isLeftEye)
{
	FLOAT4 tint = FLOAT4(1.0, 1.0, 1.0, 1.0);

#if defined(STEREO_TOP_BOTTOM) | defined(STEREO_LEFT_RIGHT)
	FLOAT4 leftEyeColor = FLOAT4(0.0, 1.0, 0.0, 1.0);		// green
	FLOAT4 rightEyeColor = FLOAT4(1.0, 0.0, 0.0, 1.0);		// red

	if (isLeftEye)
	{
		tint = leftEyeColor;
	}
	else
	{
		tint = rightEyeColor;
	}
#endif

#if defined(UNITY_UV_STARTS_AT_TOP)
	tint.b = 0.5;
#endif

	return tint;
}
#endif

FLOAT2 ScaleZoomToFit(float targetWidth, float targetHeight, float sourceWidth, float sourceHeight)
{
#if defined(ALPHAPACK_TOP_BOTTOM)
	sourceHeight *= 0.5;
#elif defined(ALPHAPACK_LEFT_RIGHT)
	sourceWidth *= 0.5;
#endif
	float targetAspect = targetHeight / targetWidth;
	float sourceAspect = sourceHeight / sourceWidth;
	FLOAT2 scale = FLOAT2(1.0, sourceAspect / targetAspect);
	if (targetAspect < sourceAspect)
	{
		scale = FLOAT2(targetAspect / sourceAspect, 1.0);
	}
	return scale;
}

FLOAT4 OffsetAlphaPackingUV(FLOAT2 texelSize, FLOAT2 uv, bool flipVertical)
{
	FLOAT4 result = uv.xyxy;

	// We don't want bilinear interpolation to cause bleeding
	// when reading the pixels at the edge of the packed areas.
	// So we shift the UV's by a fraction of a pixel so the edges don't get sampled.

#if defined(ALPHAPACK_TOP_BOTTOM)
	float offset = texelSize.y * 1.5;
	result.y = lerp(0.0 + offset, 0.5 - offset, uv.y);
	result.w = result.y + 0.5;

	if (flipVertical)
	{
		// Flip vertically (and offset to put back in 0..1 range)
		result.yw = 1.0 - result.yw;
		result.yw = result.wy;
	}
	else
	{
#if !defined(UNITY_UV_STARTS_AT_TOP)
		// For opengl we flip
		result.yw = result.wy;
#endif
	}

#elif defined(ALPHAPACK_LEFT_RIGHT)
	float offset = texelSize.x * 1.5;
	result.x = lerp(0.0 + offset, 0.5 - offset, uv.x);
	result.z = result.x + 0.5;

	if (flipVertical)
	{
		// Flip vertically (and offset to put back in 0..1 range)
		result.yw = 1.0 - result.yw;
	}

#else

	if (flipVertical)
	{
		// Flip vertically (and offset to put back in 0..1 range)
		result.yw = 1.0 - result.yw;
	}

#endif

	return result;
}


// http://entropymine.com/imageworsener/srgbformula/
HALF3 GammaToLinear(HALF3 col)
{
#if defined(CHEAP_GAMMATOLINEAR)
#if defined (SHADERLAB_GLSL)
	return pow(col, 2.2);
#else
	// Approximate version from http://chilliant.blogspot.com.au/2012/08/srgb-approximations-for-hlsl.html?m=1
	return col * (col * (col * 0.305306011h + 0.682171111h) + 0.012522878h);
#endif
#else
	if (col.r <= 0.04045)
		col.r = col.r / 12.92;
	else
		col.r = pow((col.r + 0.055) / 1.055, 2.4);

	if (col.g <= 0.04045)
		col.g = col.g / 12.92;
	else
		col.g = pow((col.g + 0.055) / 1.055, 2.4);

	if (col.b <= 0.04045)
		col.b = col.b / 12.92;
	else
		col.b = pow((col.b + 0.055) / 1.055, 2.4);
#endif
	return col;
}