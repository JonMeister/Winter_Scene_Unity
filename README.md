# 🚓❄️ Escena Invernal de Rescate — Unity 3D (URP)

Proyecto de laboratorio desarrollado en **Unity 6 (Universal Render Pipeline)** para el módulo de **Composición de Escenas y Control de Transformaciones**.

## 📖 Contexto y Descripción de la Escena

La temperatura ha caído drásticamente y una patrulla de policía ha quedado atrapada y parcialmente sepultada bajo una densa capa de nieve durante la noche. El motor permanece encendido emitiendo humo por el escape, las luces de emergencia giran continuamente iluminando el manto blanco y una ventisca arrecia sobre todo el entorno.

---

## 🏗️ Estructura y Jerarquía de la Escena (10 Objetos Fundamentales)

La escena (`Assets/Scenes/SampleScene.unity`) está organizada respetando estrictamente las transformaciones relativas entre objetos padres e hijos:

```text
SampleScene
├── Main Camera          # Cámara en encuadre diagonal/lateral hacia la patrulla
├── Moon_Light           # Directional Light azul pálido (intensidad 0.2) para atmósfera nocturna
├── Snow_Terrain         # Plano de terreno nevado en Y = 0
├── Police_Car           # Objeto Padre (Y = -0.13) hundido bajo la nieve + Audio de sirena + CarMovement.cs
│   ├── Car_Mesh         # Modelo 3D de la carrocería de la patrulla
│   ├── Siren_Pivot      # Pivote en el techo con el script SirenRotation.cs
│   │   ├── Red_Light    # Spot Light roja brillante (-90° en Y)
│   │   └── Blue_Light   # Spot Light azul brillante (+90° en Y, lado opuesto)
│   └── Exhaust_Smoke    # Particle System de humo saliendo del escape trasero
└── Global_Blizzard      # Particle System global de tormenta de nieve + Audio ambiental de viento
```

---

## 💻 Scripts Implementados (`Assets/Scripts/`)

### 1. `SirenRotation.cs`
Asignado únicamente al objeto `Siren_Pivot`. Controla el giro continuo de las luces de emergencia de manera independiente a la tasa de fotogramas (*framerate*):
* Expone la variable pública `rotationSpeed` (`250f` por defecto) en el Inspector.
* Utiliza `transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f)` dentro de `Update()`.

### 2. `CarMovement.cs` *(Extra)*
Asignado al objeto padre `Police_Car`. Permite desplazar la patrulla sobre la nieve usando el nuevo **Unity Input System** (`W/A/S/D` o flechas direccionales), moviendo de forma solidaria la carrocería, las sirenas y el humo del escape mientras la cámara permanece estática.

---

## 🌨️ Sistemas de Partículas y Audio

* **`Global_Blizzard` (Nieve):** Emisor tipo `Box` (`50x50`) situado a `Y = 10` orientado hacia abajo (`X = 90°`), con velocidad inicial aleatoria entre `2` y `4.5`, gravedad moderada (`0.08`) y tinte azul hielo.
* **`Exhaust_Smoke` (Humo de escape):** Emisor tipo `Cone` estrecho (`Angle: 10`, `Radius: 0.05`) con gravedad negativa leve (`-0.05`), módulo **Color over Lifetime** (de gris oscuro a transparente) y **Size over Lifetime** (curva ascendente de expansión).
* **Inmersión Sonora *(Extra)*:**
  * Sonido ambiental de ventisca (`Snow_Sound.mp3`) en bucle 2D sobre `Global_Blizzard`.
  * Sonido de sirena policial (`Siren_Sound.wav`) en bucle espacial sobre `Police_Car`.

---

## 🔀 Historial de Commits Atómicos

1. `feat: configuracion inicial del proyecto y escena vacia`
2. `feat: agregar terreno nevado y coche enterrado`
3. `feat: jerarquia de luces y sirenas de emergencia`
4. `feat: implementar script SirenRotation.cs`
5. `feat: integrar particulas de nieve y humo de escape`
6. `feat: integrar audio ambiental de tormenta y sirena de emergencia` *(Extra)*
7. `feat: agregar control de movimiento al vehiculo en la nieve, camara permanece estatica` *(Extra)*

