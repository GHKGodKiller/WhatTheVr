# What The Vr Sonic Edition

Un entorno interactivo de Realidad Virtual desarrollado en **Unity 6** utilizando el **Meta XR SDK**. Este proyecto es una demostración técnica de interacciones físicas en VR, donde el jugador puede explorar una serie de islas flotantes y participar en diferentes minijuegos experimentando con masas, gravedades y colisiones.

## Descripción del Proyecto
El jugador aparece en un archipiélago de islas flotantes (Basadas en el universo de Sonic). El entorno está diseñado para probar la recolección y lanzamiento de objetos (Grabbing/Throwing) con diferentes configuraciones de `Rigidbody`, interactuando con elementos clásicos como un palo de golf, pinos de boliche y aros flotantes.

## Requisitos del Sistema
* **Motor:** Unity 6.
* **SDK:** Meta XR Core SDK / Meta XR Interaction SDK (Building Blocks).
* **Hardware:** Visor compatible con Meta Quest (Quest 2, Quest 3, Quest Pro) y controles VR.
* **Conexión:** Cable Link o Air Link habilitado para pruebas en el editor, o compilación directa a `.apk`.

## Instrucciones para abrir y ejecutar el proyecto

1. **Clonar o descargar el repositorio:**
   Descarga los archivos del proyecto a tu computadora.
2. **Abrir en Unity Hub:**
   Abre Unity Hub, haz clic en `Add` (Añadir) y selecciona la carpeta principal del proyecto extraído. Asegúrate de abrirlo con la versión correcta de Unity 6.
3. **Cargar la Escena Principal:**
   Una vez dentro del editor de Unity, navega a la carpeta `Assets/Scenes/` en la ventana *Project* y haz doble clic en tu escena principal (ej. `MyFirstVR_Scene`).
4. **Conectar el Visor VR:**
   Enciende tus Meta Quest, conéctalas a la PC mediante cable o Quest Link, y habilita la conexión.
5. **Ejecutar el Juego:**
   En Unity, presiona el botón **Play** en la parte superior central. Ponte el visor y deberías aparecer directamente sobre la isla principal.

## Mecánicas Principales

* **Variabilidad de Físicas:** El entorno cuenta con diferentes tipos de pelotas (bola de golf, pelota de playa, pelota pesada) y un globo. Cada objeto tiene un peso y material físico (`PhysicMaterial`) distinto, demostrando rebotes, caídas lentas y peso realista al ser agarrados con las manos VR.
* **Mini-Golf de Altura:** El jugador puede utilizar un palo de golf para golpear las pelotas hacia el cráter de la isla natural. El hoyo cuenta con un sistema de detección (`OnTriggerEnter`) que activa partículas y efectos de sonido de victoria al encestar.
* **Sistema de Boliche:** Una plataforma tecnológica dedicada a jugar a los bolos. Los pinos cuentan con físicas realistas para ser derribados y un script de reinicio para volver a su formación original despues de unos segundos (configurable para que se reinicie con un botón de ser neecesario).
* **Aro de Sonic (Target Practice):** Un aro flotante que funciona como zona de anotación al lanzar objetos a través de su centro, recompensando al jugador con retroalimentación audiovisual.
* **Sistema Anti-Caídas (Out of Bounds):** Dado que el juego ocurre en islas flotantes, existe un volumen invisible en la parte inferior del nivel. Si el jugador, el palo de golf o cualquier pelota cae al vacío, el sistema los teletransporta de manera segura e inmediata a su posición inicial, evitando mareos (motion sickness) o pérdida de objetos.
* **Islas Dinámicas:** Integración de animaciones cíclicas mediante código y Animator para dar la ilusión de levitación constante en ciertos elementos del entorno.