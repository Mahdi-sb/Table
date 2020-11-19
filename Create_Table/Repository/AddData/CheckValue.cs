using Create_Table.Service.AddData;
using Create_Table.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Create_Table.Repository.AddData
{
    public class CheckValue :ICheckValue
    {
        public string CheckBool(List<ValueView> values)
        {
            foreach (var item in values)
            {

                if (item.Type == "BOOL" && (item.FieldValue.ToLower() != "true" && item.FieldValue.ToLower() != "false"))
                {
                    return "متغیر از نوع BOOL فقط شامل true یا false میباشد .";
                }


            }
            return null;
        }

        public string CheckInt(List<ValueView> values)
        {
            foreach (var item in values)
            {
                if (item.Type == "INT" && item.FieldValue.Any(char.IsLetter))
                {
                    return "متغیر از نوع INT نمیتواند شامل حروف باشد.";

                }

            }
            return null;

        }

        public string CheckString(List<ValueView> values)
        {
            foreach (var item in values)
            {
                if (item.Type == "STRING" && item.FieldValue.All(char.IsDigit))
                {
                    return "متغیر از نوع STRING نمیتواند تماما شامل عدد باشد.";
                }
            }
            return null;

        }

        public string CheckValues(List<ValueView> values)
        {
            if (CheckString(values) != null) return CheckString(values);
            if (CheckInt(values) != null) return CheckInt(values);
            if (CheckBool(values) != null) return CheckBool(values);
            return null;
        }
    }
}
