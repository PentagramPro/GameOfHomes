using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using CommonClasses;

namespace GameOfHomes.Model
{
	[DataContract]
	public class Population
	{
		int workerAgeStart = 16;
		int workerAgeLength = 30;

		[DataMember]
		List<float> ByAges;

		float popCache = 0;
		float workerCache = 0;
		float childrenCache = 0;
		float agedCache = 0;
		float repCache = 0;

		[DataMember]
		Country country;

		[DataMember]
		float lastChange = 0;

		public float Total => popCache;
		public float Workers => workerCache;
		public float Children => childrenCache;
		public float Aged => agedCache;
		public float Reproductable => repCache;
		public float LastChange => lastChange;

		public Population(Country country)
		{
			this.country = country;
		}

		public Population(Country country, float pop)
		{
			this.country = country;

			ByAges = new List<float>();

			if (pop <= 0)
				return;

			
			for(int i=0;i<30;i++)
				ByAges.Add(pop/30);
		}

		[OnDeserialized]
		internal void OnDeserializedMethod(StreamingContext context)
		{
			UpdateCache();
		}

		void UpdateCache()
		{
			int age = 0;
			popCache = workerCache = childrenCache = agedCache = repCache = 0;

			foreach (var num in ByAges)
			{
				popCache += num;
				age++;
				if (age < workerAgeStart)
				{
					childrenCache += num;
				}
				else if (age > workerAgeStart + workerAgeLength)
				{
					agedCache += num;
				}
				else
				{
					workerCache += num;
					repCache += num;
				}
			}
		}

		public void Turn()
		{
			float foodProduction=country.OverallProduction[Resources.Food];
			
			float oldTotal = Total;
			float infants = Workers*0.2f;
			float foodBalance = Total - foodProduction;
			float deathRate=0.01f;

			if (foodBalance > 0)
			{
				infants = Math.Min(infants, foodBalance);
				foodBalance -= infants;
			}
			else
			{
				deathRate += 1-Math.Abs(foodBalance)/Total;
			}

			for (int i = 1; i < ByAges.Count; i++)
			{
				if (deathRate > 1)
					deathRate = 1;
				
				ByAges[i] = ByAges[i - 1]*(1-Rnd.Range(0,deathRate));

				deathRate += 0.005f;
			}

			UpdateCache();
			lastChange = Total - oldTotal;
		}
		

	}
}
