# Guia de montagem na Unity

## 1. Criar o projeto base
1. Unity Hub → **New project** → template **Karting Microgame** (Unity 2021.3 LTS ou superior recomendado).
2. Feche a janela de tutorial se quiser.

## 2. Importar os scripts
Copie `Assets/_Custom` para a pasta `Assets` do projeto. A Unity compila automaticamente.

## 3. Montar a cena

### Managers
1. Crie um GameObject vazio chamado `GameManagers`.
2. Adicione os componentes `ScoreManager`, `RaceTimer` e `HudDisplay`.
3. No `HudDisplay`, arraste o `RaceTimer` para o campo **Race Timer**.

### Pad de turbo
1. Crie um Cube, achate (Scale `3, 0.1, 5`) e posicione sobre a pista.
2. Adicione `SpeedBoostPad` (o Collider vira *Is Trigger* automaticamente).
3. Ajuste **Boost Force** (sugestão: 10–15). Salve como Prefab.

### Moedas
1. Crie um Cylinder (Scale `0.6, 0.05, 0.6`, Rotation X = 90) com material amarelo.
2. Adicione `CoinPickup`. Salve como Prefab e espalhe pela pista.

### Respawn
1. Selecione o GameObject do kart (o que tem o Rigidbody).
2. Adicione `KartRespawn`.

## 4. Dicas
- Ajuste skybox e iluminação em **Window → Rendering → Lighting**.
- Se o kart não ativa os triggers, confirme que o objeto com Rigidbody tem Collider.
- Grave um GIF (ScreenToGif/LICEcap) e salve em `Docs/gameplay.gif`.

## 5. Subir para o GitHub
```bash
git init
git add .
git commit -m "Adiciona scripts customizados do Karting Microgame"
git branch -M main
git remote add origin https://github.com/SEU-USUARIO/karting-microgame-custom.git
git push -u origin main
```
