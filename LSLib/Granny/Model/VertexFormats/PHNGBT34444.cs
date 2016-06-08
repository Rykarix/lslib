﻿using LSLib.Granny.GR2;
using System;

#pragma warning disable 0649

namespace LSLib.Granny.Model.VertexFormat
{
    [StructSerialization(MixedMarshal = true)]
    internal class PHNGBT34444_Prototype
    {
        [Serialization(ArraySize = 3)]
        public float[] Position;
        [Serialization(ArraySize = 4)]
        public ushort[] Normal;
        [Serialization(ArraySize = 4)]
        public ushort[] Tangent;
        [Serialization(ArraySize = 4)]
        public ushort[] Binormal;
        [Serialization(ArraySize = 2)]
        public ushort[] TextureCoordinates0;
        [Serialization(ArraySize = 2)]
        public ushort[] TextureCoordinates1;
    }

    [VertexPrototype(Prototype = typeof(PHNGBT34444_Prototype)),
    VertexDescription(Position = true, Normal = true, Tangent = true, Binormal = true, TextureCoordinates = true)]
    public class PHNGBT34444 : Vertex
    {
        public override void Serialize(WritableSection section)
        {
            WriteVector3(section, Position);
            WriteHalfVector3As4(section, Normal);
            WriteHalfVector3As4(section, Tangent);
            WriteHalfVector3As4(section, Binormal);
            WriteHalfVector2(section, TextureCoordinates0);
            WriteHalfVector2(section, new OpenTK.Vector2(0, 0));
        }

        public override void Unserialize(GR2Reader reader)
        {
            Position = ReadVector3(reader);
            Normal = ReadHalfVector4As3(reader);
            Tangent = ReadHalfVector4As3(reader);
            Binormal = ReadHalfVector4As3(reader);
            TextureCoordinates0 = ReadHalfVector2(reader);
            /* TextureCoordinates1 = */ ReadHalfVector2(reader);
        }
    }
}
