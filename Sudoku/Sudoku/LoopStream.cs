using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NAudio.Wave;

namespace Sudoku
{
   public class LoopStream :WaveStream
    {

        //Source: http://mark-dot-net.blogspot.se/2009/10/looped-playback-in-net-with-naudio.html

        //Music: http://www.youtube.com/watch?v=Eh3AuwiG9L0

        WaveStream sourceStream;

        ///// Creates a new Loop stream

        ///// <param name="sourceStream">The stream to read from. Note: the Read method of this stream should return 0 when it reaches the end
        ///// or else we will not loop to the start again.</param>
        public LoopStream(WaveStream sourceStream)
        {
            this.sourceStream = sourceStream;
            this.EnableLooping = true;
        }


        // /// Use this to turn looping on or off

        public bool EnableLooping { get; set; }


        ///// Return source stream's wave format

        public override WaveFormat WaveFormat
        {
            get { return sourceStream.WaveFormat; }
        }


        ///// LoopStream simply returns

        public override long Length
        {
            get { return sourceStream.Length; }
        }


        /// LoopStream simply passes on positioning to source stream

        public override long Position
        {
            get { return sourceStream.Position; }
            set { sourceStream.Position = value; }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            int totalBytesRead = 0;

            while (totalBytesRead < count)
            {
                int bytesRead = sourceStream.Read(buffer, offset + totalBytesRead, count - totalBytesRead);
                if (bytesRead == 0)
                {
                    if (sourceStream.Position == 0 || !EnableLooping)
                    {
                        // something wrong with the source stream
                        break;
                    }
                    // loop
                    sourceStream.Position = 0;
                }
                totalBytesRead += bytesRead;
            }
            return totalBytesRead;
        }



    }
}
