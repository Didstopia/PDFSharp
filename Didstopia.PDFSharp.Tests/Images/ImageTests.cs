using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Didstopia.PDFSharp.Drawing;
using Xunit;

namespace Didstopia.PDFSharp.Tests.Images
{
    public class ImageTests
    {
        private TestImages images = new TestImages();
        [Fact()]
        public void IsJpg_ShouldReturnTrue()
        {
            Assert.True(XImage.IsImageJpg(images.W3CJpg));
            Assert.True(XImage.IsImageJpg(images.W3C2Jpg));
            Assert.True(XImage.IsImageJpg(images.W3C256Jpg));
            Assert.True(XImage.IsImageJpg(images.W3CGrayJpg));

        }
        [Fact()]
        public void IsNotJpg_ShouldReturnFalse()
        {
            Assert.False(XImage.IsImageJpg(images.W3CBmp));
            Assert.False(XImage.IsImageJpg(images.W3CGif));
            Assert.False(XImage.IsImageJpg(images.W3CPng));
            Assert.False(XImage.IsImageJpg(images.W3C2Bmp));
            Assert.False(XImage.IsImageJpg(images.W3C2Gif));
            Assert.False(XImage.IsImageJpg(images.W3C2Png));
            Assert.False(XImage.IsImageJpg(images.W3C256Bmp));
            Assert.False(XImage.IsImageJpg(images.W3C256Gif));
            Assert.False(XImage.IsImageJpg(images.W3C256Png));
            Assert.False(XImage.IsImageJpg(images.W3CAnimationGif));
            Assert.False(XImage.IsImageJpg(images.W3CAnimationMng));
            Assert.False(XImage.IsImageJpg(images.W3CGrayBmp));
            Assert.False(XImage.IsImageJpg(images.W3CGrayGif));
            Assert.False(XImage.IsImageJpg(images.W3CGrayPng));

        }
    }
}


