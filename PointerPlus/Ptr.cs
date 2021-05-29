using System;
using System.Runtime.InteropServices;

namespace PointerPlus
{
    /// <summary>
    /// A Pointer with an <see cref="IntPtr"/> and a <seealso cref="GCHandle"/>
    /// </summary>
    public struct Ptr : IDisposable
    {
        /// <summary>
        /// Create a pointer with a GcHandle
        /// </summary>
        /// <param name="handle">The Handle to convert to a <see cref="IntPtr"/></param>
        public Ptr(GCHandle handle)
        {
            Handle = handle;
            mem = -1;
        }

        /// <summary>
        /// A direct ref to the Handle converted to a <see cref="IntPtr"/>
        /// </summary>
        public IntPtr Pointer => (IntPtr)Handle;

        /// <summary>
        /// The handle used
        /// </summary>
        public GCHandle Handle { get; }

        private long mem;
        /// <summary>
        /// A direct reference to the memory to make an IntPtr
        /// <para>Will return -1 if <see cref="Handle"/> or <seealso cref="Pointer"/> is default</para>
        /// </summary>
        public long Memory
        {
            get
            {
                if (Pointer == default || Handle == default)
                    return -1;

                if (Handle.Target == null)
                    return -1;

                if (mem <= -1)
                    mem = Pointer.ToInt64();

                return mem;
            }
        }

        /// <summary>
        /// <see cref="GCHandle.Free"/>
        /// </summary>
        public void Free() => Handle.Free();

        /// <summary>
        /// <see cref="Free"/>
        /// </summary>
        public void Dispose()
        {
            Free();
        }
    }

}
