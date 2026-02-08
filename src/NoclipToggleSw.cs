using SwiftlyS2.Shared;
using SwiftlyS2.Shared.Commands;
using SwiftlyS2.Shared.Players;
using SwiftlyS2.Shared.Plugins;
using SwiftlyS2.Shared.SchemaDefinitions;

namespace NoclipTogglePlugin;

[PluginMetadata(
    Id = "noclip.toggle.selim",
    Name = "The plugin that gives noclip to the person who types !nc",
    Author = "Selim Yaşar",
    Version = "1.2.0"
)]
public class NoclipToggle : BasePlugin
{
    private NoclipConfig _config = new();

    public NoclipToggle(ISwiftlyCore core) : base(core) { }

    public override void Load(bool hotReload)
    {
        Console.WriteLine("[Selim Noclip] Plugin yüklendi.");
    }

    public override void Unload() { }

    [Command("nc")]
    public void NoclipCommand(ICommandContext context)
    {
        if (!context.IsSentByPlayer) return;

        var player = context.Sender as IPlayer;
        if (player == null || !player.IsValid) return;

        var pawn = player.PlayerPawn;
        if (pawn == null || !pawn.IsValid) return;

        // Localizer'ı burada tanımla (scope hatası önlemek için)
        var localizer = Core.Translation.GetPlayerLocalizer(player);

        // Ölü kontrolü
        if (pawn.Health <= 0)
        {
            string deadMsg = ReplaceColors(localizer["noclip.dead"] ?? "{Red}Ölüyken noclip komutu kullanamazsın!");
            player.SendChat(deadMsg);  // Sadece ölü oyuncuya gönder
            return;
        }

        string playerName = player.Controller?.PlayerName ?? "Bilinmeyen";

        bool enabling = pawn.MoveType != MoveType_t.MOVETYPE_NOCLIP;

        SetMoveType(player, enabling ? MoveType_t.MOVETYPE_NOCLIP : MoveType_t.MOVETYPE_WALK);

        // Translation'dan mesajları çek (fallback config ile)
        string prefix = ReplaceColors(localizer["noclip.prefix"] ?? _config.Prefix);
        string stateMsg = enabling
            ? localizer["noclip.enable"] ?? _config.EnableMessage
            : localizer["noclip.disable"] ?? _config.DisableMessage;
        string stateText = ReplaceColors(stateMsg);

        string message = $"{prefix} {playerName} {stateText}";

        // Tüm oyunculara broadcast
        foreach (var p in Core.PlayerManager.GetAllPlayers())
        {
            if (p != null && p.IsValid)
                p.SendChat(message);
        }
    }

    private void SetMoveType(IPlayer player, MoveType_t moveType)
    {
        var pawn = player.PlayerPawn;
        if (pawn == null) return;
        pawn.ActualMoveType = moveType;
        pawn.MoveType = moveType;
        pawn.MoveTypeUpdated();
    }

    private string ReplaceColors(string message)
    {
        if (string.IsNullOrEmpty(message)) return "";
        return message
            .Replace("{Default}", Helper.ChatColors.Default)
            .Replace("{White}", Helper.ChatColors.White)
            .Replace("{DarkRed}", Helper.ChatColors.DarkRed)
            .Replace("{Green}", Helper.ChatColors.Green)
            .Replace("{LightYellow}", Helper.ChatColors.LightYellow)
            .Replace("{LightBlue}", Helper.ChatColors.LightBlue)
            .Replace("{Olive}", Helper.ChatColors.Olive)
            .Replace("{Lime}", Helper.ChatColors.Lime)
            .Replace("{Red}", Helper.ChatColors.Red)
            .Replace("{Purple}", Helper.ChatColors.Purple)
            .Replace("{Grey}", Helper.ChatColors.Grey)
            .Replace("{Yellow}", Helper.ChatColors.Yellow)
            .Replace("{Gold}", Helper.ChatColors.Gold)
            .Replace("{Silver}", Helper.ChatColors.Silver)
            .Replace("{Blue}", Helper.ChatColors.Blue)
            .Replace("{DarkBlue}", Helper.ChatColors.DarkBlue)
            .Replace("{BlueGrey}", Helper.ChatColors.BlueGrey)
            .Replace("{Magenta}", Helper.ChatColors.Magenta)
            .Replace("{LightRed}", Helper.ChatColors.LightRed);
    }
}