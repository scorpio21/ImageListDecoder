# ImageList Decoder Tool

Herramienta diseñada para codificar y decodificar imágenes en formato Base64, con soporte específico para el objeto `ImageListStreamer` de .NET Framework, así como imágenes estándar (PNG, JPG, BMP) e iconos (.ico).

## Características principales

*   **Decodificación Inteligente**: Soporta tanto flujos de `ImageListStreamer` (propios de Visual Studio) como imágenes individuales y archivos de icono (.ico).
*   **Limpieza de Base64 Avanzada**: Limpia automáticamente encabezados de Data URI (ej. `data:image/png;base64,`) y elimina cualquier espacio en blanco, salto de línea o tabulación mediante expresiones regulares (Regex).
*   **Vista Previa de Imágenes**: Incluye una zona de previsualización (`PictureBox`) y una lista de imágenes decodificadas (`ListView`).
*   **Codificación con Drag & Drop**: Permite arrastrar archivos de imagen directamente a la aplicación para convertirlos a Base64.
*   **Sistema de Logs**: Genera automáticamente un archivo `error_log.txt` con detalles técnicos (incluyendo volcado hexadecimal de los primeros bytes) en caso de fallos de decodificación.
*   **Interfaz Intuitiva**: Etiquetas descriptivas y botones de acción rápida, incluyendo un botón para limpiar el área de texto.

## Requisitos del sistema

*   **Framework**: .NET Framework 4.8
*   **IDE Recomendado**: Visual Studio 2022 o superior.

## Cómo usar la aplicación

### Decodificar Base64 a Imagen
1.  Pega el código Base64 en el cuadro de texto de la izquierda.
2.  Haz clic en **"Decodificar Base64 -> Imagenes"**.
3.  Si el código es válido, las imágenes aparecerán en la lista de la derecha y en el cuadro de previsualización.

### Codificar Imagen a Base64
1.  Arrastra un archivo de imagen desde tu computadora al cuadro **"Arrastra aquí una imagen (Drag & Drop)"** en la esquina superior derecha.
2.  Haz clic en **"Codificar imagen -> Base64"**.
3.  El código resultante aparecerá en el cuadro de texto de la izquierda.

## Registro de Errores (Logging)
Si ocurre un error durante el proceso de decodificación:
1.  La aplicación mostrará un mensaje de alerta.
2.  Se generará o actualizará el archivo `error_log.txt` en la carpeta del ejecutable (`bin/Debug/`).
3.  Este archivo contiene la fecha, el tipo de excepción y los primeros bytes del código Base64 en formato hexadecimal para facilitar el diagnóstico.

## Compilación
Para compilar manualmente desde la terminal (usando MSBuild):
```powershell
msbuild ImageListDecoder.sln /p:Configuration=Debug /t:Build
```
