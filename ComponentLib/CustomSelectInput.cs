using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComponentLib
{
    class CustomSelectInput<TValue> : InputSelect<TValue>
    {

        protected override bool TryParseValueFromString(string value, out TValue result, out string validationErrorMessage)
        {
            if(typeof(TValue) == typeof(int)){
                if (int.TryParse(value, out var resultInt))
                {
                    result = (TValue)(object)resultInt;
                    validationErrorMessage = null;
                    return true;
                }
                result = default;
                validationErrorMessage = $"The selected value {value} is not a valid number";
                return true;
            }

            return base.TryParseValueFromString(value, out result, out validationErrorMessage);
        }

    }
}
