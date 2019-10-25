using System;
using System.Collections.Generic;
using System.Text;

namespace OneBoard.Core.Utilities
{
    public static class BasicCrudOperationMessages
    {

        public static string SUCCESS_ADD = "Successfully added the entity";

        public static string SUCCESS_UPDATE = "Successfully updated the entity";

        public static string SUCCESS_DELETE = "Successfully deleted the entity";

        public static string SUCCESS_GET_LİST = "The operation get related list of entity successfully";

        public static string FAIL_GET_LİST = "FAIL_GET_LİST";

        public static string FAIL_ADD = "FAIL_ADD";

        public static string SUCCESS_GET_ID = "The operation get the entity successfully";

        public static string FAIL_UPDATE = "FAIL_UPDATE";

        public static string FAIL_DELETE = "FAIL_DELETE";

        public static string NOT_FOUND_ENTİTY = "Not found any entity.";



        #region User
        public static string FIND_BY_ID_ERROR = "When It is finding a content.An error occurred.";
        public static string FIND_BY_NAME_AND_PASSWORD = "When It is trying to find a user.An Error occurred.";
        public static string GET_USER_REFRESH_TOKEN = "When it is getting a user , An Error occurred.";

        public static string REMOVE_REFRESH_TOKEN = "Refresh Token was deleted successfully. ";
        public static string SAVE_REFRESH_TOKEN = "New token successfully saved.";
        #endregion

        #region AuthMessage
        public static string CREATE_TOKEN = "Successfully created a token.";
        public static string FAIL_CREATE_TOKEN = "When it creating a token, Any problem occurred.";
        public static string ACCESS_TOKEN_ENOUGH_TİME_NOT = "Refresh token have not remained enough time.";
        public static string HAVE_NOT_USER = "User not found.";
        public static string USER_EXIT = "Successfully,User refresh token to set null.";
        public static string TOKEN_NOT_FOUND = "Refresh token is not found";
            #endregion

    }
}
