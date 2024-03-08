namespace SmartDevice.Tests
{
    using NUnit.Framework;
    using System;
    using System.Text;

    public class Tests
    {
        private Device device;

        [SetUp]
        public void Setup()
        {
            device = new(100);
        }

        [Test]
        public void TestConstructor()
        {
            Assert.IsNotNull(device);
            Assert.AreEqual(100, device.MemoryCapacity);
            Assert.AreEqual(100, device.AvailableMemory);
            Assert.AreEqual(0, device.Photos);
            Assert.IsEmpty(device.Applications);
        }

        [Test]
        public void TakePhotoWithEnoughMemory()
        {
            Assert.IsTrue(device.TakePhoto(50));
            Assert.AreEqual(50, device.AvailableMemory);
            Assert.IsTrue(device.TakePhoto(0));
            Assert.AreEqual(50, device.AvailableMemory);
            Assert.IsTrue(device.TakePhoto(50));
            Assert.AreEqual(0, device.AvailableMemory);
            Assert.AreEqual(3, device.Photos);
            Assert.AreEqual(100, device.MemoryCapacity);
        }

        [Test]
        public void TakePhotoWithNotEnoughMemory() 
        {
            Assert.IsFalse(device.TakePhoto(101));
            Assert.AreEqual(0,device.Photos);
            Assert.AreEqual(100, device.AvailableMemory);
            Assert.AreEqual(100, device.MemoryCapacity);
        }

        [Test]
        public void TakePhotoWithNegativSizePhoto()
        {
            Assert.IsTrue(device.TakePhoto(-1));
            Assert.AreEqual(101, device.AvailableMemory);
            Assert.AreEqual(1, device.Photos);
        }

        [Test]
        public void InstallAppWithNotEnoughMemory()
        {
            Assert.Throws<InvalidOperationException>(
                () => device.InstallApp("Facebook", 101), "Not enough available memory to install the app.");
        }

        [Test]
        public void InstallAppWithEnoughMemory()
        {
            string expected = $"Facebook is installed successfully. Run application?";

            Assert.AreEqual(expected, device.InstallApp("Facebook", 100));
            Assert.AreEqual(1, device.Applications.Count);
            Assert.AreEqual(0, device.AvailableMemory);
        }

        [Test]
        public void InstallManyApps()
        {
            device.InstallApp("Facebook", 20);

            Assert.AreEqual(1, device.Applications.Count);
            Assert.AreEqual(80, device.AvailableMemory);

            device.InstallApp("Instagram", 33);

            Assert.AreEqual(2, device.Applications.Count);
            Assert.AreEqual(47, device.AvailableMemory);

            device.InstallApp("TikTok", 43);

            Assert.AreEqual(3, device.Applications.Count);
            Assert.AreEqual(4, device.AvailableMemory);

            Assert.Throws<InvalidOperationException>(
               () => device.InstallApp("Facebook", 101), "Not enough available memory to install the app.");
        }

        [Test]
        public void TestFormatDevice()
        {
            device.InstallApp("Facebook", 20);
            device.InstallApp("Instagram", 33);
            device.InstallApp("TikTok", 43);
            device.TakePhoto(3);

            device.FormatDevice();

            Assert.IsNotNull(device);
            Assert.AreEqual(0, device.Applications.Count);
            Assert.AreEqual(100, device.AvailableMemory);
            Assert.AreEqual(0, device.Photos);
            Assert.AreEqual(100, device.MemoryCapacity);
        }

        [Test]
        public void GetDeviceStatusWithAllMemory()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Memory Capacity: 100 MB, Available Memory: 100 MB");
            stringBuilder.AppendLine($"Photos Count: 0");
            stringBuilder.AppendLine($"Applications Installed: ");

            string expected = stringBuilder.ToString().Trim();

            Assert.AreEqual(expected, device.GetDeviceStatus());

        }

        [Test]
        public void GetDeviceStatusWithPhotosAndApps()
        {
            device.TakePhoto(1);
            device.TakePhoto(2);
            device.TakePhoto(3);

            device.InstallApp("Facebook", 34);
            device.InstallApp("Instagram", 14);
            device.InstallApp("TikTok", 33);

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Memory Capacity: 100 MB, Available Memory: 13 MB");
            stringBuilder.AppendLine($"Photos Count: 3");
            stringBuilder.AppendLine($"Applications Installed: Facebook, Instagram, TikTok");

            string expected = stringBuilder.ToString().Trim();

            Assert.AreEqual(expected, device.GetDeviceStatus());

        }
    }
}