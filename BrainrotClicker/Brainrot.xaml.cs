using Plugin.Maui.Audio;

namespace BrainrotClicker;

public partial class Brainrot : ContentPage
{
    private IAudioPlayer _player;

    int points = 0;
    int upgValue = 1;
    public string songPath = "braun.mp3";
    private int autoBrainrot = 0; 
    private System.Timers.Timer timer;

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
        _ = LoadSong(); 
        UpdateButtonState();
        StartAutoCollection();
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
        if (points >= 10)
        {
            upgValue += 1;
            points -= 10;
            UpdateUI();
        }
    }

    private void Upd2(object sender, EventArgs e)
    {
        if (points >= 25)
        {
            upgValue += 5;
            points -= 25;
            UpdateUI();
        }
    }

    private void Upd3(object sender, EventArgs e)
    {
        if (points >= 50)
        {
            upgValue += 10;
            points -= 50;
            UpdateUI();
        }
    }

    private void Upd4(object sender, EventArgs e)
    {
        if (points >= 1000)
        {
            upgValue += 100;
            points -= 1000;
            UpdateUI();
        }
    }

    private void Upd9(object sender, EventArgs e)
    {
        if (points >= 5000)
        {
            upgValue += 500;
            points -= 5000;
            UpdateUI();
        }
    }

    private void Upd11(object sender, EventArgs e)
    {
        if (points >= 10000)
        {
            upgValue += 1000;
            points -= 10000;
            UpdateUI();
        }
    }

    private void Upd13(object sender, EventArgs e)
    {
        if (points >= 50000)
        {
            upgValue += 5000;
            points -= 50000;
            UpdateUI();
        }
    }

    private void Upd15(object sender, EventArgs e)
    {
        if (points >= 100000)
        {
            upgValue += 10000;
            points -= 100000;
            UpdateUI();
        }
    }

    private void Upd17(object sender, EventArgs e)
    {
        if (points >= 500000)
        {
            upgValue += 50000;
            points -= 500000;
            UpdateUI();
        }
    }

    // Automatyczne ulepszenia
    private void Upd5(object sender, EventArgs e)
    {
        if (points >= 100)
        {
            autoBrainrot += 1;
            points -= 100;
            UpdateUI();
        }
    }

    private void Upd6(object sender, EventArgs e)
    {
        if (points >= 500)
        {
            autoBrainrot += 5;
            points -= 500;
            UpdateUI();
        }
    }

    private void Upd7(object sender, EventArgs e)
    {
        if (points >= 1000)
        {
            autoBrainrot += 10;
            points -= 1000;
            UpdateUI();
        }
    }

    private void Upd8(object sender, EventArgs e)
    {
        if (points >= 5000)
        {
            autoBrainrot += 50;
            points -= 5000;
            UpdateUI();
        }
    }

    private void Upd10(object sender, EventArgs e)
    {
        if (points >= 10000)
        {
            autoBrainrot += 100;
            points -= 10000;
            UpdateUI();
        }
    }

    private void Upd12(object sender, EventArgs e)
    {
        if (points >= 50000)
        {
            autoBrainrot += 500;
            points -= 50000;
            UpdateUI();
        }
    }

    private void Upd14(object sender, EventArgs e)
    {
        if (points >= 100000)
        {
            autoBrainrot += 1000;
            points -= 100000;
            UpdateUI();
        }
    }

    private void Upd16(object sender, EventArgs e)
    {
        if (points >= 500000)
        {
            autoBrainrot += 5000;
            points -= 500000;
            UpdateUI();
        }
    }

    private void Upd18(object sender, EventArgs e)
    {
        if (points >= 1000000)
        {
            autoBrainrot += 10000;
            points -= 1000000;
            UpdateUI();
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
    private void StartAutoCollection()
    {
        timer = new System.Timers.Timer(1000); 
        timer.Elapsed += (s, e) =>
        {
            if (autoBrainrot > 0)
            {
                points += autoBrainrot;

                Dispatcher.Dispatch(() =>
                {
                    brainrots.Text = points.ToString();
                });
            }
        };
        timer.AutoReset = true;
        timer.Enabled = true;
    }
    private void UpdateUI()
    {
        brainrots.Text = points.ToString();
        brainrotClickValue.Text = upgValue.ToString();
        brainrotPerSecond.Text = $"{autoBrainrot} / sek";
    }
}

