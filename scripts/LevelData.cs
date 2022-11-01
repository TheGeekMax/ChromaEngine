

public class LevelData{
    public string levelName;
    public string levelCode;
    public string cityName;
    public LevelbuttonManager.LevelButtonState state;

    public LevelData(string levelName, string levelCode,string cityName, LevelbuttonManager.LevelButtonState state){
        this.levelName = levelName;
        this.levelCode = levelCode;
        this.cityName = cityName;
        this.state = state;
    }

    public static LevelData DefaultSandBox(string levelName,string cityName, string levelCode){
        return new LevelData(levelName, levelCode, cityName, LevelbuttonManager.LevelButtonState.SandBox);
    }

    public static LevelData DefaultLevel(string levelName,string cityName, string levelCode){
        return new LevelData(levelName, levelCode, cityName, LevelbuttonManager.LevelButtonState.Unlocked);
    }

    public static LevelData DefaultCompleted(string levelName,string cityName, string levelCode){
        return new LevelData(levelName, levelCode, cityName, LevelbuttonManager.LevelButtonState.Completed);
    }
}