
using Plugin.Maui.Audio;

namespace BrainrotClicker;

public partial class Brainrot : ContentPage
{
    private readonly IAudioPlayer _player;
    int points = 0;
    int upgValue = 1;
    public Brainrot()
	{
		InitializeComponent();
           var audioManager = AudioManager.Current;
        var stream = FileSystem.OpenAppPackageFileAsync("braun.mp3").Result;
        _player = audioManager.CreatePlayer(stream);
	}


    private void UpgClick(object sender, EventArgs e)
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
        if(points > 10) { 
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
            points -= 10;
            brainrotClickValue.Text = upgValue.ToString();
        }
    }
}
