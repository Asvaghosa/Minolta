// SampleApp.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <map>
#include "CMMISDK.h"
#include <Windows.h >
using namespace std;
#define STR(var) #var

void PerformMeasurement(char *in_com)
{
	int32_km instrumentNo;
	error_km ret;

	// Connect
	CMMISDK_Port Port = { '\0' };
	strncpy_s(Port.port_name, sizeof(Port.port_name), in_com, sizeof(Port.port_name));
	ret = CMMISDK_Connect(&Port, &instrumentNo);
	if ((ret != KmSuccess) && (ret != KmWarning))
	{
		printf("Error:%d CMMISDK_Connect\n", ret);
		return;
	}

	// Get instrumentInfo
	CMMISDK_InstrumentInfo instInfo = { 0 };
	ret = CMMISDK_GetInstrumentInfo(instrumentNo, &instInfo);
	if ((ret != KmSuccess) && (ret != KmWarning))
	{
		printf("Error:%d CMMISDK_GetInstrumentInfo\n", ret);
		CMMISDK_Disconnect(instrumentNo);
		return;
	}

	if (strcmp(instInfo.InstrumentName, "CM-25cG") != 0)
	{
		printf("Unsupported model\n");
		CMMISDK_Disconnect(instrumentNo);
		return;
	}

	// Set measurement mode (color & gloss)
	CMMISDK_MeasMode mode = MEASMODE_COLORANDGLOSS;
	ret = CMMISDK_SetMeasurementMode(instrumentNo, mode);
	if ((ret != KmSuccess) && (ret != KmWarning))
	{
		printf("Error:%d CMMISDK_SetMeasurementMode\n", ret);
		CMMISDK_Disconnect(instrumentNo);
		return;
	}

	// Check Calibration
	bool calComplete = false;
	do
	{
		CMMISDK_CalStatus calStatus;
		ret = CMMISDK_GetCalibrationStatus(instrumentNo, &calStatus);
		if ((ret != KmSuccess) && (ret != KmWarning))
		{
			printf("Error:%d CMMISDK_GetCalibrationStatus\n", ret);
			CMMISDK_Disconnect(instrumentNo);
			break;
		}

		switch (calStatus)
		{
		case StatusZero:
			// Zero calibration
			printf("Please set the zero calibration box.\n");
			system("pause");
			ret = CMMISDK_PerformZeroCalibration(instrumentNo);
			if ((ret != KmSuccess) && (ret != KmWarning))
			{
				printf("Error:%d CMMISDK_PerformZeroCalibration\n", ret);
				CMMISDK_Disconnect(instrumentNo);
			}
			break;

		case StatusWhite:
			// White calibration
			printf("Please set the white calibration box.\n");
			system("pause");
			ret = CMMISDK_PerformWhiteCalibration(instrumentNo);
			if ((ret != KmSuccess) && (ret != KmWarning))
			{
				printf("Error:%d CMMISDK_PerformWhiteCalibration\n", ret);
				CMMISDK_Disconnect(instrumentNo);
			}
			break;

		case StatusGloss:
			// Gloss calibration
			printf("Please set the gloss calibration box.\n");
			system("pause");
			ret = CMMISDK_PerformGlossCalibration(instrumentNo);
			if ((ret != KmSuccess) && (ret != KmWarning))
			{
				printf("Error:%d CMMISDK_PerformGlossCalibration\n", ret);
				CMMISDK_Disconnect(instrumentNo);
				return;
			}
			break;

		case StatusUser:
			// User calibration
			printf("Please set the user calibration box.\n");
			system("pause");
			ret = CMMISDK_PerformUserCalibration(instrumentNo);
			if ((ret != KmSuccess) && (ret != KmWarning))
			{
				printf("Error:%d CMMISDK_PerformUserCalibration\n", ret);
				CMMISDK_Disconnect(instrumentNo);
				return;
			}
			break;

		default:
			calComplete = true;
			break;
		}
	} while (!calComplete);

	// Perform measurement
	printf("Please set the sample plate.\n");
	system("pause");
	ret = CMMISDK_PerformMeasurement(instrumentNo);
	if ((ret != KmSuccess) && (ret != KmWarning))
	{
		printf("Error:%d CMMISDK_PerformMeasurement\n", ret);
		CMMISDK_Disconnect(instrumentNo);
		return;
	}

	// Polling measurement
	CMMISDK_MeasStatus measStatus;
	do
	{
		ret = CMMISDK_PollingMeasurement(instrumentNo, &measStatus);
		if ((ret != KmSuccess) && (ret != KmWarning))
		{
			printf("Error:%d CMMISDK_PollingMeasurement\n", ret);
			CMMISDK_Disconnect(instrumentNo);
			return;
		}
	} while (measStatus != Idling);

	// Get sample data
	ret = CMMISDK_LoadLatestData(instrumentNo);
	if ((ret != KmSuccess) && (ret != KmWarning))
	{
		printf("Error:%d CMMISDK_LoadLatestData\n", ret);
		CMMISDK_Disconnect(instrumentNo);
		return;
	}

	// Get sample colorimetric data
	CMMISDK_ColorCond cond;
	cond.obs = OBS_10;
	cond.ill = ILL_D65;
	cond.colorSpace = COLOR_LAB;
	CMMISDK_Data measurementColorData = { 0 };
	ret = CMMISDK_GetLatestDataColor(instrumentNo, CMMISDK_DataType::DATATYPE_SPEC, &cond, &measurementColorData);
	if ((ret != KmSuccess) && (ret != KmWarning))
	{
		printf("Error:%d CMMISDK_GetLatestDataColor\n", ret);
		CMMISDK_Disconnect(instrumentNo);
		return;
	}
	// Color data display
	printf("L*:%6.2f a*:%6.2f b*:%6.2f\n", measurementColorData.data[0], measurementColorData.data[1], measurementColorData.data[2]);

	// Get sample spectral data
	CMMISDK_Data measurementSpecData = { 0 };
	ret = CMMISDK_GetLatestDataSpec(instrumentNo, CMMISDK_DataType::DATATYPE_SPEC, &measurementSpecData);
	if ((ret != KmSuccess) && (ret != KmWarning))
	{
		printf("Error:%d CMMISDK_GetLatestDataSpec\n", ret);
	}

	// Spectral data display
	int count = 0;
	for (int32_km waveLength = instInfo.WaveLengthStart; waveLength <= instInfo.WaveLengthEnd; waveLength += instInfo.WaveLengthPitch)
	{
		printf("%3d :", waveLength);
		printf(" %6.2f", measurementSpecData.data[count]);
		printf("\n");
		count++;
	}

	// Get gloss data
	CMMISDK_Data measurementGlossData = { 0 };
	ret = CMMISDK_GetLatestDataSpec(instrumentNo, CMMISDK_DataType::DATATYPE_GLOSS, &measurementGlossData);
	if ((ret != KmSuccess) && (ret != KmWarning))
	{
		printf("Error:%d CMMISDK_GetLatestDataSpec\n", ret);
	}

	// Gloss data display
	printf("GLOSS %6.2f\n", measurementGlossData.data[0]);

	// Disconnect
	CMMISDK_Disconnect(instrumentNo);

	return;
}

void ReadSampleData(char* in_com)
{
	int32_km instrumentNo;

	// Connect
	CMMISDK_Port Port = { '\0' };
	strncpy_s(Port.port_name, sizeof(Port.port_name), in_com, sizeof(Port.port_name));
	error_km ret = CMMISDK_Connect(&Port, &instrumentNo);
	if ((ret != KmSuccess) && (ret != KmWarning))
	{
		printf("Error:%d CMMISDK_Connect\n", ret);
		return;
	}

	// Get instrumentInfo
	CMMISDK_InstrumentInfo instInfo = { 0 };
	ret = CMMISDK_GetInstrumentInfo(instrumentNo, &instInfo);
	if ((ret != KmSuccess) && (ret != KmWarning))
	{
		printf("Error:%d CMMISDK_GetInstrumentInfo\n", ret);
		CMMISDK_Disconnect(instrumentNo);
		return;
	}

	if (strcmp(instInfo.InstrumentName, "CM-25cG") != 0)
	{
		printf("Unsupported model\n");
		CMMISDK_Disconnect(instrumentNo);
		return;
	}

	// Get saved sample count
	int32_km sampleCount = 0;
	ret = CMMISDK_GetSavedSampleCount(instrumentNo, &sampleCount);
	if ((ret != KmSuccess) && (ret != KmWarning))
	{
		printf("Error:%d CMMISDK_GetSavedSampleCount\n", ret);
		CMMISDK_Disconnect(instrumentNo);
		return;
	}

	// Load sample Infomation
	for (int32_km i = 1; i <= sampleCount; i++)
	{
		ret = CMMISDK_LoadSampleInfo(instrumentNo, i);
		if ((ret != KmSuccess) && (ret != KmWarning))
		{
			printf("Error:%d CMMISDK_LoadSampleInfo\n", ret);
			CMMISDK_Disconnect(instrumentNo);
			return;
		}

		// Get sample property
		CMMISDK_SampleProperty sampleProperty = { 0 };
		ret = CMMISDK_GetSampleProperty(instrumentNo, &sampleProperty);
		if ((ret != KmSuccess) && (ret != KmWarning))
		{
			printf("Error:%d CMMISDK_GetSampleProperty\n", ret);
			CMMISDK_Disconnect(instrumentNo);
			return;
		}

		// display sample property
		map<CMMISDK_MeasMode, string> convertMode = { { MEASMODE_COLORANDGLOSS, STR(MEASMODE_COLORANDGLOSS) }, { MEASMODE_COLORONLY, STR(MEASMODE_COLORONLY) }, { MEASMODE_GLOSSONLY, STR(MEASMODE_GLOSSONLY) } };
		map<CMMISDK_MeasArea, string> convertArea = { { AREA_MAV, STR(AREA_MAV) }, { AREA_SAV, STR(AREA_SAV) } };
		printf("No.%04d Name:%s Date:%02d/%02d/%02d %02d:%02d:%02d \n", i, sampleProperty.name, sampleProperty.date[0], sampleProperty.date[1], sampleProperty.date[2], sampleProperty.date[3], sampleProperty.date[4], sampleProperty.date[5]);
		printf("%s %s\n", convertMode[sampleProperty.meas_mode].c_str(), convertArea[sampleProperty.meas_area].c_str());

		CMMISDK_Data sampleSpectralData[DATATYPE_BACKBLACK + 1] = { 0 };

		if ((sampleProperty.meas_mode == MEASMODE_COLORANDGLOSS) || (sampleProperty.meas_mode == MEASMODE_COLORONLY))
		{
			// Get sample spectral data
			ret = CMMISDK_GetSampleData(instrumentNo, DATATYPE_SPEC, &sampleSpectralData[DATATYPE_SPEC]);
			if ((ret != KmSuccess) && (ret != KmWarning))
			{
				printf("Error:%d CMMISDK_GetSampleData spectral SCI\n", ret);
				continue;
			}

			// display sample spectral data
			int count = 0;
			char message[128] = { 0 };
			for (int32_km i = instInfo.WaveLengthStart; i <= instInfo.WaveLengthEnd; i += instInfo.WaveLengthPitch)
			{
				memset(message, 0, sizeof(message));
				sprintf_s(message, "%d : %6.2f", i, sampleSpectralData[DATATYPE_SPEC].data[count]);
				count++;
				printf("%s\n", message);
			}
		}

		// Get gloss data
		if ((sampleProperty.meas_mode == MEASMODE_COLORANDGLOSS) || (sampleProperty.meas_mode == MEASMODE_GLOSSONLY))
		{
			ret = CMMISDK_GetSampleData(instrumentNo, DATATYPE_GLOSS, &sampleSpectralData[DATATYPE_GLOSS]);
			if ((ret != KmSuccess) && (ret != KmWarning))
			{
				printf("Error:%d CMMISDK_GetSampleData spectral\n", ret);
			}
			printf("GLOSS %6.2f\n", sampleSpectralData[DATATYPE_GLOSS].data[0]);
		}

	}

	// Disconnect
	CMMISDK_Disconnect(instrumentNo);

	return;
}

void WriteTargetData(char* in_com)
{
	int32_km instrumentNo;

	// Connect
	CMMISDK_Port Port = { '\0' };
	strncpy_s(Port.port_name, sizeof(Port.port_name), in_com, sizeof(Port.port_name));
	error_km ret = CMMISDK_Connect(&Port, &instrumentNo);
	if ((ret != KmSuccess) && (ret != KmWarning))
	{
		printf("Error:%d CMMISDK_Connect\n", ret);
		return;
	}

	// Get instrumentInfo
	CMMISDK_InstrumentInfo instInfo = { 0 };
	ret = CMMISDK_GetInstrumentInfo(instrumentNo, &instInfo);
	if ((ret != KmSuccess) && (ret != KmWarning))
	{
		printf("Error:%d CMMISDK_GetInstrumentInfo\n", ret);
		CMMISDK_Disconnect(instrumentNo);
		return;
	}

	if (strcmp(instInfo.InstrumentName, "CM-25cG") != 0)
	{
		printf("Unsupported model\n");
		CMMISDK_Disconnect(instrumentNo);
		return;
	}

	int specOrColor = 0;
	printf("Please set 1 for spectral and 2 for colorimetric.\n");
	scanf_s("%d", &specOrColor);

	long targetNum = 0;
	printf("Please input the target number to be written. 1-1000\n");
	scanf_s("%ld", &targetNum);

	//Clear target information
	ret = CMMISDK_ClearTargetInfo(instrumentNo);
	if ((ret != KmSuccess) && (ret != KmWarning))
	{
		printf("Error:%d CMMISDK_ClearTargetInfo\n", ret);
		CMMISDK_Disconnect(instrumentNo);
		return;
	}

	// Set Target Property
	CMMISDK_TargetProperty targetProperty = { 0 };
	// Set time
	time_t nowTime = time(NULL);
	tm sampleTime;
	localtime_s(&sampleTime, &nowTime);
	targetProperty.date[0] = sampleTime.tm_year + 1900;
	targetProperty.date[1] = sampleTime.tm_mon + 1;
	targetProperty.date[2] = sampleTime.tm_mday;
	targetProperty.date[3] = sampleTime.tm_hour;
	targetProperty.date[4] = sampleTime.tm_min;
	targetProperty.date[5] = sampleTime.tm_sec;

	// Set meas type
	targetProperty.meas_type = MEASTYPE_NONE;
	// Set meas mode
	targetProperty.meas_mode = MEASMODE_COLORANDGLOSS;
	// Set meas area
	targetProperty.meas_area = AREA_MAV;
	// Set meas angel
	targetProperty.meas_angle = MEAS_ANGLE_NONE;
	// Set light direction
	targetProperty.meas_ldirection = LDIRECTION_NONE;
	// Set meas specular component 
	targetProperty.meas_scie = SC_NONE;
	// Set meas UV
	targetProperty.meas_uv = UV_NONE;
	// Set warning level
	targetProperty.warning_level = 80;
	// Set warning
	targetProperty.warning = 0;
	// Set diagnosis
	targetProperty.diagnosis = 0;
	// Set data attribute
	if (specOrColor == 1)
	{
		// spectral data
		targetProperty.data_attr = DATAATTR_SPEC;
	}
	else
	{
		// colorimetric data
		targetProperty.data_attr = DATAATTR_LAB;
	}
	// Set name (MAX 30 characters)
	sprintf_s(targetProperty.name, sizeof(targetProperty.name), "%s:%d", "target", targetNum);

	// Set target property
	ret = CMMISDK_SetTargetProperty(instrumentNo, &targetProperty);
	if ((ret != KmSuccess) && (ret != KmWarning))
	{
		printf("Error:%d CMMISDK_SetTargetProperty\n", ret);
		CMMISDK_Disconnect(instrumentNo);
		return;
	}

	// Set target data
	if (specOrColor == 1)
	{
		// Set spectral data
		CMMISDK_Data targetData = { 0 };
		int count = 0;
		for (int32_km i = instInfo.WaveLengthStart; i <= instInfo.WaveLengthEnd; i += instInfo.WaveLengthPitch)
		{
			targetData.data[count] = 100.00;
			count++;
		}
		ret = CMMISDK_SetTargetData(instrumentNo, DATATYPE_SPEC, (const CMMISDK_Data*)&targetData);
		if ((ret != KmSuccess) && (ret != KmWarning))
		{
			printf("Error:%d CMMISDK_SetTargetData spectral\n", ret);
			CMMISDK_Disconnect(instrumentNo);
			return;
		}
		// Set gloss data
		CMMISDK_Data glossData = { 0 };
		glossData.data[0] = 10.00;
		ret = CMMISDK_SetTargetData(instrumentNo, DATATYPE_GLOSS, (const CMMISDK_Data*)&glossData);
		if ((ret != KmSuccess) && (ret != KmWarning))
		{
			printf("Error:%d CMMISDK_SetTargetData gloss\n", ret);
			CMMISDK_Disconnect(instrumentNo);
			return;
		}
	}
	else if (specOrColor == 2)
	{
		// colorimetric data
		CMMISDK_ColorCond cond;
		cond.obs = OBS_10;
		cond.ill = ILL_D65;
		cond.colorSpace = COLOR_LAB;
		CMMISDK_Data targetData = { 0 };
		targetData.data[0] = 91.11;
		targetData.data[1] = -1.11;
		targetData.data[2] = 1.11;
		// light source primary
		ret = CMMISDK_SetTargetDataColor(instrumentNo, DATATYPE_SPEC, 0, &cond, (const CMMISDK_Data*)&targetData);
		if ((ret != KmSuccess) && (ret != KmWarning))
		{
			printf("Error:%d CMMISDK_SetTargetData color primary\n", ret);
			CMMISDK_Disconnect(instrumentNo);
			return;
		}
		cond.obs = OBS_10;
		cond.ill = ILL_C;
		// light source secondary
		targetData.data[0] = 92.22;
		targetData.data[1] = -2.22;
		targetData.data[2] = 2.22;
		ret = CMMISDK_SetTargetDataColor(instrumentNo, DATATYPE_SPEC, 1, &cond, (const CMMISDK_Data*)&targetData);
		if ((ret != KmSuccess) && (ret != KmWarning))
		{
			printf("Error:%d CMMISDK_SetTargetData color secondary\n", ret);
			CMMISDK_Disconnect(instrumentNo);
			return;
		}
		// gloss data
		CMMISDK_Data glossData = { 0 };
		glossData.data[0] = 11.00;
		// light source primary
		ret = CMMISDK_SetTargetDataColor(instrumentNo, DATATYPE_GLOSS, 0, &cond, (const CMMISDK_Data*)&glossData);
		if ((ret != KmSuccess) && (ret != KmWarning))
		{
			printf("Error:%d CMMISDK_SetTargetData color gloss\n", ret);
			CMMISDK_Disconnect(instrumentNo);
			return;
		}
	}

	// Set tolerance for light source primary
	CMMISDK_ToleranceData tolerancePrimaryData = { 0 };
	tolerancePrimaryData.upper_enable = 1;
	tolerancePrimaryData.upper_value = 110;
	tolerancePrimaryData.lower_enable = 1;
	tolerancePrimaryData.lower_value = -120;
	ret = CMMISDK_SetToleranceForTarget(instrumentNo, TOLETYPE_SPEC, 0, TOLERANCE_ID_L, (const CMMISDK_ToleranceData*)&tolerancePrimaryData);
	if ((ret != KmSuccess) && (ret != KmWarning))
	{
		printf("Error:%d CMMISDK_SetToleranceForTarget primary L*\n", ret);
		CMMISDK_Disconnect(instrumentNo);
		return;
	}
	ret = CMMISDK_SetToleranceForTarget(instrumentNo, TOLETYPE_SPEC, 0, TOLERANCE_ID_A, (const CMMISDK_ToleranceData*)&tolerancePrimaryData);
	if ((ret != KmSuccess) && (ret != KmWarning))
	{
		printf("Error:%d CMMISDK_SetToleranceForTarget primary a*\n", ret);
		CMMISDK_Disconnect(instrumentNo);
		return;
	}
	ret = CMMISDK_SetToleranceForTarget(instrumentNo, TOLETYPE_SPEC, 0, TOLERANCE_ID_B, (const CMMISDK_ToleranceData*)&tolerancePrimaryData);
	if ((ret != KmSuccess) && (ret != KmWarning))
	{
		printf("Error:%d CMMISDK_SetToleranceForTarget primary b*\n", ret);
		CMMISDK_Disconnect(instrumentNo);
		return;
	}

	// Set tolerance for light source secondary
	CMMISDK_ToleranceData toleranceSecondaryData = { 0 };
	toleranceSecondaryData.upper_enable = 0;
	toleranceSecondaryData.upper_value = 150;
	toleranceSecondaryData.lower_enable = 0;
	toleranceSecondaryData.lower_value = -160;
	ret = CMMISDK_SetToleranceForTarget(instrumentNo, TOLETYPE_SPEC, 1, TOLERANCE_ID_L, (const CMMISDK_ToleranceData*)&toleranceSecondaryData);
	if ((ret != KmSuccess) && (ret != KmWarning))
	{
		printf("Error:%d CMMISDK_SetToleranceForTarget secondary L*\n", ret);
		CMMISDK_Disconnect(instrumentNo);
		return;
	}
	ret = CMMISDK_SetToleranceForTarget(instrumentNo, TOLETYPE_SPEC, 1, TOLERANCE_ID_A, (const CMMISDK_ToleranceData*)&toleranceSecondaryData);
	if ((ret != KmSuccess) && (ret != KmWarning))
	{
		printf("Error:%d CMMISDK_SetToleranceForTarget secondary a*\n", ret);
		CMMISDK_Disconnect(instrumentNo);
		return;
	}
	ret = CMMISDK_SetToleranceForTarget(instrumentNo, TOLETYPE_SPEC, 1, TOLERANCE_ID_B, (const CMMISDK_ToleranceData*)&toleranceSecondaryData);
	if ((ret != KmSuccess) && (ret != KmWarning))
	{
		printf("Error:%d CMMISDK_SetToleranceForTarget secondary b*\n", ret);
		CMMISDK_Disconnect(instrumentNo);
		return;
	}

	// Set parametric for tolerance
	CMMISDK_ParametricCoef parametricData = { 0 };
	parametricData.coef[0] = 1.1;
	parametricData.coef[1] = 1.2;
	ret = CMMISDK_SetParametricForTarget(instrumentNo, TOLETYPE_SPEC, PARAMETRIC_ID_CMC, (const CMMISDK_ParametricCoef*)&parametricData);
	if ((ret != KmSuccess) && (ret != KmWarning))
	{
		printf("Error:%d CMMISDK_SetParametricForTarget CMC\n", ret);
		CMMISDK_Disconnect(instrumentNo);
		return;
	}
	parametricData.coef[0] = 2.1;
	parametricData.coef[1] = 2.2;
	parametricData.coef[2] = 2.3;
	ret = CMMISDK_SetParametricForTarget(instrumentNo, TOLETYPE_SPEC, PARAMETRIC_ID_DE94, (const CMMISDK_ParametricCoef*)&parametricData);
	if ((ret != KmSuccess) && (ret != KmWarning))
	{
		printf("Error:%d CMMISDK_SetParametricForTarget DE94\n", ret);
		CMMISDK_Disconnect(instrumentNo);
		return;
	}
	parametricData.coef[0] = 3.1;
	parametricData.coef[1] = 3.2;
	parametricData.coef[2] = 3.3;
	ret = CMMISDK_SetParametricForTarget(instrumentNo, TOLETYPE_SPEC, PARAMETRIC_ID_DE00, (const CMMISDK_ParametricCoef*)&parametricData);
	if ((ret != KmSuccess) && (ret != KmWarning))
	{
		printf("Error:%d CMMISDK_SetParametricForTarget DE00\n", ret);
		CMMISDK_Disconnect(instrumentNo);
		return;
	}

	// Save Target information
	ret = CMMISDK_SaveTargetInfo(instrumentNo, targetNum);
	if ((ret != KmSuccess) && (ret != KmWarning))
	{
		printf("Error:%d CMMISDK_SaveTargetInfo\n", ret);
		CMMISDK_Disconnect(instrumentNo);
		return;
	}

	// Disconnect
	CMMISDK_Disconnect(instrumentNo);

	return;
}

//int _tmain(int argc, _TCHAR* argv[])
int main(int argc, char *argv[])
{	
	if (argc != 3)
	{
		printf("Parameter error\n1:Test type:1-3\n2:COMPort number\n");
		printf("ex. SampleApp.exe 1 COM10\n");
		system("pause");
		return 0;
	}

	// Get SDK version
	CMMISDK_Version version;
	CMMISDK_GetSDKVersion(&version);
	printf("SDK Version: %1d.%02d.%04d %s\n", version.major, version.minor, version.free, argv[2]);

	int testType = strtol(argv[1], NULL, 10);
	switch (testType)
	{
	case 1:
		// Perform measurement
		PerformMeasurement(argv[2]);
		break;

	case 2:
		// Read sample data
		ReadSampleData(argv[2]);
		break;

	case 3:
		// Write target data
		WriteTargetData(argv[2]);
		break;

	default:
		break;
	}

	system("pause");

	return 0;
}
