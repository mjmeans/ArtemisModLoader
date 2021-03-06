﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using log4net;
using System.Windows.Data;
using System.Collections;

namespace RussLibrary.ValueConverters
{
    
    public class TrueOnlyIfLastOne : IMultiValueConverter
    {
        static readonly ILog _log = LogManager.GetLogger(typeof(TrueOnlyIfLastOne));


        

        #region IMultiValueConverter Members

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults", MessageId = "System.Boolean.TryParse(System.String,System.Boolean@)")]
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (_log.IsDebugEnabled) { _log.DebugFormat("Starting {0}", MethodBase.GetCurrentMethod().ToString()); }
            //First one is the ICollection
            //Second is the current binding.
            bool MatchedReturn = true;
            if (parameter != null)
            {
                bool.TryParse(parameter.ToString(), out MatchedReturn);
            }
            bool retVal = false;
            if (values == null || values.Length != 2)
            {
                throw new InvalidOperationException("Only two bindings are valid for this converter.");
            }
            IList collection = values[0] as IList;

            object element = values[1];

            if (collection != null)
            {
                if (collection.Contains(element))
                {
                    retVal = (collection.IndexOf(element) == collection.Count - 1);
                }
                else
                {
                    retVal = false;
                }
            }
            else
            {
                retVal = false;
            }


            if (_log.IsDebugEnabled) { _log.DebugFormat("Ending {0}", MethodBase.GetCurrentMethod().ToString()); }
            if (retVal)
            {
                return MatchedReturn;
            }
            else
            {
                return !MatchedReturn;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
