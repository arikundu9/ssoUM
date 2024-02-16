
namespace ssoUM.Utils;
public enum ResponseCode
{
    //____________#_10XX_:_Main_App_Errors____________
    App_Server_Error = 1000,
    Missing_Headers = 1001,
    Missing_Parameters = 1002,
    Invalid_offset_or_limit = 1003,
    Invalid_Locale = 1004,
    Invalid_Timezone = 1005,
    You_exceeded_the_limit_of_requests_per_minute___Please_try_again_after_sometime = 1006,
    //____________#_11XX_:_Http_Errors____________
    Unauthorized = 1101,
    Not_authorized_to_access = 1102,
    Unprocessable_Entity = 1103,
    Authentication_Failed = 1104,
    Not_Found = 1105,
    //____________#_12XX_:_Auth_Erorrs____________
    Your_session_is_expired___please_login_again___Token_expired = 1201,
    Your_sessions_is_invalid___JWT_verification_error = 1202,
    Your_sessions_is_invalid___Error_encountered_while_decoding_JWT_token = 1203,
    Your_sessions_token_is_invalid___Invalid_token = 1204,
    You_are_Unauthorized___Please_login___You_are_Unauthorized___Please_login = 1205,
    Authentication_Error___User_Not_found___Authentication_Error___User_Not_found = 1206,
    //____________#_13XX_Session_Errors____________
    Invalid_Credentials = 1301,
    Invalid_Login_Type = 1302,
    Invalid_Social_Type = 1303,
    Login_Error = 1304,
    You_Account_is_disabled_by_the_admin = 1305,
    Invalid_mobile_number = 1306,
    Wrong_confirmation_code__Try_again = 1307,
    Invalid_email_or_password = 1308,
    Your_account_already_exist_in_the_app___please_try_to_login = 1309,
    Your_request_is_invalid_or_your_request_time_is_over___please_try_again = 1310,
    You_are_not_authorized_to_access_this_app = 1311,
    An_issue_in_the_Active_Directory_Service___please_contat_the_Administrator = 1312,
    your_email_still_not_confirmed___please_confirm_your_email = 1313,
    Email_link_has_been_expired = 1314,
    Your_account_is_not_activated_Please_verify_your_email_to_activate_the_account = 1315,
    You_cannot_delete_user_until_his_requests_been_completed_or_cancelled = 1316,
    This_number_has_already_registered = 1317,
    Please_before_you_login_with_google_account_first_sign_up = 1318,
    Your_old_mobile_number_is_wrong = 1319,
    confirmation_code_is_expired_Try_again = 1320,
    You_cannot_delete_provider_until_he_completed_or_cancelled_his_requests = 1321,
    Your_account_was_blocked_by_Admin__Please_contact_admin_at_support_AT_laancare_DOT_com = 1322,
    //____________#_14XX_Database_Error____________
    Generic_Database_error = 1400,
    Foreign_Key_Violation = 1401,
    //____________#_2XXX_Success____________
    Success = 2000,
}
