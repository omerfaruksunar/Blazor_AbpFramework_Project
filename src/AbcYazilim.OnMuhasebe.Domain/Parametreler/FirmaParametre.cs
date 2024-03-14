namespace AbcYazilim.OnMuhasebe.Parametreler;
public class FirmaParametre : Entity<Guid>
{
	public Guid UseerId { get; set; }
	public Guid SubeId { get; set; }
	public Guid DonemId { get; set; }
	public Guid? DepoId { get; set; }
}
