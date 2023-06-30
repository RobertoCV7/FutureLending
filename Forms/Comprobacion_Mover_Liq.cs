namespace FutureLending.Forms;

public partial class ComprobacionMoverLiq : Form
{
    private bool click;
    public bool Mover4;

    public ComprobacionMoverLiq()
    {
        InitializeComponent();
    }

    private void rjButton2_Click(object sender, EventArgs e)
    {
        Mover4 = true;
        click = true;
        Close();
    }

    private void rjButton1_Click(object sender, EventArgs e)
    {
        Mover4 = false;
        click = true;
        Close();
    }

    private void Comprobacion_Mover_Liq_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (click) return;
        Form1.MessageB("Debes seleccionar una opcion", "Advertencia", 2);
        e.Cancel = true;
    }
}