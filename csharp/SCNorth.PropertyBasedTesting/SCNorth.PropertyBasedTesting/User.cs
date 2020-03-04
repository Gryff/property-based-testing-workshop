using System.Runtime.Serialization;

namespace SCNorth.PropertyBasedTesting
{
	[DataContract]
	public class User
	{
		[DataMember(Name="id")]
		public int Id { get; set; }

		[DataMember(Name="name")]
		public string Name { get; set; }

		[DataMember(Name="age")]
		public int Age { get; set; }

		[DataMember(Name="occupation")]
		public string Occupation { get; set; }
	}
}
