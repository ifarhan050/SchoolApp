namespace DemoAttendenceFeature.Helper.EmailDynamic_Content
{
    public static class AttendenceAlertEmailBody
    {
        public static readonly string SingleStudentBody=
            $"<div class=\"detail-item\"><img src=\"https://rerp.braincrop.net/images/checkin.png\" width=\"40\" height=\"40\" alt=\"\\\">" +
            $"<div class=\"detail-heading\"><h2>{{student.Checkin}}<p>Check In</p></h2></div>" +
            $"</div>" +
            $"<div class=\"detail-item\"><img src=\"https://rerp.braincrop.net/images/checkout.png\" width=\"40\" height=\"40\" alt=\"\\\">" +
            $"<div class=\"detail-heading\"><h2>{{student.Checkout}}<p>Check Out</p></h2></div></div>";  
    }
}