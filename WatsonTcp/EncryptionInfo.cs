﻿using System;

namespace WatsonTcp
{
    internal class EncryptionInfo
    {
        public EncryptionInfo(EncryptionType algorithm)
        {
            Algorithm = algorithm;

            if (Algorithm == EncryptionType.None)
            {
                // do nothing
            }
            else if (Algorithm == EncryptionType.Aes)
            {
                Salt = RandomizeSalt();
            } else if (Algorithm == EncryptionType.TripleDes)
            {
                Salt = RandomizeSalt();
            }
            else if (Algorithm == EncryptionType.Custom)
            {
                Salt = RandomizeSalt();
            }
            else
            {
                throw new InvalidOperationException("Unknown encryption type: " + Algorithm.ToString());
            }
        }
        
        /// <summary>
        /// The type of algorithm used in the message.
        /// </summary>
        public EncryptionType Algorithm = EncryptionType.None;
        
        /// <summary>
        /// The salt used in the encryption.
        /// </summary>
        public string Salt = null;

        
        /// <summary>
        /// Random salt
        /// </summary>
        private static string RandomizeSalt()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}