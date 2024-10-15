using UnityEngine;

public class DeathSplatterHandler : MonoBehaviour {
    
        private void OnEnable() {
        Health.OnDeath += SpawnDeathSplatterPrefabs;
        Health.OnDeath += SpawnDeathVFX;
    }
    private void OnDisable() {
        Health.OnDeath -= SpawnDeathSplatterPrefabs;
        Health.OnDeath -= SpawnDeathVFX;
    }
        private void SpawnDeathSplatterPrefabs(Health sender) {
        GameObject newSplatterPrefabs = Instantiate(sender.SplatterPrefab, sender.transform.position, transform.rotation);
        SpriteRenderer deathSplatterSpriteRenderer = newSplatterPrefabs.GetComponent<SpriteRenderer>();
        ColorChanger colorChanger = sender.GetComponent<ColorChanger>();
        Color currentColor = colorChanger.DefaultColor;
        deathSplatterSpriteRenderer.color = currentColor;
        newSplatterPrefabs.transform.SetParent(this.transform);
    }
    private void SpawnDeathVFX(Health sender) {
        GameObject deathVFX = Instantiate(sender.DeathVFX, sender.transform.position, transform.rotation);
        ParticleSystem.MainModule ps = deathVFX.GetComponent<ParticleSystem>().main;
        ColorChanger colorChanger = sender.GetComponent<ColorChanger>();
        Color currentColor = colorChanger.DefaultColor;
        ps.startColor = currentColor;
        deathVFX.transform.SetParent(this.transform);
    }
}