using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebDoctor.Models
{
    public class ClientRecordingContext : DbContext
    {
        public ClientRecordingContext():base("name=DefaultConnection")
        {

        }

        public DbSet<ClientRecording> ClientRecordings { get; set; }
    }
}