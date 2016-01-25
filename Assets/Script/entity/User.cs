using System;
namespace com.binaryleeward.entity
{
		public class User : Message
		{

		public User(){}

		public uint Id{ get; set;}
		public string Name{get; set;}

		public override byte Type ()
		{
			return (byte)1;
		}
		}
}

