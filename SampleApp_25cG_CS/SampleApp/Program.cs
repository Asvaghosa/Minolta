using System;
using System.Collections.Generic;
using System.Linq;
using Konicaminolta;

namespace SampleApp
{
    class Program
    {
        static void PerformMeasurement(Int32 in_com)
        {
            ColorManagementMISDK sdk = ColorManagementMISDK.GetInstance();
            ReturnMessage ret = new ReturnMessage();

            // Connect
            ret = sdk.Connect(in_com);
            if (!ErrorDefine.IsNormalCode(ret.errorCode))
            {
                Console.WriteLine("Error:{0:d} Connect", ret.errorCode);
                return;
            }

            // Get instrumentInfo
            InstrumentInfoEx instInfoEx;
            ret = sdk.GetInstrumentInfo(out instInfoEx, in_com);
            if (!ErrorDefine.IsNormalCode(ret.errorCode))
            {
                Console.WriteLine("Error:{0:d} GetInstrumentInfo Ex", ret.errorCode);
                sdk.DisConnect(in_com);
                return;
            }

            if (instInfoEx.Name != "CM-25cG")
            {
                Console.WriteLine("Unsppoted instrument");
                sdk.DisConnect(in_com);
                return;
            }

            // Set measurement mode (color & gloss)
            MeasCondMode mode = MeasCondMode.MeasModeColorAndGloss;
            ret = sdk.SetMeasurementMode(mode, in_com);
            if (!ErrorDefine.IsNormalCode(ret.errorCode))
            {
                Console.WriteLine("Error:{0:d} SetMeasurementMode", ret.errorCode);
                sdk.DisConnect(in_com);
                return;
            }

            // Calibration check
            bool calComplete = false;
            do
            {
                CalStatus calStatus;
                ret = sdk.GetCalibrationStatus(out calStatus, in_com);
                if (!ErrorDefine.IsNormalCode(ret.errorCode))
                {
                    Console.WriteLine("Error:{0:d} GetCalibrationStatus", ret.errorCode);
                    sdk.DisConnect(in_com);
                    return;
                }

                switch (calStatus)
                {
                    case CalStatus.StatusZero:
                        // Zero calibration
                        Console.WriteLine("Please set the zero calibration box.");
                        Console.ReadKey();
                        ret = sdk.PerformZeroCalibration(in_com);
                        if (!ErrorDefine.IsNormalCode(ret.errorCode))
                        {
                            Console.WriteLine("Error:{0:d} PerformZeroCalibration", ret.errorCode);
                            sdk.DisConnect(in_com);
                            return;
                        }
                        break;

                    case CalStatus.StatusWhite:
                        // White calibration
                        Console.WriteLine("Please set the white calibration box.");
                        Console.ReadKey();
                        ret = sdk.PerformWhiteCalibration(in_com);
                        if (!ErrorDefine.IsNormalCode(ret.errorCode))
                        {
                            Console.WriteLine("Error:{0:d} PerformWhiteCalibration", ret.errorCode);
                            sdk.DisConnect(in_com);
                            return;
                        }
                        break;

                    case CalStatus.StatusGloss:
                        // Gloss calibration
                        Console.WriteLine("Please set the gloss calibration box.");
                        Console.ReadKey();
                        ret = sdk.PerformGlossCalibration(in_com);
                        if (!ErrorDefine.IsNormalCode(ret.errorCode))
                        {
                            Console.WriteLine("Error:{0:d} PerformGlossCalibration", ret.errorCode);
                            sdk.DisConnect(in_com);
                            return;
                        }
                        break;

                    case CalStatus.StatusUser:
                        // User calibration
                        Console.WriteLine("Please set the User calibration box.");
                        Console.ReadKey();
                        ret = sdk.PerformUserCalibration(in_com);
                        if (!ErrorDefine.IsNormalCode(ret.errorCode))
                        {
                            Console.WriteLine("Error:{0:d} PerformUserCalibration", ret.errorCode);
                            sdk.DisConnect(in_com);
                            return;
                        }
                        break;

                    default:
                        calComplete = true;
                        break;
                }
            }
            while (!calComplete);

            // Perform measurement
            Console.WriteLine("Please set the sample plate.");
            Console.ReadKey();
            ret = sdk.PerformMeasurement(in_com);
            if (!ErrorDefine.IsNormalCode(ret.errorCode))
            {
                Console.WriteLine("Error:{0:d} PerformMeasurement", ret.errorCode);
                sdk.DisConnect(in_com);
                return;
            }

            // Polling measurement
            MeasStatus measStatus;
            do
            {
                ret = sdk.PollingMeasurement(out measStatus, in_com);
                if (!ErrorDefine.IsNormalCode(ret.errorCode))
                {
                    Console.WriteLine("Error:{0:d} PollingMeasurement", ret.errorCode);
                    sdk.DisConnect(in_com);
                    return;
                }
            }
            while (measStatus != MeasStatus.Idling);

            // Set MeasDataType to display on the screen
            Dictionary<MeasDataType, string> convertMeasColorDataTypeTable = new Dictionary<MeasDataType, string>()
            {
                { MeasDataType.DTYPE_SPEC, "SPEC" },
            };
            Dictionary<MeasDataType, string> convertMeasSpecDataTypeTable = new Dictionary<MeasDataType, string>()
            {
                { MeasDataType.DTYPE_GLOSS, "GLOSS" }, { MeasDataType.DTYPE_SPEC, "SPEC" },
            };

            // Get sample color data
            MeasDataColor measurementColorData = new MeasDataColor();
            measurementColorData.color = ColorSpace.COLOR_LAB;
            ret = sdk.ReadAllLatestData(measurementColorData, in_com);
            if (!ErrorDefine.IsNormalCode(ret.errorCode))
            {
                Console.WriteLine("Error:{0:d} ReadAllLatestData Color", ret.errorCode);
                sdk.DisConnect(in_com);
                return;
            }
            // Colorimetric data display
            foreach (KeyValuePair<MeasDataType, List<double>> data in measurementColorData.data)
            {
                if (convertMeasColorDataTypeTable.ContainsKey(data.Key))
                {
                    Console.WriteLine("{3} L*:{0,6:f2} a*:{1,6:f2} b*:{2,6:f2}", data.Value[0], data.Value[1], data.Value[2], convertMeasColorDataTypeTable[data.Key]);
                }
            }

            // Get sample spec data
            Dictionary<MeasDataType, List<double>> measurementSpecData = new Dictionary<MeasDataType, List<double>>();
            ret = sdk.ReadAllLatestData(out measurementSpecData, in_com);
            if (!ErrorDefine.IsNormalCode(ret.errorCode))
            {
                Console.WriteLine("Error:{0:d} ReadAllLatestData Spec", ret.errorCode);
                sdk.DisConnect(in_com);
                return;
            }
            // Spectral data display
            if (measurementSpecData.Count != 0)
            {
                Console.Write("      ");
                foreach (MeasDataType key in measurementSpecData.Keys)
                {
                    if (convertMeasSpecDataTypeTable.ContainsKey(key))
                    {
                        Console.Write("{0:s},   ", convertMeasSpecDataTypeTable[key]);
                    }
                }
                Console.Write('\n');

                int waveLength = instInfoEx.WaveLengthStart;
                int maxWaveCount = ((instInfoEx.WaveLengthEnd - instInfoEx.WaveLengthStart) / instInfoEx.WaveLengthPitch) + 1;
                for (Int32 count = 0; count < maxWaveCount; count++)
                {
                    Console.Write("{0:d3}: ", waveLength);
                    foreach (MeasDataType key in measurementSpecData.Keys)
                    {
                        if (convertMeasSpecDataTypeTable.ContainsKey(key))
                        {
                            Console.Write("{0,6:f2}, ", measurementSpecData[key][count]);
                        }
                    }
                    Console.Write('\n');
                    waveLength += instInfoEx.WaveLengthPitch;
                }
            }

            // Disconnect
            sdk.DisConnect(in_com);

            return;
        }

        static void ReadSampleData(Int32 in_com)
        {
            ColorManagementMISDK sdk = ColorManagementMISDK.GetInstance();

            // Connect
            ReturnMessage ret = sdk.Connect(in_com);
            if (!ErrorDefine.IsNormalCode(ret.errorCode))
            {
                Console.WriteLine("Error:{0:d} Connect", ret.errorCode);
                return;
            }

            // Get instrumentInfo
            InstrumentInfoEx instInfoEx;
            ret = sdk.GetInstrumentInfo(out instInfoEx, in_com);
            if (!ErrorDefine.IsNormalCode(ret.errorCode))
            {
                Console.WriteLine("Error:{0:d} GetInstrumentInfo Ex", ret.errorCode);
                sdk.DisConnect(in_com);
                return;
            }

            if (instInfoEx.Name != "CM-25cG")
            {
                Console.WriteLine("Unsppoted instrument");
                sdk.DisConnect(in_com);
                return;
            }

            // Get sample count
            Int32 sampleCount = 0;
            ret = sdk.GetSampleCount(out sampleCount, in_com);
            if (!ErrorDefine.IsNormalCode(ret.errorCode))
            {
                Console.WriteLine("Error:{0:d} GetSampleCount", ret.errorCode);
                sdk.DisConnect(in_com);
                return;
            }

            Dictionary<DataId, string> convertDataIDTable1 = new Dictionary<DataId, string>() { { DataId.DATAID_GLOSS, " GLOSS" }, { DataId.DATAID_SPEC, " SPEC " } };

            for (Int32 i = 1; i <= sampleCount; i++)
            {
                SampleData sampleData = new SampleData();
                sampleData.ColorData = new ColorValue();
                SampleDataPack sampleDataPacket = new SampleDataPack();

                // Get sample data
                ret = sdk.GetSampleData(i, sampleDataPacket, in_com);
                if (!ErrorDefine.IsNormalCode(ret.errorCode))
                {
                    Console.WriteLine("Error:{0:d} GetSampleData", ret.errorCode);
                    sdk.DisConnect(in_com);
                    return;
                }
                Console.WriteLine("No.{0:d4} Name:{1} Date:{2}", i, sampleDataPacket.name, sampleDataPacket.date);
                Console.WriteLine("{0} {1}", sampleDataPacket.meas_mode.ToString(), sampleDataPacket.meas_area.ToString());

                // Display data
                if (sampleDataPacket.data != null && sampleDataPacket.data.Count != 0)
                {
                    Console.Write("   , ");
                    foreach (DataId key in sampleDataPacket.data.Keys)
                    {
                        Console.Write("{0:s}, ", convertDataIDTable1[key]);
                    }
                    Console.Write('\n');

                    int maxCount = sampleDataPacket.data.Values.FirstOrDefault().Count;
                    int WaveLength = instInfoEx.WaveLengthStart;

                    // Spectral & Gloss data display
                    for (Int32 count = 0; count < maxCount; count++)
                    {
                        Console.Write("{0:d3}, ", WaveLength);
                        foreach (DataId key in sampleDataPacket.data.Keys)
                        {
                            Console.Write("{0,6:00.00}, ", sampleDataPacket.data[key][count]);
                        }
                        Console.Write('\n');
                        WaveLength += instInfoEx.WaveLengthPitch;
                    }
                }
            }

            // Disconnect
            sdk.DisConnect(in_com);

            return;
        }

        static void WriteTargetData(Int32 in_com)
        {
            ColorManagementMISDK sdk = ColorManagementMISDK.GetInstance();

            // Connect
            ReturnMessage ret = sdk.Connect(in_com);
            if (!ErrorDefine.IsNormalCode(ret.errorCode))
            {
                Console.WriteLine("Error:{0:d} Connect", ret.errorCode);
                return;
            }

            // Get instrumentInfo
            InstrumentInfoEx instInfoEx;
            ret = sdk.GetInstrumentInfo(out instInfoEx, in_com);
            if (!ErrorDefine.IsNormalCode(ret.errorCode))
            {
                Console.WriteLine("Error:{0:d} GetInstrumentInfo Ex", ret.errorCode);
                sdk.DisConnect(in_com);
                return;
            }

            if (instInfoEx.Name != "CM-25cG")
            {
                Console.WriteLine("Unsppoted instrument");
                sdk.DisConnect(in_com);
                return;
            }

            Console.WriteLine("Please input the target number to be written. 1-2500");
            int targetNum = Convert.ToInt32(Console.ReadLine());

            // Set target data
            TargetDataPack targetDataPack = new TargetDataPack();
            // Set time
            targetDataPack.date = DateTime.Now;
            // Set group list
            targetDataPack.group_list = new List<int> { 0, 0, 0, 0, 0 };
            // Set name (MAX 30 characters)
            string name = "target:" + targetNum.ToString();
            if (name.Length > 30) { name.Remove(30); }
            targetDataPack.name = name;
            // Set meas mode
            targetDataPack.meas_mode = MeasCondMode.MeasModeColorAndGloss;
            // Set meas area
            targetDataPack.meas_area = MeasArea.AREA_MAV;
            // Set meas type
            targetDataPack.meas_type = MeasType.MEASTYPE_NONE;
            // Set meas angel
            targetDataPack.meas_angle = MeasAngle.MEAS_ANGLE_NONE;
            // Set light direction
            targetDataPack.l_direction = LightDirection.LDIRECTION_NONE;
            // Set meas specular component 
            targetDataPack.meas_scie = MeasCondScie.SC_NONE;
            // Set meas UV
            targetDataPack.meas_uv = MeasCondUv.UV_NONE;
            // Set warning level
            targetDataPack.warning_level = 80;
            // Set warning
            targetDataPack.warning = 0;
            // Set diagnosis
            targetDataPack.diagnosis = 0;
            // Set data attribute
            int specOrColor = 0;
            Console.WriteLine("Please set 1 for spectral and 2 for colorimetric.");
            specOrColor = Convert.ToInt32(Console.ReadLine());
            if (specOrColor == 1)
            {
                // spectral data
                targetDataPack.data_attr = DataAttr.DATAATTR_SPEC;
            }
            else
            {
                // colorimetric data
                targetDataPack.data_attr = DataAttr.DATAATTR_LAB;
            }

            // Set target data
            if (specOrColor == 1)
            {
                // spectral data
                List<double> gloss = new List<double>();
                gloss.Add(10.00);
                List<double> data = new List<double>();
                for (Int32 i = instInfoEx.WaveLengthStart; i <= instInfoEx.WaveLengthEnd; i += instInfoEx.WaveLengthPitch)
                {
                    data.Add(100.00);
                }
                targetDataPack.data = new Dictionary<DataId, List<double>>();
                targetDataPack.data.Add(DataId.DATAID_GLOSS, gloss);
                targetDataPack.data.Add(DataId.DATAID_SPEC, data);

                // Set target
                ret = sdk.SetTargetData(targetNum, targetDataPack, in_com);
                if (!ErrorDefine.IsNormalCode(ret.errorCode))
                {
                    Console.WriteLine("Error:{0:d} SetTargetData", ret.errorCode);
                    sdk.DisConnect(in_com);
                    return;
                }
            }
            else if (specOrColor == 2)
            {
                targetDataPack.data_color = new ColorData();
                targetDataPack.data_color.obs1 = Observer.Deg10;
                targetDataPack.data_color.ill1 = Illuminant.ILL_D65;
                targetDataPack.data_color.obs2 = Observer.Deg10;
                targetDataPack.data_color.ill2 = Illuminant.ILL_C;

                targetDataPack.data_color.data1 = new Dictionary<DataId, List<double>>();
                List<double> data1 = new List<double>() { 100.00, 100.00, 100.00 };
                targetDataPack.data_color.data1.Add(DataId.DATAID_SPEC, data1);

                targetDataPack.data_color.data2 = new Dictionary<DataId, List<double>>();
                List<double> data2 = new List<double>() { 99.00, 1.10, 1.20 };
                targetDataPack.data_color.data2.Add(DataId.DATAID_SPEC, data2);

                List<double> gloss = new List<double>() { 10.00 };
                targetDataPack.data_color.data1.Add(DataId.DATAID_GLOSS, gloss);
                targetDataPack.data_color.data2.Add(DataId.DATAID_GLOSS, gloss);

                // Set target
                ret = sdk.SetTargetData(targetNum, targetDataPack, in_com);
                if (!ErrorDefine.IsNormalCode(ret.errorCode))
                {
                    Console.WriteLine("Error:{0:d} SetTargetData", ret.errorCode);
                    sdk.DisConnect(in_com);
                    return;
                }
            }
            else
            {
                // specOrColor
                Console.WriteLine("Unsupported");
                sdk.DisConnect(in_com);
                return;
            }

            // Set tolerance for light source primary
            DataForm dataForm = new DataForm();
            dataForm.IrradiationDirection = IrradiationDirection.NO_PARAM;
            dataForm.DataType = DataType.NO_PARAM;
            ToleranceData tolerancePrimaryData = new ToleranceData();
            ToleranceParam tolerancePrimaryParam = new ToleranceParam();
            tolerancePrimaryParam.Upper_enable = 1;
            tolerancePrimaryParam.Upper_value = 1.1;
            tolerancePrimaryParam.Lower_enable = 1;
            tolerancePrimaryParam.Lower_value = -1.2;
            tolerancePrimaryData.Tolerance = new Dictionary<int, ToleranceParam>();
            tolerancePrimaryData.Tolerance.Add((int)ToleranceId.TOLERANCE_ID_L, tolerancePrimaryParam); //L*
            tolerancePrimaryData.Tolerance.Add((int)ToleranceId.TOLERANCE_ID_A, tolerancePrimaryParam); //a*
            tolerancePrimaryData.Tolerance.Add((int)ToleranceId.TOLERANCE_ID_B, tolerancePrimaryParam); //b*
            ret = sdk.SetToleranceForTarget(targetNum, 0, dataForm, tolerancePrimaryData, in_com);
            if (!ErrorDefine.IsNormalCode(ret.errorCode))
            {
                Console.WriteLine("Error:{0:d} SetToleranceForTarget primary", ret.errorCode);
                sdk.DisConnect(in_com);
                return;
            }

            // Set tolerance for light source secondary
            ToleranceData toleranceSecondaryData = new ToleranceData();
            ToleranceParam toleranceSecondaryParam = new ToleranceParam();
            toleranceSecondaryParam.Upper_enable = 0;
            toleranceSecondaryParam.Upper_value = 2.1;
            toleranceSecondaryParam.Lower_enable = 0;
            toleranceSecondaryParam.Lower_value = -2.2;
            toleranceSecondaryData.Tolerance = new Dictionary<int, ToleranceParam>();
            toleranceSecondaryData.Tolerance.Add((int)ToleranceId.TOLERANCE_ID_L, toleranceSecondaryParam); //L*
            toleranceSecondaryData.Tolerance.Add((int)ToleranceId.TOLERANCE_ID_A, toleranceSecondaryParam); //a*
            toleranceSecondaryData.Tolerance.Add((int)ToleranceId.TOLERANCE_ID_B, toleranceSecondaryParam); //b*
            ret = sdk.SetToleranceForTarget(targetNum, 1, dataForm, toleranceSecondaryData, in_com);
            if (!ErrorDefine.IsNormalCode(ret.errorCode))
            {
                Console.WriteLine("Error:{0:d} SetToleranceForTarget secondary", ret.errorCode);
                sdk.DisConnect(in_com);
                return;
            }

            // Set parametric for tolerance
            ParametricCoef parametricData = new ParametricCoef();
            parametricData.CMC = new List<double>();
            parametricData.CMC.Add(1.1);
            parametricData.CMC.Add(1.2);
            parametricData.DeltaE94 = new List<double>();
            parametricData.DeltaE94.Add(2.1);
            parametricData.DeltaE94.Add(2.2);
            parametricData.DeltaE94.Add(2.3);
            parametricData.DeltaE00 = new List<double>();
            parametricData.DeltaE00.Add(3.1);
            parametricData.DeltaE00.Add(3.2);
            parametricData.DeltaE00.Add(3.3);
            ret = sdk.SetParametricForTarget(targetNum, dataForm, parametricData, in_com);
            if (!ErrorDefine.IsNormalCode(ret.errorCode))
            {
                Console.WriteLine("Error:{0:d} SetParametricForTarget", ret.errorCode);
                sdk.DisConnect(in_com);
                return;
            }

            // Disconnect
            sdk.DisConnect(in_com);

            return;
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
            Int32 COMPort = Convert.ToInt32(new string(args[1].Where(Char.IsDigit).ToArray()));

            string version = string.Empty;
            ColorManagementMISDK.GetInstance().GetSDKVersion(out version);
            Console.WriteLine("SDK Version: {0:s} COM{1}",version, COMPort);

            switch (args[0])
            {
                case "1":
                    // Perform measurement
                    PerformMeasurement(COMPort);
                    break;

                case "2":
                    // Read sample data
                    ReadSampleData(COMPort);
                    break;

                case "3":
                    // Write target data
                    WriteTargetData(COMPort);
                    break;
            }

            Console.ReadKey();
        }
    }
}
