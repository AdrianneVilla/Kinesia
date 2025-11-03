using System;
using System.Collections.Generic;
using System.Text;

namespace KinesiaLibrary
{
    public class ContactHelper
    {
        public static string ContactFormatter(string contact)
        {
            if (contact[0] == '0')
            {
                contact = contact.Substring(1); // will remove the "0" in the contact
            }

            contact = "+63" + contact; // will insert '+63' at the start of contact

            return contact;
        }
    }
}
