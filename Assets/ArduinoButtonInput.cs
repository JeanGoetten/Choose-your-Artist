using System.IO.Ports;  // Necess�rio para usar a comunica��o serial
using UnityEngine;

public class ArduinoButtonInput : MonoBehaviour
{
    SerialPort serialPort = new SerialPort("COM3", 9600);  // Ajuste a porta COM conforme necess�rio

    public CanvasController controller;

    void Start()
    {
        // Tenta abrir a comunica��o serial
        if (!serialPort.IsOpen)
        {
            serialPort.Open();
            serialPort.ReadTimeout = 1000;  // Timeout para evitar travamentos
            Debug.Log("Conex�o com o Arduino iniciada.");
        }
    }

    void Update()
    {
        // Se a porta serial est� aberta, tenta ler o valor enviado pelo Arduino
        if (serialPort.IsOpen)
        {
            try
            {
                string input = serialPort.ReadLine();  // L� uma linha da porta serial

                if (input == "A")
                {
                    Debug.Log("Bot�o A foi apertado");
                    controller.Next1();
                }
                else if (input == "B")
                {
                    Debug.Log("Bot�o B foi apertado");
                    controller.Next2();
                }
            }
            catch (System.Exception e)
            {
                Debug.LogWarning("Erro ao ler porta serial: " + e.Message);
            }
        }
    }

    void OnApplicationQuit()
    {
        // Fecha a comunica��o serial ao sair
        if (serialPort.IsOpen)
        {
            serialPort.Close();
            Debug.Log("Conex�o com o Arduino encerrada.");
        }
    }
}
