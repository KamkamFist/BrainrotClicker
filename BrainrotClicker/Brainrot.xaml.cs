using Plugin.Maui.Audio;

namespace BrainrotClicker;

public partial class Brainrot : ContentPage
{
    private IAudioPlayer _player;

    int points = 0;
    int upgValue = 1;
    public string songPath = "braun.mp3";

    private string[] imagePaths = new string[]
    {
        "tralalero.jpg", 
        "balerina.jpg", 
        "patapim.jpg", 
        "bombardilo.jpg", 
        "trippu.jpg", 
        "tung.jpg"  
    };
    private string[] songPaths = new string[]
    {
        "tralalero.mp3",
        "balerinacapucina.mp3",
        "brrbrrpatapim.mp3",
        "bombardilocrocodilo.mp3",
        "trippitroppa.mp3",
        "tungsahur.mp3"
    };

    private int currentStateIndex = 0; // Indeks aktualnego stanu obrazka

    public Brainrot()
    {
        InitializeComponent();
        _ = LoadSong(); // uruchom asynchronicznie
        UpdateButtonState(); // poka¿ pierwszy obrazek
    }
    private async Task LoadSong()
    {
        try
        {
            var audioManager = AudioManager.Current;
            var stream = await FileSystem.OpenAppPackageFileAsync(songPath);

            _player?.Stop();
            _player?.Dispose();
            _player = audioManager.CreatePlayer(stream);
        }
        catch (Exception ex)
        {
            await DisplayAlert("B³¹d", $"Nie uda³o siê za³adowaæ piosenki: {ex.Message}", "OK");
        }
    }


    private void Klik(object sender, EventArgs e)
    {
        _player.Play();
        brainrotClick();

    }
    public void brainrotClick()
    {
        points += upgValue;
        brainrots.Text = points.ToString();
    }
    private void Upd1(object sender, EventArgs e)
    {
        if (points > 10)
        {
            upgValue += 1;
            points -= 10;
            brainrotClickValue.Text = upgValue.ToString();
        }

    }
    private void Upd2(object sender, EventArgs e)
    {
        if (points > 25)
        {
            upgValue += 100;
            points -= 10;
            brainrotClickValue.Text = upgValue.ToString();
        }
    }
    private void Upd3(object sender, EventArgs e)
    {
        if (points > 50)
        {
            upgValue += 100;
            points -= 10;
            brainrotClickValue.Text = upgValue.ToString();
        }
    }
    private void Upd4(object sender, EventArgs e)
    {
        if (points > 1000)
        {
            upgValue += 1;
            points -= 10000;
            brainrotClickValue.Text = upgValue.ToString();
        }
    }
    private async void UpdateButtonState()
    {
        KlickImage.Source = imagePaths[currentStateIndex];
        songPath = songPaths[currentStateIndex];
        await LoadSong(); // teraz mo¿esz poczekaæ na za³adowanie
    }

    private void OnGoraClicked(object sender, EventArgs e)
    {
        currentStateIndex = (currentStateIndex + 1) % imagePaths.Length;
        UpdateButtonState();
    }

    private void OnDolClicked(object sender, EventArgs e)
    {
        currentStateIndex = (currentStateIndex - 1 + imagePaths.Length) % imagePaths.Length; 
        UpdateButtonState();
    }
}

