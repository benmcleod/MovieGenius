using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Review : IComparable
{
    public string critic { get; set; }
    public string date { get; set; }
    public string freshness { get; set; }
    public string publication { get; set; }
    public string quote { get; set; }
    public List<Link> Links { get; set; }

    public Review()
    {
        Links = new List<Link>();
    }

    public int CompareTo(object obj)
    {
        if (obj == null || obj.GetType() != typeof(Review))
        {
            throw new ArgumentException("Object is not a Review type");
        }

        Review temp = (Review)obj;
        return (temp.critic.CompareTo(this.critic));
    }

}

