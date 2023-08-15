namespace DNQT.ToolCommon.ListStringApi
{
    public class STR_URI_User
    {
        public class nameController
        {
            public const string STR = "User";
        }
        
        public class TARInsertUser
        {
            public const string STR = "TARInsertUser";
        }

        public class STR_URI_INSERT_USER
        {
            public const string STR = "/" + STR_api.name.STR + "/" + nameController.STR 
                + "/" + TARInsertUser.STR;
        }

    }
}
