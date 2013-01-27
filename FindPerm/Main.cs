using System;
using Terraria;
using Hooks;
using TShockAPI;

namespace FindPerm
{
    [APIVersion(1, 12)]
    public class FindPerm : TerrariaPlugin
    {    	
        public override Version Version
        {
            get { return new Version("1.0"); }
        }
        public override string Name
        {
            get { return "FindPerm"; }
        }
        public override string Author
        {
            get { return "Ijwu"; }
        }
        public override string Description
        {
            get { return "FindPerm"; }
        }

        public FindPerm(Main game)
            : base(game)
        {
        	
        }
        
        public override void Initialize()
        {
        	GameHooks.Initialize += OnInitialize;

        }
        
        public void OnInitialize()
        {
         	Commands.ChatCommands.Add(new Command("findperm", FindPerms, "findperm"));
        }
		        
        public static void FindPerms(CommandArgs args)
        {
        	if (args.Parameters.Count == 1)
        	{
	        	foreach (Command cmd in TShockAPI.Commands.ChatCommands)
	        	{
	        		if (cmd.Names.Contains(args.Parameters[0]))
	        		{
	        			args.Player.SendInfoMessage(string.Format("Permission to use {0}: {1}", cmd.Name, cmd.Permission != "" ? cmd.Permission : "Nothing"));
	        			return;
	        		}
	        	}
	        	args.Player.SendErrorMessage("That command could not be found.");
        	}
        	else
        	{
        		args.Player.SendErrorMessage("Too many or not enough parameters. The format is: /findperm [command name]");
        	}
        }
    }
}