using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Configuration;
using System.Net.Configuration;

// AUTHOR: SHARJEEL SOHAIL
// DATE: 04/06/2021
// PROJECT: INFT3050 - ASSIGNMENT 1 (PART2)

namespace TheVintageStore.BusinessLayer
{
    public class SendEmail
    {
        // CLASS LEVEL VARIABLES DECLARATION & PROPERTIES
        public string sFromAddress { get; set; }        // From Email address
        public string sFromName { get; set; }           // From Name
        public string sToAddress { get; set; }          // To Email Address
        public string sSubject { get; set; }            // Email Subject
        public string sBody { get; set; }               // Email Body (Message)

        // METHOD: SendAnEmail()
        // PURPOSE: Sends an email using all the fields required such as 
        // Sender, reciever, subject, body message, CC, ReplyTo
        // Using SMTP client 
        public void SendAnEmail(int iCase)
        {
            MailMessage mail = new MailMessage();
            MailAddress fromAddress = new MailAddress(sFromAddress, sFromName);
            mail.To.Add(sToAddress);
            mail.From = fromAddress;
            mail.Subject = sSubject;
            mail.Body = sBody;

            // CASE 1: HELP / QUERIES (CONTACT US)
            // We add CC to ourselves since we want their message in our inbox,
            // And all replyTo so that we can reply to them using Reply button 
            if (iCase == 1)
            {
                mail.CC.Add(fromAddress.Address);
                mail.Sender = fromAddress;
                mail.ReplyToList.Add(new MailAddress(fromAddress.Address));
            }

            // CASE 2: FORGOT PASSWORD
            // WE DON'T CHANGE ANYTHING SO, WE'LL JUST AVOID THE HELP/QUERY CODE PART

            // CASE 3: PURCHASE RECEIPT
            // WE DON'T CHANGE ANYTHING SO, WE'LL JUST AVOID THE HELP/QUERY CODE PART

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            
            // GMAIL account made just for this web application
            smtp.Credentials = new System.Net.NetworkCredential("thevintagestoreshop@gmail.com", "C3316130");
            smtp.EnableSsl = true;

            smtp.Send(mail);
        }

    }

}