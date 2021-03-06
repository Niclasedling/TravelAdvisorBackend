using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAdvisor.Infrastructure.Migrations.Enum
{
    public static class StaticEnums
    {

        public static IDictionary<string, Guid> users = new Dictionary<string, Guid> {
            {"PONTUS",           Guid.Parse("6D157D49-58CA-4760-9FE1-7917FB8189DA")},
            {"ROBIN",            Guid.Parse("7A2DCB8D-2195-4B41-A4D0-875C6EBCF1E8")},
            {"ALEX",             Guid.Parse("AB731F94-C0D5-4246-A4F6-8245C723D72C")},
            {"JENS",             Guid.Parse("ECE1DA1C-6263-47E7-C36A-08D8911E42f9")},
            {"JOHAN",            Guid.Parse("72898113-5015-44ED-9CC2-57382B5CD7F2")},
            {"MATTIAS",          Guid.Parse("109B6E0A-A64A-4FEB-F16C-E68926AB2658")},
            {"NICKI",            Guid.Parse("4B3F3998-C612-4B5F-9994-887BA7496A21")},

        };

        public static IDictionary<string, Guid> attraction = new Dictionary<string, Guid> {
            {"STOCKHOLM",  Guid.Parse("514FAE50-43A7-4958-9ABD-C549817B9414")},
            {"OSLO",       Guid.Parse("E0044D7A-3B3B-4A10-B67C-D85B2181FBE9")},
            {"BERLIN",     Guid.Parse("252E9EEA-9F1E-4FE2-BBF2-BCC17D1DF943")},
            {"PRAG",       Guid.Parse("9B6CD306-A29F-40F5-9BA6-25906164D849")},
            {"ROME",       Guid.Parse("0f8fad5b-d9cb-469f-a165-70867728950e")},

        };
        public static IDictionary<string, Guid> review = new Dictionary<string, Guid> {
            {"REVIEWGUID1",       Guid.Parse("94c0462b-bcaf-4dac-852c-fa254e4c0045")},
            {"REVIEWGUID2",       Guid.Parse("fc7e794e-00cc-4896-b361-e98c36c5ea72")},
            {"REVIEWGUID3",       Guid.Parse("36985fbd-ed1e-4cd6-82bf-ea7ae2b9dfa3")},
            {"REVIEWGUID4",       Guid.Parse("265dca9d-6224-41f7-8a82-464692528928")},
            {"REVIEWGUID5",       Guid.Parse("3d1885e7-25e5-4d7c-8112-f9c763b3d831")},
            {"REVIEWGUID6",       Guid.Parse("df4550e0-68ed-400f-b721-c893b14e2cef")},
        };
    }
}
