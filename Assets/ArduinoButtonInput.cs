using System.IO.Ports;  // Necessário para usar a comunicação serial
using UnityEngine;

public class ArduinoButtonInput : MonoBehaviour
{
    SerialPort serialPort = new SerialPort("COM3", 9600);  // Ajuste a porta COM conforme necessário

    public CanvasController controller;

    void Start()
    {
        // Tenta abrir a comunicação serial
        if (!serialPort.IsOpen)
        {
            serialPort.Open();
            serialPort.ReadTimeout = 1000;  // Timeout para evitar travamentos
            Debug.Log("Conexão com o Arduino iniciada.");
        }
    }

    void Update()
    {
        // Se a porta serial está aberta, tenta ler o valor enviado pelo Arduino
        if (serialPort.IsOpen)
        {
            try
            {
                string input = serialPort.ReadLine();  // Lê uma linha da porta serial

                if (input == "A")
                {
                    Debug.Log("Botão A foi apertado");
                    controller.Next1();
                }
                else if (input == "B")
                {
                    Debug.Log("Botão B foi apertado");
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
        // Fecha a comunicação serial ao sair
        if (serialPort.IsOpen)
        {
            serialPort.Close();
            Debug.Log("Conexão com o Arduino encerrada.");
        }
    }
}
