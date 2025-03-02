public class Bin : StaticEquipment {

    public override void Interact(PlayerInteraction player) {
        base.Interact(player);

        if (!player.HasMovableEquipment()) {
            return;
        }

        Destroy(player.GetMovableEquipment());
        player.SetMovableEquipment(null);
    }
}