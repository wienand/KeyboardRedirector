﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;


namespace KeyboardRedirector
{
    public class KeysWithExtended
    {
        public uint keycode;

        private const uint maskKeys = 0xFF;
        private const uint maskExtended = 0x8000;

        public Keys Keys
        {
            get
            {
                return (Keys)(keycode & maskKeys);
            }
            set
            {
                keycode &= ~maskKeys;
                keycode |= (uint)value;
            }
        }

        public bool Extended
        {
            get
            {
                return ((keycode & maskExtended) != 0);
            }
            set
            {
                if (value)
                    keycode |= maskExtended;
                else
                    keycode &= ~maskExtended;
            }
        }

        public KeysWithExtended(uint keycode)
        {
            this.keycode = keycode;
        }

        public KeysWithExtended(Keys keys, bool extended)
        {
            keycode = 0;
            this.Keys = keys;
            this.Extended = extended;
        }

        public static KeysWithExtended None
        {
            get
            {
                KeysWithExtended result = new KeysWithExtended(0);
                return result;
            }
        }

        public override string ToString()
        {
            if (this.Extended)
                return "^" + NiceKeyName.GetName(this.Keys);
            else
                return NiceKeyName.GetName(this.Keys);
        }

        public static KeysWithExtended Parse(string s)
        {
            KeysWithExtended result = new KeysWithExtended(0);
            if (s.StartsWith("^"))
            {
                s = s.Substring(1);
                result.Extended = true;
            }
            result.Keys = NiceKeyName.GetKey(s);
            return result;
        }

        public static bool operator ==(KeysWithExtended k1, KeysWithExtended k2)
        {
            return (k1.keycode == k2.keycode);
        }

        public static bool operator !=(KeysWithExtended k1, KeysWithExtended k2)
        {
            return (k1.keycode != k2.keycode);
        }
    }
}
