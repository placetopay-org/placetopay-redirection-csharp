﻿using Newtonsoft.Json.Linq;
using PlacetoPay.Redirection.Contracts;
using System;
using System.Collections.Generic;

namespace PlacetoPay.Redirection.Entities
{
    /// <summary>
    /// Class <c>Subscription</c>
    /// </summary>
    public class Subscription : Entity
    {
        protected string reference;
        protected string description;
        protected List<NameValuePair> fields;

        /// <summary>
        /// Subscription constructor.
        /// </summary>
        /// <param name="data">JObject</param>
        public Subscription(JObject data)
        {
            Load(data, new JArray { "reference", "description" });

            if (data.ContainsKey("fields"))
            {
                SetFields(data.GetValue("fields").ToObject<JArray>());
            }
        }

        /// <summary>
        /// Subscription constructor.
        /// </summary>
        /// <param name="data">string</param>
        public Subscription(string data)
        {
            JObject json = JObject.Parse(data);

            Load(json, new JArray { "reference", "description" });

            if (json.ContainsKey("fields"))
            {
                SetFields(json.GetValue("fields").ToObject<JArray>());
            }
        }

        /// <summary>
        /// Subscription constructor.
        /// </summary>
        /// <param name="reference">string</param>
        /// <param name="description">string</param>
        /// <param name="fields">list</param>
        public Subscription(
            string reference,
            string description,
            List<NameValuePair> fields
            )
        {
            this.reference = reference;
            this.description = description;
            this.fields = fields;
        }

        /// <summary>
        /// Reference property.
        /// </summary>
        public string Reference
        {
            get { return reference; }
            set { reference = value; }
        }

        /// <summary>
        /// Description property.
        /// </summary>
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        /// <summary>
        /// Fields property.
        /// </summary>
        public List<NameValuePair> Fields
        {
            get { return fields; }
            set { fields = value; }
        }

        /// <summary>
        /// Json Object sent back from API.
        /// </summary>
        /// <returns>JsonObject</returns>
        public override JObject ToJsonObject()
        {
            throw new NotImplementedException();
        }
    }
}
