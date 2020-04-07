﻿using JT808.Protocol.Enums;
using JT808.Protocol.Extensions;
using JT808.Protocol.Formatters;
using JT808.Protocol.Interfaces;
using JT808.Protocol.MessagePack;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace JT808.Protocol.MessageBody
{
    public class JT808_0x8700 : JT808Bodies, IJT808MessagePackFormatter<JT808_0x8700>, IJT808_2019_Version, IJT808Analyze
    {
        public override ushort MsgId => 0x8700;

        public override string Description => "行驶记录数据采集命令";
        /// <summary>
        /// 
        /// </summary>
        public byte CommandId { get; set; }

        public JT808CarDVRDownPackage JT808CarDVRDownPackage { get; set; }

        public void Analyze(ref JT808MessagePackReader reader, Utf8JsonWriter writer, IJT808Config config)
        {
            JT808_0x8700 value = new JT808_0x8700();
            writer.WriteStartObject("行驶记录数据采集命令");
            value.CommandId = reader.ReadByte();
            writer.WriteString($"[{value.CommandId.ReadNumber()}]命令字", ((JT808CarDVRCommandID)value.CommandId).ToString());
            writer.WriteStartObject(((JT808CarDVRCommandID)value.CommandId).ToString());
            JT808CarDVRSerializer.JT808CarDVRDownPackage.Analyze(ref reader, writer, config);
            writer.WriteEndObject();
            writer.WriteEndObject();
        }

        public JT808_0x8700 Deserialize(ref JT808MessagePackReader reader, IJT808Config config)
        {
            JT808_0x8700 value = new JT808_0x8700();
            value.CommandId = reader.ReadByte();
            value.JT808CarDVRDownPackage = JT808CarDVRSerializer.JT808CarDVRDownPackage.Deserialize(ref reader, config);
            return value;
        }

        public void Serialize(ref JT808MessagePackWriter writer, JT808_0x8700 value, IJT808Config config)
        {
            writer.WriteByte(value.CommandId);
            JT808CarDVRSerializer.JT808CarDVRDownPackage.Serialize(ref writer, value.JT808CarDVRDownPackage, config);
        }
    }
}
