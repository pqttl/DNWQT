namespace DNQT.ToolCommon.ListStringApi
{
    public class STR_URI_Login
    {
        public class nameController
        {
            public const string STR = "Login";
        }

        public class TARAuthenticate
        {
            public const string STR = "TARAuthenticate";
        }

        public class STR_URI_DANGNHAP
        {
            public const string STR = "/" + STR_api.name.STR + "/" + nameController.STR 
                + "/" + TARAuthenticate.STR;
            //public const string STR = $"/{api.name.STR}/{nameController.STR}/{TARAuthenticate.STR}";
        }

    }
}
