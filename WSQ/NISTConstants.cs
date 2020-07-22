namespace Wsqm
{
    internal static class NistConstants
    {
        /* From nistcom.h */
        public const string NCM_EXT = "ncm";
        public const string NCM_HEADER = "NIST_COM";        /* mandatory */
        public const string NCM_PIX_WIDTH = "PIX_WIDTH";       /* mandatory */
        public const string NCM_PIX_HEIGHT = "PIX_HEIGHT";      /* mandatory */
        public const string NCM_PIX_DEPTH = "PIX_DEPTH";       /* 1,8,24 (mandatory)*/
        public const string NCM_PPI = "PPI";             /* -1 if unknown (mandatory)*/
        public const string NCM_COLORSPACE = "COLORSPACE";      /* RGB,YCbCr,GRAY */
        public const string NCM_N_CMPNTS = "NUM_COMPONENTS";  /* [1..4] (mandatory w/hv_factors)*/
        public const string NCM_HV_FCTRS = "HV_FACTORS";      /* H0,V0:H1,V1:...*/
        public const string NCM_INTRLV = "INTERLEAVE";      /* 0,1 (mandatory w/depth=24) */
        public const string NCM_COMPRESSION = "COMPRESSION";     /* NONE,JPEGB,JPEGL,WSQ */
        public const string NCM_JPEGB_QUAL = "JPEGB_QUALITY";   /* [20..95] */
        public const string NCM_JPEGL_PREDICT = "JPEGL_PREDICT"; /* [1..7] */
        public const string NCM_WSQ_RATE = "WSQ_BITRATE";     /* ex. .75,2.25 (-1.0 if unknown)*/
        public const string NCM_LOSSY = "LOSSY";           /* 0,1 */
        public const string NCM_HISTORY = "HISTORY";         /* ex. SD historical data */
        public const string NCM_FING_CLASS = "FING_CLASS";      /* ex. A,L,R,S,T,W */
        public const string NCM_SEX = "SEX";             /* m,f */
        public const string NCM_SCAN_TYPE = "SCAN_TYPE";       /* l,i */
        public const string NCM_FACE_POS = "FACE_POS";        /* f,p */
        public const string NCM_AGE = "AGE";
        public const string NCM_SD_ID = "SD_ID";           /* 4,9,10,14,18 */
    }
}