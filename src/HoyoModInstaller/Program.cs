// Ejecutar certutil para agregar el certificado al almacén TrustedPeople
using System.Diagnostics;

var certutilStartInfo = new ProcessStartInfo
{
	FileName = "certutil.exe",
	Arguments = "-addstore TrustedPeople .\\HoyoModExplorer.cer",
	RedirectStandardOutput = true,
	RedirectStandardError = true,
	UseShellExecute = false,
	CreateNoWindow = true
};

using (var certutilProcess = Process.Start(certutilStartInfo))
{
	string output = certutilProcess.StandardOutput.ReadToEnd();
	string error = certutilProcess.StandardError.ReadToEnd();
	certutilProcess.WaitForExit();

	if (certutilProcess.ExitCode != 0)
	{
		// Manejar el error
		System.Console.WriteLine($"Error al agregar el certificado: {output}");
		Environment.Exit(certutilProcess.ExitCode);
	}
	else
	{
		System.Console.WriteLine($"Certificado agregado exitosamente: {output}");
	}
}

// Ejecutar el archivo .appinstaller
var appInstallerStartInfo = new ProcessStartInfo
{
	FileName = ".\\HoyoModExplorer_x64.appinstaller",
	UseShellExecute = true
};

using (var appInstallerProcess = Process.Start(appInstallerStartInfo))
{
	appInstallerProcess.WaitForExit();
}