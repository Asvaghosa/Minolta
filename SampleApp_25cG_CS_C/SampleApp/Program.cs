using System;
using System.Text;
using System.Linq;
using Konicaminolta.CMMISDK.API;
using System.Collections.Generic;

namespace SampleApp
{
    class Program
    {
        // error check
        static bool IsNormalCode(Int32 ret)
        {
            if ((ret == (Int32)_error_km.KmSuccess) || (ret == (Int32)_error_km.KmWarning))
            {
                return true;
            }
            return false;
        }

        static void PerformMeasurement(string in_com)
        {
            Int32 ret;

            // Connect
            CMMISDK_Port Port = new CMMISDK_Port();
            Port.port_name = new byte[Define.SIZE_PORTNAME];
            for (int name_count = 0; name_count < in_com.Length; name_count++)
            {
                Port.port_name[name_count] = Convert.ToByte(in_com[name_count]);
            }
            int instrumentNo = 0;
            ret = CMMISDK_API.CMMISDK_Connect(ref Port, ref instrumentNo);
            if (!IsNormalCode(ret))
            {
                Console.WriteLine("Error:{0} CMMISDK_Connect", ret);
                CMMISDK_API.CMMISDK_Disconnect(instrumentNo);
                return;
            }

            // Get instrumentInfo
            CMMISDK_InstrumentInfo instInfo = new CMMISDK_InstrumentInfo();
            ret = CMMISDK_API.CMMISDK_GetInstrumentInfo(instrumentNo, ref instInfo);
            if (!IsNormalCode(ret))
            {
                Console.WriteLine("Error:{0} CMMISDK_GetInstrumentInfo", ret);
                CMMISDK_API.CMMISDK_Disconnect(instrumentNo);
                return;
            }

            if (Encoding.ASCII.GetString(instInfo.InstrumentName).TrimEnd('\0') != "CM-25cG")
            {
                Console.WriteLine("Unsppoted instrument");
                CMMISDK_API.CMMISDK_Disconnect(instrumentNo);
                return;
            }

            // Set measurement mode (color & gloss)
            _CMMISDK_MeasMode mode = _CMMISDK_MeasMode.MEASMODE_COLORANDGLOSS;
            ret = CMMISDK_API.CMMISDK_SetMeasurementMode(instrumentNo, (int)mode);
            if (!IsNormalCode(ret))
            {
                Console.WriteLine("Error:{0} CMMISDK_SetMeasurementMode", ret);
                CMMISDK_API.CMMISDK_Disconnect(instrumentNo);
                return;
            }

            // Check Calibration
            bool calComplete = false;
            do
            {
                int calStatus = 0;
                ret = CMMISDK_API.CMMISDK_GetCalibrationStatus(instrumentNo, ref calStatus);
                if (!IsNormalCode(ret))
                {
                    Console.WriteLine("Error:{0} CMMISDK_GetCalibrationStatus", ret);
                    CMMISDK_API.CMMISDK_Disconnect(instrumentNo);
                    break;
                }

                switch ((_CMMISDK_CalStatus)calStatus)
                {
                    case _CMMISDK_CalStatus.StatusZero:
                        // Zero calibration
                        Console.WriteLine("Please set the zero calibration box.");
                        Console.ReadKey();
                        ret = CMMISDK_API.CMMISDK_PerformZeroCalibration(instrumentNo);
                        if (!IsNormalCode(ret))
                        {
                            Console.WriteLine("Error:{0} CMMISDK_PerformZeroCalibration", ret);
                            CMMISDK_API.CMMISDK_Disconnect(instrumentNo);
                        }
                        break;

                    case _CMMISDK_CalStatus.StatusWhite:
                        // White calibration
                        Console.WriteLine("Please set the white calibration box.");
                        Console.ReadKey();
                        ret = CMMISDK_API.CMMISDK_PerformWhiteCalibration(instrumentNo);
                        if (!IsNormalCode(ret))
                        {
                            Console.WriteLine("Error:{0} CMMISDK_PerformWhiteCalibration", ret);
                            CMMISDK_API.CMMISDK_Disconnect(instrumentNo);
                        }
                        break;

                    case _CMMISDK_CalStatus.StatusGloss:
                        // Gloss calibration
                        Console.WriteLine("Please set the gloss calibration box.");
                        Console.ReadKey();
                        ret = CMMISDK_API.CMMISDK_PerformGlossCalibration(instrumentNo);
                        if (!IsNormalCode(ret))
                        {
                            Console.WriteLine("Error:{0} PerformGlossCalibration", ret);
                            CMMISDK_API.CMMISDK_Disconnect(instrumentNo);
                            return;
                        }
                        break;

                    case _CMMISDK_CalStatus.StatusUser:
                        // User calibration
                        Console.WriteLine("Please set the User calibration box.");
                        Console.ReadKey();
                        ret = CMMISDK_API.CMMISDK_PerformUserCalibration(instrumentNo);
                        if (!IsNormalCode(ret))
                        {
                            Console.WriteLine("Error:{0} PerformUserCalibration", ret);
                            CMMISDK_API.CMMISDK_Disconnect(instrumentNo);
                            return;
                        }
                        break;

                    default:
                        calComplete = true;
                        break;
                }
            } while (!calComplete);

            // Perform measurement
            Console.WriteLine("Please set the sample plate.");
            Console.ReadKey();
            ret = CMMISDK_API.CMMISDK_PerformMeasurement(instrumentNo);
            if (!IsNormalCode(ret))
            {
                Console.WriteLine("Error:{0} CMMISDK_PerformMeasurement", ret);
                CMMISDK_API.CMMISDK_Disconnect(instrumentNo);
                return;
            }

            // Polling measurement
            int measStatus = (int)_CMMISDK_MeasStatus.Measuring;
            do
            {
                ret = CMMISDK_API.CMMISDK_PollingMeasurement(instrumentNo, ref measStatus);
                if (!IsNormalCode(ret))
                {
                    Console.WriteLine("Error:{0} CMMISDK_PollingMeasurement", ret);
                    CMMISDK_API.CMMISDK_Disconnect(instrumentNo);
                    break;
                }
            } while ((_CMMISDK_MeasStatus)measStatus != _CMMISDK_MeasStatus.Idling);

            // Get sample data
            ret = CMMISDK_API.CMMISDK_LoadLatestData(instrumentNo);
            if (!IsNormalCode(ret))
            {
                Console.WriteLine("Error:{0} CMMISDK_LoadLatestData", ret);
                CMMISDK_API.CMMISDK_Disconnect(instrumentNo);
                return;
            }

            // Get sample colorimetric data
            CMMISDK_ColorCond cond;
            cond.obs = (int)_CMMISDK_Observer.OBS_10;
            cond.ill = (int)_CMMISDK_Illuminant.ILL_D65;
            cond.colorSpace = (int)_CMMISDK_ColorSpace.COLOR_LAB;
            CMMISDK_Data measurementColorData = new CMMISDK_Data();
            ret = CMMISDK_API.CMMISDK_GetLatestDataColor(instrumentNo, (int)_CMMISDK_DataType.DATATYPE_SPEC, ref cond, ref measurementColorData);
            if (!IsNormalCode(ret))
            {
                Console.WriteLine("Error:{0} CMMISDK_GetLatestDataColor", ret);
                CMMISDK_API.CMMISDK_Disconnect(instrumentNo);
                return;
            }
            // Color data display
            Console.WriteLine("L*:{0,6:f2} a*:{1,6:f2} b*:{2,6:f2}", measurementColorData.data[0], measurementColorData.data[1], measurementColorData.data[2]);

            // Get sample spectral data
            CMMISDK_Data[] measurementSpecData = new CMMISDK_Data[(int)_CMMISDK_DataType.DATATYPE_SPEC + 1];
            for (_CMMISDK_DataType inDataType = _CMMISDK_DataType.DATATYPE_GLOSS; inDataType <= _CMMISDK_DataType.DATATYPE_SPEC; inDataType = (_CMMISDK_DataType)(inDataType + 1))
            {
                ret = CMMISDK_API.CMMISDK_GetLatestDataSpec(instrumentNo, (int)inDataType, ref measurementSpecData[(int)inDataType]);
                if (!IsNormalCode(ret))
                {
                    Console.WriteLine("Error:{0} CMMISDK_GetLatestDataSpec", ret);
                }
            }

            // Spectral data display
            Console.WriteLine("       GLOSS   SPEC");
            int count = 0;
            for (int waveLength = instInfo.WaveLengthStart; waveLength <= instInfo.WaveLengthEnd; waveLength += instInfo.WaveLengthPitch)
            {
                Console.Write("{0} :", waveLength);
                for (_CMMISDK_DataType inDataType = _CMMISDK_DataType.DATATYPE_GLOSS; inDataType <= _CMMISDK_DataType.DATATYPE_SPEC; inDataType = (_CMMISDK_DataType)(inDataType + 1))
                {
                    Console.Write(" {0,6:f2}", measurementSpecData[(int)inDataType].data[count]);
                }
                Console.WriteLine("");
                count++;
            }

            // Disconnect
            CMMISDK_API.CMMISDK_Disconnect(instrumentNo);

            return;
        }

        static void ReadSampleData(string in_com)
        {
            int ret;
            // Connect
            CMMISDK_Port Port = new CMMISDK_Port();
            Port.port_name = new byte[Define.SIZE_PORTNAME];
            for (int name_count = 0; name_count < in_com.Length; name_count++)
            {
                Port.port_name[name_count] = Convert.ToByte(in_com[name_count]);
            }
            int instrumentNo = 0;
            ret = CMMISDK_API.CMMISDK_Connect(ref Port, ref instrumentNo);
            if (!IsNormalCode(ret))
            {
                Console.WriteLine("Error:{0} CMMISDK_Connect", ret);
                CMMISDK_API.CMMISDK_Disconnect(instrumentNo);
                return;
            }

            // Get instrumentInfo
            CMMISDK_InstrumentInfo instInfo = new CMMISDK_InstrumentInfo();
            ret = CMMISDK_API.CMMISDK_GetInstrumentInfo(instrumentNo, ref instInfo);
            if (!IsNormalCode(ret))
            {
                Console.WriteLine("Error:{0} CMMISDK_GetInstrumentInfo", ret);
                CMMISDK_API.CMMISDK_Disconnect(instrumentNo);
                return;
            }

            if ( Encoding.ASCII.GetString(instInfo.InstrumentName).TrimEnd('\0') != "CM-25cG")
            {
                Console.WriteLine("Unsppoted instrument");
                CMMISDK_API.CMMISDK_Disconnect(instrumentNo);
                return;
            }

            // Get sample count
            Int32 sampleCount = 0;
            ret = CMMISDK_API.CMMISDK_GetSavedSampleCount(instrumentNo, ref sampleCount);
            if (!IsNormalCode(ret))
            {
                Console.WriteLine("Error:{0:d} GetSampleCount", ret);
                CMMISDK_API.CMMISDK_Disconnect(instrumentNo);
                return;
            }

            Dictionary<_CMMISDK_DataType, string> convertDataTypeTable = new Dictionary<_CMMISDK_DataType, string>() { { _CMMISDK_DataType.DATATYPE_GLOSS, " GLOSS" }, { _CMMISDK_DataType.DATATYPE_SCI, " SPEC " } };
            for (Int32 i = 1; i <= sampleCount; i++)
            {
                ret = CMMISDK_API.CMMISDK_LoadSampleInfo(instrumentNo, i);
                if (!IsNormalCode(ret))
                {
                    Console.WriteLine("Error:{0:d} CMMISDK_LoadSampleInfo", ret);
                    CMMISDK_API.CMMISDK_Disconnect(instrumentNo);
                    return;
                }

                // Get sample property
                CMMISDK_SampleProperty sampleProperty = new CMMISDK_SampleProperty();
                ret = CMMISDK_API.CMMISDK_GetSampleProperty(instrumentNo, ref sampleProperty);
                if (!IsNormalCode(ret))
                {
                    Console.WriteLine("Error:{0:d} CMMISDK_GetSampleProperty", ret);
                    CMMISDK_API.CMMISDK_Disconnect(instrumentNo);
                    return;
                }

                // display sample property
                Console.WriteLine("No.{0:d4} Name:{1} Date:{2}", i, Encoding.ASCII.GetString(sampleProperty.name).TrimEnd('\0'), new DateTime(sampleProperty.date[0], sampleProperty.date[1], sampleProperty.date[2], sampleProperty.date[3], sampleProperty.date[4], sampleProperty.date[5]));
                Console.WriteLine("{0} {1}", Enum.GetName(typeof(_CMMISDK_MeasMode), sampleProperty.meas_mode), Enum.GetName(typeof(_CMMISDK_MeasArea), sampleProperty.meas_area));

                // Get sample spectral data
                Dictionary<_CMMISDK_DataType, CMMISDK_Data> sampleSpectralData = new Dictionary<_CMMISDK_DataType, CMMISDK_Data>();
             	if ((sampleProperty.meas_mode == (int)_CMMISDK_MeasMode.MEASMODE_COLORANDGLOSS) || (sampleProperty.meas_mode == (int)_CMMISDK_MeasMode.MEASMODE_COLORONLY))
                {
                        CMMISDK_Data sampleData = new CMMISDK_Data();
                        ret = CMMISDK_API.CMMISDK_GetSampleData(instrumentNo, (int)_CMMISDK_DataType.DATATYPE_SPEC, ref sampleData);
                        if (!IsNormalCode(ret))
                        {
                            Console.WriteLine("Error:{0:d} CMMISDK_GetSampleData SCI", ret);
                            CMMISDK_API.CMMISDK_Disconnect(instrumentNo);
                            return;
                        }
                        sampleSpectralData.Add(_CMMISDK_DataType.DATATYPE_SCI, sampleData);
                }
                if ((sampleProperty.meas_mode == (int)_CMMISDK_MeasMode.MEASMODE_COLORANDGLOSS) || (sampleProperty.meas_mode == (int)_CMMISDK_MeasMode.MEASMODE_GLOSSONLY))
                {
                    CMMISDK_Data sampleGlossData = new CMMISDK_Data();
                    ret = CMMISDK_API.CMMISDK_GetSampleData(instrumentNo, (int)_CMMISDK_DataType.DATATYPE_GLOSS, ref sampleGlossData);
                    if (!IsNormalCode(ret))
                    {
                        Console.WriteLine("Error:{0:d} CMMISDK_GetSampleData GLOSS", ret);
                        CMMISDK_API.CMMISDK_Disconnect(instrumentNo);
                        return;
                    }
                    sampleSpectralData.Add(_CMMISDK_DataType.DATATYPE_GLOSS, sampleGlossData);
                }
                // Display data
                if (sampleSpectralData.Count != 0)
                {
                    Console.Write("   , ");
                    foreach (_CMMISDK_DataType key in sampleSpectralData.Keys)
                    {
                        Console.Write("{0:s}, ", convertDataTypeTable[key]);
                    }
                    Console.Write('\n');

                    // Spectral data display
                    int index = 0;
                    for (Int32 WaveLength = instInfo.WaveLengthStart; WaveLength <= instInfo.WaveLengthEnd; WaveLength = WaveLength + instInfo.WaveLengthPitch)
                    {
                        Console.Write("{0:d3}, ", WaveLength);
                        foreach (_CMMISDK_DataType key in sampleSpectralData.Keys)
                        {
                            Console.Write("{0,6:00.00}, ", sampleSpectralData[key].data[index]);
                        }
                        index++;
                        Console.Write('\n');
                    }
                }
            }

            // Disconnect
            CMMISDK_API.CMMISDK_Disconnect(instrumentNo);

            return;
        }

        static void WriteTargetData(string in_com)
        {
            int ret;
            // Connect
            CMMISDK_Port Port = new CMMISDK_Port();
            Port.port_name = new byte[Define.SIZE_PORTNAME];
            for (int name_count = 0; name_count < in_com.Length; name_count++)
            {
                Port.port_name[name_count] = Convert.ToByte(in_com[name_count]);
            }
            int instrumentNo = 0;
            ret = CMMISDK_API.CMMISDK_Connect(ref Port, ref instrumentNo);
            if (!IsNormalCode(ret))
            {
                Console.WriteLine("Error:{0} CMMISDK_Connect", ret);
                CMMISDK_API.CMMISDK_Disconnect(instrumentNo);
                return;
            }

            // Get instrumentInfo
            CMMISDK_InstrumentInfo instInfo = new CMMISDK_InstrumentInfo();
            ret = CMMISDK_API.CMMISDK_GetInstrumentInfo(instrumentNo, ref instInfo);
            if (!IsNormalCode(ret))
            {
                Console.WriteLine("Error:{0} CMMISDK_GetInstrumentInfo", ret);
                CMMISDK_API.CMMISDK_Disconnect(instrumentNo);
                return;
            }

            if (Encoding.ASCII.GetString(instInfo.InstrumentName).TrimEnd('\0') != "CM-25cG")
            {
                Console.WriteLine("Unsppoted instrument");
                CMMISDK_API.CMMISDK_Disconnect(instrumentNo);
                return;
            }

            Console.WriteLine("Please input the target number to be written. 1-2500");
            int targetNum = Convert.ToInt32(Console.ReadLine());

            //Clear target information
            ret = CMMISDK_API.CMMISDK_ClearTargetInfo(instrumentNo);
            if (!IsNormalCode(ret))
            {
                Console.WriteLine("Error:{0} CMMISDK_ClearTargetInfo", ret);
                CMMISDK_API.CMMISDK_Disconnect(instrumentNo);
                return;
            }

            // Set Target Property
            CMMISDK_TargetProperty targetProperty = new CMMISDK_TargetProperty();
            // Set time
            targetProperty.date = new int[Define.SIZE_DATE];
            DateTime date = DateTime.Now;
            targetProperty.date[0] = date.Year;
            targetProperty.date[1] = date.Month;
            targetProperty.date[2] = date.Day;
            targetProperty.date[3] = date.Hour;
            targetProperty.date[4] = date.Minute;
            targetProperty.date[5] = date.Second;
            // Set group list
            targetProperty.group_list = new int[] { 0, 0, 0, 0, 0 };
            // Set meas type
            targetProperty.meas_type = (int)_CMMISDK_MeasType.MEASTYPE_NONE;
            // Set meas mode
            targetProperty.meas_mode = (int)_CMMISDK_MeasMode.MEASMODE_COLORANDGLOSS;
            // Set meas area
            targetProperty.meas_area = (int)_CMMISDK_MeasArea.AREA_MAV;
            // Set meas angel
            targetProperty.meas_angle = (int)_CMMISDK_MeasAngle.MEAS_ANGLE_NONE;
            // Set light direction
            targetProperty.meas_ldirection = (int)_CMMISDK_LightDirection.LDIRECTION_NONE;
            // Set meas specular component 
            targetProperty.meas_scie = (int)_CMMISDK_SpecularComponent.SC_NONE;
            // Set meas UV
            targetProperty.meas_uv = (int)_CMMISDK_Uv.UV_NONE;
            // Set warning level
            targetProperty.warning_level = 80;
            // Set warning
            targetProperty.warning = 0;
            // Set diagnosis
            targetProperty.diagnosis = 0;
            // Set data attribute
            int specOrColor = 0;
            Console.WriteLine("Please set 1 for spectral and 2 for colorimetric.");
            specOrColor = Convert.ToInt32(Console.ReadLine());
            if (specOrColor == 1)
            {
                // spectral data
                targetProperty.data_attr = (int)_CMMISDK_DataAttr.DATAATTR_SPEC;
            }
            else
            {
                // colorimetric data
                targetProperty.data_attr = (int)_CMMISDK_DataAttr.DATAATTR_LAB;
            }
            // Set name (MAX 30 characters)
            string name = "target:" + targetNum.ToString();
            if (name.Length > 30) { name.Remove(30); }
            targetProperty.name = Encoding.ASCII.GetBytes(name.PadRight(Define.SIZE_DATANAME, '\0'));

            ret = CMMISDK_API.CMMISDK_SetTargetProperty(instrumentNo, ref targetProperty);
            if (!IsNormalCode(ret))
            {
                Console.WriteLine("Error:{0} CMMISDK_SetTargetProperty", ret);
                CMMISDK_API.CMMISDK_Disconnect(instrumentNo);
                return;
            }

            // Set target data
            if (specOrColor == 1)
            {
                // Set spectral data
                CMMISDK_Data targetData = new CMMISDK_Data() { data = new double[Define.SIZE_DATA] };
                CMMISDK_Data targetGloss = new CMMISDK_Data() { data = new double[Define.SIZE_DATA] };
                int count = 0;
                for (int i = instInfo.WaveLengthStart; i <= instInfo.WaveLengthEnd; i += instInfo.WaveLengthPitch)
                {
                    targetData.data[count] = 100.00;
                    count++;
                }
                ret = CMMISDK_API.CMMISDK_SetTargetData(instrumentNo, (int)_CMMISDK_DataType.DATATYPE_SPEC, ref targetData);
                if (!IsNormalCode(ret))
                {
                    Console.WriteLine("Error:{0} CMMISDK_SetTargetData SCI", ret);
                    CMMISDK_API.CMMISDK_Disconnect(instrumentNo);
                    return;
                }

                // Set gloss data
                targetGloss.data[0] = 10.0;
                ret = CMMISDK_API.CMMISDK_SetTargetData(instrumentNo, (int)_CMMISDK_DataType.DATATYPE_GLOSS, ref targetGloss);
                if (!IsNormalCode(ret))
                {
                    Console.WriteLine("Error:{0} CMMISDK_SetTargetData GLOSS", ret);
                    CMMISDK_API.CMMISDK_Disconnect(instrumentNo);
                    return;
                }

            }
            else
            {
                // colorimetric data
                CMMISDK_ColorCond cond;
                cond.obs = (int)_CMMISDK_Observer.OBS_10;
                cond.ill = (int)_CMMISDK_Illuminant.ILL_D65;
                cond.colorSpace = (int)_CMMISDK_ColorSpace.COLOR_LAB;
                CMMISDK_Data targetData = new CMMISDK_Data() { data = new double[Define.SIZE_DATA] };
                targetData.data[0] = 91.11;
                targetData.data[1] = -1.11;
                targetData.data[2] = 1.11;
                // light source primary
                ret = CMMISDK_API.CMMISDK_SetTargetDataColor(instrumentNo, (int)_CMMISDK_DataType.DATATYPE_SPEC, 0, ref cond, ref targetData);
                if (!IsNormalCode(ret))
                {
                    Console.WriteLine("Error:{0} CMMISDK_SetTargetData color primary SCI", ret);
                    CMMISDK_API.CMMISDK_Disconnect(instrumentNo);
                    return;
                }
                cond.obs = (int)_CMMISDK_Observer.OBS_10;
                cond.ill = (int)_CMMISDK_Illuminant.ILL_C;
                // light source secondary
                targetData.data[0] = 92.22;
                targetData.data[1] = -2.22;
                targetData.data[2] = 2.22;
                ret = CMMISDK_API.CMMISDK_SetTargetDataColor(instrumentNo, (int)_CMMISDK_DataType.DATATYPE_SPEC, 1, ref cond, ref targetData);
                if (!IsNormalCode(ret))
                {
                    Console.WriteLine("Error:{0} CMMISDK_SetTargetData color secondary SCI", ret);
                    CMMISDK_API.CMMISDK_Disconnect(instrumentNo);
                    return;
                }

                // gloss data
                CMMISDK_Data glossData = new CMMISDK_Data() { data = new double[Define.SIZE_DATA] };
                glossData.data[0] = 11.00;
                // light source primary
                ret = CMMISDK_API.CMMISDK_SetTargetDataColor(instrumentNo, (int)_CMMISDK_DataType.DATATYPE_GLOSS, 0, ref cond, ref glossData);
                if (!IsNormalCode(ret))
                {
                    Console.WriteLine("Error:{0} CMMISDK_SetTargetData color gloss", ret);
                    CMMISDK_API.CMMISDK_Disconnect(instrumentNo);
                    return;
                }
            }

            // Set tolerance for light source primary
            CMMISDK_ToleranceData tolerancePrimaryData = new CMMISDK_ToleranceData();
            tolerancePrimaryData.upper_enable = 1;
            tolerancePrimaryData.upper_value = 110;
            tolerancePrimaryData.lower_enable = 1;
            tolerancePrimaryData.lower_value = -120;
            ret = CMMISDK_API.CMMISDK_SetToleranceForTarget(instrumentNo, (int)_CMMISDK_ToleranceType.TOLETYPE_SPEC, 0, (int)_CMMISDK_ToleranceId.TOLERANCE_ID_L, ref tolerancePrimaryData);
            if (!IsNormalCode(ret))
            {
                Console.WriteLine("Error:{0} CMMISDK_SetToleranceForTarget primary L*", ret);
                CMMISDK_API.CMMISDK_Disconnect(instrumentNo);
                return;
            }
            ret = CMMISDK_API.CMMISDK_SetToleranceForTarget(instrumentNo, (int)_CMMISDK_ToleranceType.TOLETYPE_SPEC, 0, (int)_CMMISDK_ToleranceId.TOLERANCE_ID_A, ref tolerancePrimaryData);
            if (!IsNormalCode(ret))
            {
                Console.WriteLine("Error:{0} CMMISDK_SetToleranceForTarget primary a*", ret);
                CMMISDK_API.CMMISDK_Disconnect(instrumentNo);
                return;
            }
            ret = CMMISDK_API.CMMISDK_SetToleranceForTarget(instrumentNo, (int)_CMMISDK_ToleranceType.TOLETYPE_SPEC, 0, (int)_CMMISDK_ToleranceId.TOLERANCE_ID_B, ref tolerancePrimaryData);
            if (!IsNormalCode(ret))
            {
                Console.WriteLine("Error:{0} CMMISDK_SetToleranceForTarget primary b*", ret);
                CMMISDK_API.CMMISDK_Disconnect(instrumentNo);
                return;
            }

            // Set tolerance for light source secondary
            CMMISDK_ToleranceData toleranceSecondaryData = new CMMISDK_ToleranceData();
            toleranceSecondaryData.upper_enable = 0;
            toleranceSecondaryData.upper_value = 150;
            toleranceSecondaryData.lower_enable = 0;
            toleranceSecondaryData.lower_value = -160;
            ret = CMMISDK_API.CMMISDK_SetToleranceForTarget(instrumentNo, (int)_CMMISDK_ToleranceType.TOLETYPE_SPEC, 1, (int)_CMMISDK_ToleranceId.TOLERANCE_ID_L, ref toleranceSecondaryData);
            if (!IsNormalCode(ret))
            {
                Console.WriteLine("Error:{0} CMMISDK_SetToleranceForTarget secondary L*", ret);
                CMMISDK_API.CMMISDK_Disconnect(instrumentNo);
                return;
            }
            ret = CMMISDK_API.CMMISDK_SetToleranceForTarget(instrumentNo, (int)_CMMISDK_ToleranceType.TOLETYPE_SPEC, 1, (int)_CMMISDK_ToleranceId.TOLERANCE_ID_A, ref toleranceSecondaryData);
            if (!IsNormalCode(ret))
            {
                Console.WriteLine("Error:{0} CMMISDK_SetToleranceForTarget secondary a*", ret);
                CMMISDK_API.CMMISDK_Disconnect(instrumentNo);
                return;
            }
            ret = CMMISDK_API.CMMISDK_SetToleranceForTarget(instrumentNo, (int)_CMMISDK_ToleranceType.TOLETYPE_SPEC, 1, (int)_CMMISDK_ToleranceId.TOLERANCE_ID_B, ref toleranceSecondaryData);
            if (!IsNormalCode(ret))
            {
                Console.WriteLine("Error:{0} CMMISDK_SetToleranceForTarget secondary b*", ret);
                CMMISDK_API.CMMISDK_Disconnect(instrumentNo);
                return;
            }

            // Set parametric for tolerance
            CMMISDK_ParametricCoef parametricData = new CMMISDK_ParametricCoef();
            parametricData.coef = new double[Define.SIZE_PARAMETRIC_COEF];
            parametricData.coef[0] = 1.1;
            parametricData.coef[1] = 1.2;
            ret = CMMISDK_API.CMMISDK_SetParametricForTarget(instrumentNo, (int)_CMMISDK_ToleranceType.TOLETYPE_SPEC, (int)_CMMISDK_ParametricId.PARAMETRIC_ID_CMC, ref parametricData);
            if (!IsNormalCode(ret))
            {
                Console.WriteLine("Error:{0} CMMISDK_SetParametricForTarget CMC", ret);
                CMMISDK_API.CMMISDK_Disconnect(instrumentNo);
                return;
            }
            parametricData.coef[0] = 2.1;
            parametricData.coef[1] = 2.2;
            parametricData.coef[2] = 2.3;
            ret = CMMISDK_API.CMMISDK_SetParametricForTarget(instrumentNo, (int)_CMMISDK_ToleranceType.TOLETYPE_SPEC, (int)_CMMISDK_ParametricId.PARAMETRIC_ID_DE94, ref parametricData);
            if (!IsNormalCode(ret))
            {
                Console.WriteLine("Error:{0} CMMISDK_SetParametricForTarget DE94", ret);
                CMMISDK_API.CMMISDK_Disconnect(instrumentNo);
                return;
            }
            parametricData.coef[0] = 3.1;
            parametricData.coef[1] = 3.2;
            parametricData.coef[2] = 3.3;
            ret = CMMISDK_API.CMMISDK_SetParametricForTarget(instrumentNo, (int)_CMMISDK_ToleranceType.TOLETYPE_SPEC, (int)_CMMISDK_ParametricId.PARAMETRIC_ID_DE00, ref parametricData);
            if (!IsNormalCode(ret))
            {
                Console.WriteLine("Error:{0} CMMISDK_SetParametricForTarget DE00", ret);
                CMMISDK_API.CMMISDK_Disconnect(instrumentNo);
                return;
            }

            // Save Target information
            ret = CMMISDK_API.CMMISDK_SaveTargetInfo(instrumentNo, targetNum);
            if (!IsNormalCode(ret))
            {
                Console.WriteLine("Error:{0} CMMISDK_SaveTargetInfo", ret);
                CMMISDK_API.CMMISDK_Disconnect(instrumentNo);
                return;
            }

            // Disconnect
            CMMISDK_API.CMMISDK_Disconnect(instrumentNo);
        }

        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Parameter error\n1:Test type:1-3\n2:COMPort number");
                Console.WriteLine("ex. SampleApp.exe 1 COM10");
                Console.ReadKey();
                return;
            }

            // Get SDK version
            CMMISDK_Version version = new CMMISDK_Version();
            CMMISDK_API.CMMISDK_GetSDKVersion(ref version);
            Console.WriteLine("SDK Version: {0:0}.{1:00}.{2:0000}", version.major, version.minor, version.free);

            switch (args[0])
            {
                case "1":
                    // Perform measurement
                    PerformMeasurement(args[1]);
                    break;

                case "2":
                    // Read sample data
                    ReadSampleData(args[1]);
                    break;

                case "3":
                    // Write target data
                    WriteTargetData(args[1]);
                    break;
            }

            Console.ReadKey();
        }
    }
}
