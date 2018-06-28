﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace WebOfThings {
   // Note: Special structure to make it work for our implementation.
   [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy), NamingStrategyParameters = new object[] { true, false, false })]
   public class WoTPropertyReadHandler {
      public Uri Address { get; set; }
      public string Verb { get; set; }
   }
}
