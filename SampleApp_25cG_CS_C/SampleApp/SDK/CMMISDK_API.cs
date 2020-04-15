using System;
using System.Runtime.InteropServices;

using CMMISDK_CalStatus = System.Int32;
using CMMISDK_CalDataType = System.Int32;
using CMMISDK_MeasStatus = System.Int32;
using CMMISDK_DataType = System.Int32;
using CMMISDK_CondUvAdjust = System.Int32;
using CMMISDK_UvAdjustDataType = System.Int32;
using CMMISDK_MeasType = System.Int32;
using CMMISDK_MeasArea = System.Int32;
using CMMISDK_MeasAngle = System.Int32;
using CMMISDK_MeasMode = System.Int32;
using CMMISDK_SpecularComponent = System.Int32;
using CMMISDK_Uv = System.Int32;
using CMMISDK_SaveMode = System.Int32;
using CMMISDK_Observer = System.Int32;
using CMMISDK_Illuminant = System.Int32;
using CMMISDK_ColorSpace = System.Int32;
using CMMISDK_Equation = System.Int32;
using CMMISDK_CustomIndex = System.Int32;
using CMMISDK_Direction = System.Int32;
using CMMISDK_LightDirection = System.Int32;
using CMMISDK_DataAttr = System.Int32;
using CMMISDK_FilterIndex = System.Int32;
using CMMISDK_InstrumentMode = System.Int32;
using CMMISDK_UserType = System.Int32;
using CMMISDK_ScreenDirection = System.Int32;
using CMMISDK_DateFormat = System.Int32;
using CMMISDK_Language = System.Int32;
using CMMISDK_JobStepType = System.Int32;
using CMMISDK_OnOff = System.Int32;
using CMMISDK_ToleranceType = System.Int32;
using CMMISDK_ToleranceId = System.Int32;
using CMMISDK_ParametricId = System.Int32;
using CMMISDK_CapabilityType = System.Int32;
using CMMISDK_DateType = System.Int32;

using CMMISDK_DisplayType = System.Int32;
using error_km = System.Int32;

using CMMISDK_Warning = System.Int32;

namespace Konicaminolta.CMMISDK.API
{
    static partial class Define
    {
        public const Int32 DISPTYPE_ABS = 0x001;
        public const Int32 DISPTYPE_DIF = 0x002;
        public const Int32 DISPTYPE_ABSDIF = 0x004;
        public const Int32 DISPTYPE_CUSTOM = 0x008;
        public const Int32 DISPTYPE_GRAPH_ABS = 0x010;
        public const Int32 DISPTYPE_GRAPH_DIF = 0x020;
        public const Int32 DISPTYPE_GRAPH_REF = 0x040;
        public const Int32 DISPTYPE_PASS_FAIL = 0x080;
        public const Int32 DISPTYPE_MI = 0x100;
        public const Int32 DISPTYPE_GRAPH_LINE = 0x200;
        public const Int32 DISPTYPE_AUDI2000_EC = 0x400;
        public const Int32 DISPTYPE_AUDI2000_EP = 0x800;
        public const Int32 SIZE_PORTNAME = 32;
        public const Int32 SIZE_INSTRUMENT_NAME = 32;
        public const Int32 SIZE_DATA = 39;
        public const Int32 SIZE_USERCAL_ID = 16;
		public const Int32 SIZE_GG = 5;
		public const Int32 SIZE_GG_PARAM = 7;
        public const Int32 SIZE_USER_ILLUMINANT = 85;
		public const Int32 SIZE_USER_ILL_NAME = 16;
        public const Int32 SIZE_TARGET = 2500;
        public const Int32 SIZE_DATE = 6;
        public const Int32 SIZE_GROUP = 5;
        public const Int32 SIZE_GROUP_ALL = 50;
        public const Int32 SIZE_DATANAME = 64;
        public const Int32 SIZE_UUID = 16;
        public const Int32 SIZE_PARAMETRIC_COEF = 3;
        public const Int32 SIZE_USER_EQUATION = 200;
        public const Int32 SIZE_GROUP_NAME = 32;
        public const Int32 SIZE_ADMIN_PASS = 8;
        public const Int32 SIZE_JOB_NAME = 32;
        public const Int32 SIZE_JOB_COMMENT = 128;
        public const Int32 SIZE_JOB_INDEX = 7;
        public const Int32 SIZE_JOBIMAGE_NAME = 32;
        public const Int32 SIZE_IMAGEDATA = 153600;
        public const Int32 SIZE_IMAGE_FINDER = 307200;
    }

    public enum _CMMISDK_CalStatus
    {
        StatusZero = 0,
        StatusWhite,
        StatusGloss,
        StatusMeasure,
        StatusMeasureWrn,
        StatusUser,
    }
    public enum _CMMISDK_CalDataType
    {
        CALTYPE_MAV = 0,
        CALTYPE_SAV,


        CALTYPE_MAV_SCI = 0,
        CALTYPE_MAV_SCE,
        CALTYPE_SAV_SCI,
        CALTYPE_SAV_SCE,


        CALTYPE_L_ANGLE_M15 = 0,
        CALTYPE_L_ANGLE_15,
        CALTYPE_L_ANGLE_25,
        CALTYPE_L_ANGLE_45,
        CALTYPE_L_ANGLE_75,
        CALTYPE_L_ANGLE_110,
        CALTYPE_R_ANGLE_M15,
        CALTYPE_R_ANGLE_15,
        CALTYPE_R_ANGLE_25,
        CALTYPE_R_ANGLE_45,
        CALTYPE_R_ANGLE_75,
        CALTYPE_R_ANGLE_110,
	

		CALTYPE_LAV_SCI = 4,	
		CALTYPE_LAV_SCE,		
	
		CALTYPE_LMAV_SCI = 6,	
		CALTYPE_LMAV_SCE,		
		CALTYPE_TRA,
    }
    public enum _CMMISDK_MeasStatus
    {
        Idling = 0,
        Measuring
    }
    public enum _CMMISDK_DataType
    {
        DATATYPE_GLOSS = 0,
        DATATYPE_SPEC = 1,

        DATATYPE_SCI = 1,
        DATATYPE_SCE = 2,
        DATATYPE_BACKWHITE = 3,
        DATATYPE_BACKBLACK = 4,

	    DATATYPE_SCI_UVFULL = 10,	
	    DATATYPE_SCE_UVFULL = 11,	
	    DATATYPE_SCI_UVCUT = 12,	
	    DATATYPE_SCE_UVCUT = 13,	
	    DATATYPE_SCI_UVADJ = 14,	
	    DATATYPE_SCE_UVADJ = 15,	

	    DATATYPE_TRA = 16,			

        DATATYPE_L_ANGLE_M15 = 0,
        DATATYPE_L_ANGLE_15,
        DATATYPE_L_ANGLE_25,
        DATATYPE_L_ANGLE_45,
        DATATYPE_L_ANGLE_75,
        DATATYPE_L_ANGLE_110,
        DATATYPE_R_ANGLE_M15,
        DATATYPE_R_ANGLE_15,
        DATATYPE_R_ANGLE_25,
        DATATYPE_R_ANGLE_45,
        DATATYPE_R_ANGLE_75,
        DATATYPE_R_ANGLE_110,
        DATATYPE_DP_ANGLE_M15,
        DATATYPE_DP_ANGLE_15,
        DATATYPE_DP_ANGLE_25,
        DATATYPE_DP_ANGLE_45,
        DATATYPE_DP_ANGLE_75,
        DATATYPE_DP_ANGLE_110,
    }
	public enum _CMMISDK_CondUvAdjust
	{
		UVADJ_PROFILE =	0,	
		UVADJ_WI,			
		UVADJ_TINT,			
		UVADJ_WITINT,		
		UVADJ_BRIGHTNESS,	
		UVADJ_GG,			
		UVADJ_NONE = -1,
	}
	public enum _CMMISDK_UvAdjustDataType
	{
		UVADJ_DATATYPE_SCI = 0,	
		UVADJ_DATATYPE_SCE,
	}
    public enum _CMMISDK_MeasType
    {
        MEASTYPE_REF = 0,
        MEASTYPE_TRA,
        MEASTYPE_NONE = -1,
    }
    public enum _CMMISDK_MeasArea
    {
        AREA_MAV = 0,
        AREA_SAV = 1,
        AREA_LAV = 2,
		AREA_LMAV = 3,	
        AREA_NONE = -1,
    }
    public enum _CMMISDK_MeasAngle
    {
        MEAS_ANGLE_M15 = 0x01,
        MEAS_ANGLE_15 = 0x02,
        MEAS_ANGLE_25 = 0x04,
        MEAS_ANGLE_45 = 0x08,
        MEAS_ANGLE_75 = 0x10,
        MEAS_ANGLE_110 = 0x20,
        MEAS_ANGLE_NONE = -1,
    }
    public enum _CMMISDK_MeasMode
    {
        MEASMODE_COLORANDGLOSS = 0,
        MEASMODE_COLORONLY,
        MEASMODE_GLOSSONLY,
        MEASMODE_OPACITY,
        MEASMODE_NONE = -1,
    }
    public enum _CMMISDK_SpecularComponent
    {
        SC_SCI = 0,
        SC_SCE,
        SC_SCIE,
        SC_NONE = -1,
    }
    public enum _CMMISDK_Uv
    {
        UV_100 = 0,
        UV_CUT400,
        UV_CUT420,
        UV_CUT400N,
        UV_CUT400L,
        UV_CUT420N,
        UV_CUT420L,
        UV_100_CUT400,
        UV_100_CUT420,
        UV_100_CUT400N,
        UV_100_CUT400L,
        UV_100_CUT420N,
        UV_100_CUT420L,

        UV_NONE = -1,
    }
    public enum _CMMISDK_SaveMode
    {
        SAVEMODE_AUTO = 0,
        SAVEMODE_MANUAL,
    }
    public enum _CMMISDK_Observer
    {
        OBS_02 = 0,
        OBS_10,
    }
    public enum _CMMISDK_Illuminant
    {
        ILL_NONE = 0,
        ILL_A,
        ILL_C,
        ILL_D50,

        ILL_D65,
        ILL_ID50,
        ILL_ID65,
        ILL_F2,
        ILL_F6,
        ILL_F7,
        ILL_F8,
        ILL_F10,
        ILL_F11,
        ILL_F12,
        ILL_USER1,
    }
    public enum _CMMISDK_ColorSpace
    {
        COLOR_LAB = 0,
        COLOR_LCH,
        COLOR_HLAB,
        COLOR_YXY,
        COLOR_XYZ,
        COLOR_MUNSELL_C,
    }
    public enum _CMMISDK_Equation
    {
        EQUATION_DE1976 = 0,
        EQUATION_CMC,
        EQUATION_DE1994,
        EQUATION_DE2000,
        EQUATION_DEH,
        EQUATION_DEP,
        EQUATION_DEC,
        EQUATION_DE99o,
    }
    public enum _CMMISDK_CustomIndex
    {
        CUSTOM_NONE = 0,

        CUSTOM_L,
        CUSTOM_A,
        CUSTOM_B,
        CUSTOM_C,
        CUSTOM_H,
        CUSTOM_HL,
        CUSTOM_HA,
        CUSTOM_HB,
        CUSTOM_X,
        CUSTOM_Y,
        CUSTOM_Z,
        CUSTOM_SX,
        CUSTOM_SY,
        CUSTOM_MH,
        CUSTOM_MV,
        CUSTOM_MC,
        CUSTOM_WI_E,
        CUSTOM_WI_C,
        CUSTOM_TINT_C,
        CUSTOM_YI_E,
        CUSTOM_YI_D,
        CUSTOM_B_ISO,
        CUSTOM_GU,
        CUSTOM_USER_E1,
        CUSTOM_USER_C1,
        CUSTOM_USER_E2,
        CUSTOM_USER_C2,
        CUSTOM_USER_E3,
        CUSTOM_USER_C3,
        CUSTOM_GLOSS8,
		CUSTOM_WI_G,			
		CUSTOM_TINT_G,			

        CUSTOM_DL = -1,
        CUSTOM_DA = -2,
        CUSTOM_DB = -3,
        CUSTOM_DC = -4,
        CUSTOM_DH = -5,
        CUSTOM_DHL = -6,
        CUSTOM_DHA = -7,
        CUSTOM_DHB = -8,
        CUSTOM_DX = -9,
        CUSTOM_DY = -10,
        CUSTOM_DZ = -11,
        CUSTOM_DSX = -12,
        CUSTOM_DSY = -13,
        CUSTOM_DWI_E = -14,
        CUSTOM_DWI_C = -15,
        CUSTOM_DTINT_C = -16,
        CUSTOM_DYI_E = -17,
        CUSTOM_DYI_D = -18,
        CUSTOM_DB_ISO = -19,
        CUSTOM_DGU = -20,
        CUSTOM_MI = -21,
        CUSTOM_DE = -22,
        CUSTOM_CMC = -23,
        CUSTOM_DE94 = -24,
        CUSTOM_DE00 = -25,
        CUSTOM_DEH = -26,
        CUSTOM_DE99O = -27,

        CUSTOM_STRENGTH_XYZ = -28,
        CUSTOM_STRENGTH_X = -29,
        CUSTOM_STRENGTH_Y = -30,
        CUSTOM_STRENGTH_Z = -31,
        CUSTOM_GREYSCALE = -32,
		CUSTOM_DWI_G = -33,			
		CUSTOM_DTINT_G = -34,
    }
    public enum _CMMISDK_Direction
    {
        DIRECTION_DP = 0,
        DIRECTION_L,
    }
    public enum _CMMISDK_LightDirection
    {
        LDIRECTION_NONE = 0,
        LDIRECTION_L = 0x01,
        LDIRECTION_R = 0x02,
        LDIRECTION_DP = 0x04,
    }
    public enum _CMMISDK_DataAttr
    {
        DATAATTR_SPEC = 0,
        DATAATTR_LAB,
        DATAATTR_HLAB,
        DATAATTR_XYZ,
    }
    public enum _CMMISDK_FilterIndex
    {
        FILTER_OFF = 0,
        FILTER_SAVE,
        FILTER_GROUP,
    }
    public enum _CMMISDK_InstrumentMode
    {
        INSTRUMENTMODE_NORMAL = 0,
        INSTRUMENTMODE_SIMPLE,
    }
    public enum _CMMISDK_UserType
    {
        USERTYPE_ADMIN = 0,
        USERTYPE_WORKER,
    }
    public enum _CMMISDK_ScreenDirection
    {
        SCREENDIR_0 = 0,
        SCREENDIR_180,
    }
    public enum _CMMISDK_DateFormat
    {
        DF_YYYYMMDD = 0,
        DF_MMDDYYYY,
        DF_DDMMYYYY,
    }
    public enum _CMMISDK_Language
    {
        LANGUAGE_ENGLISH = 0,
        LANGUAGE_JAPANESE,
        LANGUAGE_GERMAN,
        LANGUAGE_FRENCH,
        LANGUAGE_SPANISH,
        LANGUAGE_ITALIAN,
        LANGUAGE_CHINESE_S,
        LANGUAGE_PORTUGUESE,
        LANGUAGE_RUSSIAN,
        LANGUAGE_POLISH,
        LANGUAGE_TURKISH,
    }
	public enum _CMMISDK_JobStepType
	{
		JOB_STEPTYPE_OPERATION = 0,	
		JOB_STEPTYPE_RESULT,
	}
    public enum _CMMISDK_OnOff
    {
        OFF = 0,
        ON,
    }
    public enum _CMMISDK_ToleranceType
    {
        TOLETYPE_SPEC = 0,


        TOLETYPE_SCI = 0,
        TOLETYPE_SCE = 1,


        TOLETYPE_L_ANGLE_M15 = 0,
        TOLETYPE_L_ANGLE_15 = 1,
        TOLETYPE_L_ANGLE_25 = 2,
        TOLETYPE_L_ANGLE_45 = 3,
        TOLETYPE_L_ANGLE_75 = 4,
        TOLETYPE_L_ANGLE_110 = 5,
        TOLETYPE_R_ANGLE_M15 = 6,
        TOLETYPE_R_ANGLE_15 = 7,
        TOLETYPE_R_ANGLE_25 = 8,
        TOLETYPE_R_ANGLE_45 = 9,
        TOLETYPE_R_ANGLE_75 = 10,
        TOLETYPE_R_ANGLE_110 = 11,
        TOLETYPE_DP_ANGLE_M15 = 12,
        TOLETYPE_DP_ANGLE_15 = 13,
        TOLETYPE_DP_ANGLE_25 = 14,
        TOLETYPE_DP_ANGLE_45 = 15,
        TOLETYPE_DP_ANGLE_75 = 16,
        TOLETYPE_DP_ANGLE_110 = 17,
    }
    public enum _CMMISDK_ToleranceId
    {
        TOLERANCE_ID_L = -1,
        TOLERANCE_ID_A = -2,
        TOLERANCE_ID_B = -3,
        TOLERANCE_ID_C = -4,
        TOLERANCE_ID_H = -5,
        TOLERANCE_ID_HL = -6,
        TOLERANCE_ID_HA = -7,
        TOLERANCE_ID_HB = -8,
        TOLERANCE_ID_X = -9,
        TOLERANCE_ID_Y = -10,
        TOLERANCE_ID_Z = -11,
        TOLERANCE_ID_SX = -12,
        TOLERANCE_ID_SY = -13,
        TOLERANCE_ID_WI_E = -14,
        TOLERANCE_ID_WI_C = -15,
        TOLERANCE_ID_TINT_C = -16,
        TOLERANCE_ID_YI_E = -17,
        TOLERANCE_ID_YI_D = -18,
        TOLERANCE_ID_B_ISO = -19,
        TOLERANCE_ID_GU = -20,
        TOLERANCE_ID_MI = -21,
        TOLERANCE_ID_DE = -22,
        TOLERANCE_ID_CMC = -23,
        TOLERANCE_ID_DE94 = -24,
        TOLERANCE_ID_DE00 = -25,
        TOLERANCE_ID_DEH = -26,
        TOLERANCE_ID_DEP_DIN6175 = -27,
        TOLERANCE_ID_DEC_DIN6175 = -28,
        TOLERANCE_ID_FF = -29,
        TOLERANCE_ID_DE99O = -30,
        TOLERANCE_ID_DEC_AUDI2000 = -31,
        TOLERANCE_ID_MDEC_AUDI2000 = -32,
        TOLERANCE_ID_DECM_AUDI2000 = -33,
        TOLERANCE_ID_DEP_AUDI2000 = -34,
        TOLERANCE_ID_MDEP_AUDI2000 = -35,
        TOLERANCE_ID_DEPM_AUDI2000 = -36,
        TOLERANCE_ID_DSTRENGTH_XYZ = -37,
        TOLERANCE_ID_DSTRENGTH_X = -38,
        TOLERANCE_ID_DSTRENGTH_Y = -39,
        TOLERANCE_ID_DSTRENGTH_Z = -40,
        TOLERANCE_ID_DOPACITY = -41,
        TOLERANCE_ID_DGRAYSCALE = -42,
		TOLERANCE_ID_WI_G = -43,	
		TOLERANCE_ID_TINT_G = -44,
    }
    public enum _CMMISDK_ParametricId
    {
        PARAMETRIC_ID_CMC = 0,
        PARAMETRIC_ID_DE94,
        PARAMETRIC_ID_DE00,
    }
	public enum _CMMISDK_CapabilityType
    {
		CAPTYPE_LIST_SINGLE = 0,	
		CAPTYPE_LIST_MULTI,			
		CAPTYPE_VALUE,
    }
    public enum _CMMISDK_DateType
    {
        DATETYPE_COLOR = 0,
        DATETYPE_GLOSS,
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct CMMISDK_Port
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Define.SIZE_PORTNAME)]
        public byte[] port_name;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct CMMISDK_InstrumentInfo
    {
        public Int32 DataSize;
        public Int32 WaveLengthStart;
        public Int32 WaveLengthEnd;
        public Int32 WaveLengthPitch;
        public Int32 SerialNo;
        public Int32 VersionMajor;
        public Int32 VersionMinor;
        public Int32 VersionFree;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Define.SIZE_INSTRUMENT_NAME)]
        public byte[] InstrumentName;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct CMMISDK_Version
    {
        public Int32 major;
        public Int32 minor;
        public Int32 free;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct CMMISDK_Data
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Define.SIZE_DATA)]
        public double[] data;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct CMMISDK_ColorCond
    {
        public CMMISDK_Observer obs;
        public CMMISDK_Illuminant ill;
        public CMMISDK_ColorSpace colorSpace;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct CMMISDK_UserCalId
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Define.SIZE_USERCAL_ID)]
        public byte[] id;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
	public struct CMMISDK_UvAdjustIndex
    {
		public double value;
		public double tolerance;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct CMMISDK_UvAdjustCoef
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=Define.SIZE_DATA)]
        public double[] coefficient;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=Define.SIZE_DATA)]
        public double[] correction;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=Define.SIZE_GG_PARAM)]
        public double[] param;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst=Define.SIZE_DATE)]
		public Int32[] date;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct CMMISDK_UvAdjustGG
    {
        public Int32 count;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=Define.SIZE_GG)]
        public double[] WI;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=Define.SIZE_GG)]
        public double[] Tint;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct CMMISDK_GGData
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=Define.SIZE_GG*Define.SIZE_DATA)]
        public double[] UvFull;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=Define.SIZE_GG*Define.SIZE_DATA)]
        public double[] UvCut;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct CMMISDK_CondSMC
    {
        public CMMISDK_OnOff enable;
        public double threshold;
        public Int32 times;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct CMMISDK_UserIlluminant
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Define.SIZE_USER_ILLUMINANT)]
        public double[] data;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst=Define.SIZE_USER_ILL_NAME)]
		public byte[] name;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct CMMISDK_SavedTargetList
    {
        public Int32 size;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Define.SIZE_TARGET)]
        public Int32[] list;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct CMMISDK_TargetProperty
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Define.SIZE_DATE)]
        public Int32[] date;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Define.SIZE_GROUP)]
        public Int32[] group_list;
        public CMMISDK_MeasType meas_type;
        public CMMISDK_MeasMode meas_mode;
        public CMMISDK_MeasArea meas_area;
        public CMMISDK_MeasAngle meas_angle;
        public CMMISDK_LightDirection meas_ldirection;
        public CMMISDK_SpecularComponent meas_scie;
        public CMMISDK_Uv meas_uv;
        public Int32 warning_level;
        public CMMISDK_Warning warning;
        public Int32 diagnosis;
        public CMMISDK_DataAttr data_attr;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Define.SIZE_DATANAME)]
        public byte[] name;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct CMMISDK_ToleranceData
    {
        public Int32 upper_enable;
        public Int32 upper_value;
        public Int32 lower_enable;
        public Int32 lower_value;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct CMMISDK_ParametricCoef
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Define.SIZE_PARAMETRIC_COEF)]
        public double[] coef;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct CMMISDK_SampleProperty
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Define.SIZE_DATE)]
        public Int32[] date;
        public CMMISDK_MeasType meas_type;
        public CMMISDK_MeasMode meas_mode;
        public CMMISDK_MeasArea meas_area;
        public CMMISDK_MeasAngle meas_angle;
        public CMMISDK_LightDirection meas_ldirection;
        public CMMISDK_SpecularComponent meas_scie;
        public CMMISDK_Uv meas_uv;
        public CMMISDK_Warning warning;
        public Int32 diagnosis;
        public CMMISDK_DataAttr data_attr;
        public Int32 relation_target;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Define.SIZE_DATANAME)]
        public byte[] name;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct CMMISDK_DateTime
    {
        public Int32 year;
        public Int32 month;
        public Int32 day;
        public Int32 hour;
        public Int32 minute;
        public Int32 second;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct CMMISDK_UserEquation
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Define.SIZE_USER_EQUATION)]
        public byte[] formula;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Define.SIZE_USER_EQUATION)]
        public byte[] user_class;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct CMMISDK_GroupList
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Define.SIZE_GROUP)]
        public Int32[] group;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct CMMISDK_Group
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Define.SIZE_GROUP_NAME)]
        public byte[] name;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct CMMISDK_GroupAll
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Define.SIZE_GROUP_ALL * Define.SIZE_GROUP_NAME)]
        public byte[] name;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct CMMISDK_AdminPass
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Define.SIZE_ADMIN_PASS)]
        public byte[] password;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct CMMISDK_JobInfo
    {
        public Int32 step_count;
        public CMMISDK_OnOff step_loop;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Define.SIZE_JOB_NAME)]
        public byte[] name;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct CMMISDK_JobStepOperation
    {
        public Int32 image_num;
        public CMMISDK_MeasType meas_type;
        public CMMISDK_MeasMode meas_mode;
        public CMMISDK_MeasArea meas_area;
        public CMMISDK_MeasAngle meas_angle;
        public CMMISDK_LightDirection meas_ldirection;
        public CMMISDK_SpecularComponent meas_scie;
        public CMMISDK_Uv meas_uv;
        public Int32 auto_ave_times;
        public Int32 manu_ave_times;
        public Int32 relation_target;
        public CMMISDK_OnOff enable_meas;
        public CMMISDK_OnOff enable_prev;
        public CMMISDK_OnOff enable_next;
        public CMMISDK_OnOff enable_end;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Define.SIZE_DATANAME)]
        public byte[] name;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Define.SIZE_JOB_COMMENT)]
        public byte[] comment;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct CMMISDK_JobStepResult
    {
        public CMMISDK_SpecularComponent meas_scie;
        public CMMISDK_Observer obs1;
        public CMMISDK_Observer obs2;
        public CMMISDK_Illuminant ill1;
        public CMMISDK_Illuminant ill2;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Define.SIZE_JOB_INDEX)]
        public CMMISDK_CustomIndex[] index;
        public CMMISDK_OnOff enable_meas;
        public CMMISDK_OnOff enable_prev;
        public CMMISDK_OnOff enable_next;
        public CMMISDK_OnOff enable_end;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct CMMISDK_JobImage
    {
        public Int32 width;
        public Int32 height;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Define.SIZE_IMAGEDATA)]
        public Int32[] data;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Define.SIZE_JOBIMAGE_NAME)]
        public byte[] name;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct CMMISDK_FinderImage
    {
        public Int32 width;
        public Int32 height;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Define.SIZE_IMAGE_FINDER)]
        public Int32[] data;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct CMMISDK_Image
    {
        public Int32 width;
        public Int32 height;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = Define.SIZE_IMAGEDATA)]
        public Int32[] data;
    }

    static partial class Define
    {
        public const Int32 KmWrBattery = 0x01;
        public const Int32 KmWrCalibration = 0x02;
        public const Int32 KmWrPreAnnualCalibraton = 0x04;
        public const Int32 KmWrAnnualCalibraton = 0x08;
        public const Int32 KmWrLampForColor = 0x10;
        public const Int32 KmWrOutOfColorRange = 0x20;
        public const Int32 KmWrOutOfGlossRange = 0x40;
        public const Int32 KmWrLampForGloss = 0x80;
    }

    public enum _error_km
    {
        KmSuccess = 0,
        KmWarning = 1,
        KmErNoConnect = 10,
        KmErInvalidParameter = 25,
        KmErCannotCommand = 30,
        KmErNoData = 45,
        KmErDataProtected = 46,
        KmErOutOfRangeValue = 50,
        KmErConnectFailed = 100,
        KmErDevice = 110,
        KmErAd = 111,
        KmErCharge = 112,
        KmErFlash = 113,
        KmErFinder = 114,
        KmErCalculation = 115,
		KmErCamera = 116,				
        KmErCalibration = 120,
        KmErCalibrationRequired = 130,
        KmErNoCalibrationData = 131,
        KmErTiltDetection = 140,
        KmErNotUse = 170,
        KmErDisagreeCond = 171,
		KmErUvAdjust = 172,				
        KmErBattery = 180,
        KmErMemory = 181,
        KmErMotor = 182,
        KmErNotSupported = 190,
        KmErCalculateColor = 195,
		KmErCalculateCoef = 196,		
        KmErUuid = 198,
        KmEr = 200,
		KmErTimeout = 210,
    }

    class CMMISDK_API_x86
    {
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_Connect(ref CMMISDK_Port inPortInfo, ref Int32 outInstrumentNo);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_Disconnect(Int32 inInstrumentNo);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetInstrumentInfo(Int32 inInstrumentNo, ref CMMISDK_InstrumentInfo outInfo);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetSDKVersion(ref CMMISDK_Version version);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetWarning(Int32 inInstrumentNo, ref CMMISDK_Warning warning);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetCalibrationStatus(Int32 inInstrumentNo, ref CMMISDK_CalStatus outCalStatus);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_PerformZeroCalibration(Int32 inInstrumentNo);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_PerformWhiteCalibration(Int32 inInstrumentNo);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_PerformGlossCalibration(Int32 inInstrumentNo);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_PerformUserCalibration(Int32 inInstrumentNo);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_PerformMeasurement(Int32 inInstrumentNo);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_PollingMeasurement(Int32 inInstrumentNo, ref CMMISDK_MeasStatus outStatus);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_CancelMeasurement(Int32 inInstrumentNo);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_ReadLatestDataSpec(Int32 inInstrumentNo, CMMISDK_DataType inDataType, ref CMMISDK_Data outData);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_ReadLatestDataColor(Int32 inInstrumentNo, CMMISDK_DataType inDataType, ref CMMISDK_ColorCond inColorCond, ref CMMISDK_Data outData);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_LoadLatestData(Int32 inInstrumentNo);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetLatestDataSpec(Int32 inInstrumentNo, CMMISDK_DataType inDataType, ref CMMISDK_Data outData);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetLatestDataColor(Int32 inInstrumentNo, CMMISDK_DataType inDataType, ref CMMISDK_ColorCond inColorCond, ref CMMISDK_Data outData);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetWhiteCalibrationData(Int32 inInstrumentNo, CMMISDK_CalDataType inDataType, Int32 inCalId, ref CMMISDK_Data inCalData);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetWhiteCalibrationData(Int32 inInstrumentNo, CMMISDK_CalDataType inDataType, ref Int32 outCalId, ref CMMISDK_Data outCalData);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetGlossCalibrationData(Int32 inInstrumentNo, CMMISDK_MeasArea inArea, Int32 inCalId, double inCalData);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetGlossCalibrationData(Int32 inInstrumentNo, CMMISDK_MeasArea inArea, ref Int32 outCalId, ref double outCalData); //Scriptと違うので注意
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetUserCalibrationData(Int32 inInstrumentNo, CMMISDK_CalDataType inDataType, ref CMMISDK_UserCalId inCalId, ref CMMISDK_Data inCalData);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetUserCalibrationData(Int32 inInstrumentNo, CMMISDK_CalDataType inDataType, ref CMMISDK_UserCalId outCalId, ref CMMISDK_Data outCalData);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetUserCalibrationEnable(Int32 inInstrumentNo, CMMISDK_OnOff inCalEnable);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetUserCalibrationEnable(Int32 inInstrumentNo, ref CMMISDK_OnOff outCalEnable);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetTriggerMode(Int32 inInstrumentNo, CMMISDK_OnOff inTrigger);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetTriggerMode(Int32 inInstrumentNo, ref CMMISDK_OnOff outTrigger);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_ClearTriggerData(Int32 inInstrumentNo);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_IsTriggerData(Int32 inInstrumentNo, ref CMMISDK_OnOff outData);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetZeroCalibrationDate(Int32 inInstrumentNo, CMMISDK_DateType inType, ref CMMISDK_DateTime outDate);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetWhiteCalibrationDate(Int32 inInstrumentNo, ref CMMISDK_DateTime outDate);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetGlossCalibrationDate(Int32 inInstrumentNo, ref CMMISDK_DateTime outDate);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetUserCalibrationDate(Int32 inInstrumentNo, ref CMMISDK_DateTime outDate);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_ClearUvAdjustInfo(Int32 inInstrumentNo);
        [DllImport("CMMISDK_x86.dll")]
		extern public static Int32 CMMISDK_SetProfileForUvAdjust(Int32 inInstrumentNo, ref CMMISDK_Data inData);
		[DllImport("CMMISDK_x86.dll")]
		extern public static Int32 CMMISDK_GetProfileForUvAdjust(Int32 inInstrumentNo, ref CMMISDK_Data outData);
		[DllImport("CMMISDK_x86.dll")]
		extern public static Int32 CMMISDK_SetWiForUvAdjust(Int32 inInstrumentNo, ref CMMISDK_UvAdjustIndex inData);
		[DllImport("CMMISDK_x86.dll")]
		extern public static Int32 CMMISDK_GetWiForUvAdjust(Int32 inInstrumentNo, ref CMMISDK_UvAdjustIndex outData);
		[DllImport("CMMISDK_x86.dll")]
		extern public static Int32 CMMISDK_SetTintForUvAdjust(Int32 inInstrumentNo, ref CMMISDK_UvAdjustIndex inData);
		[DllImport("CMMISDK_x86.dll")]
		extern public static Int32 CMMISDK_GetTintForUvAdjust(Int32 inInstrumentNo, ref CMMISDK_UvAdjustIndex outData);
		[DllImport("CMMISDK_x86.dll")]
		extern public static Int32 CMMISDK_SetIsoBrightnessForUvAdjust(Int32 inInstrumentNo, ref CMMISDK_UvAdjustIndex inData);
        [DllImport("CMMISDK_x86.dll")]
		extern public static Int32 CMMISDK_GetIsoBrightnessForUvAdjust(Int32 inInstrumentNo, ref CMMISDK_UvAdjustIndex outData);
		[DllImport("CMMISDK_x86.dll")]
		extern public static Int32 CMMISDK_SetGanzForUvAdjust(Int32 inInstrumentNo, ref CMMISDK_UvAdjustGG inData);
        [DllImport("CMMISDK_x86.dll")]
		extern public static Int32 CMMISDK_GetGanzForUvAdjust(Int32 inInstrumentNo, ref CMMISDK_UvAdjustGG outData);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetEachProfileForUvAdjust(Int32 inInstrumentNo, CMMISDK_UvAdjustDataType inType, ref CMMISDK_Data inData);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetEachProfileForUvAdjust(Int32 inInstrumentNo, CMMISDK_UvAdjustDataType inType, ref CMMISDK_Data outData);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetEachWiForUvAdjust(Int32 inInstrumentNo, CMMISDK_UvAdjustDataType inType, ref CMMISDK_UvAdjustIndex inData);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetEachWiForUvAdjust(Int32 inInstrumentNo, CMMISDK_UvAdjustDataType inType, ref CMMISDK_UvAdjustIndex outData);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetEachTintForUvAdjust(Int32 inInstrumentNo, CMMISDK_UvAdjustDataType inType, ref CMMISDK_UvAdjustIndex inData);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetEachTintForUvAdjust(Int32 inInstrumentNo, CMMISDK_UvAdjustDataType inType, ref CMMISDK_UvAdjustIndex outData);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetEachIsoBrightnessForUvAdjust(Int32 inInstrumentNo, CMMISDK_UvAdjustDataType inType, ref CMMISDK_UvAdjustIndex inData);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetEachIsoBrightnessForUvAdjust(Int32 inInstrumentNo, CMMISDK_UvAdjustDataType inType, ref CMMISDK_UvAdjustIndex outData);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetEachGanzForUvAdjust(Int32 inInstrumentNo, CMMISDK_UvAdjustDataType inType, ref CMMISDK_UvAdjustGG inData);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetEachGanzForUvAdjust(Int32 inInstrumentNo, CMMISDK_UvAdjustDataType inType, ref CMMISDK_UvAdjustGG outData);
        [DllImport("CMMISDK_x86.dll")]
		extern public static Int32 CMMISDK_SetDataForUvAdjust(Int32 inInstrumentNo, CMMISDK_UvAdjustDataType inType, Int32 inNum, ref CMMISDK_Data inFull, ref CMMISDK_Data inCut);
        [DllImport("CMMISDK_x86.dll")]
		extern public static Int32 CMMISDK_GetDataForUvAdjust(Int32 inInstrumentNo, CMMISDK_UvAdjustDataType inType, Int32 inNum, ref CMMISDK_Data outFull, ref CMMISDK_Data outCut);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_PerformUvAdjust(Int32 inInstrumentNo, CMMISDK_CondUvAdjust inCond);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_PerformUvAdjustUsingData(Int32 inInstrumentNo, CMMISDK_CondUvAdjust inCond);
        [DllImport("CMMISDK_x86.dll")]
		extern public static Int32 CMMISDK_ClearCoefForUvAdjust(Int32 inInstrumentNo);
		[DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetCoefForUvAdjust(Int32 inInstrumentNo, CMMISDK_MeasArea inArea, CMMISDK_UvAdjustDataType inType, CMMISDK_CondUvAdjust inCond, ref CMMISDK_UvAdjustCoef inCoef);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetCoefForUvAdjust(Int32 inInstrumentNo, CMMISDK_MeasArea inArea, CMMISDK_UvAdjustDataType inType, ref CMMISDK_CondUvAdjust outCond, ref CMMISDK_UvAdjustCoef outCoef);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetMeasurementArea(Int32 inInstrumentNo, CMMISDK_MeasArea inArea);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetMeasurementArea(Int32 inInstrumentNo, ref CMMISDK_MeasArea outArea);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetMeasurementType(Int32 inInstrumentNo, CMMISDK_MeasType inType);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetMeasurementType(Int32 inInstrumentNo, ref CMMISDK_MeasType outType);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetMeasurementAngle(Int32 inInstrumentNo, CMMISDK_MeasAngle inAngle);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetMeasurementAngle(Int32 inInstrumentNo, ref CMMISDK_MeasAngle outAngle);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetTiltDetection(Int32 inInstrumentNo, CMMISDK_OnOff inDetection);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetTiltDetection(Int32 inInstrumentNo, ref CMMISDK_OnOff outDetection);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetMeasurementMode(Int32 inInstrumentNo, CMMISDK_MeasMode inMode);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetMeasurementMode(Int32 inInstrumentNo, ref CMMISDK_MeasMode outMode);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetSpecularComponent(Int32 inInstrumentNo, CMMISDK_SpecularComponent inSpecularComponent);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetSpecularComponent(Int32 inInstrumentNo, ref CMMISDK_SpecularComponent outSpecularComponent);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetUv(Int32 inInstrumentNo, CMMISDK_Uv inUv);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetUv(Int32 inInstrumentNo, ref CMMISDK_Uv outUv);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetAutoAverageTimes(Int32 inInstrumentNo, Int32 inTimes);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetAutoAverageTimes(Int32 inInstrumentNo, ref Int32 outTimes);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetManualAverageTimes(Int32 inInstrumentNo, Int32 inTimes);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetManualAverageTimes(Int32 inInstrumentNo, ref Int32 outTimes);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetManualAverageSaveMode(Int32 inInstrumentNo, CMMISDK_SaveMode inMode);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetManualAverageSaveMode(Int32 inInstrumentNo, ref CMMISDK_SaveMode outMode);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetCondSMC(Int32 inInstrumentNo, ref CMMISDK_CondSMC inCond);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetCondSMC(Int32 inInstrumentNo, ref CMMISDK_CondSMC outCond);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetDisplayType(Int32 inInstrumentNo, CMMISDK_DisplayType inDisplayType);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetDisplayType(Int32 inInstrumentNo, ref CMMISDK_DisplayType outDisplayType);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetObserverAndIlluminant(Int32 inInstrumentNo, Int32 inNum, CMMISDK_Observer inObs, CMMISDK_Illuminant inIll);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetObserverAndIlluminant(Int32 inInstrumentNo, Int32 inNum, ref CMMISDK_Observer outObs, ref CMMISDK_Illuminant outIll);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetUserIlluminant(Int32 inInstrumentNo, ref CMMISDK_UserIlluminant inIllData);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetUserIlluminant(Int32 inInstrumentNo, ref CMMISDK_UserIlluminant outIllData);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetColorSpace(Int32 inInstrumentNo, CMMISDK_ColorSpace inColorSpace);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetColorSpace(Int32 inInstrumentNo, ref CMMISDK_ColorSpace outColorSpace);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetEquation(Int32 inInstrumentNo, CMMISDK_Equation inEquation);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetEquation(Int32 inInstrumentNo, ref CMMISDK_Equation outEquation);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetCustomIndex(Int32 inInstrumentNo, Int32 inCustomNum, CMMISDK_CustomIndex inCustomIndex);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetCustomIndex(Int32 inInstrumentNo, Int32 inCustomNum, ref CMMISDK_CustomIndex outCustomIndex);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetDirection(Int32 inInstrumentNo, CMMISDK_Direction inDirection);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetDirection(Int32 inInstrumentNo, ref CMMISDK_Direction outDirection);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetUserEquation(Int32 inInstrumentNo, Int32 inNum, ref CMMISDK_UserEquation inEquation);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetUserEquation(Int32 inInstrumentNo, Int32 inNum, ref CMMISDK_UserEquation outEquation);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetActiveTarget(Int32 inInstrumentNo, Int32 inNum);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetActiveTarget(Int32 inInstrumentNo, ref Int32 outNum);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetSavedTargetList(Int32 inInstrumentNo, ref CMMISDK_SavedTargetList outList);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetTargetListInFilter(Int32 inInstrumentNo, ref CMMISDK_SavedTargetList outList);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_DeleteTargetData(Int32 inInstrumentNo, Int32 inNum);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_DeleteAllTargetData(Int32 inInstrumentNo);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_ClearTargetInfo(Int32 inInstrumentNo);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_LoadTargetInfo(Int32 inInstrumentNo, Int32 inNum);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SaveTargetInfo(Int32 inInstrumentNo, Int32 inNum);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetTargetProperty(Int32 inInstrumentNo, ref CMMISDK_TargetProperty inProperty);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetTargetProperty(Int32 inInstrumentNo, ref CMMISDK_TargetProperty outProperty);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetTargetData(Int32 inInstrumentNo, CMMISDK_DataType inDataType, ref CMMISDK_Data inData);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetTargetDataColor(Int32 inInstrumentNo, CMMISDK_DataType inDataType, Int32 inNum, ref CMMISDK_ColorCond inCond, ref CMMISDK_Data inData);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetTargetDataColor(Int32 inInstrumentNo, CMMISDK_DataType inDataType, Int32 inNum, ref CMMISDK_ColorCond outCond, ref CMMISDK_Data outData);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetTargetData(Int32 inInstrumentNo, CMMISDK_DataType inDataType, ref CMMISDK_Data outData);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetToleranceForTarget(Int32 inInstrumentNo, CMMISDK_ToleranceType inType, Int32 inObsIll, CMMISDK_ToleranceId inId, ref CMMISDK_ToleranceData inTolerance);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetToleranceForTarget(Int32 inInstrumentNo, CMMISDK_ToleranceType inType, Int32 inObsIll, CMMISDK_ToleranceId inId, ref CMMISDK_ToleranceData outTolerance);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetParametricForTarget(Int32 inInstrumentNo, CMMISDK_ToleranceType inType, CMMISDK_ParametricId inId, ref CMMISDK_ParametricCoef inParametric);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetParametricForTarget(Int32 inInstrumentNo, CMMISDK_ToleranceType inType, CMMISDK_ParametricId inId, ref CMMISDK_ParametricCoef outParametric);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetTargetFilter(Int32 inInstrumentNo, CMMISDK_FilterIndex inIndex, ref CMMISDK_GroupList inGroup);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetTargetFilter(Int32 inInstrumentNo, ref CMMISDK_FilterIndex outIndex, ref CMMISDK_GroupList outGroup);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetTargetProtect(Int32 inInstrumentNo, CMMISDK_OnOff inProtect);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetTargetProtect(Int32 inInstrumentNo, ref CMMISDK_OnOff outProtect);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetSavedSampleCount(Int32 inInstrumentNo, ref Int32 outCount);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_DeleteSampleData(Int32 inInstrumentNo, Int32 inNum);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_DeleteAllSampleData(Int32 inInstrumentNo);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_LoadSampleInfo(Int32 inInstrumentNo, Int32 inNum);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetSampleProperty(Int32 inInstrumentNo, ref CMMISDK_SampleProperty outProperty);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetSampleData(Int32 inInstrumentNo, CMMISDK_DataType inDataType, ref CMMISDK_Data outData);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetActiveGroup(Int32 inInstrumentNo, ref CMMISDK_GroupList inGroup);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetActiveGroup(Int32 inInstrumentNo, ref CMMISDK_GroupList outGroup);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetGroupName(Int32 inInstrumentNo, Int32 inGroup, ref CMMISDK_Group inName);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetGroupName(Int32 inInstrumentNo, Int32 inGroup, ref CMMISDK_Group outName);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetMultipleGroupName(Int32 inInstrumentNo, ref CMMISDK_GroupAll inName);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetMultipleGroupName(Int32 inInstrumentNo, ref CMMISDK_GroupAll outName);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_LoadDefaultInfo(Int32 inInstrumentNo);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SaveDefaultInfo(Int32 inInstrumentNo);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetTolerance(Int32 inInstrumentNo, CMMISDK_ToleranceType inType, Int32 inObsIll, CMMISDK_ToleranceId inId, ref CMMISDK_ToleranceData inTolerance);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetTolerance(Int32 inInstrumentNo, CMMISDK_ToleranceType inType, Int32 inObsIll, CMMISDK_ToleranceId inId, ref CMMISDK_ToleranceData outTolerance);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetParametric(Int32 inInstrumentNo, CMMISDK_ToleranceType inType, CMMISDK_ParametricId inId, ref CMMISDK_ParametricCoef inParametric);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetParametric(Int32 inInstrumentNo, CMMISDK_ToleranceType inType, CMMISDK_ParametricId inId, ref CMMISDK_ParametricCoef outParametric);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetWarningLevel(Int32 inInstrumentNo, Int32 inLevel);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetWarningLevel(Int32 inInstrumentNo, ref Int32 outLevel);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetInstrumentMode(Int32 inInstrumentNo, CMMISDK_InstrumentMode inMode);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetInstrumentMode(Int32 inInstrumentNo, ref CMMISDK_InstrumentMode outMode);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetUserType(Int32 inInstrumentNo, CMMISDK_UserType inType);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetUserType(Int32 inInstrumentNo, ref CMMISDK_UserType outType);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetAdminPassword(Int32 inInstrumentNo, ref CMMISDK_AdminPass inPass);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetAdminPassword(Int32 inInstrumentNo, ref CMMISDK_AdminPass outPass);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetAutoPrint(Int32 inInstrumentNo, CMMISDK_OnOff inPrint);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetAutoPrint(Int32 inInstrumentNo, ref CMMISDK_OnOff outPrint);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetBrightness(Int32 inInstrumentNo, Int32 inBrightness);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetBrightness(Int32 inInstrumentNo, ref Int32 outBrightness);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetScreenDirection(Int32 inInstrumentNo, CMMISDK_ScreenDirection inScreenDirection);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetScreenDirection(Int32 inInstrumentNo, ref CMMISDK_ScreenDirection outScreenDirection);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetSound(Int32 inInstrumentNo, CMMISDK_OnOff inSound);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetSound(Int32 inInstrumentNo, ref CMMISDK_OnOff outSound);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetCalibrationInterval(Int32 inInstrumentNo, Int32 inInterval);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetCalibrationInterval(Int32 inInstrumentNo, ref Int32 outInterval);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetAnnualCalibration(Int32 inInstrumentNo, CMMISDK_OnOff inCal);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetAnnualCalibration(Int32 inInstrumentNo, ref CMMISDK_OnOff outCal);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetZeroCalibrationSkip(Int32 inInstrumentNo, CMMISDK_OnOff inSkip);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetZeroCalibrationSkip(Int32 inInstrumentNo, ref CMMISDK_OnOff outSkip);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetDateTime(Int32 inInstrumentNo, ref CMMISDK_DateTime inDate);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetDateFormat(Int32 inInstrumentNo, CMMISDK_DateFormat inFormat);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetDateFormat(Int32 inInstrumentNo, ref CMMISDK_DateFormat outFormat);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetLanguage(Int32 inInstrumentNo, CMMISDK_Language inLanguage);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetLanguage(Int32 inInstrumentNo, ref CMMISDK_Language outLanguage);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetPowerSaving(Int32 inInstrumentNo, Int32 inPowerSaving);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetPowerSaving(Int32 inInstrumentNo, ref Int32 outPowerSaving);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_ClearJobInfo(Int32 inInstrumentNo, Int32 inJobNum);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetJobInfo(Int32 inInstrumentNo, Int32 inJobNum, ref CMMISDK_JobInfo inInfo);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetJobInfo(Int32 inInstrumentNo, Int32 inJobNum, ref CMMISDK_JobInfo outInfo);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetJobStepType(Int32 inInstrumentNo, Int32 inJobNum, Int32 inStepNum, ref CMMISDK_JobStepType outType);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetJobStepForOperation(Int32 inInstrumentNo, Int32 inJobNum, Int32 inStepNum, ref CMMISDK_JobStepOperation inOperation);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetJobStepForOperation(Int32 inInstrumentNo, Int32 inJobNum, Int32 inStepNum, ref CMMISDK_JobStepOperation outOperation);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetJobStepForResult(Int32 inInstrumentNo, Int32 inJobNum, Int32 inStepNum, ref CMMISDK_JobStepResult inResult);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetJobStepForResult(Int32 inInstrumentNo, Int32 inJobNum, Int32 inStepNum, ref CMMISDK_JobStepResult outResult);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_SetJobImage(Int32 inInstrumentNo, Int32 inJobNum, Int32 inImageNum, IntPtr inImage);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_GetJobImage(Int32 inInstrumentNo, Int32 inJobNum, Int32 inImageNum, IntPtr outImage);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_ResetSetting(Int32 inInstrumentNo);
        [DllImport("CMMISDK_x86.dll")]
        extern public static Int32 CMMISDK_ResetSettingAndData(Int32 inInstrumentNo);
    }
    class CMMISDK_API_x64
    {
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_Connect(ref CMMISDK_Port inPortInfo, ref Int32 outInstrumentNo);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_Disconnect(Int32 inInstrumentNo);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetInstrumentInfo(Int32 inInstrumentNo, ref CMMISDK_InstrumentInfo outInfo);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetSDKVersion(ref CMMISDK_Version version);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetWarning(Int32 inInstrumentNo, ref CMMISDK_Warning warning);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetCalibrationStatus(Int32 inInstrumentNo, ref CMMISDK_CalStatus outCalStatus);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_PerformZeroCalibration(Int32 inInstrumentNo);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_PerformWhiteCalibration(Int32 inInstrumentNo);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_PerformGlossCalibration(Int32 inInstrumentNo);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_PerformUserCalibration(Int32 inInstrumentNo);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_PerformMeasurement(Int32 inInstrumentNo);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_PollingMeasurement(Int32 inInstrumentNo, ref CMMISDK_MeasStatus outStatus);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_CancelMeasurement(Int32 inInstrumentNo);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_ReadLatestDataSpec(Int32 inInstrumentNo, CMMISDK_DataType inDataType, ref CMMISDK_Data outData);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_ReadLatestDataColor(Int32 inInstrumentNo, CMMISDK_DataType inDataType, ref CMMISDK_ColorCond inColorCond, ref CMMISDK_Data outData);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_LoadLatestData(Int32 inInstrumentNo);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetLatestDataSpec(Int32 inInstrumentNo, CMMISDK_DataType inDataType, ref CMMISDK_Data outData);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetLatestDataColor(Int32 inInstrumentNo, CMMISDK_DataType inDataType, ref CMMISDK_ColorCond inColorCond, ref CMMISDK_Data outData);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetWhiteCalibrationData(Int32 inInstrumentNo, CMMISDK_CalDataType inDataType, Int32 inCalId, ref CMMISDK_Data inCalData);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetWhiteCalibrationData(Int32 inInstrumentNo, CMMISDK_CalDataType inDataType, ref Int32 outCalId, ref CMMISDK_Data outCalData);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetGlossCalibrationData(Int32 inInstrumentNo, CMMISDK_MeasArea inArea, Int32 inCalId, double inCalData);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetGlossCalibrationData(Int32 inInstrumentNo, CMMISDK_MeasArea inArea, ref Int32 outCalId, ref double outCalData);//Scriptと違うので注意
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetUserCalibrationData(Int32 inInstrumentNo, CMMISDK_CalDataType inDataType, ref CMMISDK_UserCalId inCalId, ref CMMISDK_Data inCalData);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetUserCalibrationData(Int32 inInstrumentNo, CMMISDK_CalDataType inDataType, ref CMMISDK_UserCalId outCalId, ref CMMISDK_Data outCalData);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetUserCalibrationEnable(Int32 inInstrumentNo, CMMISDK_OnOff inCalEnable);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetUserCalibrationEnable(Int32 inInstrumentNo, ref CMMISDK_OnOff outCalEnable);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetTriggerMode(Int32 inInstrumentNo, CMMISDK_OnOff inTrigger);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetTriggerMode(Int32 inInstrumentNo, ref CMMISDK_OnOff outTrigger);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_ClearTriggerData(Int32 inInstrumentNo);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_IsTriggerData(Int32 inInstrumentNo, ref CMMISDK_OnOff outData);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetZeroCalibrationDate(Int32 inInstrumentNo, CMMISDK_DateType inType, ref CMMISDK_DateTime outDate);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetWhiteCalibrationDate(Int32 inInstrumentNo, ref CMMISDK_DateTime outDate);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetGlossCalibrationDate(Int32 inInstrumentNo, ref CMMISDK_DateTime outDate);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetUserCalibrationDate(Int32 inInstrumentNo, ref CMMISDK_DateTime outDate);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_ClearUvAdjustInfo(Int32 inInstrumentNo);
        [DllImport("CMMISDK_x64.dll")]
		extern public static Int32 CMMISDK_SetProfileForUvAdjust(Int32 inInstrumentNo, ref CMMISDK_Data inData);
		[DllImport("CMMISDK_x64.dll")]
		extern public static Int32 CMMISDK_GetProfileForUvAdjust(Int32 inInstrumentNo, ref CMMISDK_Data outData);
		[DllImport("CMMISDK_x64.dll")]
		extern public static Int32 CMMISDK_SetWiForUvAdjust(Int32 inInstrumentNo, ref CMMISDK_UvAdjustIndex inData);
		[DllImport("CMMISDK_x64.dll")]
		extern public static Int32 CMMISDK_GetWiForUvAdjust(Int32 inInstrumentNo, ref CMMISDK_UvAdjustIndex outData);
		[DllImport("CMMISDK_x64.dll")]
		extern public static Int32 CMMISDK_SetTintForUvAdjust(Int32 inInstrumentNo, ref CMMISDK_UvAdjustIndex inData);
		[DllImport("CMMISDK_x64.dll")]
		extern public static Int32 CMMISDK_GetTintForUvAdjust(Int32 inInstrumentNo, ref CMMISDK_UvAdjustIndex outData);
		[DllImport("CMMISDK_x64.dll")]
		extern public static Int32 CMMISDK_SetIsoBrightnessForUvAdjust(Int32 inInstrumentNo, ref CMMISDK_UvAdjustIndex inData);
		[DllImport("CMMISDK_x64.dll")]
		extern public static Int32 CMMISDK_GetIsoBrightnessForUvAdjust(Int32 inInstrumentNo, ref CMMISDK_UvAdjustIndex outData);
        [DllImport("CMMISDK_x64.dll")]
		extern public static Int32 CMMISDK_SetGanzForUvAdjust(Int32 inInstrumentNo, ref CMMISDK_UvAdjustGG inData);
		[DllImport("CMMISDK_x64.dll")]
		extern public static Int32 CMMISDK_GetGanzForUvAdjust(Int32 inInstrumentNo, ref CMMISDK_UvAdjustGG outData);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetEachProfileForUvAdjust(Int32 inInstrumentNo, CMMISDK_UvAdjustDataType inType, ref CMMISDK_Data inData);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetEachProfileForUvAdjust(Int32 inInstrumentNo, CMMISDK_UvAdjustDataType inType, ref CMMISDK_Data outData);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetEachWiForUvAdjust(Int32 inInstrumentNo, CMMISDK_UvAdjustDataType inType, ref CMMISDK_UvAdjustIndex inData);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetEachWiForUvAdjust(Int32 inInstrumentNo, CMMISDK_UvAdjustDataType inType, ref CMMISDK_UvAdjustIndex outData);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetEachTintForUvAdjust(Int32 inInstrumentNo, CMMISDK_UvAdjustDataType inType, ref CMMISDK_UvAdjustIndex inData);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetEachTintForUvAdjust(Int32 inInstrumentNo, CMMISDK_UvAdjustDataType inType, ref CMMISDK_UvAdjustIndex outData);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetEachIsoBrightnessForUvAdjust(Int32 inInstrumentNo, CMMISDK_UvAdjustDataType inType, ref CMMISDK_UvAdjustIndex inData);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetEachIsoBrightnessForUvAdjust(Int32 inInstrumentNo, CMMISDK_UvAdjustDataType inType, ref CMMISDK_UvAdjustIndex outData);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetEachGanzForUvAdjust(Int32 inInstrumentNo, CMMISDK_UvAdjustDataType inType, ref CMMISDK_UvAdjustGG inData);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetEachGanzForUvAdjust(Int32 inInstrumentNo, CMMISDK_UvAdjustDataType inType, ref CMMISDK_UvAdjustGG outData);
        [DllImport("CMMISDK_x64.dll")]
		extern public static Int32 CMMISDK_SetDataForUvAdjust(Int32 inInstrumentNo, CMMISDK_UvAdjustDataType inType, Int32 inNum, ref CMMISDK_Data inFull, ref CMMISDK_Data inCut);
        [DllImport("CMMISDK_x64.dll")]
		extern public static Int32 CMMISDK_GetDataForUvAdjust(Int32 inInstrumentNo, CMMISDK_UvAdjustDataType inType, Int32 inNum, ref CMMISDK_Data outFull, ref CMMISDK_Data outCut);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_PerformUvAdjust(Int32 inInstrumentNo, CMMISDK_CondUvAdjust inCond);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_PerformUvAdjustUsingData(Int32 inInstrumentNo, CMMISDK_CondUvAdjust inCond);
        [DllImport("CMMISDK_x64.dll")]
		extern public static Int32 CMMISDK_ClearCoefForUvAdjust(Int32 inInstrumentNo);
		[DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetCoefForUvAdjust(Int32 inInstrumentNo, CMMISDK_MeasArea inArea, CMMISDK_UvAdjustDataType inType, CMMISDK_CondUvAdjust inCond, ref CMMISDK_UvAdjustCoef inCoef);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetCoefForUvAdjust(Int32 inInstrumentNo, CMMISDK_MeasArea inArea, CMMISDK_UvAdjustDataType inType, ref CMMISDK_CondUvAdjust outCond, ref CMMISDK_UvAdjustCoef outCoef);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetMeasurementArea(Int32 inInstrumentNo, CMMISDK_MeasArea inArea);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetMeasurementArea(Int32 inInstrumentNo, ref CMMISDK_MeasArea outArea);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetMeasurementType(Int32 inInstrumentNo, CMMISDK_MeasType inType);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetMeasurementType(Int32 inInstrumentNo, ref CMMISDK_MeasType outType);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetMeasurementAngle(Int32 inInstrumentNo, CMMISDK_MeasAngle inAngle);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetMeasurementAngle(Int32 inInstrumentNo, ref CMMISDK_MeasAngle outAngle);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetTiltDetection(Int32 inInstrumentNo, CMMISDK_OnOff inDetection);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetTiltDetection(Int32 inInstrumentNo, ref CMMISDK_OnOff outDetection);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetMeasurementMode(Int32 inInstrumentNo, CMMISDK_MeasMode inMode);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetMeasurementMode(Int32 inInstrumentNo, ref CMMISDK_MeasMode outMode);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetSpecularComponent(Int32 inInstrumentNo, CMMISDK_SpecularComponent inSpecularComponent);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetSpecularComponent(Int32 inInstrumentNo, ref CMMISDK_SpecularComponent outSpecularComponent);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetUv(Int32 inInstrumentNo, CMMISDK_Uv inUv);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetUv(Int32 inInstrumentNo, ref CMMISDK_Uv outUv);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetAutoAverageTimes(Int32 inInstrumentNo, Int32 inTimes);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetAutoAverageTimes(Int32 inInstrumentNo, ref Int32 outTimes);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetManualAverageTimes(Int32 inInstrumentNo, Int32 inTimes);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetManualAverageTimes(Int32 inInstrumentNo, ref Int32 outTimes);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetManualAverageSaveMode(Int32 inInstrumentNo, CMMISDK_SaveMode inMode);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetManualAverageSaveMode(Int32 inInstrumentNo, ref CMMISDK_SaveMode outMode);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetCondSMC(Int32 inInstrumentNo, ref CMMISDK_CondSMC inCond);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetCondSMC(Int32 inInstrumentNo, ref CMMISDK_CondSMC outCond);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetDisplayType(Int32 inInstrumentNo, CMMISDK_DisplayType inDisplayType);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetDisplayType(Int32 inInstrumentNo, ref CMMISDK_DisplayType outDisplayType);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetObserverAndIlluminant(Int32 inInstrumentNo, Int32 inNum, CMMISDK_Observer inObs, CMMISDK_Illuminant inIll);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetObserverAndIlluminant(Int32 inInstrumentNo, Int32 inNum, ref CMMISDK_Observer outObs, ref CMMISDK_Illuminant outIll);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetUserIlluminant(Int32 inInstrumentNo, ref CMMISDK_UserIlluminant inIllData);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetUserIlluminant(Int32 inInstrumentNo, ref CMMISDK_UserIlluminant outIllData);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetColorSpace(Int32 inInstrumentNo, CMMISDK_ColorSpace inColorSpace);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetColorSpace(Int32 inInstrumentNo, ref CMMISDK_ColorSpace outColorSpace);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetEquation(Int32 inInstrumentNo, CMMISDK_Equation inEquation);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetEquation(Int32 inInstrumentNo, ref CMMISDK_Equation outEquation);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetCustomIndex(Int32 inInstrumentNo, Int32 inCustomNum, CMMISDK_CustomIndex inCustomIndex);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetCustomIndex(Int32 inInstrumentNo, Int32 inCustomNum, ref CMMISDK_CustomIndex outCustomIndex);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetDirection(Int32 inInstrumentNo, CMMISDK_Direction inDirection);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetDirection(Int32 inInstrumentNo, ref CMMISDK_Direction outDirection);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetUserEquation(Int32 inInstrumentNo, Int32 inNum, ref CMMISDK_UserEquation inEquation);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetUserEquation(Int32 inInstrumentNo, Int32 inNum, ref CMMISDK_UserEquation outEquation);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetActiveTarget(Int32 inInstrumentNo, Int32 inNum);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetActiveTarget(Int32 inInstrumentNo, ref Int32 outNum);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetSavedTargetList(Int32 inInstrumentNo, ref CMMISDK_SavedTargetList outList);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetTargetListInFilter(Int32 inInstrumentNo, ref CMMISDK_SavedTargetList outList);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_DeleteTargetData(Int32 inInstrumentNo, Int32 inNum);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_DeleteAllTargetData(Int32 inInstrumentNo);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_ClearTargetInfo(Int32 inInstrumentNo);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_LoadTargetInfo(Int32 inInstrumentNo, Int32 inNum);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SaveTargetInfo(Int32 inInstrumentNo, Int32 inNum);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetTargetProperty(Int32 inInstrumentNo, ref CMMISDK_TargetProperty inProperty);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetTargetProperty(Int32 inInstrumentNo, ref CMMISDK_TargetProperty outProperty);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetTargetData(Int32 inInstrumentNo, CMMISDK_DataType inDataType, ref CMMISDK_Data inData);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetTargetDataColor(Int32 inInstrumentNo, CMMISDK_DataType inDataType, Int32 inNum, ref CMMISDK_ColorCond inCond, ref CMMISDK_Data inData);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetTargetDataColor(Int32 inInstrumentNo, CMMISDK_DataType inDataType, Int32 inNum, ref CMMISDK_ColorCond outCond, ref CMMISDK_Data outData);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetTargetData(Int32 inInstrumentNo, CMMISDK_DataType inDataType, ref CMMISDK_Data outData);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetToleranceForTarget(Int32 inInstrumentNo, CMMISDK_ToleranceType inType, Int32 inObsIll, CMMISDK_ToleranceId inId, ref CMMISDK_ToleranceData inTolerance);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetToleranceForTarget(Int32 inInstrumentNo, CMMISDK_ToleranceType inType, Int32 inObsIll, CMMISDK_ToleranceId inId, ref CMMISDK_ToleranceData outTolerance);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetParametricForTarget(Int32 inInstrumentNo, CMMISDK_ToleranceType inType, CMMISDK_ParametricId inId, ref CMMISDK_ParametricCoef inParametric);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetParametricForTarget(Int32 inInstrumentNo, CMMISDK_ToleranceType inType, CMMISDK_ParametricId inId, ref CMMISDK_ParametricCoef outParametric);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetTargetFilter(Int32 inInstrumentNo, CMMISDK_FilterIndex inIndex, ref CMMISDK_GroupList inGroup);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetTargetFilter(Int32 inInstrumentNo, ref CMMISDK_FilterIndex outIndex, ref CMMISDK_GroupList outGroup);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetTargetProtect(Int32 inInstrumentNo, CMMISDK_OnOff inProtect);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetTargetProtect(Int32 inInstrumentNo, ref CMMISDK_OnOff outProtect);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetSavedSampleCount(Int32 inInstrumentNo, ref Int32 outCount);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_DeleteSampleData(Int32 inInstrumentNo, Int32 inNum);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_DeleteAllSampleData(Int32 inInstrumentNo);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_LoadSampleInfo(Int32 inInstrumentNo, Int32 inNum);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetSampleProperty(Int32 inInstrumentNo, ref CMMISDK_SampleProperty outProperty);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetSampleData(Int32 inInstrumentNo, CMMISDK_DataType inDataType, ref CMMISDK_Data outData);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetActiveGroup(Int32 inInstrumentNo, ref CMMISDK_GroupList inGroup);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetActiveGroup(Int32 inInstrumentNo, ref CMMISDK_GroupList outGroup);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetGroupName(Int32 inInstrumentNo, Int32 inGroup, ref CMMISDK_Group inName);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetGroupName(Int32 inInstrumentNo, Int32 inGroup, ref CMMISDK_Group outName);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetMultipleGroupName(Int32 inInstrumentNo, ref CMMISDK_GroupAll inName);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetMultipleGroupName(Int32 inInstrumentNo, ref CMMISDK_GroupAll outName);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_LoadDefaultInfo(Int32 inInstrumentNo);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SaveDefaultInfo(Int32 inInstrumentNo);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetTolerance(Int32 inInstrumentNo, CMMISDK_ToleranceType inType, Int32 inObsIll, CMMISDK_ToleranceId inId, ref CMMISDK_ToleranceData inTolerance);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetTolerance(Int32 inInstrumentNo, CMMISDK_ToleranceType inType, Int32 inObsIll, CMMISDK_ToleranceId inId, ref CMMISDK_ToleranceData outTolerance);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetParametric(Int32 inInstrumentNo, CMMISDK_ToleranceType inType, CMMISDK_ParametricId inId, ref CMMISDK_ParametricCoef inParametric);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetParametric(Int32 inInstrumentNo, CMMISDK_ToleranceType inType, CMMISDK_ParametricId inId, ref CMMISDK_ParametricCoef outParametric);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetWarningLevel(Int32 inInstrumentNo, Int32 inLevel);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetWarningLevel(Int32 inInstrumentNo, ref Int32 outLevel);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetInstrumentMode(Int32 inInstrumentNo, CMMISDK_InstrumentMode inMode);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetInstrumentMode(Int32 inInstrumentNo, ref CMMISDK_InstrumentMode outMode);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetUserType(Int32 inInstrumentNo, CMMISDK_UserType inType);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetUserType(Int32 inInstrumentNo, ref CMMISDK_UserType outType);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetAdminPassword(Int32 inInstrumentNo, ref CMMISDK_AdminPass inPass);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetAdminPassword(Int32 inInstrumentNo, ref CMMISDK_AdminPass outPass);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetAutoPrint(Int32 inInstrumentNo, CMMISDK_OnOff inPrint);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetAutoPrint(Int32 inInstrumentNo, ref CMMISDK_OnOff outPrint);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetBrightness(Int32 inInstrumentNo, Int32 inBrightness);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetBrightness(Int32 inInstrumentNo, ref Int32 outBrightness);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetScreenDirection(Int32 inInstrumentNo, CMMISDK_ScreenDirection inScreenDirection);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetScreenDirection(Int32 inInstrumentNo, ref CMMISDK_ScreenDirection outScreenDirection);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetSound(Int32 inInstrumentNo, CMMISDK_OnOff inSound);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetSound(Int32 inInstrumentNo, ref CMMISDK_OnOff outSound);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetCalibrationInterval(Int32 inInstrumentNo, Int32 inInterval);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetCalibrationInterval(Int32 inInstrumentNo, ref Int32 outInterval);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetAnnualCalibration(Int32 inInstrumentNo, CMMISDK_OnOff inCal);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetAnnualCalibration(Int32 inInstrumentNo, ref CMMISDK_OnOff outCal);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetZeroCalibrationSkip(Int32 inInstrumentNo, CMMISDK_OnOff inSkip);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetZeroCalibrationSkip(Int32 inInstrumentNo, ref CMMISDK_OnOff outSkip);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetDateTime(Int32 inInstrumentNo, ref CMMISDK_DateTime inDate);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetDateFormat(Int32 inInstrumentNo, CMMISDK_DateFormat inFormat);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetDateFormat(Int32 inInstrumentNo, ref CMMISDK_DateFormat outFormat);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetLanguage(Int32 inInstrumentNo, CMMISDK_Language inLanguage);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetLanguage(Int32 inInstrumentNo, ref CMMISDK_Language outLanguage);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetPowerSaving(Int32 inInstrumentNo, Int32 inPowerSaving);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetPowerSaving(Int32 inInstrumentNo, ref Int32 outPowerSaving);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_ClearJobInfo(Int32 inInstrumentNo, Int32 inJobNum);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetJobInfo(Int32 inInstrumentNo, Int32 inJobNum, ref CMMISDK_JobInfo inInfo);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetJobInfo(Int32 inInstrumentNo, Int32 inJobNum, ref CMMISDK_JobInfo outInfo);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetJobStepType(Int32 inInstrumentNo, Int32 inJobNum, Int32 inStepNum, ref CMMISDK_JobStepType outType);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetJobStepForOperation(Int32 inInstrumentNo, Int32 inJobNum, Int32 inStepNum, ref CMMISDK_JobStepOperation inOperation);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetJobStepForOperation(Int32 inInstrumentNo, Int32 inJobNum, Int32 inStepNum, ref CMMISDK_JobStepOperation outOperation);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetJobStepForResult(Int32 inInstrumentNo, Int32 inJobNum, Int32 inStepNum, ref CMMISDK_JobStepResult inResult);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetJobStepForResult(Int32 inInstrumentNo, Int32 inJobNum, Int32 inStepNum, ref CMMISDK_JobStepResult outResult);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_SetJobImage(Int32 inInstrumentNo, Int32 inJobNum, Int32 inImageNum, IntPtr inImage);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_GetJobImage(Int32 inInstrumentNo, Int32 inJobNum, Int32 inImageNum, IntPtr outImage);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_ResetSetting(Int32 inInstrumentNo);
        [DllImport("CMMISDK_x64.dll")]
        extern public static Int32 CMMISDK_ResetSettingAndData(Int32 inInstrumentNo);
    }
    class CMMISDK_API
    {
        public static Int32 CMMISDK_Connect(ref CMMISDK_Port inPortInfo, ref Int32 outInstrumentNo)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_Connect(ref inPortInfo, ref outInstrumentNo) :
                CMMISDK_API_x86.CMMISDK_Connect(ref inPortInfo, ref outInstrumentNo);
        }
        public static Int32 CMMISDK_Disconnect(Int32 inInstrumentNo)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_Disconnect(inInstrumentNo) :
                CMMISDK_API_x86.CMMISDK_Disconnect(inInstrumentNo);
        }
        public static Int32 CMMISDK_GetInstrumentInfo(Int32 inInstrumentNo, ref CMMISDK_InstrumentInfo outInfo)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetInstrumentInfo(inInstrumentNo, ref outInfo) :
                CMMISDK_API_x86.CMMISDK_GetInstrumentInfo(inInstrumentNo, ref outInfo);
        }
        public static Int32 CMMISDK_GetSDKVersion(ref CMMISDK_Version version)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetSDKVersion(ref version) :
                CMMISDK_API_x86.CMMISDK_GetSDKVersion(ref version);
        }
        public static Int32 CMMISDK_GetWarning(Int32 inInstrumentNo, ref CMMISDK_Warning warning)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetWarning(inInstrumentNo, ref warning) :
                CMMISDK_API_x86.CMMISDK_GetWarning(inInstrumentNo, ref warning);
        }
        public static Int32 CMMISDK_GetCalibrationStatus(Int32 inInstrumentNo, ref CMMISDK_CalStatus outCalStatus)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetCalibrationStatus(inInstrumentNo, ref outCalStatus) :
                CMMISDK_API_x86.CMMISDK_GetCalibrationStatus(inInstrumentNo, ref outCalStatus);
        }
        public static Int32 CMMISDK_PerformZeroCalibration(Int32 inInstrumentNo)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_PerformZeroCalibration(inInstrumentNo) :
                CMMISDK_API_x86.CMMISDK_PerformZeroCalibration(inInstrumentNo);
        }
        public static Int32 CMMISDK_PerformWhiteCalibration(Int32 inInstrumentNo)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_PerformWhiteCalibration(inInstrumentNo) :
                CMMISDK_API_x86.CMMISDK_PerformWhiteCalibration(inInstrumentNo);
        }
        public static Int32 CMMISDK_PerformGlossCalibration(Int32 inInstrumentNo)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_PerformGlossCalibration(inInstrumentNo) :
                CMMISDK_API_x86.CMMISDK_PerformGlossCalibration(inInstrumentNo);
        }
        public static Int32 CMMISDK_PerformUserCalibration(Int32 inInstrumentNo)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_PerformUserCalibration(inInstrumentNo) :
                CMMISDK_API_x86.CMMISDK_PerformUserCalibration(inInstrumentNo);
        }
        public static Int32 CMMISDK_PerformMeasurement(Int32 inInstrumentNo)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_PerformMeasurement(inInstrumentNo) :
                CMMISDK_API_x86.CMMISDK_PerformMeasurement(inInstrumentNo);
        }
        public static Int32 CMMISDK_PollingMeasurement(Int32 inInstrumentNo, ref CMMISDK_MeasStatus outStatus)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_PollingMeasurement(inInstrumentNo, ref outStatus) :
                CMMISDK_API_x86.CMMISDK_PollingMeasurement(inInstrumentNo, ref outStatus);
        }
        public static Int32 CMMISDK_CancelMeasurement(Int32 inInstrumentNo)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_CancelMeasurement(inInstrumentNo) :
                CMMISDK_API_x86.CMMISDK_CancelMeasurement(inInstrumentNo);
        }
        public static Int32 CMMISDK_ReadLatestDataSpec(Int32 inInstrumentNo, CMMISDK_DataType inDataType, ref CMMISDK_Data outData)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_ReadLatestDataSpec(inInstrumentNo, inDataType, ref outData) :
                CMMISDK_API_x86.CMMISDK_ReadLatestDataSpec(inInstrumentNo, inDataType, ref outData);
        }
        public static Int32 CMMISDK_ReadLatestDataColor(Int32 inInstrumentNo, CMMISDK_DataType inDataType, ref CMMISDK_ColorCond inColorCond, ref CMMISDK_Data outData)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_ReadLatestDataColor(inInstrumentNo, inDataType, ref inColorCond, ref outData) :
                CMMISDK_API_x86.CMMISDK_ReadLatestDataColor(inInstrumentNo, inDataType, ref inColorCond, ref outData);
        }
        public static Int32 CMMISDK_LoadLatestData(Int32 inInstrumentNo)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_LoadLatestData(inInstrumentNo) :
                CMMISDK_API_x86.CMMISDK_LoadLatestData(inInstrumentNo);
        }
        public static Int32 CMMISDK_GetLatestDataSpec(Int32 inInstrumentNo, CMMISDK_DataType inDataType, ref CMMISDK_Data outData)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetLatestDataSpec(inInstrumentNo, inDataType, ref outData) :
                CMMISDK_API_x86.CMMISDK_GetLatestDataSpec(inInstrumentNo, inDataType, ref outData);
        }
        public static Int32 CMMISDK_GetLatestDataColor(Int32 inInstrumentNo, CMMISDK_DataType inDataType, ref CMMISDK_ColorCond inColorCond, ref CMMISDK_Data outData)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetLatestDataColor(inInstrumentNo, inDataType, ref inColorCond, ref outData) :
                CMMISDK_API_x86.CMMISDK_GetLatestDataColor(inInstrumentNo, inDataType, ref inColorCond, ref outData);
        }
        public static Int32 CMMISDK_SetWhiteCalibrationData(Int32 inInstrumentNo, CMMISDK_CalDataType inDataType, Int32 inCalId, ref CMMISDK_Data inCalData)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetWhiteCalibrationData(inInstrumentNo, inDataType, inCalId, ref inCalData) :
                CMMISDK_API_x86.CMMISDK_SetWhiteCalibrationData(inInstrumentNo, inDataType, inCalId, ref inCalData);
        }
        public static Int32 CMMISDK_GetWhiteCalibrationData(Int32 inInstrumentNo, CMMISDK_CalDataType inDataType, ref Int32 outCalId, ref CMMISDK_Data outCalData)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetWhiteCalibrationData(inInstrumentNo, inDataType, ref outCalId, ref outCalData) :
                CMMISDK_API_x86.CMMISDK_GetWhiteCalibrationData(inInstrumentNo, inDataType, ref outCalId, ref outCalData);
        }
        public static Int32 CMMISDK_SetGlossCalibrationData(Int32 inInstrumentNo, CMMISDK_MeasArea inArea, Int32 inCalId, double inCalData)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetGlossCalibrationData(inInstrumentNo, inArea, inCalId, inCalData) :
                CMMISDK_API_x86.CMMISDK_SetGlossCalibrationData(inInstrumentNo, inArea, inCalId, inCalData);
        }
        public static Int32 CMMISDK_GetGlossCalibrationData(Int32 inInstrumentNo, CMMISDK_MeasArea inArea, ref Int32 outCalId, ref double outCalData)//Scriptと違うので注意
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetGlossCalibrationData(inInstrumentNo, inArea, ref outCalId, ref outCalData) ://Scriptと違うので注意
                CMMISDK_API_x86.CMMISDK_GetGlossCalibrationData(inInstrumentNo, inArea, ref outCalId, ref outCalData);//Scriptと違うので注意
        }
        public static Int32 CMMISDK_SetUserCalibrationData(Int32 inInstrumentNo, CMMISDK_CalDataType inDataType, ref CMMISDK_UserCalId inCalId, ref CMMISDK_Data inCalData)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetUserCalibrationData(inInstrumentNo, inDataType, ref inCalId, ref inCalData) :
                CMMISDK_API_x86.CMMISDK_SetUserCalibrationData(inInstrumentNo, inDataType, ref inCalId, ref inCalData);
        }
        public static Int32 CMMISDK_GetUserCalibrationData(Int32 inInstrumentNo, CMMISDK_CalDataType inDataType, ref CMMISDK_UserCalId outCalId, ref CMMISDK_Data outCalData)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetUserCalibrationData(inInstrumentNo, inDataType, ref outCalId, ref outCalData) :
                CMMISDK_API_x86.CMMISDK_GetUserCalibrationData(inInstrumentNo, inDataType, ref outCalId, ref outCalData);
        }
        public static Int32 CMMISDK_SetUserCalibrationEnable(Int32 inInstrumentNo, CMMISDK_OnOff inCalEnable)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetUserCalibrationEnable(inInstrumentNo, inCalEnable) :
                CMMISDK_API_x86.CMMISDK_SetUserCalibrationEnable(inInstrumentNo, inCalEnable);
        }
        public static Int32 CMMISDK_GetUserCalibrationEnable(Int32 inInstrumentNo, ref CMMISDK_OnOff outCalEnable)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetUserCalibrationEnable(inInstrumentNo, ref outCalEnable) :
                CMMISDK_API_x86.CMMISDK_GetUserCalibrationEnable(inInstrumentNo, ref outCalEnable);
        }
        public static Int32 CMMISDK_SetTriggerMode(Int32 inInstrumentNo, CMMISDK_OnOff inTrigger)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetTriggerMode(inInstrumentNo, inTrigger) :
                CMMISDK_API_x86.CMMISDK_SetTriggerMode(inInstrumentNo, inTrigger);
        }
        public static Int32 CMMISDK_GetTriggerMode(Int32 inInstrumentNo, ref CMMISDK_OnOff outTrigger)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetTriggerMode(inInstrumentNo, ref outTrigger) :
                CMMISDK_API_x86.CMMISDK_GetTriggerMode(inInstrumentNo, ref outTrigger);
        }
        public static Int32 CMMISDK_ClearTriggerData(Int32 inInstrumentNo)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_ClearTriggerData(inInstrumentNo) :
                CMMISDK_API_x86.CMMISDK_ClearTriggerData(inInstrumentNo);
        }
        public static Int32 CMMISDK_IsTriggerData(Int32 inInstrumentNo, ref CMMISDK_OnOff outData)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_IsTriggerData(inInstrumentNo, ref outData) :
                CMMISDK_API_x86.CMMISDK_IsTriggerData(inInstrumentNo, ref outData);
        }
        public static Int32 CMMISDK_GetZeroCalibrationDate(Int32 inInstrumentNo, CMMISDK_DateType inType, ref CMMISDK_DateTime outDate)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetZeroCalibrationDate(inInstrumentNo, inType, ref outDate) :
                CMMISDK_API_x86.CMMISDK_GetZeroCalibrationDate(inInstrumentNo, inType, ref outDate);
        }
        public static Int32 CMMISDK_GetWhiteCalibrationDate(Int32 inInstrumentNo, ref CMMISDK_DateTime outDate)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetWhiteCalibrationDate(inInstrumentNo, ref outDate) :
                CMMISDK_API_x86.CMMISDK_GetWhiteCalibrationDate(inInstrumentNo, ref outDate);
        }
        public static Int32 CMMISDK_GetGlossCalibrationDate(Int32 inInstrumentNo, ref CMMISDK_DateTime outDate)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetGlossCalibrationDate(inInstrumentNo, ref outDate) :
                CMMISDK_API_x86.CMMISDK_GetGlossCalibrationDate(inInstrumentNo, ref outDate);
        }
        public static Int32 CMMISDK_GetUserCalibrationDate(Int32 inInstrumentNo, ref CMMISDK_DateTime outDate)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetUserCalibrationDate(inInstrumentNo, ref outDate) :
                CMMISDK_API_x86.CMMISDK_GetUserCalibrationDate(inInstrumentNo, ref outDate);
        }
        public static Int32 CMMISDK_ClearUvAdjustInfo(Int32 inInstrumentNo)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_ClearUvAdjustInfo(inInstrumentNo) :
                CMMISDK_API_x86.CMMISDK_ClearUvAdjustInfo(inInstrumentNo);
        }
		public static Int32 CMMISDK_SetProfileForUvAdjust(Int32 inInstrumentNo, ref CMMISDK_Data inData)
		{
			return Environment.Is64BitProcess ?
				CMMISDK_API_x64.CMMISDK_SetProfileForUvAdjust(inInstrumentNo, ref inData) :
				CMMISDK_API_x86.CMMISDK_SetProfileForUvAdjust(inInstrumentNo, ref inData);
		}
		public static Int32 CMMISDK_GetProfileForUvAdjust(Int32 inInstrumentNo, ref CMMISDK_Data outData)
		{
			return Environment.Is64BitProcess ?
				CMMISDK_API_x64.CMMISDK_GetProfileForUvAdjust(inInstrumentNo, ref outData) :
				CMMISDK_API_x86.CMMISDK_GetProfileForUvAdjust(inInstrumentNo, ref outData);
		}
		public static Int32 CMMISDK_SetWiForUvAdjust(Int32 inInstrumentNo, ref CMMISDK_UvAdjustIndex inData)
		{
			return Environment.Is64BitProcess ?
				CMMISDK_API_x64.CMMISDK_SetWiForUvAdjust(inInstrumentNo, ref inData) :
				CMMISDK_API_x86.CMMISDK_SetWiForUvAdjust(inInstrumentNo, ref inData);
		}
		public static Int32 CMMISDK_GetWiForUvAdjust(Int32 inInstrumentNo, ref CMMISDK_UvAdjustIndex outData)
		{
			return Environment.Is64BitProcess ?
				CMMISDK_API_x64.CMMISDK_GetWiForUvAdjust(inInstrumentNo, ref outData) :
				CMMISDK_API_x86.CMMISDK_GetWiForUvAdjust(inInstrumentNo, ref outData);
		}
		public static Int32 CMMISDK_SetTintForUvAdjust(Int32 inInstrumentNo, ref CMMISDK_UvAdjustIndex inData)
		{
			return Environment.Is64BitProcess ?
				CMMISDK_API_x64.CMMISDK_SetTintForUvAdjust(inInstrumentNo, ref inData) :
				CMMISDK_API_x86.CMMISDK_SetTintForUvAdjust(inInstrumentNo, ref inData);
		}
		public static Int32 CMMISDK_GetTintForUvAdjust(Int32 inInstrumentNo, ref CMMISDK_UvAdjustIndex outData)
        {
            return Environment.Is64BitProcess ?
				CMMISDK_API_x64.CMMISDK_GetTintForUvAdjust(inInstrumentNo, ref outData) :
				CMMISDK_API_x86.CMMISDK_GetTintForUvAdjust(inInstrumentNo, ref outData);
		}
		public static Int32 CMMISDK_SetIsoBrightnessForUvAdjust(Int32 inInstrumentNo, ref CMMISDK_UvAdjustIndex inData)
		{
			return Environment.Is64BitProcess ?
				CMMISDK_API_x64.CMMISDK_SetIsoBrightnessForUvAdjust(inInstrumentNo, ref inData) :
				CMMISDK_API_x86.CMMISDK_SetIsoBrightnessForUvAdjust(inInstrumentNo, ref inData);
		}
		public static Int32 CMMISDK_GetIsoBrightnessForUvAdjust(Int32 inInstrumentNo, ref CMMISDK_UvAdjustIndex outData)
		{
			return Environment.Is64BitProcess ?
				CMMISDK_API_x64.CMMISDK_GetIsoBrightnessForUvAdjust(inInstrumentNo, ref outData) :
				CMMISDK_API_x86.CMMISDK_GetIsoBrightnessForUvAdjust(inInstrumentNo, ref outData);
		}
		public static Int32 CMMISDK_SetGanzForUvAdjust(Int32 inInstrumentNo, ref CMMISDK_UvAdjustGG inData)
		{
			return Environment.Is64BitProcess ?
				CMMISDK_API_x64.CMMISDK_SetGanzForUvAdjust(inInstrumentNo, ref inData) :
				CMMISDK_API_x86.CMMISDK_SetGanzForUvAdjust(inInstrumentNo, ref inData);
	    }
		public static Int32 CMMISDK_GetGanzForUvAdjust(Int32 inInstrumentNo, ref CMMISDK_UvAdjustGG outData)
        {
            return Environment.Is64BitProcess ?
				CMMISDK_API_x64.CMMISDK_GetGanzForUvAdjust(inInstrumentNo, ref outData) :
				CMMISDK_API_x86.CMMISDK_GetGanzForUvAdjust(inInstrumentNo, ref outData);
        }
        public static Int32 CMMISDK_SetEachProfileForUvAdjust(Int32 inInstrumentNo, CMMISDK_UvAdjustDataType inType, ref CMMISDK_Data inData)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetEachProfileForUvAdjust(inInstrumentNo, inType, ref inData) :
                CMMISDK_API_x86.CMMISDK_SetEachProfileForUvAdjust(inInstrumentNo, inType, ref inData);
        }
        public static Int32 CMMISDK_GetEachProfileForUvAdjust(Int32 inInstrumentNo, CMMISDK_UvAdjustDataType inType, ref CMMISDK_Data outData)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetEachProfileForUvAdjust(inInstrumentNo, inType, ref outData) :
                CMMISDK_API_x86.CMMISDK_GetEachProfileForUvAdjust(inInstrumentNo, inType, ref outData);
        }
        public static Int32 CMMISDK_SetEachWiForUvAdjust(Int32 inInstrumentNo, CMMISDK_UvAdjustDataType inType, ref CMMISDK_UvAdjustIndex inData)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetEachWiForUvAdjust(inInstrumentNo, inType, ref inData) :
                CMMISDK_API_x86.CMMISDK_SetEachWiForUvAdjust(inInstrumentNo, inType, ref inData);
        }
        public static Int32 CMMISDK_GetEachWiForUvAdjust(Int32 inInstrumentNo, CMMISDK_UvAdjustDataType inType, ref CMMISDK_UvAdjustIndex outData)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetEachWiForUvAdjust(inInstrumentNo, inType, ref outData) :
                CMMISDK_API_x86.CMMISDK_GetEachWiForUvAdjust(inInstrumentNo, inType, ref outData);
        }
        public static Int32 CMMISDK_SetEachTintForUvAdjust(Int32 inInstrumentNo, CMMISDK_UvAdjustDataType inType, ref CMMISDK_UvAdjustIndex inData)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetEachTintForUvAdjust(inInstrumentNo, inType, ref inData) :
                CMMISDK_API_x86.CMMISDK_SetEachTintForUvAdjust(inInstrumentNo, inType, ref inData);
        }
        public static Int32 CMMISDK_GetEachTintForUvAdjust(Int32 inInstrumentNo, CMMISDK_UvAdjustDataType inType, ref CMMISDK_UvAdjustIndex outData)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetEachTintForUvAdjust(inInstrumentNo, inType, ref outData) :
                CMMISDK_API_x86.CMMISDK_GetEachTintForUvAdjust(inInstrumentNo, inType, ref outData);
        }
        public static Int32 CMMISDK_SetEachIsoBrightnessForUvAdjust(Int32 inInstrumentNo, CMMISDK_UvAdjustDataType inType, ref CMMISDK_UvAdjustIndex inData)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetEachIsoBrightnessForUvAdjust(inInstrumentNo, inType, ref inData) :
                CMMISDK_API_x86.CMMISDK_SetEachIsoBrightnessForUvAdjust(inInstrumentNo, inType, ref inData);
        }
        public static Int32 CMMISDK_GetEachIsoBrightnessForUvAdjust(Int32 inInstrumentNo, CMMISDK_UvAdjustDataType inType, ref CMMISDK_UvAdjustIndex outData)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetEachIsoBrightnessForUvAdjust(inInstrumentNo, inType, ref outData) :
                CMMISDK_API_x86.CMMISDK_GetEachIsoBrightnessForUvAdjust(inInstrumentNo, inType, ref outData);
        }
        public static Int32 CMMISDK_SetEachGanzForUvAdjust(Int32 inInstrumentNo, CMMISDK_UvAdjustDataType inType, ref CMMISDK_UvAdjustGG inData)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetEachGanzForUvAdjust(inInstrumentNo, inType, ref inData) :
                CMMISDK_API_x86.CMMISDK_SetEachGanzForUvAdjust(inInstrumentNo, inType, ref inData);
        }
        public static Int32 CMMISDK_GetEachGanzForUvAdjust(Int32 inInstrumentNo, CMMISDK_UvAdjustDataType inType, ref CMMISDK_UvAdjustGG outData)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetEachGanzForUvAdjust(inInstrumentNo, inType, ref outData) :
                CMMISDK_API_x86.CMMISDK_GetEachGanzForUvAdjust(inInstrumentNo, inType, ref outData);
        }
        public static Int32 CMMISDK_SetDataForUvAdjust(Int32 inInstrumentNo, CMMISDK_UvAdjustDataType inType, Int32 inNum, ref CMMISDK_Data inFull, ref CMMISDK_Data inCut)
        {
            return Environment.Is64BitProcess ?
				CMMISDK_API_x64.CMMISDK_SetDataForUvAdjust(inInstrumentNo, inType, inNum, ref inFull, ref inCut) :
				CMMISDK_API_x86.CMMISDK_SetDataForUvAdjust(inInstrumentNo, inType, inNum, ref inFull, ref inCut);
        }
		public static Int32 CMMISDK_GetDataForUvAdjust(Int32 inInstrumentNo, CMMISDK_UvAdjustDataType inType, Int32 inNum, ref CMMISDK_Data outFull, ref CMMISDK_Data outCut)
        {
            return Environment.Is64BitProcess ?
				CMMISDK_API_x64.CMMISDK_GetDataForUvAdjust(inInstrumentNo, inType, inNum, ref outFull, ref outCut) :
				CMMISDK_API_x86.CMMISDK_GetDataForUvAdjust(inInstrumentNo, inType, inNum, ref outFull, ref outCut);
        }
        public static Int32 CMMISDK_PerformUvAdjust(Int32 inInstrumentNo, CMMISDK_CondUvAdjust inCond)
        {
            return Environment.Is64BitProcess ?
	            CMMISDK_API_x64.CMMISDK_PerformUvAdjust(inInstrumentNo, inCond) :
	            CMMISDK_API_x86.CMMISDK_PerformUvAdjust(inInstrumentNo, inCond);
        }
        public static Int32 CMMISDK_PerformUvAdjustUsingData(Int32 inInstrumentNo, CMMISDK_CondUvAdjust inCond)
        {
            return Environment.Is64BitProcess ?
	            CMMISDK_API_x64.CMMISDK_PerformUvAdjustUsingData(inInstrumentNo, inCond) :
	            CMMISDK_API_x86.CMMISDK_PerformUvAdjustUsingData(inInstrumentNo, inCond);
        }
		public static Int32 CMMISDK_ClearCoefForUvAdjust(Int32 inInstrumentNo)
		{
			return Environment.Is64BitProcess ?
				CMMISDK_API_x64.CMMISDK_ClearCoefForUvAdjust(inInstrumentNo) :
				CMMISDK_API_x86.CMMISDK_ClearCoefForUvAdjust(inInstrumentNo);
		}
        public static Int32 CMMISDK_SetCoefForUvAdjust(Int32 inInstrumentNo, CMMISDK_MeasArea inArea, CMMISDK_UvAdjustDataType inType, CMMISDK_CondUvAdjust inCond, ref CMMISDK_UvAdjustCoef inCoef)
        {
            return Environment.Is64BitProcess ?
	            CMMISDK_API_x64.CMMISDK_SetCoefForUvAdjust(inInstrumentNo, inArea, inType, inCond, ref inCoef) :
	            CMMISDK_API_x86.CMMISDK_SetCoefForUvAdjust(inInstrumentNo, inArea, inType, inCond, ref inCoef);
        }
        public static Int32 CMMISDK_GetCoefForUvAdjust(Int32 inInstrumentNo, CMMISDK_MeasArea inArea, CMMISDK_UvAdjustDataType inType, ref CMMISDK_CondUvAdjust outCond, ref CMMISDK_UvAdjustCoef outCoef)
        {
            return Environment.Is64BitProcess ?
	            CMMISDK_API_x64.CMMISDK_GetCoefForUvAdjust(inInstrumentNo, inArea, inType, ref outCond, ref outCoef) :
	            CMMISDK_API_x86.CMMISDK_GetCoefForUvAdjust(inInstrumentNo, inArea, inType, ref outCond, ref outCoef);
        }
        public static Int32 CMMISDK_SetMeasurementArea(Int32 inInstrumentNo, CMMISDK_MeasArea inArea)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetMeasurementArea(inInstrumentNo, inArea) :
                CMMISDK_API_x86.CMMISDK_SetMeasurementArea(inInstrumentNo, inArea);
        }
        public static Int32 CMMISDK_GetMeasurementArea(Int32 inInstrumentNo, ref CMMISDK_MeasArea outArea)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetMeasurementArea(inInstrumentNo, ref outArea) :
                CMMISDK_API_x86.CMMISDK_GetMeasurementArea(inInstrumentNo, ref outArea);
        }
        public static Int32 CMMISDK_SetMeasurementType(Int32 inInstrumentNo, CMMISDK_MeasType inType)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetMeasurementType(inInstrumentNo, inType) :
                CMMISDK_API_x86.CMMISDK_SetMeasurementType(inInstrumentNo, inType);
        }
        public static Int32 CMMISDK_GetMeasurementType(Int32 inInstrumentNo, ref CMMISDK_MeasType outType)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetMeasurementType(inInstrumentNo, ref outType) :
                CMMISDK_API_x86.CMMISDK_GetMeasurementType(inInstrumentNo, ref outType);
        }
        public static Int32 CMMISDK_SetMeasurementAngle(Int32 inInstrumentNo, CMMISDK_MeasAngle inAngle)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetMeasurementAngle(inInstrumentNo, inAngle) :
                CMMISDK_API_x86.CMMISDK_SetMeasurementAngle(inInstrumentNo, inAngle);
        }
        public static Int32 CMMISDK_GetMeasurementAngle(Int32 inInstrumentNo, ref CMMISDK_MeasAngle outAngle)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetMeasurementAngle(inInstrumentNo, ref outAngle) :
                CMMISDK_API_x86.CMMISDK_GetMeasurementAngle(inInstrumentNo, ref outAngle);
        }
        public static Int32 CMMISDK_SetTiltDetection(Int32 inInstrumentNo, CMMISDK_OnOff inDetection)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetTiltDetection(inInstrumentNo, inDetection) :
                CMMISDK_API_x86.CMMISDK_SetTiltDetection(inInstrumentNo, inDetection);
        }
        public static Int32 CMMISDK_GetTiltDetection(Int32 inInstrumentNo, ref CMMISDK_OnOff outDetection)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetTiltDetection(inInstrumentNo, ref outDetection) :
                CMMISDK_API_x86.CMMISDK_GetTiltDetection(inInstrumentNo, ref outDetection);
        }
        public static Int32 CMMISDK_SetMeasurementMode(Int32 inInstrumentNo, CMMISDK_MeasMode inMode)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetMeasurementMode(inInstrumentNo, inMode) :
                CMMISDK_API_x86.CMMISDK_SetMeasurementMode(inInstrumentNo, inMode);
        }
        public static Int32 CMMISDK_GetMeasurementMode(Int32 inInstrumentNo, ref CMMISDK_MeasMode outMode)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetMeasurementMode(inInstrumentNo, ref outMode) :
                CMMISDK_API_x86.CMMISDK_GetMeasurementMode(inInstrumentNo, ref outMode);
        }
        public static Int32 CMMISDK_SetSpecularComponent(Int32 inInstrumentNo, CMMISDK_SpecularComponent inSpecularComponent)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetSpecularComponent(inInstrumentNo, inSpecularComponent) :
                CMMISDK_API_x86.CMMISDK_SetSpecularComponent(inInstrumentNo, inSpecularComponent);
        }
        public static Int32 CMMISDK_GetSpecularComponent(Int32 inInstrumentNo, ref CMMISDK_SpecularComponent outSpecularComponent)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetSpecularComponent(inInstrumentNo, ref outSpecularComponent) :
                CMMISDK_API_x86.CMMISDK_GetSpecularComponent(inInstrumentNo, ref outSpecularComponent);
        }
        public static Int32 CMMISDK_SetUv(Int32 inInstrumentNo, CMMISDK_Uv inUv)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetUv(inInstrumentNo, inUv) :
                CMMISDK_API_x86.CMMISDK_SetUv(inInstrumentNo, inUv);
        }
        public static Int32 CMMISDK_GetUv(Int32 inInstrumentNo, ref CMMISDK_Uv outUv)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetUv(inInstrumentNo, ref outUv) :
                CMMISDK_API_x86.CMMISDK_GetUv(inInstrumentNo, ref outUv);
        }
        public static Int32 CMMISDK_SetAutoAverageTimes(Int32 inInstrumentNo, Int32 inTimes)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetAutoAverageTimes(inInstrumentNo, inTimes) :
                CMMISDK_API_x86.CMMISDK_SetAutoAverageTimes(inInstrumentNo, inTimes);
        }
        public static Int32 CMMISDK_GetAutoAverageTimes(Int32 inInstrumentNo, ref Int32 outTimes)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetAutoAverageTimes(inInstrumentNo, ref outTimes) :
                CMMISDK_API_x86.CMMISDK_GetAutoAverageTimes(inInstrumentNo, ref outTimes);
        }
        public static Int32 CMMISDK_SetManualAverageTimes(Int32 inInstrumentNo, Int32 inTimes)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetManualAverageTimes(inInstrumentNo, inTimes) :
                CMMISDK_API_x86.CMMISDK_SetManualAverageTimes(inInstrumentNo, inTimes);
        }
        public static Int32 CMMISDK_GetManualAverageTimes(Int32 inInstrumentNo, ref Int32 outTimes)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetManualAverageTimes(inInstrumentNo, ref outTimes) :
                CMMISDK_API_x86.CMMISDK_GetManualAverageTimes(inInstrumentNo, ref outTimes);
        }
        public static Int32 CMMISDK_SetManualAverageSaveMode(Int32 inInstrumentNo, CMMISDK_SaveMode inMode)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetManualAverageSaveMode(inInstrumentNo, inMode) :
                CMMISDK_API_x86.CMMISDK_SetManualAverageSaveMode(inInstrumentNo, inMode);
        }
        public static Int32 CMMISDK_GetManualAverageSaveMode(Int32 inInstrumentNo, ref CMMISDK_SaveMode outMode)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetManualAverageSaveMode(inInstrumentNo, ref outMode) :
                CMMISDK_API_x86.CMMISDK_GetManualAverageSaveMode(inInstrumentNo, ref outMode);
        }
        public static Int32 CMMISDK_SetCondSMC(Int32 inInstrumentNo, ref CMMISDK_CondSMC inCond)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetCondSMC(inInstrumentNo, ref inCond) :
                CMMISDK_API_x86.CMMISDK_SetCondSMC(inInstrumentNo, ref inCond);
        }
        public static Int32 CMMISDK_GetCondSMC(Int32 inInstrumentNo, ref CMMISDK_CondSMC outCond)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetCondSMC(inInstrumentNo, ref outCond) :
                CMMISDK_API_x86.CMMISDK_GetCondSMC(inInstrumentNo, ref outCond);
        }
        public static Int32 CMMISDK_SetDisplayType(Int32 inInstrumentNo, CMMISDK_DisplayType inDisplayType)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetDisplayType(inInstrumentNo, inDisplayType) :
                CMMISDK_API_x86.CMMISDK_SetDisplayType(inInstrumentNo, inDisplayType);
        }
        public static Int32 CMMISDK_GetDisplayType(Int32 inInstrumentNo, ref CMMISDK_DisplayType outDisplayType)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetDisplayType(inInstrumentNo, ref outDisplayType) :
                CMMISDK_API_x86.CMMISDK_GetDisplayType(inInstrumentNo, ref outDisplayType);
        }
        public static Int32 CMMISDK_SetObserverAndIlluminant(Int32 inInstrumentNo, Int32 inNum, CMMISDK_Observer inObs, CMMISDK_Illuminant inIll)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetObserverAndIlluminant(inInstrumentNo, inNum, inObs, inIll) :
                CMMISDK_API_x86.CMMISDK_SetObserverAndIlluminant(inInstrumentNo, inNum, inObs, inIll);
        }
        public static Int32 CMMISDK_GetObserverAndIlluminant(Int32 inInstrumentNo, Int32 inNum, ref CMMISDK_Observer outObs, ref CMMISDK_Illuminant outIll)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetObserverAndIlluminant(inInstrumentNo, inNum, ref outObs, ref outIll) :
                CMMISDK_API_x86.CMMISDK_GetObserverAndIlluminant(inInstrumentNo, inNum, ref outObs, ref outIll);
        }
        public static Int32 CMMISDK_SetUserIlluminant(Int32 inInstrumentNo, ref CMMISDK_UserIlluminant inIllData)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetUserIlluminant(inInstrumentNo, ref inIllData) :
                CMMISDK_API_x86.CMMISDK_SetUserIlluminant(inInstrumentNo, ref inIllData);
        }
        public static Int32 CMMISDK_GetUserIlluminant(Int32 inInstrumentNo, ref CMMISDK_UserIlluminant outIllData)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetUserIlluminant(inInstrumentNo, ref outIllData) :
                CMMISDK_API_x86.CMMISDK_GetUserIlluminant(inInstrumentNo, ref outIllData);
        }
        public static Int32 CMMISDK_SetColorSpace(Int32 inInstrumentNo, CMMISDK_ColorSpace inColorSpace)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetColorSpace(inInstrumentNo, inColorSpace) :
                CMMISDK_API_x86.CMMISDK_SetColorSpace(inInstrumentNo, inColorSpace);
        }
        public static Int32 CMMISDK_GetColorSpace(Int32 inInstrumentNo, ref CMMISDK_ColorSpace outColorSpace)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetColorSpace(inInstrumentNo, ref outColorSpace) :
                CMMISDK_API_x86.CMMISDK_GetColorSpace(inInstrumentNo, ref outColorSpace);
        }
        public static Int32 CMMISDK_SetEquation(Int32 inInstrumentNo, CMMISDK_Equation inEquation)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetEquation(inInstrumentNo, inEquation) :
                CMMISDK_API_x86.CMMISDK_SetEquation(inInstrumentNo, inEquation);
        }
        public static Int32 CMMISDK_GetEquation(Int32 inInstrumentNo, ref CMMISDK_Equation outEquation)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetEquation(inInstrumentNo, ref outEquation) :
                CMMISDK_API_x86.CMMISDK_GetEquation(inInstrumentNo, ref outEquation);
        }
        public static Int32 CMMISDK_SetCustomIndex(Int32 inInstrumentNo, Int32 inCustomNum, CMMISDK_CustomIndex inCustomIndex)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetCustomIndex(inInstrumentNo, inCustomNum, inCustomIndex) :
                CMMISDK_API_x86.CMMISDK_SetCustomIndex(inInstrumentNo, inCustomNum, inCustomIndex);
        }
        public static Int32 CMMISDK_GetCustomIndex(Int32 inInstrumentNo, Int32 inCustomNum, ref CMMISDK_CustomIndex outCustomIndex)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetCustomIndex(inInstrumentNo, inCustomNum, ref outCustomIndex) :
                CMMISDK_API_x86.CMMISDK_GetCustomIndex(inInstrumentNo, inCustomNum, ref outCustomIndex);
        }
        public static Int32 CMMISDK_SetDirection(Int32 inInstrumentNo, CMMISDK_Direction inDirection)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetDirection(inInstrumentNo, inDirection) :
                CMMISDK_API_x86.CMMISDK_SetDirection(inInstrumentNo, inDirection);
        }
        public static Int32 CMMISDK_GetDirection(Int32 inInstrumentNo, ref CMMISDK_Direction outDirection)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetDirection(inInstrumentNo, ref outDirection) :
                CMMISDK_API_x86.CMMISDK_GetDirection(inInstrumentNo, ref outDirection);
        }
        public static Int32 CMMISDK_SetUserEquation(Int32 inInstrumentNo, Int32 inNum, ref CMMISDK_UserEquation inEquation)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetUserEquation(inInstrumentNo, inNum, ref inEquation) :
                CMMISDK_API_x86.CMMISDK_SetUserEquation(inInstrumentNo, inNum, ref inEquation);
        }
        public static Int32 CMMISDK_GetUserEquation(Int32 inInstrumentNo, Int32 inNum, ref CMMISDK_UserEquation outEquation)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetUserEquation(inInstrumentNo, inNum, ref outEquation) :
                CMMISDK_API_x86.CMMISDK_GetUserEquation(inInstrumentNo, inNum, ref outEquation);
        }
        public static Int32 CMMISDK_SetActiveTarget(Int32 inInstrumentNo, Int32 inNum)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetActiveTarget(inInstrumentNo, inNum) :
                CMMISDK_API_x86.CMMISDK_SetActiveTarget(inInstrumentNo, inNum);
        }
        public static Int32 CMMISDK_GetActiveTarget(Int32 inInstrumentNo, ref Int32 outNum)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetActiveTarget(inInstrumentNo, ref outNum) :
                CMMISDK_API_x86.CMMISDK_GetActiveTarget(inInstrumentNo, ref outNum);
        }
        public static Int32 CMMISDK_GetSavedTargetList(Int32 inInstrumentNo, ref CMMISDK_SavedTargetList outList)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetSavedTargetList(inInstrumentNo, ref outList) :
                CMMISDK_API_x86.CMMISDK_GetSavedTargetList(inInstrumentNo, ref outList);
        }
        public static Int32 CMMISDK_GetTargetListInFilter(Int32 inInstrumentNo, ref CMMISDK_SavedTargetList outList)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetTargetListInFilter(inInstrumentNo, ref outList) :
                CMMISDK_API_x86.CMMISDK_GetTargetListInFilter(inInstrumentNo, ref outList);
        }
        public static Int32 CMMISDK_DeleteTargetData(Int32 inInstrumentNo, Int32 inNum)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_DeleteTargetData(inInstrumentNo, inNum) :
                CMMISDK_API_x86.CMMISDK_DeleteTargetData(inInstrumentNo, inNum);
        }
        public static Int32 CMMISDK_DeleteAllTargetData(Int32 inInstrumentNo)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_DeleteAllTargetData(inInstrumentNo) :
                CMMISDK_API_x86.CMMISDK_DeleteAllTargetData(inInstrumentNo);
        }
        public static Int32 CMMISDK_ClearTargetInfo(Int32 inInstrumentNo)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_ClearTargetInfo(inInstrumentNo) :
                CMMISDK_API_x86.CMMISDK_ClearTargetInfo(inInstrumentNo);
        }
        public static Int32 CMMISDK_LoadTargetInfo(Int32 inInstrumentNo, Int32 inNum)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_LoadTargetInfo(inInstrumentNo, inNum) :
                CMMISDK_API_x86.CMMISDK_LoadTargetInfo(inInstrumentNo, inNum);
        }
        public static Int32 CMMISDK_SaveTargetInfo(Int32 inInstrumentNo, Int32 inNum)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SaveTargetInfo(inInstrumentNo, inNum) :
                CMMISDK_API_x86.CMMISDK_SaveTargetInfo(inInstrumentNo, inNum);
        }
        public static Int32 CMMISDK_SetTargetProperty(Int32 inInstrumentNo, ref CMMISDK_TargetProperty inProperty)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetTargetProperty(inInstrumentNo, ref inProperty) :
                CMMISDK_API_x86.CMMISDK_SetTargetProperty(inInstrumentNo, ref inProperty);
        }
        public static Int32 CMMISDK_GetTargetProperty(Int32 inInstrumentNo, ref CMMISDK_TargetProperty outProperty)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetTargetProperty(inInstrumentNo, ref outProperty) :
                CMMISDK_API_x86.CMMISDK_GetTargetProperty(inInstrumentNo, ref outProperty);
        }
        public static Int32 CMMISDK_SetTargetData(Int32 inInstrumentNo, CMMISDK_DataType inDataType, ref CMMISDK_Data inData)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetTargetData(inInstrumentNo, inDataType, ref inData) :
                CMMISDK_API_x86.CMMISDK_SetTargetData(inInstrumentNo, inDataType, ref inData);
        }
        public static Int32 CMMISDK_SetTargetDataColor(Int32 inInstrumentNo, CMMISDK_DataType inDataType, Int32 inNum, ref CMMISDK_ColorCond inCond, ref CMMISDK_Data inData)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetTargetDataColor(inInstrumentNo, inDataType, inNum, ref inCond, ref inData) :
                CMMISDK_API_x86.CMMISDK_SetTargetDataColor(inInstrumentNo, inDataType, inNum, ref inCond, ref inData);
        }
        public static Int32 CMMISDK_GetTargetDataColor(Int32 inInstrumentNo, CMMISDK_DataType inDataType, Int32 inNum, ref CMMISDK_ColorCond outCond, ref CMMISDK_Data outData)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetTargetDataColor(inInstrumentNo, inDataType, inNum, ref outCond, ref outData) :
                CMMISDK_API_x86.CMMISDK_GetTargetDataColor(inInstrumentNo, inDataType, inNum, ref outCond, ref outData);
        }
        public static Int32 CMMISDK_GetTargetData(Int32 inInstrumentNo, CMMISDK_DataType inDataType, ref CMMISDK_Data outData)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetTargetData(inInstrumentNo, inDataType, ref outData) :
                CMMISDK_API_x86.CMMISDK_GetTargetData(inInstrumentNo, inDataType, ref outData);
        }
        public static Int32 CMMISDK_SetToleranceForTarget(Int32 inInstrumentNo, CMMISDK_ToleranceType inType, Int32 inObsIll, CMMISDK_ToleranceId inId, ref CMMISDK_ToleranceData inTolerance)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetToleranceForTarget(inInstrumentNo, inType, inObsIll, inId, ref inTolerance) :
                CMMISDK_API_x86.CMMISDK_SetToleranceForTarget(inInstrumentNo, inType, inObsIll, inId, ref inTolerance);
        }
        public static Int32 CMMISDK_GetToleranceForTarget(Int32 inInstrumentNo, CMMISDK_ToleranceType inType, Int32 inObsIll, CMMISDK_ToleranceId inId, ref CMMISDK_ToleranceData outTolerance)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetToleranceForTarget(inInstrumentNo, inType, inObsIll, inId, ref outTolerance) :
                CMMISDK_API_x86.CMMISDK_GetToleranceForTarget(inInstrumentNo, inType, inObsIll, inId, ref outTolerance);
        }
        public static Int32 CMMISDK_SetParametricForTarget(Int32 inInstrumentNo, CMMISDK_ToleranceType inType, CMMISDK_ParametricId inId, ref CMMISDK_ParametricCoef inParametric)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetParametricForTarget(inInstrumentNo, inType, inId, ref inParametric) :
                CMMISDK_API_x86.CMMISDK_SetParametricForTarget(inInstrumentNo, inType, inId, ref inParametric);
        }
        public static Int32 CMMISDK_GetParametricForTarget(Int32 inInstrumentNo, CMMISDK_ToleranceType inType, CMMISDK_ParametricId inId, ref CMMISDK_ParametricCoef outParametric)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetParametricForTarget(inInstrumentNo, inType, inId, ref outParametric) :
                CMMISDK_API_x86.CMMISDK_GetParametricForTarget(inInstrumentNo, inType, inId, ref outParametric);
        }
        public static Int32 CMMISDK_SetTargetFilter(Int32 inInstrumentNo, CMMISDK_FilterIndex inIndex, ref CMMISDK_GroupList inGroup)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetTargetFilter(inInstrumentNo, inIndex, ref inGroup) :
                CMMISDK_API_x86.CMMISDK_SetTargetFilter(inInstrumentNo, inIndex, ref inGroup);
        }
        public static Int32 CMMISDK_GetTargetFilter(Int32 inInstrumentNo, ref CMMISDK_FilterIndex outIndex, ref CMMISDK_GroupList outGroup)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetTargetFilter(inInstrumentNo, ref outIndex, ref outGroup) :
                CMMISDK_API_x86.CMMISDK_GetTargetFilter(inInstrumentNo, ref outIndex, ref outGroup);
        }
        public static Int32 CMMISDK_SetTargetProtect(Int32 inInstrumentNo, CMMISDK_OnOff inProtect)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetTargetProtect(inInstrumentNo, inProtect) :
                CMMISDK_API_x86.CMMISDK_SetTargetProtect(inInstrumentNo, inProtect);
        }
        public static Int32 CMMISDK_GetTargetProtect(Int32 inInstrumentNo, ref CMMISDK_OnOff outProtect)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetTargetProtect(inInstrumentNo, ref outProtect) :
                CMMISDK_API_x86.CMMISDK_GetTargetProtect(inInstrumentNo, ref outProtect);
        }
        public static Int32 CMMISDK_GetSavedSampleCount(Int32 inInstrumentNo, ref Int32 outCount)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetSavedSampleCount(inInstrumentNo, ref outCount) :
                CMMISDK_API_x86.CMMISDK_GetSavedSampleCount(inInstrumentNo, ref outCount);
        }
        public static Int32 CMMISDK_DeleteSampleData(Int32 inInstrumentNo, Int32 inNum)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_DeleteSampleData(inInstrumentNo, inNum) :
                CMMISDK_API_x86.CMMISDK_DeleteSampleData(inInstrumentNo, inNum);
        }
        public static Int32 CMMISDK_DeleteAllSampleData(Int32 inInstrumentNo)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_DeleteAllSampleData(inInstrumentNo) :
                CMMISDK_API_x86.CMMISDK_DeleteAllSampleData(inInstrumentNo);
        }
        public static Int32 CMMISDK_LoadSampleInfo(Int32 inInstrumentNo, Int32 inNum)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_LoadSampleInfo(inInstrumentNo, inNum) :
                CMMISDK_API_x86.CMMISDK_LoadSampleInfo(inInstrumentNo, inNum);
        }
        public static Int32 CMMISDK_GetSampleProperty(Int32 inInstrumentNo, ref CMMISDK_SampleProperty outProperty)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetSampleProperty(inInstrumentNo, ref outProperty) :
                CMMISDK_API_x86.CMMISDK_GetSampleProperty(inInstrumentNo, ref outProperty);
        }
        public static Int32 CMMISDK_GetSampleData(Int32 inInstrumentNo, CMMISDK_DataType inDataType, ref CMMISDK_Data outData)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetSampleData(inInstrumentNo, inDataType, ref outData) :
                CMMISDK_API_x86.CMMISDK_GetSampleData(inInstrumentNo, inDataType, ref outData);
        }
        public static Int32 CMMISDK_SetActiveGroup(Int32 inInstrumentNo, ref CMMISDK_GroupList inGroup)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetActiveGroup(inInstrumentNo, ref inGroup) :
                CMMISDK_API_x86.CMMISDK_SetActiveGroup(inInstrumentNo, ref inGroup);
        }
        public static Int32 CMMISDK_GetActiveGroup(Int32 inInstrumentNo, ref CMMISDK_GroupList outGroup)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetActiveGroup(inInstrumentNo, ref outGroup) :
                CMMISDK_API_x86.CMMISDK_GetActiveGroup(inInstrumentNo, ref outGroup);
        }
        public static Int32 CMMISDK_SetGroupName(Int32 inInstrumentNo, Int32 inGroup, ref CMMISDK_Group inName)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetGroupName(inInstrumentNo, inGroup, ref inName) :
                CMMISDK_API_x86.CMMISDK_SetGroupName(inInstrumentNo, inGroup, ref inName);
        }
        public static Int32 CMMISDK_GetGroupName(Int32 inInstrumentNo, Int32 inGroup, ref CMMISDK_Group outName)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetGroupName(inInstrumentNo, inGroup, ref outName) :
                CMMISDK_API_x86.CMMISDK_GetGroupName(inInstrumentNo, inGroup, ref outName);
        }
        public static Int32 CMMISDK_SetMultipleGroupName(Int32 inInstrumentNo, ref CMMISDK_GroupAll inName)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetMultipleGroupName(inInstrumentNo, ref inName) :
                CMMISDK_API_x86.CMMISDK_SetMultipleGroupName(inInstrumentNo, ref inName);
        }
        public static Int32 CMMISDK_GetMultipleGroupName(Int32 inInstrumentNo, ref CMMISDK_GroupAll outName)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetMultipleGroupName(inInstrumentNo, ref outName) :
                CMMISDK_API_x86.CMMISDK_GetMultipleGroupName(inInstrumentNo, ref outName);
        }
        public static Int32 CMMISDK_LoadDefaultInfo(Int32 inInstrumentNo)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_LoadDefaultInfo(inInstrumentNo) :
                CMMISDK_API_x86.CMMISDK_LoadDefaultInfo(inInstrumentNo);
        }
        public static Int32 CMMISDK_SaveDefaultInfo(Int32 inInstrumentNo)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SaveDefaultInfo(inInstrumentNo) :
                CMMISDK_API_x86.CMMISDK_SaveDefaultInfo(inInstrumentNo);
        }
        public static Int32 CMMISDK_SetTolerance(Int32 inInstrumentNo, CMMISDK_ToleranceType inType, Int32 inObsIll, CMMISDK_ToleranceId inId, ref CMMISDK_ToleranceData inTolerance)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetTolerance(inInstrumentNo, inType, inObsIll, inId, ref inTolerance) :
                CMMISDK_API_x86.CMMISDK_SetTolerance(inInstrumentNo, inType, inObsIll, inId, ref inTolerance);
        }
        public static Int32 CMMISDK_GetTolerance(Int32 inInstrumentNo, CMMISDK_ToleranceType inType, Int32 inObsIll, CMMISDK_ToleranceId inId, ref CMMISDK_ToleranceData outTolerance)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetTolerance(inInstrumentNo, inType, inObsIll, inId, ref outTolerance) :
                CMMISDK_API_x86.CMMISDK_GetTolerance(inInstrumentNo, inType, inObsIll, inId, ref outTolerance);
        }
        public static Int32 CMMISDK_SetParametric(Int32 inInstrumentNo, CMMISDK_ToleranceType inType, CMMISDK_ParametricId inId, ref CMMISDK_ParametricCoef inParametric)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetParametric(inInstrumentNo, inType, inId, ref inParametric) :
                CMMISDK_API_x86.CMMISDK_SetParametric(inInstrumentNo, inType, inId, ref inParametric);
        }
        public static Int32 CMMISDK_GetParametric(Int32 inInstrumentNo, CMMISDK_ToleranceType inType, CMMISDK_ParametricId inId, ref CMMISDK_ParametricCoef outParametric)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetParametric(inInstrumentNo, inType, inId, ref outParametric) :
                CMMISDK_API_x86.CMMISDK_GetParametric(inInstrumentNo, inType, inId, ref outParametric);
        }
        public static Int32 CMMISDK_SetWarningLevel(Int32 inInstrumentNo, Int32 inLevel)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetWarningLevel(inInstrumentNo, inLevel) :
                CMMISDK_API_x86.CMMISDK_SetWarningLevel(inInstrumentNo, inLevel);
        }
        public static Int32 CMMISDK_GetWarningLevel(Int32 inInstrumentNo, ref Int32 outLevel)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetWarningLevel(inInstrumentNo, ref outLevel) :
                CMMISDK_API_x86.CMMISDK_GetWarningLevel(inInstrumentNo, ref outLevel);
        }
        public static Int32 CMMISDK_SetInstrumentMode(Int32 inInstrumentNo, CMMISDK_InstrumentMode inMode)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetInstrumentMode(inInstrumentNo, inMode) :
                CMMISDK_API_x86.CMMISDK_SetInstrumentMode(inInstrumentNo, inMode);
        }
        public static Int32 CMMISDK_GetInstrumentMode(Int32 inInstrumentNo, ref CMMISDK_InstrumentMode outMode)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetInstrumentMode(inInstrumentNo, ref outMode) :
                CMMISDK_API_x86.CMMISDK_GetInstrumentMode(inInstrumentNo, ref outMode);
        }
        public static Int32 CMMISDK_SetUserType(Int32 inInstrumentNo, CMMISDK_UserType inType)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetUserType(inInstrumentNo, inType) :
                CMMISDK_API_x86.CMMISDK_SetUserType(inInstrumentNo, inType);
        }
        public static Int32 CMMISDK_GetUserType(Int32 inInstrumentNo, ref CMMISDK_UserType outType)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetUserType(inInstrumentNo, ref outType) :
                CMMISDK_API_x86.CMMISDK_GetUserType(inInstrumentNo, ref outType);
        }
        public static Int32 CMMISDK_SetAdminPassword(Int32 inInstrumentNo, ref CMMISDK_AdminPass inPass)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetAdminPassword(inInstrumentNo, ref inPass) :
                CMMISDK_API_x86.CMMISDK_SetAdminPassword(inInstrumentNo, ref inPass);
        }
        public static Int32 CMMISDK_GetAdminPassword(Int32 inInstrumentNo, ref CMMISDK_AdminPass outPass)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetAdminPassword(inInstrumentNo, ref outPass) :
                CMMISDK_API_x86.CMMISDK_GetAdminPassword(inInstrumentNo, ref outPass);
        }
        public static Int32 CMMISDK_SetAutoPrint(Int32 inInstrumentNo, CMMISDK_OnOff inPrint)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetAutoPrint(inInstrumentNo, inPrint) :
                CMMISDK_API_x86.CMMISDK_SetAutoPrint(inInstrumentNo, inPrint);
        }
        public static Int32 CMMISDK_GetAutoPrint(Int32 inInstrumentNo, ref CMMISDK_OnOff outPrint)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetAutoPrint(inInstrumentNo, ref outPrint) :
                CMMISDK_API_x86.CMMISDK_GetAutoPrint(inInstrumentNo, ref outPrint);
        }
        public static Int32 CMMISDK_SetBrightness(Int32 inInstrumentNo, Int32 inBrightness)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetBrightness(inInstrumentNo, inBrightness) :
                CMMISDK_API_x86.CMMISDK_SetBrightness(inInstrumentNo, inBrightness);
        }
        public static Int32 CMMISDK_GetBrightness(Int32 inInstrumentNo, ref Int32 outBrightness)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetBrightness(inInstrumentNo, ref outBrightness) :
                CMMISDK_API_x86.CMMISDK_GetBrightness(inInstrumentNo, ref outBrightness);
        }
        public static Int32 CMMISDK_SetScreenDirection(Int32 inInstrumentNo, CMMISDK_ScreenDirection inScreenDirection)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetScreenDirection(inInstrumentNo, inScreenDirection) :
                CMMISDK_API_x86.CMMISDK_SetScreenDirection(inInstrumentNo, inScreenDirection);
        }
        public static Int32 CMMISDK_GetScreenDirection(Int32 inInstrumentNo, ref CMMISDK_ScreenDirection outScreenDirection)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetScreenDirection(inInstrumentNo, ref outScreenDirection) :
                CMMISDK_API_x86.CMMISDK_GetScreenDirection(inInstrumentNo, ref outScreenDirection);
        }
        public static Int32 CMMISDK_SetSound(Int32 inInstrumentNo, CMMISDK_OnOff inSound)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetSound(inInstrumentNo, inSound) :
                CMMISDK_API_x86.CMMISDK_SetSound(inInstrumentNo, inSound);
        }
        public static Int32 CMMISDK_GetSound(Int32 inInstrumentNo, ref CMMISDK_OnOff outSound)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetSound(inInstrumentNo, ref outSound) :
                CMMISDK_API_x86.CMMISDK_GetSound(inInstrumentNo, ref outSound);
        }
        public static Int32 CMMISDK_SetCalibrationInterval(Int32 inInstrumentNo, Int32 inInterval)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetCalibrationInterval(inInstrumentNo, inInterval) :
                CMMISDK_API_x86.CMMISDK_SetCalibrationInterval(inInstrumentNo, inInterval);
        }
        public static Int32 CMMISDK_GetCalibrationInterval(Int32 inInstrumentNo, ref Int32 outInterval)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetCalibrationInterval(inInstrumentNo, ref outInterval) :
                CMMISDK_API_x86.CMMISDK_GetCalibrationInterval(inInstrumentNo, ref outInterval);
        }
        public static Int32 CMMISDK_SetAnnualCalibration(Int32 inInstrumentNo, CMMISDK_OnOff inCal)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetAnnualCalibration(inInstrumentNo, inCal) :
                CMMISDK_API_x86.CMMISDK_SetAnnualCalibration(inInstrumentNo, inCal);
        }
        public static Int32 CMMISDK_GetAnnualCalibration(Int32 inInstrumentNo, ref CMMISDK_OnOff outCal)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetAnnualCalibration(inInstrumentNo, ref outCal) :
                CMMISDK_API_x86.CMMISDK_GetAnnualCalibration(inInstrumentNo, ref outCal);
        }
        public static Int32 CMMISDK_SetZeroCalibrationSkip(Int32 inInstrumentNo, CMMISDK_OnOff inSkip)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetZeroCalibrationSkip(inInstrumentNo, inSkip) :
                CMMISDK_API_x86.CMMISDK_SetZeroCalibrationSkip(inInstrumentNo, inSkip);
        }
        public static Int32 CMMISDK_GetZeroCalibrationSkip(Int32 inInstrumentNo, ref CMMISDK_OnOff outSkip)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetZeroCalibrationSkip(inInstrumentNo, ref outSkip) :
                CMMISDK_API_x86.CMMISDK_GetZeroCalibrationSkip(inInstrumentNo, ref outSkip);
        }
        public static Int32 CMMISDK_SetDateTime(Int32 inInstrumentNo, ref CMMISDK_DateTime inDate)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetDateTime(inInstrumentNo, ref inDate) :
                CMMISDK_API_x86.CMMISDK_SetDateTime(inInstrumentNo, ref inDate);
        }
        public static Int32 CMMISDK_SetDateFormat(Int32 inInstrumentNo, CMMISDK_DateFormat inFormat)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetDateFormat(inInstrumentNo, inFormat) :
                CMMISDK_API_x86.CMMISDK_SetDateFormat(inInstrumentNo, inFormat);
        }
        public static Int32 CMMISDK_GetDateFormat(Int32 inInstrumentNo, ref CMMISDK_DateFormat outFormat)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetDateFormat(inInstrumentNo, ref outFormat) :
                CMMISDK_API_x86.CMMISDK_GetDateFormat(inInstrumentNo, ref outFormat);
        }
        public static Int32 CMMISDK_SetLanguage(Int32 inInstrumentNo, CMMISDK_Language inLanguage)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetLanguage(inInstrumentNo, inLanguage) :
                CMMISDK_API_x86.CMMISDK_SetLanguage(inInstrumentNo, inLanguage);
        }
        public static Int32 CMMISDK_GetLanguage(Int32 inInstrumentNo, ref CMMISDK_Language outLanguage)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetLanguage(inInstrumentNo, ref outLanguage) :
                CMMISDK_API_x86.CMMISDK_GetLanguage(inInstrumentNo, ref outLanguage);
        }
        public static Int32 CMMISDK_SetPowerSaving(Int32 inInstrumentNo, Int32 inPowerSaving)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetPowerSaving(inInstrumentNo, inPowerSaving) :
                CMMISDK_API_x86.CMMISDK_SetPowerSaving(inInstrumentNo, inPowerSaving);
        }
        public static Int32 CMMISDK_GetPowerSaving(Int32 inInstrumentNo, ref Int32 outPowerSaving)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetPowerSaving(inInstrumentNo, ref outPowerSaving) :
                CMMISDK_API_x86.CMMISDK_GetPowerSaving(inInstrumentNo, ref outPowerSaving);
        }
        public static Int32 CMMISDK_ClearJobInfo(Int32 inInstrumentNo, Int32 inJobNum)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_ClearJobInfo(inInstrumentNo, inJobNum) :
                CMMISDK_API_x86.CMMISDK_ClearJobInfo(inInstrumentNo, inJobNum);
        }
        public static Int32 CMMISDK_SetJobInfo(Int32 inInstrumentNo, Int32 inJobNum, ref CMMISDK_JobInfo inInfo)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetJobInfo(inInstrumentNo, inJobNum, ref inInfo) :
                CMMISDK_API_x86.CMMISDK_SetJobInfo(inInstrumentNo, inJobNum, ref inInfo);
        }
        public static Int32 CMMISDK_GetJobInfo(Int32 inInstrumentNo, Int32 inJobNum, ref CMMISDK_JobInfo outInfo)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetJobInfo(inInstrumentNo, inJobNum, ref outInfo) :
                CMMISDK_API_x86.CMMISDK_GetJobInfo(inInstrumentNo, inJobNum, ref outInfo);
        }
        public static Int32 CMMISDK_GetJobStepType(Int32 inInstrumentNo, Int32 inJobNum, Int32 inStepNum, ref CMMISDK_JobStepType outType)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetJobStepType(inInstrumentNo, inJobNum, inStepNum, ref outType) :
                CMMISDK_API_x86.CMMISDK_GetJobStepType(inInstrumentNo, inJobNum, inStepNum, ref outType);
        }
        public static Int32 CMMISDK_SetJobStepForOperation(Int32 inInstrumentNo, Int32 inJobNum, Int32 inStepNum, ref CMMISDK_JobStepOperation inOperation)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetJobStepForOperation(inInstrumentNo, inJobNum, inStepNum, ref inOperation) :
                CMMISDK_API_x86.CMMISDK_SetJobStepForOperation(inInstrumentNo, inJobNum, inStepNum, ref inOperation);
        }
        public static Int32 CMMISDK_GetJobStepForOperation(Int32 inInstrumentNo, Int32 inJobNum, Int32 inStepNum, ref CMMISDK_JobStepOperation outOperation)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetJobStepForOperation(inInstrumentNo, inJobNum, inStepNum, ref outOperation) :
                CMMISDK_API_x86.CMMISDK_GetJobStepForOperation(inInstrumentNo, inJobNum, inStepNum, ref outOperation);
        }
        public static Int32 CMMISDK_SetJobStepForResult(Int32 inInstrumentNo, Int32 inJobNum, Int32 inStepNum, ref CMMISDK_JobStepResult inResult)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetJobStepForResult(inInstrumentNo, inJobNum, inStepNum, ref inResult) :
                CMMISDK_API_x86.CMMISDK_SetJobStepForResult(inInstrumentNo, inJobNum, inStepNum, ref inResult);
        }
        public static Int32 CMMISDK_GetJobStepForResult(Int32 inInstrumentNo, Int32 inJobNum, Int32 inStepNum, ref CMMISDK_JobStepResult outResult)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetJobStepForResult(inInstrumentNo, inJobNum, inStepNum, ref outResult) :
                CMMISDK_API_x86.CMMISDK_GetJobStepForResult(inInstrumentNo, inJobNum, inStepNum, ref outResult);
        }
        public static Int32 CMMISDK_SetJobImage(Int32 inInstrumentNo, Int32 inJobNum, Int32 inImageNum, IntPtr inImage)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_SetJobImage(inInstrumentNo, inJobNum, inImageNum, inImage) :
                CMMISDK_API_x86.CMMISDK_SetJobImage(inInstrumentNo, inJobNum, inImageNum, inImage);
        }
        public static Int32 CMMISDK_GetJobImage(Int32 inInstrumentNo, Int32 inJobNum, Int32 inImageNum, IntPtr outImage)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_GetJobImage(inInstrumentNo, inJobNum, inImageNum, outImage) :
                CMMISDK_API_x86.CMMISDK_GetJobImage(inInstrumentNo, inJobNum, inImageNum, outImage);
        }
        public static Int32 CMMISDK_ResetSetting(Int32 inInstrumentNo)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_ResetSetting(inInstrumentNo) :
                CMMISDK_API_x86.CMMISDK_ResetSetting(inInstrumentNo);
        }
        public static Int32 CMMISDK_ResetSettingAndData(Int32 inInstrumentNo)
        {
            return Environment.Is64BitProcess ?
                CMMISDK_API_x64.CMMISDK_ResetSettingAndData(inInstrumentNo) :
                CMMISDK_API_x86.CMMISDK_ResetSettingAndData(inInstrumentNo);
        }
    }
}
