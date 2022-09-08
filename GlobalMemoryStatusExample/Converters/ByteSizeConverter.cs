using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Data;
using ByteSizeLib;

namespace GlobalMemoryStatusExample.Converters;

public class ByteSizeConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        ByteSize byteSize;

        switch (value)
        {
            case uint intBytes:
                byteSize = ByteSize.FromBytes(intBytes);
                break;
            case ulong longBytes:
                byteSize = ByteSize.FromBytes(longBytes);
                break;
            default:
                Debug.WriteLine(value);
                return value;
        }

        var result = new List<string> { byteSize.ToString("B") };
        if (byteSize.MegaBytes >= 1)
            result.Add(byteSize.ToString("MB"));
        if (byteSize.GigaBytes >= 1)
            result.Add(byteSize.ToString("GB"));
        if (byteSize.TeraBytes >= 1)
            result.Add(byteSize.ToString("TB"));
        
        return string.Join(" | ", result);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return 0;
    }
}