using GDWeave;
using util.LexicalTransformer;

namespace Shaderade;

/*
 The main entrypoint of your mod project
 This code here is invoked by GDWeave when loading your mod's DLL assembly, at runtime
*/

public class Mod : IMod
{
	public Mod(IModInterface mi)
	{
		// Load your mod's configuration file
		var config = new Config(mi.ReadConfig<ConfigFileSchema>());

		mi.RegisterScriptMod(
			new TransformationRuleScriptModBuilder()
				.ForMod(mi)
				.Named("Map Environment linear interpolation speed adjustment")
				.Patching("res://Scenes/Map/game_worldenv.gd")
				.AddRule(
					new TransformationRuleBuilder()
						.Named("Change lerp speed to non-molasses")
						.Do(Operation.ReplaceLast)
						.Matching(
							TransformationPatternFactory.CreateGdSnippetPattern(
								"""
								lerp_val = 0.01
								"""
							)
						)
						.With("0.6",
							indent: 1
						)
				)
				.Build()
		);

	}

	public void Dispose()
	{
		// Post-injection cleanup (optional)
	}
}
