﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace CM94NGEditor
{
    public class ColorConverter : CustomCreationConverter<Color>
    {
        public override bool CanWrite { get { return false; } }
        public override bool CanRead { get { return true; } }
        public ColorConverter() { }
        public override Color Create(Type objectType)
        {
            return new Color();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            Color target = Create(objectType);
            target = Color.FromArgb(jObject["A"].Value<Int32>(), jObject["R"].Value<Int32>(), jObject["G"].Value<Int32>(), jObject["B"].Value<Int32>());
            return target;
        }
    }
}
