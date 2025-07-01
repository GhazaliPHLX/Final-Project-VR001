using UnityEngine;

public class BranchGroup : MonoBehaviour
{
    public BranchHintZone[] branches; // Daftar semua jalur (misal 2 atau 3)

    public void OnBranchEntered(BranchHintZone entered)
    {
        foreach (var branch in branches)
        {
            bool isThis = branch == entered;
            branch.SetHintActive(isThis); // Nyala hanya untuk cabang yang dimasuki
        }
    }

    // Opsional: panggil ini dari luar untuk reset semua hint jadi aktif lagi
    public void ResetAllHints()
    {
        foreach (var branch in branches)
        {
            branch.SetHintActive(true);
        }
    }
}
